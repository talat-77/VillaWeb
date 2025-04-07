using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.DTO.Dtos.FeatureDtos;

namespace VillaWebUI.ViewComponents.Default_Index
{
    public class _DefaultFeature:ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IFeatureSerivce _featureService;

        public _DefaultFeature(IMapper mapper, IFeatureSerivce featureService)
        {
            _mapper = mapper;
            _featureService = featureService;
        }

        public async Task <IViewComponentResult> InvokeAsync()
        {
            var value = await _featureService.TGetListAsnc();
            var FeatureList = _mapper.Map<List<ResultFeatureDto>>(value);
            return View(FeatureList);
        }
    }
}
