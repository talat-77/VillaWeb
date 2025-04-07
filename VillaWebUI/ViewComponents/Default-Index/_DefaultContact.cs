using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.DataAccess.Abstract;
using Villa.DTO.Dtos.ContactDtos;

namespace VillaWebUI.ViewComponents.Default_Index
{
    public class _DefaultContact:ViewComponent
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public _DefaultContact(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _contactService.TGetListAsnc();
            var ContactList=_mapper.Map<List<ResultContactDto>>(value);
            return View(ContactList);
        }
        
    }
}
