namespace Desafio.Backend.Domain
{
    public class Titulo
    {
        private string _devedor = string.Empty;
        private string _cpf = string.Empty;
        public string Numero { get; set; }
        public string Devedor
        {
            get => _devedor;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Devedor não pode ser nulo ou vazio.");
                _devedor = value;
            }
        }

        public string CPF
        {
            get => _cpf;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("CPF não pode ser nulo ou vazio.");
                _cpf = value;
            }
        }
        public decimal ValorOriginal { get; set; }
        public decimal ValorAtualizado { get; set; }
        public decimal Juros { get; set; }
        public decimal Multa { get; set; }
        public List<Parcela> Parcelas { get; set; } = new ();

        public List<Titulo> CalcularDividaTitulo(List<Titulo> listaTitulos)
        {        
            foreach (var titulo in listaTitulos)
            {
                decimal somaValorOriginal = 0;
                decimal vlrJurosParcelas = 0;
                foreach (var parcela in titulo.Parcelas)
                {
                    DateTime dataAtual = DateTime.Now.Date;
                    TimeSpan diferenca = dataAtual - parcela.Vencimento;
                    parcela.DiasAtraso = (int)diferenca.TotalDays;

                    if (parcela.DiasAtraso > 0)
                        vlrJurosParcelas += ((titulo.Juros / 100) / 30) * parcela.DiasAtraso * parcela.ValorParcela;

                    somaValorOriginal += parcela.ValorParcela;


                }
                titulo.ValorOriginal = somaValorOriginal;
                titulo.ValorAtualizado = Math.Round(titulo.ValorOriginal
                                                    + vlrJurosParcelas
                                                    + (titulo.ValorOriginal * (titulo.Multa / 100)), 2);
            }

            return listaTitulos;
        }
    }
}
