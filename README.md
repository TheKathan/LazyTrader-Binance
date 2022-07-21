[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![License][license-shield]][license-url]

## About The Project

This is my solution to integrate Binance API using .NET Core 6.

## Getting Started

### Prerequisites

* Get a binance api key and secret. [Get your own](https://www.binance.com/en/binance-api)

## Usage

Just reference this to your project and you will be able to use the Binance API.

Add the following to your appsettings.config:

```
"Binance": {
    "Key": "binance-api-key",
    "Secret": "binance-api-secret",
    "RecvWindow": 10000
  },
"LazyTrader" : {
    "ThrottleSleepTime": 10000,
    "TradableAssets" : "BTC;ETH;TRX"
  }
```

And then with the following code:

```
builder.Services.AddBinance();
```

You are go to go, for example Spot:

```
private readonly Spot _spot;

public SpotController(Spot spot)
{
    _spot = spot;
}

[AllowAnonymous, HttpGet("account")]
public async Task<IActionResult> Account()
{
    var result = await _spot.GetAccount();
    return Ok(result);
}
```

of for Market:

```
private readonly Market _market;

public MarketController(Market market)
{
    _market = market;
}

[AllowAnonymous, HttpGet("exchangeInfo")]
public async Task<IActionResult> ExchangeInfo(string? symbol, List<string>? symbolsList)
{
    var result = await _market.GetExchangeInfo(symbol, symbolsList);
    return Ok(result);
}
```

See the [open issues](https://github.com/TheKathan/LazyTrader-Binance/issues) for a full list of proposed features (and known issues).

## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

Distributed under the GNU GPLv3 License. See `LICENSE` for more information.

## Contact

Gonçalo Faria - [@TheKathan](https://twitter.com/TheKathan) - gonacfaria@gmail.com

[![LinkedIn][linkedin-shield]][linkedin-url]

Project Link: [https://github.com/TheKathan/LazyTrader-Binance](https://github.com/TheKathan/LazyTrader-Binance)

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/TheKathan/LazyTrader-Binance.svg?style=flat
[contributors-url]: https://github.com/TheKathan/LazyTrader-Binance/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/TheKathan/LazyTrader-Binance.svg?style=flat
[forks-url]: https://github.com/TheKathan/LazyTrader-Binance/network/members
[stars-shield]: https://img.shields.io/github/stars/TheKathan/LazyTrader-Binance.svg?style=flat
[stars-url]: https://github.com/TheKathan/LazyTrader-Binance/stargazers
[issues-shield]: https://img.shields.io/github/issues/TheKathan/LazyTrader-Binance.svg?style=flat
[issues-url]: https://github.com/TheKathan/LazyTrader-Binance/issues
[license-shield]: https://img.shields.io/github/license/TheKathan/LazyTrader-Binance.svg?style=flat
[license-url]: https://github.com/TheKathan/LazyTrader-Binance/blob/master/LICENSE
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=flat&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/gfaria
[product-screenshot]: images/screenshot.png