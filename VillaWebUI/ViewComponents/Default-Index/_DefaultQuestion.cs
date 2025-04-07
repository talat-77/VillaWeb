using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.DTO.Dtos.QuestionAnswerDtos;

namespace VillaWebUI.ViewComponents.Default_Index
{
	public class _DefaultQuestion:ViewComponent
	{
		private readonly IMapper _mapper;
		private readonly IQuestionService _questionService;
		public _DefaultQuestion(IMapper mapper, IQuestionService questionService)
		{
			_mapper = mapper;
			_questionService = questionService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var value = await _questionService.TGetListAsnc();
			var questionList = _mapper.Map<List<ResultQuestionDto>>(value);
			return View(questionList);
		}

	}
}
