using AutoMapper;
using MediatR;
using Projeto.Model.Interfaces;

namespace Projeto.Application.UseCases.Cliente.GetAll
{
    public sealed class GetAllClienteHandler : IRequestHandler<GetAllClienteRequest, List<GetAllClienteReponse>>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public GetAllClienteHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllClienteReponse>> Handle(GetAllClienteRequest request, CancellationToken cancellationToken)
        {
            var clientes = await _clienteRepository.GetAll(cancellationToken);
            return _mapper.Map<List<GetAllClienteReponse>>(clientes);
        }
    }
}
