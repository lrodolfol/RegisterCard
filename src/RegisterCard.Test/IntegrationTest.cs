using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using RegisterCard.Application.DTO.Client;
using System.Net;
using System.Text;
using System.Text.Json;

namespace RegisterCard.Test;
public class Integrationtest : IClassFixture<WebApplicationFactory<RegisterCard.API.Program>>
{
    private readonly WebApplicationFactory<RegisterCard.API.Program> _webApplicationFactory;

    public Integrationtest(WebApplicationFactory<RegisterCard.API.Program> webApplicationFactory)
    {
        _webApplicationFactory = webApplicationFactory;
    }

    [Fact(DisplayName = "Success - Create client successfuly")]
    public async void ShouldAddClientCorrectly()
    {
        var client = _webApplicationFactory.CreateClient();
        var editClient = new EditClient() { Cpf = "35950306058", Name = "Rodolfo de Jesus" };
        var body = JsonSerializer.Serialize(editClient);
        var strContent = new StringContent(body, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("api/v1/client", strContent);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
