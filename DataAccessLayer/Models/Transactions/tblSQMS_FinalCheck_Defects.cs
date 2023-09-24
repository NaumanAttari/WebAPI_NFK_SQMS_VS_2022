using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace DataAccessLayer.Models.Transactions
{
    public class tblSQMS_FinalCheck_Defects
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
        public string Floor { get; set; }
        public string QCCardNo { get; set; }
        public string QCName { get; set; }
        public string OrderID { get; set; }
        public string OrderName { get; set; }
        public string BuyerPONo { get; set; }
        public string StyleNo { get; set; }
        public string Color { get; set; }
        public string PrintName { get; set; }
        public string PrintTeam { get; set; }
        public string FinalCheckFaults { get; set; }         
        public string FaultRejectedPCS { get; set; }

    }
}
