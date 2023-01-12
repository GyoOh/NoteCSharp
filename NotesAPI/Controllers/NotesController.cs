using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesAPI.Data;
using NotesAPI.Models.DomainModels;
using NotesAPI.Models.DTO;

namespace NotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NotesDbContext dbContext;
        public NotesController(NotesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost]
        public IActionResult AddNote (AddNoteRequest addNoteRequest)
        {
            var note = new Note
            {
                Name = addNoteRequest.Name,
                Content = addNoteRequest.Content,
                Created = DateTime.Now
            };

            dbContext.Notes.Add(note);
            dbContext.SaveChanges();

            return Ok(note);
        }
        [HttpGet]
        public IActionResult GetNotes()
        {
            var notes = dbContext.Notes.ToList();
           
           var notesDTO = new List <Models.DTO.Notes>();
            foreach (var note in notes)
            {
              notesDTO.Add(new Models.DTO.Notes
                {
                    Id = note.Id,
                    Name = note.Name,
                    Content = note.Content,
                    Created = note.Created
                });
            }
            return Ok(notesDTO);
        }
        [HttpGet("{id}")]
        public IActionResult GetNoteById(int id)
        {
            var note = dbContext.Notes.FirstOrDefault(n => n.Id == id);
            if (note == null)
            {
                return NotFound();
            }
            var noteDTO = new Models.DTO.Notes
            {
                Id = note.Id,
                Name = note.Name,
                Content = note.Content,
                Created = note.Created
            };
            return Ok(noteDTO);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateNote(int id, UpdateNoteRequest updateNoteRequest)
        {
           var existingNote = dbContext.Notes.Find(id);
            if (existingNote == null)
            {
                return NotFound();
            }
            existingNote.Name = updateNoteRequest.Name;
            existingNote.Content = updateNoteRequest.Content;
            dbContext.SaveChanges();
            return Ok(existingNote);
    }
        [HttpDelete("{id}")]
        public IActionResult DeleteNote (int id)
        {
            var existingNote = dbContext.Notes.Find(id);
            if (existingNote == null)
            {
                return NotFound();
            }
            dbContext.Notes.Remove(existingNote);
            dbContext.SaveChanges();
            return Ok();
        }
}
}
