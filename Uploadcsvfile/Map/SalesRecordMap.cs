using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uploadcsvfile.Model;

namespace Uploadcsvfile.Map
{
    public sealed class SalesRecordMap : ClassMap<SalesRecord>
    {
        public SalesRecordMap()
        {
            Map(x => x.Country).Name("Country");
            Map(x => x.ItemType).Name("Item Type");
            Map(x => x.Region).Name("Region");
            Map(x => x.SalesChannel).Name("Sales Channel");
            Map(x => x.OrderPriority).Name("Order Priority");
            Map(x => x.OrderDate).Name("Order Date");
            Map(x => x.OrderID).Name("Order ID");
            Map(x => x.ShipDate).Name("Ship Date");
            Map(x => x.UnitsSold).Name("Units Sold");
            Map(x => x.OrderDate).Name("Unit Price");
            Map(x => x.UnitCost).Name("Unit Cost");
            Map(x => x.ShipDate).Name("Total Revenue");
            Map(x => x.TotalCost).Name("Total Cost");
            Map(x => x.TotalProfit).Name("Total Profit");
           

        }
    }
}
