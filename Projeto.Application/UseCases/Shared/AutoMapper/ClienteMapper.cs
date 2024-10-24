using AutoMapper;
using Projeto.Application.UseCases.Cliente.Create;
using Projeto.Application.UseCases.Cliente.Delete;
using Projeto.Application.UseCases.Cliente.GetAll;
using Projeto.Application.UseCases.Cliente.Update;
using ClienteModel = Projeto.Model.Entities.Cliente;


namespace Projeto.Application.UseCases.Shared.AutoMapper
{
    public sealed class ClienteMapper : Profile
    {
        public ClienteMapper()
        {

            CreateMap<CreateClienteRequest, ClienteModel>();
            CreateMap<ClienteModel, CreateClienteResponse>();
            CreateMap<ClienteModel, UpdateClienteResponse>();
            CreateMap<ClienteModel, GetAllClienteReponse>();
            CreateMap<ClienteModel, DeleteClienteResponse>().ReverseMap();
        }
    }
}
