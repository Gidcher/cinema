using Cinema.Service;
using Cinema.Service.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.DependencyInjection;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddScoped<IHallService, HallService>();
        service.AddScoped<IHallSeatsService, HallSeatsService>();
        service.AddScoped<IMovieService, MovieService>();
        service.AddScoped<IPriceService, PriceService>();
        service.AddScoped<ISessionService, SessionService>();
        service.AddScoped<ITicketService, TicketService>();
        
        return service;
    }
}