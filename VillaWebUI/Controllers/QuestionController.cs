using AutoMapper;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using Villa.Business.Abstract;
using Villa.Business.Validators;
using Villa.DTO.Dtos.ContactDtos;
using Villa.DTO.Dtos.QuestionAnswerDtos;
using Villa.Entity.Entities;

namespace VillaWebUI.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;

        public QuestionController(IQuestionService questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _questionService.TGetListAsnc();
            var QuestionList = _mapper.Map<List<ResultQuestionDto>>(values);
            return View(QuestionList);
        }
        public async Task<IActionResult> DeleteQuestion(ObjectId id)
        {
            await _questionService.TDelete(id);
            return RedirectToAction("Index");

        }
        public IActionResult CreateQuestion()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuestion(CreateQuestionDto questionAnswerCreateDto)
        {
           
            var newQuesiton = _mapper.Map<Question>(questionAnswerCreateDto);
            var validator = new QuestionValidator();
            var result = validator.Validate(newQuesiton);
            if (!result.IsValid)
            {
                result.Errors.ForEach (x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage.FormatWith(Color.Red));
                }) ;
                return View();
            }
            
           await _questionService.TCreateAsync(newQuesiton);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateQuestion(ObjectId id)
        {
            var value = await _questionService.TGetByIdAsync(id);
            var question = _mapper.Map<UpdateQuestionDto>(value);
            return View(question);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateQuestion(UpdateQuestionDto questionAnswerUpdateDto)
        {

            var question = _mapper.Map<Question>(questionAnswerUpdateDto);
            await _questionService.TUpdateAsync(question);

            return RedirectToAction("Index");

        }
    }
}
