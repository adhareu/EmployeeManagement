using EmployeeManagement.API.Features.Departments.Repositories.Commands;
using EmployeeManagement.API.Features.Departments.Repositories.Queries;
using EmployeeManagement.API.Features.Designations.Repositories.Commands;
using EmployeeManagement.API.Features.Designations.Repositories.Queries;
using EmployeeManagement.API.Features.Employees.Repositories.Commands;
using EmployeeManagement.API.Features.Employees.Repositories.Queries;


    public static class Extensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeCommandRepository, EmployeeCommandRepository>();
            services.AddScoped<IEmployeeQueryRepository, EmployeeQueryRepository>();
            services.AddScoped<IDepartmentCommandRepository, DepartmentCommandRepository>();
            services.AddScoped<IDepartmentQueryRepository, DepartmentQueryRepository>();
            services.AddScoped<IDesignationCommandRepository, DesignationCommandRepository>();
            services.AddScoped<IDesignationQueryRepository, DesignationQueryRepository>();
            return services;
        }
    }

