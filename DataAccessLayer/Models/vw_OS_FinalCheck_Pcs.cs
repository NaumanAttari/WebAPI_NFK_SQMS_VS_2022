using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class vw_OS_FinalCheck_Pcs
    {
        public string OrderID { get; set; }
        public string OrderName { get; set; }
        public string BuyerPONo { get; set; }
        public string Color { get; set; }
        public string StyleNo { get; set; }
        public string PrintName { get; set; }
        public string PrintTeam { get; set; }
        public long EndlinePcs { get; set; }
        public long CheckedPcs { get; set; }
        public long BalCheckPcs { get; set; }


    }
}
