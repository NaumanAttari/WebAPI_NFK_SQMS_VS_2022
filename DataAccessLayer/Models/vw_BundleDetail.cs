using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class vw_BundleDetail
    {
        public string CBNo { get; set; }
        public string Floor { get; set; }
        public string ProdLineNo { get; set; }
        public string OrderID { get; set; }
        public string OrderName { get; set; }
        public string BuyerPONo { get; set; }
        public string Color { get; set; }
        public string StyleNo { get; set; }
        public string OurLot { get; set; }
        public string DyeLot { get; set; }
        public string Size { get; set; }
        public string BundleNo { get; set; }
        public string BundleQty { get; set; }
        public bool BundleClosed { get; set; }
        public bool FinalCheckBundleClosed { get; set; }
        public string FreshPCS { get; set; }
        public string FaultyPCS { get; set; }
        public string FaultyPCSOnRework { get; set; }
        public string PCSOnRework { get; set; }
        public string FreshPCSOnRework { get; set; }
        public string RejectedPCS { get; set; }
        public string RejectedPCSOnRework { get; set; }

        public long EndlineInfo_ID { get; set; }



    }
}
