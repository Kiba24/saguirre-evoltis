using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
namespace Infraestructure.Persistance.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
