using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.DTO.Dtos.SubHeaderDtos;

namespace VillaWebUI.ViewComponents.UILayout
{
    public class _UISubHeader:ViewComponent
    {
        private readonly ISubHeaderService _subHeaderService;   
        private readonly IMapper _mapper;

        public _UISubHeader(ISubHeaderService subHeaderService, IMapper mapper)
        {
            _subHeaderService = subHeaderService;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _subHeaderService.TGetListAsnc();
            var SubHeaderList = _mapper.Map<List<ResultSubHeaderDto>>(value);
            return View(SubHeaderList); 
        }
    }
}
