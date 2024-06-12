using MyBussSiteAPIs.Models;

namespace MyBussSiteAPIs.Interfaces
{
    public interface IAuthService
    {
        Register AddUser(Register register);
        string Login(LoginRequest loginRequest);
        public Register UpdateUser(Register register);
        public List<Register> GetAllUsers();
        public Register GetAllUserById(int id);
    }
}
