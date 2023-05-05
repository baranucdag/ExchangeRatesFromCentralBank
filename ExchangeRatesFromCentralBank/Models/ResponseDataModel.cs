namespace ExchangeRatesFromCentralBank.Models
{
    public class ResponseDataModel
    {
        public List<ExchangeRateModel> Data { get; set; }
        public string Error { get; set; }
    }
}
