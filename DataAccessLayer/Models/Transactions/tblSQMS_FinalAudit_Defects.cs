using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace DataAccessLayer.Models.Transactions
{
    public class tblSQMS_FinalAudit_Defects
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
        public long MasterId { get; set; }
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
        public string FinalAuditFaults { get; set; }         
        public string MinorPcs { get; set; }
        public string MajorPcs { get; set; }
        public string FaultImageLink { get; set; }

    }
}
