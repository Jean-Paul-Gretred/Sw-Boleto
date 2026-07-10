using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwBoleto.Models
{
    class RespConsulta_Inter
    {
        
            public Cobranca cobranca { get; set; }
            public Boleto boleto { get; set; }
            public Pix pix { get; set; }
        

        public class Cobranca
        {
            public string seuNumero { get; set; }
            public string dataEmissao { get; set; }
            public string dataVencimento { get; set; }
            public float valorNominal { get; set; }
            public string tipoCobranca { get; set; }
            public string situacao { get; set; }
            public string dataSituacao { get; set; }
            public bool arquivada { get; set; }
            public Desconto[] descontos { get; set; }
            public Multa multa { get; set; }
            public Mora mora { get; set; }
            public Pagador pagador { get; set; }
        }

        public class Multa
        {
            public string codigo { get; set; }
            public float taxa { get; set; }
        }

        public class Mora
        {
            public string codigo { get; set; }
            public float taxa { get; set; }
        }

        public class Pagador
        {
            public string cpfCnpj { get; set; }
            public string tipoPessoa { get; set; }
            public string nome { get; set; }
            public string endereco { get; set; }
            public string bairro { get; set; }
            public string cidade { get; set; }
            public string uf { get; set; }
            public string cep { get; set; }
            public string email { get; set; }
            public string numero { get; set; }
            public string complemento { get; set; }
        }

        public class Desconto
        {
            public string codigo { get; set; }
            public int quantidadeDias { get; set; }
        }

        public class Boleto
        {
            public string nossoNumero { get; set; }
            public string codigoBarras { get; set; }
            public string linhaDigitavel { get; set; }
        }

        public class Pix
        {
            public string txid { get; set; }
            public string pixCopiaECola { get; set; }
        }

    }
}
