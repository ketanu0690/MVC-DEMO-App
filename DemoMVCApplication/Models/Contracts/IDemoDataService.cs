using DemoMVCApplication.Models.Dto;

namespace DemoMVCApplication.Models.Contracts
{
    public interface IDemoDataService
    {
        Task<List<UserDto>> FetchAll();
    }
}
