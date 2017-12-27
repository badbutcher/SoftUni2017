namespace News.Web.Infrastructure.Mapping
{
    using AutoMapper;
    using News.Data;
    using News.Services.Models;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<News, NewsInfoServiceModel>();
        }
    }
}