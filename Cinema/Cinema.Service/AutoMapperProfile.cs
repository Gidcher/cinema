using AutoMapper;
using Cinema.Data;
using Cinema.Service.ModelsRequest;

namespace Cinema.Service;

public class AutoMapperProfile:Profile
{
    public AutoMapperProfile()
    {
        CreateMap<HallRequest, Hall>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        
        CreateMap<HallSeats, HallSeatsRequest>();
        CreateMap<HallSeats, HallSeatsRequest>().ReverseMap();
        
        CreateMap<Movie, MovieRequest>();
        CreateMap<Movie, MovieRequest>().ReverseMap();
        
        CreateMap<Price, PriceRequest>();
        CreateMap<Price, PriceRequest>().ReverseMap();
        
        CreateMap<Session, SessionRequest>();
        CreateMap<Session, SessionRequest>().ReverseMap();
        
        CreateMap<Ticket, TicketRequest>();
        CreateMap<Ticket, TicketRequest>().ReverseMap();
    }
}