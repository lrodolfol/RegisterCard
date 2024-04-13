using DigitalPayments.Application.UseCases.Client;
using RegisterCard.Application.UseCases.Client;

namespace RegisterCard.API.Extensions;

public static class AddContainersDI
{
    public static void AddContainers(this WebApplicationBuilder builder)
    {
        LoadContextRepository(builder);
        LoadHandlers(builder);
    }

    private static void LoadContextRepository(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<Core.UseCases.Contracts.Client.ICommandRepository,
            Infra.Repository.UseCases.Client.CommandRepository>();
        builder.Services.AddScoped<Core.UseCases.Contracts.Client.IQueryRepository,
            Infra.Repository.UseCases.Client.QueryRepository>();

        builder.Services.AddScoped<Core.UseCases.Contracts.CreditCard.ICommandRepository,
            Infra.Repository.UseCases.Account.CommandRepository>();
        builder.Services.AddScoped<Core.UseCases.Contracts.CreditCard.IQueryRepository,
            Infra.Repository.UseCases.Account.QueryRepository>();

        builder.Services.AddScoped<Core.UseCases.Contracts.Token.ICommandRepository,
            Infra.Repository.UseCases.Token.CommandRepository>();
        builder.Services.AddScoped<Core.UseCases.Contracts.Token.IQueryRepository,
            Infra.Repository.UseCases.Token.QueryRepository>();
    }

    private static void LoadHandlers(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ClientCommand>();
        builder.Services.AddScoped<ClientQuery>();

        builder.Services.AddScoped<Application.UseCases.CreditCard.CreditCardCommand>();

        //builder.Services.AddScoped<Application.UseCases.Payment.PaymentCommand>();
    }
}
