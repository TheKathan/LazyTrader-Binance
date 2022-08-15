﻿namespace LazyTrader.Binance.Core.Enum;

public enum TransferType
{
	MAIN_UMFUTURE,
	MAIN_CMFUTURE,
	MAIN_MARGIN,
	UMFUTURE_MAIN,
	UMFUTURE_MARGIN,
	CMFUTURE_MAIN,
	CMFUTURE_MARGIN,
	MARGIN_MAIN,
	MARGIN_UMFUTURE,
	MARGIN_CMFUTURE,
	ISOLATEDMARGIN_MARGIN,
	MARGIN_ISOLATEDMARGIN,
	ISOLATEDMARGIN_ISOLATEDMARGIN,
	MAIN_FUNDING,
	FUNDING_MAIN,
	FUNDING_UMFUTURE,
	UMFUTURE_FUNDING,
	MARGIN_FUNDING,
	FUNDING_MARGIN,
	FUNDING_CMFUTURE,
	CMFUTURE_FUNDING
}