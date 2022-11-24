using Microsoft.EntityFrameworkCore;
using API_Notas.Models;

namespace API_Notas.Context
{
    public class Notas : DbContext
    {
        public Notas(DbContextOptions<Notas> options) : base(options)
        {

        }


        public DbSet<NotasAluno> NotasAlunos{get; set;}
    }
}