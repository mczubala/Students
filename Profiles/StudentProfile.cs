using AutoMapper;
namespace Students.Profiles;

public class StudentProfile: Profile
{
    public StudentProfile()
    {
        CreateMap<Entities.Student, Models.StudentsDto>();
        CreateMap<Models.StudentsCreateDto, Entities.Student>();
        CreateMap<Models.StudentsUpdateDto, Entities.Student>();

    }
}