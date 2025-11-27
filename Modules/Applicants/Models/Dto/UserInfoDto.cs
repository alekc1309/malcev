// Project.Api\Modules\Applicants\Models\Dto\UserInfoDto.cs
namespace Project.Api.Modules.Applicants.Models.Dto
{
    public class UserInfoDto
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}