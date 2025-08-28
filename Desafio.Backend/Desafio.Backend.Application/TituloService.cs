using Desafio.Backend.Domain;
using Desafio.Backend.Application.Interfaces;

namespace Desafio.Backend.Application
{
    public class TituloService : ITituloService
    {

        List<Titulo> listaTitulos = new List<Titulo>()
        {
            new Titulo
            {
                Numero = "12345",
                Devedor = "João da Silva",
                CPF = "123.456.789-00",
                Juros = 1,
                Multa = 2,
                Parcelas = new List<Parcela>
                {
                    new Parcela { Numero = 1, ValorParcela = 100, Vencimento = new DateTime(2025, 06, 15) },
                    new Parcela { Numero = 2, ValorParcela = 100, Vencimento = new DateTime(2025, 07, 15) },
                    new Parcela { Numero = 3, ValorParcela = 100, Vencimento = new DateTime(2025, 08, 15) }
                }
            },            
            new Titulo
            {
                Numero = "67890",
                Devedor = "Maria Oliveira",
                CPF = "987.654.321-00",
                Juros = 2,
                Multa = 4,
                Parcelas = new List<Parcela>
                {
                    new Parcela { Numero = 1, ValorParcela = 1200, Vencimento = new DateTime(2025, 01, 20)}
                }
            }
        };

        public void AdicionarTitulo(Titulo titulo)
        {
            listaTitulos.Add(titulo);  
        }

        public List<Titulo> ObterTitulos()
        {
            Titulo titulo = new();
            listaTitulos = titulo.CalcularDividaTitulo(listaTitulos);

            return listaTitulos;
            
        }
    }
}
