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
        public Guid Id { get; set; }
        public int Depth { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public virtual int Weight { get; set; }

        [JsonIgnore]
        public virtual int Volume
        {
            get
            {
                return Depth * Height * Width;
            }
        }

        private DateTime? expirationDate;
        public virtual DateTime? ExpirationDate
        {
            get 
            { 
                if (expirationDate == null)
                {
                    return DateOfProduction.AddDays(100);
                }
                return expirationDate; 
            }
            set
            {
                expirationDate = value;
            }
        }
        public virtual DateTime DateOfProduction { get; set; }
    }
}
