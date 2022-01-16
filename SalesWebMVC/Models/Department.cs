using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {

        }
        public Department(string name)
        {
            Name = name;
        }

        public void AddSales(Seller sl)
        {
            Sellers.Add(sl);
        }

        public double TotalSales(DateTime dtStart, DateTime dtEnd)
        {
            double totalSales = Sellers.Sum(x => x.TotalSales(dtStart, dtEnd));

            return totalSales;
        }
    }
}
