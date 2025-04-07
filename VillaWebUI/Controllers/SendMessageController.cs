using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.DTO.Dtos.MessageDtos;
using Villa.Entity.Entities;

namespace VillaWebUI.Controllers
{
    public class SendMessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public SendMessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {
           
            var mes = _mapper.Map<Message>(createMessageDto);
            await _messageService.TCreateAsync(mes);
            return RedirectToAction("INDEX", "Default");
        }
    }
}
