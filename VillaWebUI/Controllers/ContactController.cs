using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.DTO.Dtos.ContactDtos;
using Villa.Entity.Entities;

namespace VillaWebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }   

        public async Task<IActionResult>  Index()
        {
            var values = await _contactService.TGetListAsnc();
            var contactList=_mapper.Map<List<ResultContactDto>>(values);
            return View(contactList);
        }
        public async Task<IActionResult> DeleteContact(ObjectId id)
        {
            await _contactService.TDelete(id);
            return RedirectToAction("Index");
              
        }
        public IActionResult CreateContact()
        {
            return View();  
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
          var newContact = _mapper.Map<Contact>(createContactDto);
            _contactService.TCreateAsync(newContact);   
            return RedirectToAction("Index");   
        }
       
    public async Task<IActionResult> UpdateContact(ObjectId id)
        {
            var value=  await _contactService.TGetByIdAsync(id);
            var contact=_mapper.Map<UpdateContactDto>(value);    
            return View(contact);   
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContact(ResultContactDto resultContactDto) { 
        
            var contacts= _mapper.Map<Contact>(resultContactDto);
            await _contactService.TUpdateAsync(contacts);
            
            return RedirectToAction("Index");   
        
        }
    }
}
