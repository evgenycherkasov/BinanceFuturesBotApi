using BinanceFuturesBotApi.ApplicationCore.DomainModels.Models;

namespace BinanceFuturesBotApi.Infrastructure.Binance.Interfaces;

public interface IBinancePriceParser
{
    Task StartStreamingPriceDataAsync(IEnumerable<PairName> pairs, CancellationToken cancellationToken);
    
    Task<MinMaxModel> GetPreviousDateMinMaxPairAsync(PairName pair, CancellationToken cancellationToken);
}