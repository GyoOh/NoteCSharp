using System;
namespace NotesAPI.Models.DomainModels
{
	public class Note
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
    }
}

