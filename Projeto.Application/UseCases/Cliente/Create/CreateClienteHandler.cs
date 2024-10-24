using AutoMapper;
using MediatR;
using Projeto.Model.Interfaces;
using Projeto.Model.Interfaces.Base;
using ClienteModel = Projeto.Model.Entities.Cliente;

namespace Projeto.Application.UseCases.Cliente.Create
{
    public class CreateClienteHandler : IRequestHandler<CreateClienteRequest, CreateClienteResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public CreateClienteHandler(IUnitOfWork unitOfWork, IClienteRepository clienteRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<CreateClienteResponse> Handle(CreateClienteRequest request, CancellationToken cancellationToken)
        {
            var cliente = _mapper.Map<ClienteModel>(request);

            _clienteRepository.Create(cliente);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<CreateClienteResponse>(cliente);
        }
    }
}
