using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.DTO.Dtos.BannerDtos;
using Villa.Entity.Entities;

namespace VillaWebUI.Controllers
{
    public class BannerController : Controller
    {
        private readonly IBannerService bannerService;
        private readonly IMapper mapper;
        public BannerController(IBannerService bannerService, IMapper mapper)
        {
            this.bannerService = bannerService;
            this.mapper = mapper;
        }

        public async Task <IActionResult> Index ()
        {
            var values = await bannerService.TGetListAsnc();
            var bannerList = mapper.Map<List<ResultBannerDto>>(values);
            return View(bannerList);
        }
        public async Task<IActionResult> DeleteBanner(ObjectId id)
        {
            await bannerService.TDelete(id);    
            return RedirectToAction("Index");    
        }
        public IActionResult CreateBanner()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto createBannerDto)
        {
            var newBanner= mapper.Map<Banner>(createBannerDto);
            await bannerService.TCreateAsync(newBanner);
            return RedirectToAction("Index");
        }
        [HttpGet]
      public async Task<IActionResult> UpdateBanner(ObjectId id)
        {
            var value= await bannerService.TGetByIdAsync(id);
            var updateBanner = mapper.Map<UpdateBannerDto>(value);
            return View(updateBanner);  
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto updateBannerDto)
        {
            var banner = mapper.Map<Banner>(updateBannerDto);
            await bannerService.TUpdateAsync(banner);
            return RedirectToAction("Index");       
        }

    }
}
