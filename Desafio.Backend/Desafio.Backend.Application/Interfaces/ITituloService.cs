using Desafio.Backend.Domain;

namespace Desafio.Backend.Application.Interfaces
{
    public interface ITituloService
    {
        List<Titulo> ObterTitulos();
        void AdicionarTitulo(Titulo titulo);
    }
}
