using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StockApp.models
{
    public class BoxModel
    {
        public Guid id { get; set; }
        public int depth { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public int weight { get; set; }

        [JsonIgnore]
        public int volume
        {
            get
            {
                return depth * height * width;
            }
        }

        private DateTime? expirationDateContainer;
        public  DateTime? expirationDate
        {
            get 
            { 
                if (expirationDateContainer == null)
                {
                    return dateOfProduction.AddDays(100);
                }
                return expirationDateContainer; 
            }
            set
            {
                expirationDateContainer = value;
            }
        }
        public DateTime dateOfProduction;
    }
}
