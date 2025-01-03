using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class vw_CB_Detail
    {
        public string CBNo { get; set; }
        public string OrderID { get; set; }
        public string OrderName { get; set; }
        public string BuyerPO { get; set; }
        public string Style { get; set; }
        public string Color { get; set; }
        public string ourLot { get; set; }
        public string dyeLot { get; set; }
        public string Size { get; set; }
        public string BundleNo { get; set; }
        public string BundleQty { get; set; }
        public string LocationId { get; set; }

    }
}
