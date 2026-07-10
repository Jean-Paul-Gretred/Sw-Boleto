using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwBoleto.Models
{
    [Table("T_BOLETO_PR")]
    public class T_BOLETO_PR
    {
        public string CL_COD { get; set; }
        public string CR_COD { get; set; }
        public DateTime PR_DAT_VEN { get; set; }
        public string CC_NUMERO { get; set; }
        public Decimal PR_VALOR_PARC { get; set; }
        public string BO_NUM_TITULO_CLIENTE { get; set; }
        public string BO_STATUS { get; set; }
        public DateTime BO_DAT_HORA { get; set; }
        public string BO_COD_SOLICITAÇÃO { get; set; }
    }
}
