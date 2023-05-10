using Hangfire;

namespace API.Application.Jobs
{
    public static class HangfireExtensions
    {
        public static void AddHangfireServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHangfire(config =>
                config.UseSqlServerStorage(configuration.GetConnectionString("DefaultHangfireConnection")));

            services.AddHangfireServer();
        }
        
        public static void AddHangfireJobs(this IApplicationBuilder app)
        {
            app.UseHangfireDashboard();
            RecurringJob.AddOrUpdate<ILogJob>(x => x.Log(), Cron.Minutely);
        }
    }
}
