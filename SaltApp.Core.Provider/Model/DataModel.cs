using System.Collections.Generic;

namespace SaltApp.Core.Provider.Model
{
    public class DataModel
    {
        public DataModel()
        {
            this.VoiceCollection = new List<KeyValuePair<string, string>>();
            this.DataCollection = new List<KeyValuePair<string, string>>();
            this.SMSCollection = new List<KeyValuePair<string, string>>();
        }
        public string TotalAmount { get; set; }
        public string ExpirationDateTotalAmount { get; set; }

        public double VoiceUsage { get; set; }
        public double DataUsage { get; set; }
        public double SMSUsage { get; set; }

        public List<KeyValuePair<string, string>> VoiceCollection { get; set; }
        public List<KeyValuePair<string, string>> DataCollection { get; set; }
        public List<KeyValuePair<string, string>> SMSCollection { get; set; }
    }
}
