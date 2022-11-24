using Microsoft.AspNetCore.Mvc;
using API_Notas.Context;
using API_Notas.Models;

namespace API_Notas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotaAlunoController : ControllerBase
    {
        private readonly Notas _context;
        public NotaAlunoController(Notas context)
        {
            _context = context;
        }

        [HttpPost("CriarAluno")] //metodo criar
        public IActionResult CriarAluno(NotasAluno notasAluno)
        {
             _context.Add(notasAluno);
             _context.SaveChanges();
             return Ok(notasAluno);
        }


        [HttpGet("ObtemPeloId/{id}")] //metodo de leitura que tras a busca pelo id
        public IActionResult ObtemId(int id)
        {
            var notasAluno = _context.NotasAlunos.Find(id);

            if (notasAluno == null)
            {
                return NotFound();
            }    

            return Ok (notasAluno);
        }

        [HttpPut("AtualizarNotas/{id}")]//metodo para atualizar
        public IActionResult AtualizaNota(int id, NotasAluno notasAluno)
        {
            var notasAlunoBanco = _context.NotasAlunos.Find(id);

            if (notasAlunoBanco == null)
            {
                return NotFound();
            } 

            notasAlunoBanco.Nome = notasAluno.Nome;
            notasAlunoBanco.Idade = notasAluno.Idade;
            notasAlunoBanco.Nota =  notasAluno.Nota;

            _context.Update(notasAlunoBanco); 
            _context.SaveChanges();
            return Ok (notasAlunoBanco);
        }


        [HttpDelete("{id}")] //metodo para deletar
        public IActionResult DeleteAluno(int id)
        {
            var notasAluno = _context.NotasAlunos.Find(id);

            if (notasAluno == null)
            {
                return NotFound();
            }

            _context.Remove(notasAluno);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpGet("ListaAlunos")]
        public IActionResult Listagem(){
            var notasAluno = _context.NotasAlunos.ToList();
            return Ok (notasAluno);


        }

    }
}

