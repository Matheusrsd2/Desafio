using Desafio.Backend.Domain;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using System.Net.Http.Json;
using Xunit;

public class TituloControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public TituloControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task ObterTitulos_DeveRetornar200OK()
    {
        var response = await _client.GetAsync("/api/titulo");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var titulos = await response.Content.ReadFromJsonAsync<List<Titulo>>();
        titulos.Should().NotBeNull();
    }

    [Fact]
    public async Task CadastrarTitulo_DeveRetornar201Created()
    {
        var novoTitulo = new Titulo
        {
            Numero = "1",
            Devedor = "João Silva",
            CPF = "12345678900",
            Juros = 2,
            Multa = 5,
            Parcelas = new List<Parcela>
            {
                new Parcela { Numero = 1, Vencimento = DateTime.Now.AddDays(-5), ValorParcela = 100 }
            }
        };

        var response = await _client.PostAsJsonAsync("/api/titulo", novoTitulo);

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var tituloRetornado = await response.Content.ReadFromJsonAsync<Titulo>();
        tituloRetornado.Should().NotBeNull();
        tituloRetornado.Numero.Should().Be(novoTitulo.Numero);
    }
}
