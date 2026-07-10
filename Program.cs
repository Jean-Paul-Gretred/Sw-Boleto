using Microsoft.Data.SqlClient;

namespace SwBoleto
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static string Nome_BD_PRODUÇÃO;
        public static string Usuario_BD;
        public static string Senha_BD;
        public static string Servidor_BD;
        public static string NomeEmpresa;
        static public string gsEM_CNPJ;
        static public string gsEM_CNPJ_FORMATADO;
        static public string gsEM_RAZ_SOCIAL;
        static public string gsEM_COD;
        static public string gsUsuario;
        static public string Ambiente;
        static public string banco = Properties.Settings.Default.Banco;
        static public string certificadoCaminho = Properties.Settings.Default.CaminhoCertificado;
        static public string certificadoSenha = Properties.Settings.Default.SenhaCertificado;
        public static ConexaoSQL Conn = new ConexaoSQL();
        static public SqlConnection SqlConnection;
        public static Dictionary<int, string> Dicionario_Status = new Dictionary<int, string>()
                    {
                        {1, "ENVIADO"},
                        {2, "MOVIMENTO CARTORIO"},
                        {3, "EM CARTORIO"},
                        {4, "TITULO COM OCORRENCIA DE CARTORIO"},
                        {5, "PROTESTADO ELETRONICO"},
                        {6, "LIQUIDADO"},
                        {7, "BAIXADO"},
                        {8, "TITULO COM PENDENCIA DE CARTORIO"},
                        {9, "TITULO PROTESTADO MANUAL"},
                        {10, "TITULO BAIXADO/PAGO EM CARTORIO"},
                        {11, "TITULO LIQUIDADO/PROTESTADO"},
                        {12, "TITULO LIQUID/PGCRTO"},
                        {13, "TITULO PROTESTADO AGUARDANDO BAIXA"},
                        {14, "TITULO EM LIQUIDACAO"},
                        {15, "TITULO AGENDADO"},
                        {16, "TITULO CREDITADO"},
                        {17, "PAGO EM CHEQUE - AGUARD.LIQUIDACAO"},
                        {18, "PAGO PARCIALMENTE"},
                        {19, "PAGO PARCIALMENTE CREDITADO"},
                        {21, "TITULO AGENDADO COMPE"},
                        
                    };
        [STAThread]
        
        static void Main()
        {
            SqlConnection = Conn.conectar();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            string sSql = "";
            gsEM_COD = "1";
            Nome_BD_PRODUÇÃO = Properties.Settings.Default.Nome_BD_PRODUÇÃO;
            Usuario_BD = Properties.Settings.Default.Usuario_BD;
            Senha_BD = Properties.Settings.Default.Senha_BD;
            Servidor_BD = Properties.Settings.Default.Servidor_BD;
            Ambiente = Properties.Settings.Default.Ambiente;
            try
            {
                sSql = "SELECT EM_CGC = dbo.fn_SoNumero(EM_CGC),";
                sSql += " EM_CGC_FORMATADO = EM_CGC, EM_RAZ_SOCIAL";
                sSql += " FROM T_EMPRESA";
                sSql += " WHERE EM_COD = '" + gsEM_COD + "'";
                cmd.CommandText = sSql;
                cmd.Connection = SqlConnection;
                dr = cmd.ExecuteReader();
                dr.Read();
                gsEM_CNPJ = (string)dr["EM_CGC"];
                gsEM_CNPJ_FORMATADO = (string)dr["EM_CGC_FORMATADO"];
                gsEM_RAZ_SOCIAL = (string)dr["EM_RAZ_SOCIAL"];
                dr.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Não foi possível executar o comando sql:\r\r" + sSql + "\r\r" + ex.Message,
                                "SwErro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                System.Threading.Thread.CurrentThread.Abort();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Favor checar os valores cadastrados na tabela T_EMPRESA\r\r" + ex.Message + "\r",
                                "SwErro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                System.Threading.Thread.CurrentThread.Abort();
            }
            // Pegar PS = Nome da empresa cliente
            ////////////////////////////////////////////////////////////////
            sSql = "SELECT PS_VALOR = ISNULL(PS_VALOR,'')";
            sSql += " FROM T_PARAMETROS_SISTEMA";
            sSql += " WHERE PS_COD = '997'";
            cmd.CommandText = sSql;
            cmd.Connection = SqlConnection;
            dr = cmd.ExecuteReader();
            dr.Read();
            NomeEmpresa = (string)dr[0];
            dr.Close();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();
            Application.Run(new GerenciarBoletos());
        }
    }
}