using DemoMVCApplication.Models.Entity;

namespace DemoMVCApplication.Models.Contracts
{
    public interface IUserRepository
    {
        Task<int> SaveData(List<User> users);
        Task<List<User>> GetAllData();
    }
}
