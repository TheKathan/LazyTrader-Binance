namespace LazyTrader.Binance.Core.Models;

public record TriggerCondition(
	[property:JsonProperty("GCR")] int Gcr,
	[property:JsonProperty("IFER")] int Ifer,
	[property:JsonProperty("UFR")] int Ufr
); 