using Data.School;

namespace School.Api.School.Model
{
    public class SaveRequestDto
    {
        public SchoolDto School { get; set; } = new SchoolDto();
    }
}