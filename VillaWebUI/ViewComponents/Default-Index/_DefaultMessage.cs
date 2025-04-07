using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Villa.Business.Abstract;
using Villa.DTO.Dtos.MessageDtos;

namespace VillaWebUI.ViewComponents.Default_Index
{
    public class _DefaultMessage:ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public _DefaultMessage(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _messageService.TGetListAsnc();
            var MessageList = _mapper.Map<List<ResultMessageDto>>(value);
            return View(MessageList);   
        }
    }
}
