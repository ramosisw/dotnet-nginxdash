using System.Threading.Tasks;
using NginxDashCore.Data.Entities;
using NginxDashCore.Data.Repository;

namespace NginxDashCore.Data.Uow
{
    public class NginxDashUow : INginxDashUow
    {
        public IRepository<Domain> DomainsRepository => new GenericRepository<Domain>(_dbContext);

        private readonly NginxDashContext _dbContext;
        public NginxDashUow(NginxDashContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CommitAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}