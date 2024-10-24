using AutoMapper;
using MediatR;
using Projeto.Model.Exceptions;
using Projeto.Model.Interfaces;
using Projeto.Model.Interfaces.Base;

namespace Projeto.Application.UseCases.Cliente.Delete
{
    public class DeleteClienteHandler : IRequestHandler<DeleteClienteRequest, DeleteClienteResponse>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteClienteHandler(IClienteRepository clienteRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DeleteClienteResponse> Handle(DeleteClienteRequest request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.Get(request.Id, cancellationToken);
            if (cliente == null)
                throw new NotFoundException("Cliente");

            _clienteRepository.Delete(cliente);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<DeleteClienteResponse>(cliente);

        }
    }
}
