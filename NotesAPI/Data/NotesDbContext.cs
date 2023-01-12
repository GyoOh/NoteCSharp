using System;
using Microsoft.EntityFrameworkCore;
using NotesAPI.Models.DomainModels;

namespace NotesAPI.Data
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
    }
}

