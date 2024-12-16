using Domain.Models;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    internal class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(WebMusicAppContext repositoryContext)
            : base(repositoryContext)
        {
        }

        // Реализация методов интерфейса IUserRepository
        public async Task<List<User>> FindAll() => await RepositoryContext.Set<User>().ToListAsync();

        public async Task<List<User>> FindByCondition(Expression<Func<User, bool>> expression) =>
            await RepositoryContext.Set<User>().Where(expression).ToListAsync();

        public async Task Create(User entity) => await RepositoryContext.Set<User>().AddAsync(entity);

        public void Update(User entity) => RepositoryContext.Set<User>().Update(entity);

        public void Delete(User entity) => RepositoryContext.Set<User>().Remove(entity);
    }
}