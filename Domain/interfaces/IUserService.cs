using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User> GetById(int id);
        Task<List<User>> GetByRole(string role); // Добавленный метод
        Task Create(User model);
        Task Update(User model);
        Task Delete(int id);
    }
}