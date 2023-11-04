using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_1.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $"{ProductId};{ProductName};{Price};{IsActive}";
        }
    }
}
