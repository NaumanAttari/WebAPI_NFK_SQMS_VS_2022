using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models.MasterInfo
{
    public class tblSQMS_EndLine_Bundle_Cards
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
        public string Floor { get; set; }
        public string ProdLineNo { get; set; }
        public string CBNo { get; set; }
        public string OrderID { get; set; }
        public string OrderName { get; set; }
        public string BuyerPONo { get; set; }
        public string StyleNo { get; set; }
        public string Color { get; set; }
        public string OurLot { get; set; }
        public string DyeLot { get; set; }
        public string Size { get; set; }
        public string BundleNo { get; set; }
        public string BundleQty { get; set; }
    }
}
