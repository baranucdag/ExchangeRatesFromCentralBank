namespace ExchangeRatesFromCentralBank.Models
{
    public class ExchangeRateModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Currency { get; set; }
        public decimal BuyingRate { get; set; }
        public decimal SalesRate { get; set; }
        public decimal EfectiveBuyingRate { get; set; }
        public decimal EfectiveSalesRate { get; set; }
    }
}
