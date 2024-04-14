using DigitalPayments.Application.UseCases.Client;
using Microsoft.AspNetCore.Authorization;
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
        app.MapPost("api/v1/client", [AllowAnonymous] async ([FromBody] EditClient client, [FromServices] ClientCommand handler) =>
        {
            var result = await handler.CreateAsync(client);

            if (result.StatusCode == 201)
                return Results.Created("GetClientById", result.Data);
            else if (result.StatusCode == 400)
                return Results.BadRequest(result.Data);
            else
                return Results.StatusCode(StatusCodes.Status500InternalServerError);
        });


        app.MapGet("api/v1/client/{id}", [AllowAnonymous] async ([FromRoute] int id, [FromServices] ClientQuery handler) =>
        {
            var result = await handler.GetAsync(id);

            if (result.StatusCode == 200)
                return Results.Ok(result);
            else
                return Results.BadRequest(result.Data);
        }).WithName("GetClientById"); ;

        app.MapGet("api/v1/client", [AllowAnonymous] async ([FromServices] ClientQuery handler) =>
        {
            var result = handler.Get();

            if (result.StatusCode == 200)
                return Results.Ok(result);
            else
                return Results.BadRequest(result.Data);
        });


        //creditCard
        app.MapPost("api/v1/{clientId}/credit-card", [AllowAnonymous] async ([FromRoute] int clientId, [FromBody] EditCreditCard creditCard, [FromServices] CreditCardCommand handler) =>
        {
            var result = await handler.CreateAsync(creditCard, clientId);

            if (result.StatusCode == 201)
                return Results.Created();
            else if (result.StatusCode == 400)
                return Results.BadRequest(result.Data);
            else
                return Results.StatusCode(StatusCodes.Status500InternalServerError);
        });

        app.Run();
    }
}

public partial class Program { }