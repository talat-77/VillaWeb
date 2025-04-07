using Microsoft.AspNetCore;
using AutoMapper;
using Villa.DTO.Dtos.BannerDtos;
using Villa.DTO.Dtos.ContactDtos;
using Villa.DTO.Dtos.CounterDtos;
using Villa.DTO.Dtos.DealDtos;
using Villa.DTO.Dtos.FeatureDtos;
using Villa.DTO.Dtos.MessageDtos;
using Villa.DTO.Dtos.ProductDtos;
using Villa.DTO.Dtos.QuestionAnswerDtos;
using Villa.Entity.Entities;
using Villa.DTO.Dtos.VideoDtos;
using Villa.DTO.Dtos.SubHeaderDtos;

namespace VillaWebUI.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<ResultBannerDto, Banner>().ReverseMap();
            CreateMap<CreateBannerDto, Banner>().ReverseMap();
            CreateMap<UpdateBannerDto, Banner>().ReverseMap();

            CreateMap<CreateContactDto, Contact>().ReverseMap();
            CreateMap<UpdateContactDto, Contact>().ReverseMap();
            CreateMap<ResultContactDto, Contact>().ReverseMap();

            CreateMap<CreateCounterDto,Counter>().ReverseMap();
            CreateMap<ResultCounterDto, Counter>().ReverseMap();
            CreateMap<UpdateCounterDto, Counter>().ReverseMap();

            CreateMap<CreateDealDto,Deal>().ReverseMap();
            CreateMap<UpdateDealDto, Deal>().ReverseMap();
            CreateMap<ResultDealDto, Deal>().ReverseMap();

            CreateMap<CreateFeatureDto,Feature>().ReverseMap();
            CreateMap<ResultFeatureDto, Feature>().ReverseMap();
            CreateMap<UpdateFeatureDto, Feature>().ReverseMap();

            CreateMap<CreateMessageDto,Message>().ReverseMap();
            CreateMap<UpdateMessageDto, Message>().ReverseMap();
            CreateMap<ResultMessageDto, Message>().ReverseMap();

            CreateMap<CreateQuestionDto,Question>().ReverseMap();
            CreateMap<ResultQuestionDto, Question>().ReverseMap();
            CreateMap<UpdateQuestionDto, Question>().ReverseMap();

            CreateMap<CreateProductDto,Product>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();
            CreateMap<ResultProductDto, Product>().ReverseMap();

            CreateMap<CreateVideoDto, Video>().ReverseMap();
            CreateMap<UpdateVideoDto, Video>().ReverseMap();
            CreateMap<ResultVideoDto, Video>().ReverseMap();
            
            CreateMap<CreateSubHeaderDto , SubHeader>().ReverseMap();
            CreateMap<ResultSubHeaderDto, SubHeader>().ReverseMap();
            CreateMap<UpdateSubHeaderDto, SubHeader>().ReverseMap();

        }
    }
}
