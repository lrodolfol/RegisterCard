using Microsoft.Extensions.Logging;
using RegisterCard.Application.DTO.Client;
using RegisterCard.Application.Model;
using RegisterCard.Core.Exceptions;
using RegisterCard.Core.UseCases.Contracts.Client;

namespace RegisterCard.Application.UseCases.Client;
public class ClientCommand
{
    private readonly ICommandRepository _repository;
    private readonly ILogger _logger;

    public ClientCommand(ICommandRepository repository, ILogger logger) =>
        (_repository, _logger) = (repository, logger);

    public async Task<BaseResult<int>> CreateAsync(EditClient dto)
    {
        try
        {
            dto.Validate();
            if (!dto.IsValid)
                return new BaseResult<int>(0, dto.Notifications.ToList(), false, 400);

            Core.Entities.Client client;
            client = dto;

            await _repository.CreateAsync(client);

            return new BaseResult<int>(client.Id, true, "Client successfuly created", 201);
        }
        catch(InvalidCpfException)
        {
            _logger.LogError("CPF number is invalid");
            return new BaseResult<int>(0, false, "CPF number is invalid", 400);
        }catch (Exception ex)
        {
            _logger.LogError($"An unhandled error ocurred for create client. check messsage => {ex.Message}");
            return new BaseResult<int>(0, false, $"We have an error. Please contact the support", 500);
        }
    }
}
