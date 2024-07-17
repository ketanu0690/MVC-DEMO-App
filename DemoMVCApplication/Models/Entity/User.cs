using System.ComponentModel.DataAnnotations;

namespace DemoMVCApplication.Models.Entity
{
    public class User
    {
        public int Id { get; set; }
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
