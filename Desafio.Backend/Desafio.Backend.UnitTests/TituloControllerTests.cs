using Desafio.Backend.API.Controllers;
using Desafio.Backend.Domain;
using Desafio.Backend.Application;
using Desafio.Backend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.Backend.xUnit
{
    public class TituloControllerTests
    {
        private readonly ServiceProvider _serviceProvider;
        public TituloControllerTests()
        {  
            var services = new ServiceCollection();

            services.AddScoped<ITituloService, TituloService>();
            services.AddTransient<TituloController>();

            _serviceProvider = services.BuildServiceProvider();
        }

        [Fact]
        public void ObterTitulos_DeveRetornarListaVazia_QuandoNaoHaTitulos()
        {
            // Arrange
            var controller = _serviceProvider.GetRequiredService<TituloController>();

            // Act
            var actionResult = controller.ObterTitulos();

            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var titulos = Assert.IsType<List<Titulo>>(okResult.Value);
            // Assert
            Assert.NotNull(titulos);
            Assert.Empty(titulos);
        }

        [Fact]
        public void CadastrarTitulo_DeveAdicionarETrazerNoObter()
        {
            var controller = _serviceProvider.GetRequiredService<TituloController>();

            var titulo = new Titulo
            {
                Numero = "1",
                Devedor = "João da Silva",
                CPF = "12345678900",
                ValorOriginal = 1000,
                ValorAtualizado = 1100,
                Juros = 5,
                Multa = 2,
                Parcelas = new List<Parcela>
                {
                    new Parcela { Numero = 1, ValorParcela = 500, Vencimento = DateTime.Now.AddDays(10), DiasAtraso = 0 },
                    new Parcela { Numero = 2, ValorParcela = 600, Vencimento = DateTime.Now.AddDays(40), DiasAtraso = 0 }
                }
            };

            // Act
            var createResult = controller.CadastrarTitulo(titulo);

            var createdAt = Assert.IsType<CreatedAtActionResult>(createResult.Result);
            var tituloCriado = Assert.IsType<Titulo>(createdAt.Value);

            Assert.Equal("João da Silva", tituloCriado.Devedor);

            // Act -> chama o obter
            var actionResult = controller.ObterTitulos();
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var titulos = Assert.IsType<List<Titulo>>(okResult.Value);

            // Assert
            Assert.Single(titulos);
            Assert.Equal("João da Silva", titulos[0].Devedor);
        }
    }
}