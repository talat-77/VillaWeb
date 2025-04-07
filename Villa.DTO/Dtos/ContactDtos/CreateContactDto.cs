using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villa.DTO.Dtos.ContactDtos
{
    public class CreateContactDto
    {
        public string MapUrl { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ObjectId Id { get; set; }    
    }
}
