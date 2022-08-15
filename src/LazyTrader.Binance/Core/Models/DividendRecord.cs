namespace LazyTrader.Binance.Core.Models;

public record DividendRecord(
	[property:JsonProperty("total")] int Total,
	[property:JsonProperty("rows")] IReadOnlyList<DividendRecordRow> Rows
); 