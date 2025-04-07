using Villa.Business.Abstract;
using Villa.Business.Concrete;
using Villa.DataAccess.Abstract;
using Villa.DataAccess.EntityFrameWork;
using Villa.DataAccess.Repository;
using Villa.Entity.Entities;

namespace VillaWebUI.Extensions
{
    public static class ServicesExtension
    {
         public static void AddServiceExtension(this IServiceCollection services)
        {
            services.AddScoped<IBannerDal, EFBannerDal>();
            services.AddScoped<IBannerService, BannerManager>();
            
            services.AddScoped<IContactDal, EFContactDal>();
            services.AddScoped<IContactService, ContactManager>();
            
            services.AddScoped<ICounterDal, EFCounterDal>();
            services.AddScoped<ICounterSerivce, CounterManager>();
            
            services.AddScoped<IDealDal, EFDealDal>();
            services.AddScoped<IDealService, DealManager>();
            
            services.AddScoped<IFeatureDal, EFFeatureDal>();
            services.AddScoped<IFeatureSerivce, FeatureManager>();
            
            services.AddScoped<IMessageDal, EFMessageDal>();
            services.AddScoped<IMessageService, MessageManager>();
            
            services.AddScoped<IProductDal, EFProductDal>();
            services.AddScoped<IProductService, ProductManager>();
            
            services.AddScoped<IQuestionDal, EFQuestionDal>();
            services.AddScoped<IQuestionService, QuestionManager>();
            
            services.AddScoped<IVideoDal, EFVideoDal>();
            services.AddScoped<IVideoService, VideoManager>();

            services.AddScoped<ISubHeaderDal, EFSubHeader>();
            services.AddScoped<ISubHeaderService, SubHeaderManager>();

            services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericRepository<>));

         
        }
    }
}
