using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Models.DTO
{
    public class UpdateNoteRequest
    {
        public string Name { get; set; }
        public string Content { get; set; }
    }
}