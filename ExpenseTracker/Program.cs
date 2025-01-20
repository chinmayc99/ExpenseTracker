
using Core.Entities;
using Data;
using Microsoft.EntityFrameworkCore;
using Service;
using Serilog;
using Microsoft.ApplicationInsights.Extensibility;
using Serilog.Templates;

namespace ExpenseTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
             Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.Debug()
            .MinimumLevel.Information()
            .Enrich.FromLogContext()
            .CreateBootstrapLogger();

            try
            {
                var builder = WebApplication.CreateBuilder(args);
                builder.Host.UseSerilog((context, services, loggerConfiguration) => loggerConfiguration
               .ReadFrom.Configuration(context.Configuration)
               .ReadFrom.Services(services)
               .WriteTo.Console(new ExpressionTemplate(
                   // Include trace and span ids when present.
                   "[{@t:HH:mm:ss} {@l:u3}{#if @tr is not null} ({substring(@tr,0,4)}:{substring(@sp,0,4)}){#end}] {@m}\n{@x}")));
              

                Log.Information("Starting the application Expense Tracker Web API...");

                // Add services to the container.

                builder.Services.AddControllers();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();


                builder.Services.AddDbContext<ExpenseTrackerContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"),
                providerOptions => providerOptions.EnableRetryOnFailure()).EnableSensitiveDataLogging());

                builder.Services.AddScoped<IUserService, UserService>();
                builder.Services.AddScoped<IUserRepository, UserRepository>();
                builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
                builder.Services.AddScoped<IExpenseService, ExpenseService>();

                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseAuthorization();


                app.MapControllers();

                app.Run();
            } 
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }


        }
    }
}
