using Microsoft.EntityFrameworkCore;
using RegisterCard.Infra.Repository;

namespace RegisterCard.API.Extensions;

public static class AddConfiguration
{
    public static void AddDatabase(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(opt =>
            opt.UseInMemoryDatabase("DigialPayments"));

        //builder.Services.AddDbContext<AppDbContext>(x =>
        //x.UseSqlServer(
        //        builder.Configuration.GetConnectionString("DefaultConnection"),
        //        b => b.MigrationsAssembly("RegisterCard.API")));
    }

    public static void AddLogging(this WebApplicationBuilder builder)
    {
        var serviceProvider = builder.Services.BuildServiceProvider();
        var logger = serviceProvider.GetService<ILogger<ApplicationLogs>>();
        builder.Services.AddSingleton(typeof(ILogger), logger!);
    }
}
public class ApplicationLogs
{
}
