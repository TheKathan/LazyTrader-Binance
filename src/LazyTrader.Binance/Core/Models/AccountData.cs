namespace LazyTrader.Binance.Core.Models;

public record AccountData(
	[property:JsonProperty("isLocked")] bool isLocked,
	[property:JsonProperty("plannedRecoverTime")] int plannedRecoverTime,
	[property:JsonProperty("triggerCondition")] TriggerCondition triggerCondition,
	[property:JsonProperty("updateTime")] string updateTime
); 