using System.Threading.Tasks.Dataflow;
using BinanceFuturesBotApi.ApplicationCore.DomainModels.Models;
using BinanceFuturesBotApi.Infrastructure.Binance.Interfaces;

namespace BinanceFuturesBotApi.Infrastructure.Binance.Implementations;

public class BinancePriceDataProducer : IBinancePriceDataProducer
{
    private readonly ITargetBlock<CurrentPairState> _targetBlock;

    public BinancePriceDataProducer(ITargetBlock<CurrentPairState> targetBlock)
    {
        _targetBlock = targetBlock;
    }
    
    public void Produce(CurrentPairState currentPairState)
    {
        _targetBlock.Post(currentPairState);
    }

    public void CompleteProducing()
    {
        _targetBlock.Complete();
    }
}