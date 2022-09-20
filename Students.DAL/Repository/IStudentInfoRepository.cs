using Students.Entities;

namespace Students.DAL.Repository
{
    public interface IStudentInfoRepository
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Student?> GetStudentAsync(int id);
        Task<bool> StudentExistsAsync(int cityId);
        Task<string> GetStudentLastNameAsync(int id);
        Task CreateStudentAsync(Student newStudent);
        Task DeleteStudentAsync(Student student);
        Task<bool> SaveChangesAsync();
    }
}