
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.DTO.Dtos.DealDtos;

namespace VillaWebUI.ViewComponents.Default_Index
{
    public class _DefaultDeal:ViewComponent
    {
        private readonly IDealService _dealService;
        private readonly IMapper _mapper;
        public _DefaultDeal(IDealService dealService, IMapper mapper)
        {
            _dealService = dealService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _dealService.TGetListAsnc();
            var DealList = _mapper.Map<List<ResultDealDto>>(value);
            return View(DealList);
        }
    }
}
