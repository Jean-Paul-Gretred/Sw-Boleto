using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwBoleto.Models
{
    internal class RespBoleto
    {
            public string numero { get; set; }
            public int numeroCarteira { get; set; }
            public int numeroVariacaoCarteira { get; set; }
            public int codigoCliente { get; set; }
            public string linhaDigitavel { get; set; }
            public string codigoBarraNumerico { get; set; }
            public int numeroContratoCobranca { get; set; }
            public Beneficiario beneficiario { get; set; }
            public Qrcode qrCode { get; set; }
        }

        public class Beneficiario
        {
            public int agencia { get; set; }
            public int contaCorrente { get; set; }
            public int tipoEndereco { get; set; }
            public string logradouro { get; set; }
            public string bairro { get; set; }
            public string cidade { get; set; }
            public int codigoCidade { get; set; }
            public string uf { get; set; }
            public int cep { get; set; }
            public string indicadorComprovacao { get; set; }
        }

        public class Qrcode
        {
            public string url { get; set; }
            public string txId { get; set; }
            public string emv { get; set; }
        }

    
}
