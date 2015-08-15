
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class SimpleTradeMapper : ITradeMapper
    {
        public TradeRecord Map(string[] fields)
        {
            var sourceCurrencyCode = fields[0].Substring(0, 3);
            var destinationCurrencyCode = fields[0].Substring(3, 3);
            var tradeAmount = int.Parse(fields[1]);
            var tradePrice = decimal.Parse(fields[2]);

            var trade = new TradeRecord
            {
                SourceCurrency = sourceCurrencyCode,
                DestinationCurrency = destinationCurrencyCode,
                Lots = tradeAmount / LotSize,
                Price = tradePrice
            };

            return trade;
        }

        private static float LotSize = 100000f;
    }

	public class LoggingTradeMapper : ITradeMapper
	{
		private readonly ITradeMapper _tradeMapper;
		private readonly ILogger _logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:System.Object"/> class.
		/// </summary>
		public LoggingTradeMapper(ITradeMapper tradeMapper, ILogger logger)
		{
			_tradeMapper = tradeMapper;
			_logger = logger;
		}

		public TradeRecord Map(string[] fields)
		{
			foreach (var field in fields)
			{
				_logger.LogInfo(field);				
			}
			return _tradeMapper.Map(fields);
		}
	}
}
