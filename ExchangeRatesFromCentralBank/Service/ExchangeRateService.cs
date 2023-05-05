using ExchangeRatesFromCentralBank.Models;
using System.Xml;

namespace ExchangeRatesFromCentralBank.Service
{
    public class ExchangeRateService
    {
        public ResponseDataModel GetDataFromCentralBank(RequestDataModel model)
        {
            ResponseDataModel result = new ResponseDataModel();
            

            string cbLink = string.Format("https://www.tcmb.gov.tr/kurlar/{0}.xml",
                (model.IsToday) ? "today" : string.Format("{2}{1}/{0}{1}{2}",
                model.Day.ToString().PadLeft(2, '0'), model.Month.ToString().PadLeft(2, '0'), model.Year
                ));

            result.Data = new List<ExchangeRateModel>();
            XmlDocument doc = new XmlDocument();
            doc.Load(cbLink);

            if (doc.SelectNodes("Tarih_Date").Count < 1)
            {
                result.Error = "Kur bilgisi bulunamadı.";
                return result;
            }

            foreach (XmlNode node in doc.SelectNodes("Tarih_Date")[0].ChildNodes)
            {
                ExchangeRateModel rate = new ExchangeRateModel();

                rate.Code = node.Attributes["Kod"].Value;
                rate.Name = node["Isim"].InnerText;
                rate.Currency = int.Parse(node["Unit"].InnerText);
                rate.BuyingRate = Convert.ToDecimal("0" + node["ForexBuying"].InnerText.Replace(".", ","));
                rate.SalesRate = Convert.ToDecimal("0" + node["ForexSelling"].InnerText.Replace(".", ","));
                rate.EfectiveBuyingRate = Convert.ToDecimal("0" + node["BanknoteBuying"].InnerText.Replace(".", ","));
                rate.EfectiveSalesRate= Convert.ToDecimal("0" + node["BanknoteSelling"].InnerText.Replace(".", ","));

                result.Data.Add(rate);
            }

            return result;
        }
    }
}
