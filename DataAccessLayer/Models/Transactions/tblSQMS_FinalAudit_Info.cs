using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataAccessLayer.Models.Transactions
{
    public class tblSQMS_FinalAudit_Info
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
        public string Floor { get; set; }
        public string ProdLineNo { get; set; }
        public string QCCardNo { get; set; }
        public string QCName { get; set; }
        public string OrderID { get; set; }
        public string OrderName { get; set; }
        public string BuyerPONo { get; set; }
        public string StyleNo { get; set; }
        public string Color { get; set; }
        public string PrintName { get; set; }
        public string PrintTeam { get; set; }
        public string Sizes { get; set; }
        public string PcsRange { get; set; }
        public string AQL { get; set; }
        public string SelectedPcs { get; set; }
        public string AQLMinorPcs { get; set; }
        public string AQLMajorPcs { get; set; }
        public string MinorPcs { get; set; }
        public string MajorPcs { get; set; }
        public string AuditStatus { get; set; }
        public string InternalAuditSection { get; set; }
        public string MasterAudit { get; set; }


    }
}
