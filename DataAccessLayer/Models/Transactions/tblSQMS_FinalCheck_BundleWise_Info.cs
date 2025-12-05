using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models.Transactions
{
    public class tblSQMS_FinalCheck_BundleWise_Info
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        public string Floor { get; set; }

        public string ProdLineNo { get; set; }

        public string QCCardNo { get; set; }

        public string QCName { get; set; }

        public string CBNo { get; set; }

        public string Size { get; set; }

        public string BundleNo { get; set; }

        public string BundleQty { get; set; }

        public string FreshPCS { get; set; }
        public string ActualFreshPCS { get; set; }

        public string RejectedPCS { get; set; }
        public string AlterPCS { get; set; }

        public string FaultyPCS { get; set; }

        public string PCSOnRework { get; set; }

        public string FreshPCSOnRework { get; set; }

        public string RejectedPCSOnRework { get; set; }

        public string FaultyPCSOnRework { get; set; }
        public string RecoverAlterPCS { get; set; }
        public string RecoverRejectPCS { get; set; }
        public bool BundleClosed { get; set; }


    }
}
