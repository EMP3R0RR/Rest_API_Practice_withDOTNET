using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Domain.DTO;

namespace Project_Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<UserDTO> GetByIdAsync(int id);
        Task<int> CreateAsync(UserDTO user); // returns created ID
        Task<bool> UpdateAsync(UserDTO user);
        Task<bool> DeleteAsync(int id);
    }
}
