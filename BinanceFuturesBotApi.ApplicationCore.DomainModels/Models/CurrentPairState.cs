namespace BinanceFuturesBotApi.ApplicationCore.DomainModels.Models;

public record CurrentPairState(decimal CurrentPrice, PairName PairName, DateTime CurrentDate);