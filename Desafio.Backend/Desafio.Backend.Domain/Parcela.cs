namespace Desafio.Backend.Domain
{
    public class Parcela
    {
        public int Numero { get; set; }
        public decimal ValorParcela { get; set; }
        public DateTime Vencimento { get; set; }
        public int DiasAtraso { get; set; }
    }
}
