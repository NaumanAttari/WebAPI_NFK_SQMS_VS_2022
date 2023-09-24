using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models.Transactions
{
    public class tblSQMS_InLine_Defects
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        public string Floor { get; set; }

        public string ProdLineNo { get; set; }

        public string Operation { get; set; }

        public string MachineNo { get; set; }

        public string Shifts { get; set; }

        public string CardNo { get; set; }

        public string OperatorName { get; set; }

        public string RoundNo { get; set; }

        public string InlineFaults { get; set; }

        public long DefectedPCS { get; set; }

        public string SelColor { get; set; }

        public string QCCardNo { get; set; }

        public string QCName { get; set; }

    }
}
