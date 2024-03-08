using Binance.Net.Interfaces.Clients.CoinFuturesApi;
using BinanceFuturesBotApi.ApplicationCore.DomainModels.Models;
using BinanceFuturesBotApi.Infrastructure.Binance.Interfaces;

namespace BinanceFuturesBotApi.Infrastructure.Binance.Implementations;

public class BinancePriceParser : IBinancePriceParser
{
    private readonly IBinanceRestClientCoinFuturesApi _restClient;
    private readonly IBinanceSocketClientCoinFuturesApi _socketClient;
    private readonly IBinancePriceDataProducer _producer;
    
    public BinancePriceParser(IBinanceRestClientCoinFuturesApi restClient,
        IBinanceSocketClientCoinFuturesApi socketClient,
        IBinancePriceDataProducer producer)
    {
        _restClient = restClient;
        _socketClient = socketClient;
        _producer = producer;
    }

    public async Task StartStreamingPriceDataAsync(IEnumerable<PairName> pairs, CancellationToken cancellationToken)
    {
        _socketClient.SubscribeToMiniTickerUpdatesAsync(pairs.Select(p => p.ToString()), @event =>
        {
            var data = @event.Data;
            _producer.Produce(new CurrentPairState(data.LastPrice, data.Symbol, DateTime.Now));
        }, cancellationToken);
    }

    public async Task<MinMaxModel> GetPreviousDateMinMaxPairAsync(PairName pair, CancellationToken cancellationToken)
    {
        var result = await _restClient.ExchangeData.GetTickersAsync(pair: pair.ToString(), ct: cancellationToken);

        if (!result.Success)
            throw new ApplicationException("Response from binance is not success");

        var data = result.Data.FirstOrDefault();
        
        if (data is null)
            throw new ApplicationException($"There aren't any data from binance about pair: {pair.ToString()}");

        return new MinMaxModel(pair, data.LowPrice, data.HighPrice, data.OpenTime, data.PriceChangePercent);
    }
}