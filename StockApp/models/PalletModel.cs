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

        public PalletModel()
        {
            Boxes = new List<BoxModel>();
        }

        public override DateTime? ExpirationDate
        {
            get { return (DateTime)Boxes.Min(a => a.ExpirationDate); }
        }

        public override int Weight
        {
            get
            {
                return Boxes.Sum(p => p.Weight) + 30;
            }
        }

        public override int Volume
        {
            get
            {
                return (Depth * Height * Width) + Boxes.Sum(p => p.Volume);
            }
        }

        public DateTime? dateOfProduction;

        public List<BoxModel> Boxes { get; set; }
    }
}
