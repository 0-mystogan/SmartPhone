using SmartPhone.Model;
using System.Collections.Generic;

namespace SmartPhone.Services
{
    public interface IUserService
    {
        IEnumerable<UserRespond> GetAll();
        UserRespond? GetById(int id);
        UserRespond Create(UserRequest request);
        bool Update(int id, UserRequest request);
        bool Delete(int id);
    }
} 