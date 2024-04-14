using DigitalPayments.Application.UseCases.Client;
using Microsoft.AspNetCore.Mvc;
using RegisterCard.API.Extensions;
using RegisterCard.Application.DTO.Client;
using RegisterCard.Application.DTO.CreditCard;
using RegisterCard.Application.UseCases.Client;
using RegisterCard.Application.UseCases.CreditCard;

namespace RegisterCard.API;

public partial class Program {
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();

        builder.AddDatabase();
        builder.AddContainers();
        builder.AddLogging();

        var app = builder.Build();

        app.UseHttpsRedirection();

        app.MapGet("api/v1/healthCheck", ()
            => "Its Works!");

        //client
        app.MapPost("api/v1/client", ([FromBody] EditClient client, [FromServices] ClientCommand handler)
            => handler.CreateAsync(client));

        app.MapGet("api/v1/client/{id}", ([FromRoute] Guid id, [FromServices] ClientQuery handler)
            => handler.Get(id));

        app.MapGet("api/v1/client", ([FromServices] ClientQuery handler)
            => handler.Get());


        //creditCard
        app.MapPost("api/v1/{clientId}/credit-card", ([FromRoute] Guid clientId, [FromBody] EditCreditCard creditCard, [FromServices] CreditCardCommand handler)
            => handler.CreateAsync(creditCard, clientId));

        app.Run();
    }
}

public partial class Program { }