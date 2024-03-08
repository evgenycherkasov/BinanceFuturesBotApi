namespace BinanceFuturesBotApi.ApplicationCore.DomainModels.Models;

public record MinMaxModel(PairName PairName, decimal LowPrice, decimal HighPrice, DateTime parsingDate, decimal PriceChangePercent);
