using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwBoleto.Models
{
    public class RespConsultaBoleto
    {
        public string codigoLinhaDigitavel { get; set; }
        public string textoEmailPagador { get; set; }
        public string textoMensagemBloquetoTitulo { get; set; }
        public int codigoTipoMulta { get; set; }
        public int codigoCanalPagamento { get; set; }
        public int numeroContratoCobranca { get; set; }
        public int codigoTipoInscricaoSacado { get; set; }
        public float numeroInscricaoSacadoCobranca { get; set; }
        public int codigoEstadoTituloCobranca { get; set; }
        public int codigoTipoTituloCobranca { get; set; }
        public int codigoModalidadeTitulo { get; set; }
        public string codigoAceiteTituloCobranca { get; set; }
        public int codigoPrefixoDependenciaCobrador { get; set; }
        public int codigoIndicadorEconomico { get; set; }
        public string numeroTituloCedenteCobranca { get; set; }
        public int codigoTipoJuroMora { get; set; }
        public string dataEmissaoTituloCobranca { get; set; }
        public string dataRegistroTituloCobranca { get; set; }
        public string dataVencimentoTituloCobranca { get; set; }
        public Decimal valorOriginalTituloCobranca { get; set; }
        public Decimal valorAtualTituloCobranca { get; set; }
        public Decimal valorPagamentoParcialTitulo { get; set; }
        public Decimal valorAbatimentoTituloCobranca { get; set; }
        public Decimal percentualImpostoSobreOprFinanceirasTituloCobranca { get; set; }
        public Decimal valorImpostoSobreOprFinanceirasTituloCobranca { get; set; }
        public Decimal valorMoedaTituloCobranca { get; set; }
        public Decimal percentualJuroMoraTitulo { get; set; }
        public Decimal valorJuroMoraTitulo { get; set; }
        public Decimal percentualMultaTitulo { get; set; }
        public Decimal valorMultaTituloCobranca { get; set; }
        public int quantidadeParcelaTituloCobranca { get; set; }
        public string dataBaixaAutomaticoTitulo { get; set; }
        public string textoCampoUtilizacaoCedente { get; set; }
        public string indicadorCobrancaPartilhadoTitulo { get; set; }
        public string nomeSacadoCobranca { get; set; }
        public string textoEnderecoSacadoCobranca { get; set; }
        public string nomeBairroSacadoCobranca { get; set; }
        public string nomeMunicipioSacadoCobranca { get; set; }
        public string siglaUnidadeFederacaoSacadoCobranca { get; set; }
        public int numeroCepSacadoCobranca { get; set; }
        public Decimal valorMoedaAbatimentoTitulo { get; set; }
        public string dataProtestoTituloCobranca { get; set; }
        public int codigoTipoInscricaoSacador { get; set; }
        public int numeroInscricaoSacadorAvalista { get; set; }
        public string nomeSacadorAvalistaTitulo { get; set; }
        public Decimal percentualDescontoTitulo { get; set; }
        public string dataDescontoTitulo { get; set; }
        public Decimal valorDescontoTitulo { get; set; }
        public int codigoDescontoTitulo { get; set; }
        public Decimal percentualSegundoDescontoTitulo { get; set; }
        public string dataSegundoDescontoTitulo { get; set; }
        public Decimal valorSegundoDescontoTitulo { get; set; }
        public int codigoSegundoDescontoTitulo { get; set; }
        public Decimal percentualTerceiroDescontoTitulo { get; set; }
        public string dataTerceiroDescontoTitulo { get; set; }
        public Decimal valorTerceiroDescontoTitulo { get; set; }
        public int codigoTerceiroDescontoTitulo { get; set; }
        public string dataMultaTitulo { get; set; }
        public int numeroCarteiraCobranca { get; set; }
        public int numeroVariacaoCarteiraCobranca { get; set; }
        public int quantidadeDiaProtesto { get; set; }
        public int quantidadeDiaPrazoLimiteRecebimento { get; set; }
        public string dataLimiteRecebimentoTitulo { get; set; }
        public string indicadorPermissaoRecebimentoParcial { get; set; }
        public string textoCodigoBarrasTituloCobranca { get; set; }
        public int codigoOcorrenciaCartorio { get; set; }
        public Decimal valorImpostoSobreOprFinanceirasRecebidoTitulo { get; set; }
        public Decimal valorAbatimentoTotal { get; set; }
        public Decimal valorJuroMoraRecebido { get; set; }
        public Decimal valorDescontoUtilizado { get; set; }
        public Decimal valorPagoSacado { get; set; }
        public Decimal valorCreditoCedente { get; set; }
        public int codigoTipoLiquidacao { get; set; }
        public string dataCreditoLiquidacao { get; set; }
        public string dataRecebimentoTitulo { get; set; }
        public int codigoPrefixoDependenciaRecebedor { get; set; }
        public int codigoNaturezaRecebimento { get; set; }
        public string numeroIdentidadeSacadoTituloCobranca { get; set; }
        public string codigoResponsavelAtualizacao { get; set; }
        public int codigoTipoBaixaTitulo { get; set; }
        public Decimal valorMultaRecebido { get; set; }
        public Decimal valorReajuste { get; set; }
        public Decimal valorOutroRecebido { get; set; }
        public int codigoIndicadorEconomicoUtilizadoInadimplencia { get; set; }
    }

    

}


