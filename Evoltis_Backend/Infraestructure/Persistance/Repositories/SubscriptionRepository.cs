using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;


namespace Infraestructure.Persistance.Repositories
{
    public class SubscriptionRepository : GenericRepository<SubscriptionEntity>, ISubscriptionRepository
    {
        public SubscriptionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
