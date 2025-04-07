
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.DTO.Dtos.BannerDtos;

namespace VillaWebUI.ViewComponents.Default_Index
{
    public class DefaultBanner:ViewComponent
    {
        private readonly IBannerService _bannerService;
        private readonly IMapper _mapper;

        public DefaultBanner(IBannerService bannerService, IMapper mapper)
        {
            _bannerService = bannerService;
            _mapper = mapper;
        }

        public  async Task<IViewComponentResult>InvokeAsync()
        {
            var value = await _bannerService.TGetListAsnc();
            var BannerList = _mapper.Map<List<ResultBannerDto>>(value);
            return View(BannerList);
        }
    }
}
