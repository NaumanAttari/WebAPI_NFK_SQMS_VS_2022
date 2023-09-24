using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models.Transactions
{
    public class tblSQMS_Fault_Gen_Categ
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

        public string InitChkPoints { get; set; }

        public string FStatus { get; set; }

        public string SelColor { get; set; }

        public string QCCardNo { get; set; }

        public string QCName { get; set; }







    }
}
