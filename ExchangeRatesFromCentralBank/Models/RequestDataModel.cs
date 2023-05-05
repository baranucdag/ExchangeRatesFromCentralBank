namespace ExchangeRatesFromCentralBank.Models
{
    public class RequestDataModel
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public bool IsToday { get; set; }
    }
}
