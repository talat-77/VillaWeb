using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.DTO.Dtos.BannerDtos;
using Villa.DTO.Dtos.FeatureDtos;
using Villa.Entity.Entities;

namespace VillaWebUI.Controllers
{
    
   
    public class FeatureController : Controller
    {
        private readonly IFeatureSerivce _featureSerivce;
        private readonly IMapper _mapper;
        public FeatureController(IFeatureSerivce featureSerivce, IMapper mapper)
        {
            _featureSerivce = featureSerivce;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _featureSerivce.TGetListAsnc();
            var featureList = _mapper.Map<List<ResultFeatureDto>>(values);
            return View(featureList);
        }
        public async Task<IActionResult> DeleteFeature(ObjectId id)
        {
            await _featureSerivce.TDelete(id);
            return RedirectToAction("Index");
        }
        public IActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var newFeature = _mapper.Map<Feature>(createFeatureDto);
            await _featureSerivce.TCreateAsync(newFeature);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateFeature(ObjectId id)
        {
            var value = await _featureSerivce.TGetByIdAsync(id);
            var updateFeature = _mapper.Map<UpdateFeatureDto>(value);
            return View(updateFeature);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var feature = _mapper.Map<Feature>(updateFeatureDto);
            await _featureSerivce.TUpdateAsync(feature);
            return RedirectToAction("Index");
        }
    }
}
