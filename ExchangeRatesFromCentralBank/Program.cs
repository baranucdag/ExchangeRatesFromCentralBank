using ExchangeRatesFromCentralBank.Models;
using ExchangeRatesFromCentralBank.Service;

RequestDataModel requestModel= new RequestDataModel();
requestModel.Day = 0;
requestModel.Month= 0;
requestModel.Year= 0;
requestModel.IsToday = true;

ExchangeRateService service = new ExchangeRateService();
var datas = service.GetDataFromCentralBank(requestModel);

foreach (var item in datas.Data)
{
    Console.WriteLine($"Adı: {item.Name}, Kod:{item.Code}, Alış Kuru:{item.BuyingRate}, Satış Kuru:{item.SalesRate}");
}

Console.ReadLine();