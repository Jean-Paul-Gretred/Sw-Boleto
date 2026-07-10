using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwBoleto.Models
{
    public class RespCancelar
    {
        public string numeroContratoCobranca { get; set; }
        public string dataBaixa { get; set; }
        public string horarioBaixa { get; set; }
    }
}
