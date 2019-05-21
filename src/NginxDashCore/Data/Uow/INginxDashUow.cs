using NginxDashCore.Data.Repository;
using NginxDashCore.Data.Entities;
using System.Threading.Tasks;

namespace NginxDashCore.Data.Uow
{
    public interface INginxDashUow
    {
        IRepository<Domain> DomainsRepository { get; }
        
        Task CommitAsync();
    }
}