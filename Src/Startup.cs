using GFTGrovelorDeveloperCodeChallenge.Services;
using GFTGrovelorDeveloperCodeChallenge.Services.Interfaces;
using Prometheus;

namespace GFTGrovelorDeveloperCodeChallenge;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IDishesServices, DishesServices>();
        services.AddScoped<IOrdersService, OrdersService>();
        
        services.AddEndpointsApiExplorer();
        
        services.AddProblemDetails().AddExceptionHandler<GlobalExceptionHandler>();
        services.AddControllers().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        });

        services.UseHttpClientMetrics();
        
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new() { Title = "GFTGrovelorDeveloperCodeChallenge", Version = "v1" });
        });
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseMetricServer();
        app.UseHttpMetrics();
        
        app.UseExceptionHandler();
        
        app.UseHttpsRedirection();

        app.UseRouting();
        app.UseEndpoints(endpoints =>
            endpoints.MapControllers()
        );
    }
}
