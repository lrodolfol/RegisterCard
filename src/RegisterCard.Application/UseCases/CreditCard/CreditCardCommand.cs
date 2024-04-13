using Microsoft.Extensions.Logging;
using RegisterCard.Application.DTO.CreditCard;
using RegisterCard.Application.Model;
using RegisterCard.Application.Services;
using RegisterCard.Core.Aggregates;
using RegisterCard.Core.Exceptions;


namespace RegisterCard.Application.UseCases.CreditCard;
public class CreditCardCommand
{
    private readonly Core.UseCases.Contracts.CreditCard.ICommandRepository _repository;
    private readonly Core.UseCases.Contracts.Token.ICommandRepository _tokenRepository;

    private readonly ILogger _logger;

    public CreditCardCommand(Core.UseCases.Contracts.CreditCard.ICommandRepository repository,
        Core.UseCases.Contracts.Token.ICommandRepository tokenRepository,
        ILogger logger) =>
        (_repository, _tokenRepository, _logger) = (repository, tokenRepository, logger);

    public async Task<BaseResult<Guid>> CreateAsync(EditCreditCard dto, Guid clientId)
    {
        try
        {
            dto.Validate();
            if (!dto.IsValid)
                return new BaseResult<Guid>(new Guid(), dto.Notifications.ToList(), false, 400);

            Core.Entities.CreditCard creditCart;
            creditCart = dto;
            creditCart.SetClientId(clientId);
            creditCart.SetToken(await CreateTokenAsync(creditCart));

            await _repository.CreateAsync(creditCart);

            return new BaseResult<Guid>(creditCart.Id, true, "Client successfuly created", 201);
        }
        catch (InvalidCpfException)
        {
            _logger.LogError("CPF number is invalid");
            return new BaseResult<Guid>(new Guid(), false, "CPF number is invalid", 400);
        }
        catch (Exception ex)
        {
            _logger.LogError($"An unhandled error ocurred for create client. check messsage => {ex.Message}");
            return new BaseResult<Guid>(new Guid(), false, $"We have an error. Please contact the support", 500);
        }
    }

    private async Task<Token> CreateTokenAsync(Core.Entities.CreditCard creditCard)
    {
        Token token;
        if (creditCard.SecurityCode % 2 == 0)
            token = new CreditCardTokenGenerator().Generate(new BeloToken(), creditCard);
        else
            token = new CreditCardTokenGenerator().Generate(new FasterToken(), creditCard);

        await _tokenRepository.CreateAsync(token);
        return token;
    }
}
