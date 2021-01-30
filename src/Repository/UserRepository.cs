using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext _dbContext;

        public UserRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(User item)
        {
            var maxUserTaskId = _dbContext.Users.Select(x => x.Id).DefaultIfEmpty(0).Max();

            item.Id = maxUserTaskId + 1;

            _dbContext.Users.Add(item);

            return item.Id;
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public User Get(int id)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<User> List()
        {
            return _dbContext.Users.AsQueryable();
        }
    }
}
