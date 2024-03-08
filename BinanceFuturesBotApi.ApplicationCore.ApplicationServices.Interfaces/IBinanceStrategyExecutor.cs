using BinanceFuturesBotApi.ApplicationCore.DomainModels.Models;

namespace BinanceFuturesBotApi.ApplicationCore.ApplicationServices.Interfaces;

public interface IBinanceStrategyExecutor
{
    Task ExecuteAsync(StrategyExecutionData data, CancellationToken cancellationToken);
}