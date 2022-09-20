using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Students.DAL.Repository;
using Students.DbContext;

namespace Students.BLL;

public static class DependencyInjection
{
    public static void InjectDependencies(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddDbContext<StudentsInfoContext>(options =>
        {
            options.UseSqlite(Configuration["ConnectionStrings:StudentsInfoDBConnectionString"]);
        });
        // services.AddAutoMapper(typeof(AutoMapperProfiles));
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<IStudentInfoRepository, StudentInfoRepository>();
    }
}