namespace DemoMVCApplication.Models.Dto
{
    public class UserDto
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
