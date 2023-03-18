using FluentValidation;
using TRunner.Application.Behaviors;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TRunner.Application.Queries;
using TRunner.Infrastructure.Interfaces;
using TRunner.Application.Interfaces.Repositories;
using TRunner.Infrastructure.Repositories;
using TRunner.Application.Services.Interfaces;
using TRunner.Application.Services;
using TRunner.Infrastructure.ConnectionStrings;
using TRunner.Infrastructure.MinIO;
using TRunner.Application.Interfaces.MinIO;

namespace TRunner.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddMediatR(services);
        AddRepositories(services);
        //AddOptions(services);
        AddServices(services);
        AddDatabase(services, configuration);

        return services;
    }

    private static void AddMediatR(IServiceCollection services)
    {
        services.AddMediatR(typeof(GetSports).Assembly);
        services.AddValidatorsFromAssembly(typeof(GetSports).Assembly, includeInternalTypes: true);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
        services.AddTransient(typeof(IDbConnectionFactory), typeof(SqlDbConnectionFactory));
        services.AddTransient(typeof(ISportsRepository), typeof(SportsRepository));
        services.AddTransient(typeof(IGroupRepository), typeof(GroupRepository));
        services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
        services.AddTransient(typeof(ISportTypesRepository), typeof(SportTypesRepository));
        services.AddTransient(typeof(IUserRoleRepository), typeof(UserRoleRepository));
        services.AddTransient(typeof(IMinIOService), typeof(MinIOService));
        services.AddTransient(typeof(IWorkoutSummaryRepository), typeof(WorkoutSummaryRepository));
    }
    //private static void AddOptions(IServiceCollection services)
    //{
    //    services.AddOptions<SqlOptions>()
    //        .Configure<IConfiguration>((options, configuration) =>
    //        {
    //            options.SqlConnectionString = configuration.GetValue<string>("SqlOptions:SqlConnectionString");
    //            options.SqlUseAccessToken = configuration.GetValue<bool>("SqlOptions:SqlUseAccessToken");
    //        });

    //    services.AddOptions<AzureStorageOptions>()
    //        .Configure<IConfiguration>((options, configuration) =>
    //        {
    //            options.AzureWebJobsStorageImage = configuration.GetValue<string>("UploadImageOptions:AzureWebJobsStorageImage");
    //            options.ContainerName = configuration.GetValue<string>("UploadImageOptions:ContainerName");
    //        });
    //}

    private static void AddServices(IServiceCollection services)
    {
        services.AddTransient<ISportService, SportService>();
        services.AddTransient<ISportTypeService, SportTypesService>();
        services.AddTransient<IAuthenticateService, AuthenticateService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IWorkoutSummaryService, WorkoutSummaryService>();
    }

    private static void AddDatabase(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IConnectionStringService, ConnectionStringService>();
        services.AddDbContext<TRunnerDbContext>();
    }
}
