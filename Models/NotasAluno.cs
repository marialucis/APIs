namespace API_Notas.Models
{
    public class NotasAluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public decimal Nota { get; set; }
        public bool Ativo { get; set; }
    }
}