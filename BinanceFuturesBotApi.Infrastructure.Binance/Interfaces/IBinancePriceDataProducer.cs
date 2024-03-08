using BinanceFuturesBotApi.ApplicationCore.DomainModels.Models;

namespace BinanceFuturesBotApi.Infrastructure.Binance.Interfaces;

public interface IBinancePriceDataProducer
{
    void Produce(CurrentPairState currentPairState);
    
    void CompleteProducing();
}