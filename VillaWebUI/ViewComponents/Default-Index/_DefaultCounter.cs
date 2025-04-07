using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.DTO.Dtos.CounterDtos;

namespace VillaWebUI.ViewComponents.Default_Index
{
	public class _DefaultCounter:ViewComponent
	{
		private readonly ICounterSerivce _counterService;
		private readonly IMapper _mapper;

		public _DefaultCounter(ICounterSerivce counterService, IMapper mapper)
		{
			_counterService = counterService;
			_mapper = mapper;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var value = await _counterService.TGetListAsnc();
			var CounterList = _mapper.Map<List<ResultCounterDto>>(value);
			return View(CounterList);	
		}
	}
}
