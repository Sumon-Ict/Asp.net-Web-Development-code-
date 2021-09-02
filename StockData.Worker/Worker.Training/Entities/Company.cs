using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker.Data;

namespace Worker.Training.Entities
{
   public  class Company : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public int TradeCode { get; set;}
        public ICollection<StockPrice> StockPrices { get; set; }





    }
}
