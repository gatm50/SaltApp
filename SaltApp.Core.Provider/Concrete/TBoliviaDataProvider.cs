using Newtonsoft.Json;
using SaltApp.Core.Provider.Interfaces;
using SaltApp.Core.Provider.Model.Providers;
using SaltApp.Core.Provider.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SaltApp.Core.Provider.Concrete
{
    public class TBoliviaDataProvider : IDataProvider
    {
        public string ResponseString { get; private set; }
        public async Task<HttpStatusCode> QueryServer(string accessToken, string telephoneNumber)
        {
            throw new NotImplementedException();
        }

        public DataModel ProcessResponse()
        {
            var jsonObject = JsonConvert.DeserializeObject<TBoliviaRootObject>(this.ResponseString);
            var response = this.ProcessElement(jsonObject);
            return response;
        }

        private DataModel ProcessElement(TBoliviaRootObject jsonObject)
        {
            var response = new DataModel();

            foreach (var item in jsonObject.TigoApiResponse.response.wallets)
            {
                switch (item.ix)
                {
                    case "0":
                    case "4":
                    case "5":
                    case "10":
                    case "12":
                        response.SMSCollection.Add(this.ProcessMessagePackages(item));
                        response.SMSUsage += item.balanceAmount;
                        break;
                    case "1":
                    case "14":
                        response.VoiceCollection.Add(this.ProcessVoivePackages(item));
                        response.VoiceUsage += item.balanceAmount;
                        break;
                    case "6":
                    case "7":
                    case "9":
                    case "15":
                    case "17":
                        response.DataCollection.Add(this.ProcessDataPackages(item));
                        response.DataUsage += item.balanceAmount;
                        break;
                    case "11":
                        response.TotalAmount = string.Format("{0} {1}", item.balanceAmount, item.unit);
                        response.ExpirationDateTotalAmount = string.Format("{0}", DateTime.Parse(item.expirationDate)).ToUpperInvariant();
                        break;
                    default:
                        break;
                }
            }

            return response;
        }

        private KeyValuePair<string, string> ProcessDataPackages(Detail detail)
        {
            return new KeyValuePair<string, string>(
                detail.description, string.Format("{0} {1}",
                detail.balanceAmount.ToString(), detail.unit));
        }

        private KeyValuePair<string, string> ProcessVoivePackages(Detail detail)
        {
            return new KeyValuePair<string, string>(
                detail.description, string.Format("{0} {1}",
                detail.balanceAmount.ToString(), detail.unit));
        }

        private KeyValuePair<string, string> ProcessMessagePackages(Detail detail)
        {
            return new KeyValuePair<string, string>(
                detail.description, string.Format("{0} {1}",
                detail.balanceAmount.ToString(), detail.unit));
        }
    }
}
