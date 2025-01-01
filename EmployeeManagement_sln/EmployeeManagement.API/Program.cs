using System.Reflection;
using Asp.Versioning;
using EmployeeManagement.API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.API.Infrastructure.Repositories.Departments.Commands;
using EmployeeManagement.API.Infrastructure.Repositories.Departments.Queries;
using EmployeeManagement.API.Infrastructure.Repositories.Designations.Commands;
using EmployeeManagement.API.Infrastructure.Repositories.Employees.Commands;
using EmployeeManagement.API.Infrastructure.Repositories.Designations.Queries;
using EmployeeManagement.API.Infrastructure.Repositories.Employees.Queries;
using Serilog;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;



var builder = WebApplication.CreateBuilder(args);


Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();
// Add services to the container.
builder.Services.AddDbContext<EmployeeManagementDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeManagementDbConnection")));
builder.Services.AddScoped<IEmployeeCommandRepository, EmployeeCommandRepository>();
builder.Services.AddScoped<IEmployeeQueryRepository, EmployeeQueryRepository>();
builder.Services.AddScoped<IDepartmentCommandRepository, DepartmentCommandRepository>();
builder.Services.AddScoped<IDepartmentQueryRepository, DepartmentQueryRepository>();
builder.Services.AddScoped<IDesignationCommandRepository, DesignationCommandRepository>();
builder.Services.AddScoped<IDesignationQueryRepository, DesignationQueryRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        b => b.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
    );
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(int.Parse(builder.Configuration["Api:Version:Major"]), int.Parse(builder.Configuration["Api:Version:Minor"]));
    config.AssumeDefaultVersionWhenUnspecified = true;
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = false,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = builder.Configuration["Jwt:Issuer"],
                   ValidAudience = builder.Configuration["Jwt:Issuer"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
               };
                   // Log token content for debugging
                   options.Events = new JwtBearerEvents
                   {
                       OnAuthenticationFailed = context =>
                       {
                           Log.Logger.Error("Authentication failed. Token is invalid: {ErrorMessage}", context.Exception.Message);
                           return Task.CompletedTask;
                       },
                       OnTokenValidated = context =>
                       {
                           var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
                           var roles = claimsIdentity?.FindAll(ClaimTypes.Role)?.Select(r => r.Value).ToList();

                           Log.Logger.Information("Token validated for user: {Username} with roles: {Roles}",
                                                  context.Principal.Identity.Name, string.Join(", ", roles));

                           return Task.CompletedTask;
                       }
                   };
               });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<EmployeeManagementDbContext>();
    dbContext.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging(); // Logs each HTTP request and response automatically
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication(); // Authentication middleware
app.UseAuthorization();  // Authorization middleware
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
