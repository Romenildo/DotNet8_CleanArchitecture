using AutoMapper;
using MediatR;
using Projeto.Model.Exceptions;
using Projeto.Model.Interfaces.Base;
using Projeto.Model.Interfaces;

namespace Projeto.Application.UseCases.Cliente.Update
{
    public class UpdateClienteHandler : IRequestHandler<UpdateClienteRequest, UpdateClienteResponse>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateClienteHandler(IClienteRepository clienteRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<UpdateClienteResponse> Handle(UpdateClienteRequest request, CancellationToken cancellationToken)
        {

            var cliente = await _clienteRepository.Get(request.Id, cancellationToken);

            if (cliente is null)
            {
                throw new NotFoundException("cliente não encontrado");
            }

            cliente.Nome = request.Nome;
            _clienteRepository.Update(cliente);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<UpdateClienteResponse>(cliente);
        }
    }
}
