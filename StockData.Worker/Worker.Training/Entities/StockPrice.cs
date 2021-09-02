using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker.Data;
//StockPrice (Id, CompanyId, LastTradingPrice, High, Low, ClosePrice,
//YesterdayClosePrice, Change, Trade, Value, Volume)

namespace Worker.Training.Entities
{
  public  class StockPrice : IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public double LastTradingPrice { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double ClosePrice { get; set; }
        public double YesterdayClosePrice { get; set; }
        public double Change { get; set; }

        public int Trade { get; set; }
        public double Value { get; set; }
        public int Volume { get; set; }



    }
}
