using Microsoft.Extensions.Logging;
using RegisterCard.Application.DTO.Client;
using RegisterCard.Application.Model;
using RegisterCard.Core.UseCases.Contracts.Client;

namespace DigitalPayments.Application.UseCases.Client;
public class ClientQuery
{
    private readonly IQueryRepository _repository;
    private readonly ILogger _logger;

    public ClientQuery(IQueryRepository repository, ILogger logger) =>
        (_repository, _logger) = (repository, logger);

    public async Task<BaseResult<ReadClient>> GetAsync(int id)
    {
        try
        {
            var client = await _repository.GetAsync(id);
            if (client is null)
                return new BaseResult<ReadClient>(new ReadClient(), false, "Client not found", 400);

            var readClient = new ReadClient(client);

            return new BaseResult<ReadClient>(readClient);
        }catch(Exception ex)
        {
            _logger.LogError($"An unhandled error ocurred for get client. check messsage => {ex.Message}");
            return new BaseResult<ReadClient>(
                new ReadClient(), 
                false, 
                $"We have an error. Please contact the support", 
                500
                );
        }
    }

    public BaseResult<IEnumerable<ReadClient>> Get()
    {
        try
        {
            var client = _repository.GetAsync();

            var readClients = new List<ReadClient>();
            client.ForEach(x => readClients.Add(new ReadClient(x)));
            
            return new BaseResult<IEnumerable<ReadClient>>(readClients);
        }
        catch (Exception ex)
        {
            _logger.LogError($"An unhandled error ocurred for get clients. check messsage => {ex.Message}");
            return new BaseResult<IEnumerable<ReadClient>>(
                new List<ReadClient>(),
                false,
                $"We have an error. Please contact the support",
                500
                );
        }
    }
}
