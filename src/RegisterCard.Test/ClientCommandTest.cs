using Microsoft.Extensions.Logging;
using Moq;
using RegisterCard.Application.UseCases.Client;
using RegisterCard.Core.UseCases.Contracts.Client;
using RegisterCard.Core.ValueObjects;

namespace RegisterCard.Test;
public class ClientCommandTest
{
    private Mock<ICommandRepository> _clientRepository = null!;
    private Mock<ILogger> _logger = null!;
    public ClientCommandTest()
    {
        _logger = new Mock<ILogger>();

        GetAbstractionContext();
    }

    private void GetAbstractionContext()
    {
        _clientRepository = new Mock<ICommandRepository>();
        _clientRepository.Setup(x => x.CreateAsync(new Core.Entities.Client()
        {
            Cpf = new Cpf("35950306058"),
            Name = "Rodolfo de Jesus"
        }
        ));
    }

    [Fact(DisplayName = "Success - Create new client")]
    public async void ShouldCreateSuccessfulyNewClient()
    {
        var handler = new ClientCommand(_clientRepository.Object, _logger.Object);
        var result = await handler.CreateAsync(new Application.DTO.Client.EditClient()
        {
            Cpf = "35950306058",
            Name = "Rodolfo Jesus",
        });

        Assert.NotNull(result);
        Assert.True(result.Success);
        Assert.Equal(201, result.StatusCode);
    }

    [Fact(DisplayName = "Erro - Create new client with invalid cpf")]
    public async void ShouldReturnErroWithInvalidCpf()
    {
        var handler = new ClientCommand(_clientRepository.Object, _logger.Object);
        var result = await handler.CreateAsync(new Application.DTO.Client.EditClient()
        {
            Cpf = "35950306070",
            Name = "Rodolfo Jesus",
        });

        Assert.Equal(400, result.StatusCode);
    }
}
