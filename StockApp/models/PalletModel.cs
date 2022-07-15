using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StockApp.models
{
    public class PalletModel : BoxModel
    {

        public DateTime expirationDate
        {
            get { return (DateTime)boxs.Min(a => a.expirationDate); }
        }

        public int weight
        {
            get
            {
                return boxs.Sum(p => p.weight) + 30;
            }
        }

        public int volume
        {
            get
            {
                return (depth * height * width) + boxs.Sum(p => p.volume);
            }
        }

        public DateTime? dateOfProduction;

        public List<BoxModel> boxs { get; set; }
    }
}
