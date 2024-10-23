using Projeto.Database.Context;
using Projeto.Database.Repositories.Base;
using Projeto.Model.Entities;
using Projeto.Model.Interfaces;

namespace Projeto.Database.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
