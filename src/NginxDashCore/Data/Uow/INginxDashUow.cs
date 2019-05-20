using System.Threading.Tasks;
using NginxDashCore.Data.Entities;
using NginxDashCore.Data.Repository;

namespace NginxDashCore.Data.Uow
{
    public interface INginxDashUow
    {
        IRepository<Domain> DomainsRepository { get; }
        
        Task CommitAsync();
    }
}