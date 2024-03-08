using BinanceFuturesBotApi.ApplicationCore.ApplicationServices.Interfaces;
using BinanceFuturesBotApi.ApplicationCore.DomainModels.Models;

namespace BinanceFuturesBotApi.Infrastructure.Binance.Implementations;

public class BinanceStrategyExecutor : IBinanceStrategyExecutor
{
    public Task ExecuteAsync(StrategyExecutionData data, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}