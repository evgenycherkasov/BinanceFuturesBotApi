using BinanceFuturesBotApi.ApplicationCore.DomainModels.Models;

namespace BinanceFuturesBotApi.ApplicationCore.ApplicationServices.Interfaces;

public interface IBinanceStrategySolver
{
    Task<bool> CanExecuteAsync(MinMaxModel minMaxModel, CurrentPairState currentPairState, CancellationToken cancellationToken);
}