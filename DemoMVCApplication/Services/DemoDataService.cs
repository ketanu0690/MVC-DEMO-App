using AutoMapper;
using DemoMVCApplication.Models.Contracts;
using DemoMVCApplication.Models.Dto;
using DemoMVCApplication.Models.Entity;
using DemoMVCApplication.Models.Wrapper;
using System.Net.Http.Headers;
using System.Text.Json;

namespace DemoMVCApplication.Services
{
    public class DemoDataService : IDemoDataService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<DemoDataService> _logger;
        private readonly IApplicationSettings _applicationSettings;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DemoDataService(ILogger<DemoDataService> logger, IApplicationSettings applicationSettings, IUserRepository userRepository, IMapper mapper)
        {
            _httpClient = new HttpClient();
            _logger = logger;
            _applicationSettings = applicationSettings;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> FetchAll()
        {
            try
            {
                var users = await CallApi<User>(_applicationSettings.ApiUrl);
                if (users != null && users.Any())
                {
                    var usersToAdd = users.Select(u => new User
                    {
                        Name = u.Name,
                        Email = u.Email,
                        Gender = u.Gender,
                        Status = u.Status,
                        UserId = u.UserId
                        // Exclude  Id as it's auto-generated 
                    }).ToList();

                    await _userRepository.SaveData(usersToAdd);
                }

                return _mapper.Map<List<UserDto>>(users) ?? new List<UserDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching users");
                return new List<UserDto>();
            }
        }

        private async Task<List<T>?> CallApi<T>(string apiUrl)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<ApiResponse<T>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return apiResponse?.Data;
            }
            else
            {
                var errorMessage = $"Failed to get data from API. Status code: {response.StatusCode}";
                _logger.LogError(errorMessage);
                throw new HttpRequestException(errorMessage);
            }
        }
    }
}
