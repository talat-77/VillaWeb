using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.DTO.Dtos.ContactDtos;
using Villa.DTO.Dtos.CounterDtos;
using Villa.Entity.Entities;

namespace VillaWebUI.Controllers
{
    public class CounterController : Controller
    {
        private readonly ICounterSerivce _counterSerivce;
        private readonly IMapper _mapper;
        public CounterController(ICounterSerivce counterSerivce, IMapper mapper)
        {
            _counterSerivce = counterSerivce;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            var values = await _counterSerivce.TGetListAsnc();
            var counterList = _mapper.Map<List<ResultCounterDto>>(values);
            return View(counterList);
        }
        public async Task<IActionResult> DeleteCounter(ObjectId id)
        {
            await _counterSerivce.TDelete(id);
            return RedirectToAction("Index");

        }
        public IActionResult CreateCounter()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCounter(CreateCounterDto createCounterDto)
        {
            var newCounter = _mapper.Map<Counter>(createCounterDto);
            await _counterSerivce.TCreateAsync(newCounter);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateCounter(ObjectId id)
        {
            var value = await _counterSerivce.TGetByIdAsync(id);
            var counter = _mapper.Map<UpdateCounterDto>(value);
            return View(counter);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCounter(UpdateCounterDto updateCounterDto)
        {

            var counter = _mapper.Map<Counter>(updateCounterDto);
            await _counterSerivce.TUpdateAsync(counter);
            return RedirectToAction("Index");

        }
    }
}
