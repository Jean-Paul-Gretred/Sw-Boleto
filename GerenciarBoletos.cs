using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using SwBoleto.API;
using SwBoleto.Models;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SwBoleto
{
    public partial class GerenciarBoletos : Form
    {
        public static ConexaoSQL Conn = new ConexaoSQL();
        static public SqlConnection SqlConnection;
        public string sSql;
        public string _sSql;
        public string sOrderBy;
        DateTime dtaux;
        public GerenciarBoletos()
        {
            InitializeComponent();
            cbx_situacao.Items.Clear();
            cbx_situacao.Items.Add("ENVIADO");
            cbx_situacao.Items.Add("A_RECEBER");
            cbx_situacao.Items.Add("LIQUIDADO");
            cbx_situacao.Items.Add("RECEBIDO");
            cbx_situacao.Items.Add("BAIXADO");
            cbx_situacao.Items.Add("CANCELADO");
            cbx_situacao.Items.Add("TODOS");
            cbx_situacao.Items.Add("NÃO ENVIADO");
            checkedListBox1.SetItemChecked(0, true);


            SqlConnection = Conn.conectar();
            sSql = "SELECT [MOD] = dbo.fn_CInt(TV_COD)"
                 + ",COD = dbo.fn_CInt(VA_COD)"
                 + ",CL_COD = dbo.fn_CInt(TPR.CL_COD)"
                 + ",CL_RAZ_SOCIAL"
                 + ",TVA.CC_NUMERO"
                 //+ ",TCC.BA_COD"
                 + ",BA_NOME"
                 + ",TVA.VA_DATA "
                 + ",TPR.PR_DAT_VEN"
                 //+ ",TPR.FP_COD"
                 + ",TPR.PR_VALOR_PARC"
                 + ",ER_VALOR"
                 + ",ER_DAT_PAG"
                 + ",BO_STATUS = IIF(ER_DAT_PAG IS NOT NULL,'LIQUIDADO',BO_STATUS) "
                 + "FROM T_PARCELA_RECEBER AS TPR "
                 + "LEFT  JOIN T_BOLETO_PR AS TBO ON TPR.CL_COD = TBO.CL_COD  AND TPR.CR_COD = TBO.CR_COD  AND TPR.PR_DAT_VEN = TBO.PR_DAT_VEN "
                 + "LEFT  JOIN T_EXTRATO_RECEBER AS TER ON TPR.CL_COD = TER.CL_COD AND TPR.CR_COD = TER.CR_COD  AND TPR.PR_DAT_VEN = TER.PR_DAT_VEN "
                 + "INNER JOIN T_VENDA AS TVA ON TPR.CR_COD = TVA.TV_COD + TVA.VA_COD  "
                 + "INNER JOIN T_CLIENTE AS TCL ON TPR.CL_COD = TCL.CL_COD  "
                 + "INNER JOIN T_CONTA_CORRENTE AS TCC ON TVA.CC_NUMERO = TCC.CC_NUMERO  "
                 + "INNER JOIN T_BANCO AS TBA ON TCC.BA_COD = TBA.BA_COD "
                 + "WHERE TPR.FP_COD IN ('BO','FC') ";
            _sSql = sSql;
            
            //dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 9);
        }


        private void GerenciarBoletos_Load(object sender, EventArgs e)
        {
            lblEmpresa.Text = "Emitente: " + Program.gsEM_CNPJ_FORMATADO + " - " + Program.gsEM_RAZ_SOCIAL;



            statusStrip1.Items[0].Text = Program.NomeEmpresa + "   ";
            statusStrip1.Items[1].Text += "   ";
            statusStrip1.Items[2].Text = Program.Servidor_BD + "+" + Program.Nome_BD_PRODUÇÃO + "   ";
            //statusStrip1.Items[3].Text = Convert.ToDateTime(Program.gsDataHoraServidor).ToString().Substring(0,8) + "   "; // MLUCIO 28 10 2019
            statusStrip1.Items[3].Text = DateTime.Now.ToString("{dd/MM/yyyy}"); // MLUCIO 28 10 2019

            // MLUCIO 24 10 2022
            Form form = new FrmAcesso();
            //form.Show();
            form.ShowDialog();
            // FIM MLUCIO

            //statusStrip1.Items[3].Text = string.Format("{0:dd/MM/yy}", Convert.ToDateTime(Program.gsDataHoraServidor)) + "   ";
            //statusStrip1.Items[4].Text = "Usuario"; // 24 10 2022
            statusStrip1.Items[4].Text = Program.gsUsuario; // 24 10 2022

            bool aux = SwUtil.PermitirAcesso("Painel Boleto", Program.gsUsuario);
            if (aux)
            {

            }
            else
            {
                MessageBox.Show("Usuário sem permissão");
                this.Close();
            }
            txt_data_ini.Text = DateTime.Now.ToShortDateString();
            txt_data_fim.Text = DateTime.Now.ToShortDateString();
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            sSql = _sSql;
            if (txt_data_ini == null || txt_data_ini.Text.Length == 0)
            {
                MessageBox.Show("insira uma data de incio!");
            }
            else if (txt_data_fim == null || txt_data_fim.Text.Length == 0)
            {
                MessageBox.Show("insira uma data de fim!");
            }
            else
            {
                try
                {
                    if (checkedListBox1.GetItemChecked(0))
                    {
                        sSql += "AND TVA.VA_DATA BETWEEN '" + string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(txt_data_ini.Text))
                   + " 00:00:00' AND '" + string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(txt_data_fim.Text)) + " 23:59:59'";
                    }
                    else
                    {
                        sSql += "AND TPR.PR_DAT_VEN BETWEEN '" + string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(txt_data_ini.Text))
                    + " 00:00:00' AND '" + string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(txt_data_fim.Text)) + " 23:59:59'";
                        
                    }
                   
                    if(cbx_situacao.Text == "NÃO ENVIADO")
                    {
                        sSql += " AND BO_STATUS IS NULL AND ER_DAT_PAG IS NULL";
                    }
                    else if (cbx_situacao.Text == "ENVIADO")
                    {
                        sSql += " AND BO_STATUS = '" + cbx_situacao.Text.ToString() + "' ";
                    }
                    else if (cbx_situacao.Text == "BAIXADO")
                    {
                        sSql += " AND BO_STATUS = '" + cbx_situacao.Text.ToString() + "' ";
                    }
                    else if (cbx_situacao.Text == "CANCELADO")
                    {
                        sSql += " AND BO_STATUS = '" + cbx_situacao.Text.ToString() + "' ";
                    }
                    else if (cbx_situacao.Text == "LIQUIDADO")
                    {
                        sSql += " AND BO_STATUS = '" + cbx_situacao.Text.ToString() + "' ";
                    }
                    else if (cbx_situacao.Text == "RECEBIDO")
                    {
                        sSql += " AND BO_STATUS = '" + cbx_situacao.Text.ToString() + "' ";
                    }
                    else if (cbx_situacao.Text == "A_RECEBER")
                    {
                        sSql += " AND BO_STATUS = '" + cbx_situacao.Text.ToString() + "' ";
                    }
                    else { sSql += " "; }
                    if (checkedListBox1.GetItemChecked(0))
                    {
                        sOrderBy = "ORDER BY TVA.VA_DATA asc";
                    }
                    else
                    {
                        sOrderBy = "ORDER BY TPR.PR_DAT_VEN asc";
                    }
                    this.Cursor = Cursors.WaitCursor;
                    MontaGrid(sSql, sOrderBy);
                    //this.Cursor = Cursors.Default;
                }
                catch
                {
                    MessageBox.Show("Data incorreta!");

                }
            }

        }
        private void MontaGrid(string sSql, string sOrderBy)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            if (sOrderBy != "")
            {
                sSql = sSql + " " + sOrderBy;
            }
            
            cmd.CommandText = sSql;
            cmd.Connection = Program.SqlConnection;
            dr = cmd.ExecuteReader();
            
            MostraGrid(dr);

            dr.Close();



        }
        public void MostraGrid(SqlDataReader dr)
        {
            
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnHeadersHeight = 30;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            int iColunas = dr.FieldCount;
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = " ";
            checkBoxColumn.Name = "checkBoxColumn";

            dataGridView1.Columns.Insert(0, checkBoxColumn);
            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;
            dataGridView1.Columns[0].Width = 50;


            for (int i = 0; i < iColunas; i++)
            {


                dataGridView1.Columns.Add(dr.GetName(i).ToString(), dr.GetName(i).ToString());



                dataGridView1.Columns[i + 1].DefaultCellStyle.BackColor = Color.LightYellow;
                dataGridView1.Columns[i + 1].DefaultCellStyle.Font = new Font("Arial", 9);


            }
            
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].HeaderText = "Modelo";
            dataGridView1.Columns[2].HeaderText = "Cod Venda";
            dataGridView1.Columns[3].HeaderText = "Cod Cliente";
            dataGridView1.Columns[4].HeaderText = "Razão Social";
            dataGridView1.Columns[5].HeaderText = "Conta Corrente";
            dataGridView1.Columns[6].HeaderText = "Banco";
            dataGridView1.Columns[7].HeaderText = "Data Emissão";
            dataGridView1.Columns[8].HeaderText = "Data Vencimento";
            dataGridView1.Columns[9].HeaderText = "Valor Parcela";
            dataGridView1.Columns[10].HeaderText = "Valor Pago";
            dataGridView1.Columns[11].HeaderText = "Data Pagamento";
            dataGridView1.Columns[12].HeaderText = "Status";
            dataGridView1.Columns[12].Name = "Status";
            dataGridView1.Columns[7].Name = "Data_Emissao";
            dataGridView1.Columns[8].Name = "Data_Vencimento";
            dataGridView1.Columns[11].Name = "Data_Pag";
            dataGridView1.Columns[9].Name = "Valor_Parcela";
            dataGridView1.Columns[10].Name = "Valor_Pago";
            dataGridView1.Columns["Data_Emissao"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns["Data_Vencimento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns["Data_Pag"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns["Valor_Parcela"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["Valor_Pago"].DefaultCellStyle.Format = "N2";
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 9);

            Object[] oLinhaDados = new Object[iColunas + 1];

            try
            {

                while (dr.Read())
                {

                    //percorre cada uma das colunas
                    for (int I = 0; I < iColunas; I++)
                    {
                        if (dr.IsDBNull(I))
                        {
                            oLinhaDados[I + 1] = "";
                        }
                        else
                        {
                            oLinhaDados[I + 1] = dr.GetValue(I);



                        }

                    }

                    //atribui a linha ao datagridview
                    int rowIndex = dataGridView1.Rows.Add(oLinhaDados);
                    dataGridView1.Rows[rowIndex].Cells["checkBoxColumn"].Value = false;
                    if (dataGridView1.Rows[rowIndex].Cells["Status"].Value.ToString() == "ENVIADO" || dataGridView1.Rows[rowIndex].Cells["Status"].Value.ToString() == "A_RECEBER")
                    {
                        dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                    else if (dataGridView1.Rows[rowIndex].Cells["Status"].Value.ToString() == "LIQUIDADO" || dataGridView1.Rows[rowIndex].Cells["Status"].Value.ToString() == "RECEBIDO")
                    {
                        dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else if (dataGridView1.Rows[rowIndex].Cells["Status"].Value.ToString() == "BAIXADO" || dataGridView1.Rows[rowIndex].Cells["Status"].Value.ToString() == "CANCELADO")
                    {
                        dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.IndianRed;
                    }
                    

                }
            }
            catch { }
            
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 40;
            dataGridView1.Columns[2].Width = 75;
            dataGridView1.Columns[3].Width = 65;
            dataGridView1.Columns[4].Width = 190;
            dataGridView1.Columns[5].Width = 100;
            //dataGridView1.Columns[6].Width = 70;
            dataGridView1.Columns[6].Width = 110;
            dataGridView1.Columns[7].Width = 120;
            dataGridView1.Columns[8].Width = 120;
            //dataGridView1.Columns[10].Width = 60;
            dataGridView1.Columns[9].Width = 100;
            dataGridView1.Columns[10].Width = 100;
            dataGridView1.Columns[11].Width = 120;
            this.Cursor = Cursors.Default;
        }

        private async void btn_enviar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            Token token = new Token();
            if (Program.banco == "BB")
            {

                token = await API.BoletoAPIBB.GerarToken();
            }
            else if (Program.banco == "INTER")
            {
                token = await API.BoletoAPI_INTER.GerarToken();
            }
            else { }
            foreach (DataGridViewRow Linha in dataGridView1.Rows)
            {
                if (Program.banco == "BB") {
                    DataGridViewCheckBoxCell celula = Linha.Cells[0] as DataGridViewCheckBoxCell;
                    if (celula.Value != null && celula.Value.ToString() == "True")
                    {

                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("pa_API_BB_BoletoVenda", SqlConnection))
                            {
                                string? tv_cod = Linha.Cells[1].Value.ToString();
                                string? ta_cod = Linha.Cells[2].Value.ToString();
                                string? data_Ven = Linha.Cells[8].Value.ToString();
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add(new SqlParameter("@TV_COD", SqlDbType.VarChar)).Value = tv_cod;
                                cmd.Parameters.Add(new SqlParameter("@VA_COD", SqlDbType.VarChar)).Value = ta_cod;
                                cmd.Parameters.Add(new SqlParameter("@PR_DAT_VEN", SqlDbType.DateTime)).Value = data_Ven;
                                // Adicione quaisquer parâmetros necessários para a stored procedure, se houver

                                //SqlConnection.Open();

                                using (SqlDataReader dr = cmd.ExecuteReader())
                                {
                                    while (dr.Read())
                                    {
                                        DateTime dataEmissao = (DateTime)dr["dataEmissao"];
                                        string dataEmissaoString = dataEmissao.ToString("dd.MM.yyyy");
                                        DateTime dataVencimento = (DateTime)dr["dataVencimento"];
                                        string dataVencimentoString = dataVencimento.ToString("dd.MM.yyyy");

                                        //DateTime multa_data = (DateTime)dr["multa_data"];
                                        //string multa_dataString = multa_data.ToString("dd-MM-yyyy");
                                        // Preencha sua classe BoletoVenda com os dados do SqlDataReader
                                        int pagador_tipoInscricao;
                                        if (dr["pagador_numeroInscricao"].ToString().Replace(".", "").Replace("/", "").Replace("-", "").Replace(" ", "").Count() == 11)
                                        {
                                            pagador_tipoInscricao = 1;
                                        }
                                        else
                                        {
                                            pagador_tipoInscricao = 2;
                                        }
                                        string numeroInscricaoString = dr["pagador_numeroInscricao"].ToString();
                                        string minhaString = numeroInscricaoString.Replace(".", "").Replace("/", "").Replace("-", "").Replace(" ", "");
                                        long pagador_numeroInscricao = long.Parse(minhaString);
                                        string pagador_cepString = dr["pagador_cep"].ToString();
                                        minhaString = pagador_cepString.Replace(".", "").Replace("/", "").Replace("-", "").Replace(" ", "");
                                        int pagador_cep = int.Parse(minhaString);
                                        string numeroTitulo = tv_cod + ta_cod;
                                        int nConvenio = int.Parse(dr["numeroConvenio"].ToString());
                                        Decimal valororiginal = Decimal.Parse(dr["valorOriginal"].ToString());
                                        int diasProtesto = int.Parse(dr["quantidadeDiasProtesto"].ToString());
                                        int jurosTipo = int.Parse(dr["jurosmora_tipo"].ToString());
                                        Decimal jurosPorcentagem = Decimal.Parse(dr["jurosmora_porcentagem"].ToString());
                                        int multaTipo = int.Parse(dr["multa_tipo"].ToString());
                                        Decimal multaPorcentagem = Decimal.Parse(dr["multa_porcentagem"].ToString());
                                        ReqBoleto boleto = new ReqBoleto
                                        {


                                            numeroConvenio = nConvenio,

                                            dataVencimento = dataVencimentoString,
                                            valorOriginal = valororiginal,
                                            quantidadeDiasProtesto = diasProtesto,
                                            numeroTituloBeneficiario = numeroTitulo.ToString(),
                                            numeroTituloCliente = (string)dr["numeroTituloCliente"],


                                            jurosMora = new Jurosmora
                                            {
                                                tipo = jurosTipo,
                                                porcentagem = jurosPorcentagem,

                                            },
                                            multa = new Multa
                                            {
                                                tipo = multaTipo,
                                                data = dr["multa_data"].ToString(),
                                                porcentagem = multaPorcentagem,

                                            },
                                            pagador = new Pagador
                                            {
                                                tipoInscricao = pagador_tipoInscricao,
                                                numeroInscricao = pagador_numeroInscricao,

                                                nome = (string)dr["pagador_nome"],
                                                endereco = (string)dr["pagador_endereco"],
                                                cep = pagador_cep,
                                                cidade = (string)dr["pagador_cidade"],
                                                bairro = (string)dr["pagador_bairro"],
                                                uf = (string)dr["pagador_uf"],

                                            },

                                            indicadorPix = "S"
                                        };
                                        
                                        var stringdata = JsonConvert.SerializeObject(boleto);
                                        RespBoleto respBoleto = await API.BoletoAPIBB.CadastrarBoleto(boleto, token);
                                        if (respBoleto != null)
                                        {
                                            T_BOLETO_PR t_BOLETO_PR = new T_BOLETO_PR
                                            {
                                                CL_COD = Linha.Cells[3].Value.ToString(),
                                                CR_COD = Linha.Cells[1].Value.ToString() + Linha.Cells[2].Value.ToString(),
                                                PR_DAT_VEN = (DateTime)dr["dataVencimento"],
                                                CC_NUMERO = Linha.Cells[5].Value.ToString(),
                                                PR_VALOR_PARC = Decimal.Parse(dr["valorOriginal"].ToString()),
                                                BO_NUM_TITULO_CLIENTE = dr["numeroTituloCliente"] != DBNull.Value && dr["numeroTituloCliente"] != null ? dr["numeroTituloCliente"].ToString(): string.Empty,
                                                BO_STATUS = "ENVIADO",
                                                BO_DAT_HORA = DateTime.Now
                                            };
                                            try
                                            {
                                                SwUtil.InserirBoleto(t_BOLETO_PR);
                                            }
                                            catch
                                            {
                                                MessageBox.Show("Erro ao inserir no banco de dados.");
                                            }
                                            MessageBox.Show("Venda " + ta_cod + "Enviado com sucesso!");
                                        }
                                        else
                                        {
                                            //MessageBox.Show("Erro ao enviar boletos!");
                                        }
                                        // Faça o que você deseja com a instância de BoletoVenda
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro para gerar reqBoleto");
                            Console.WriteLine("Ocorreu um erro: " + ex.Message);
                        }

                    }
                }
                else if (Program.banco == "INTER") {
                    DataGridViewCheckBoxCell celula = Linha.Cells[0] as DataGridViewCheckBoxCell;
                    if (celula.Value != null && celula.Value.ToString() == "True")
                    {

                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("pa_API_INTER_BoletoVenda", SqlConnection))
                            {
                                string? tv_cod = Linha.Cells[1].Value.ToString();
                                string? ta_cod = Linha.Cells[2].Value.ToString();
                                string? data_Ven = Linha.Cells[8].Value.ToString();
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add(new SqlParameter("@TV_COD", SqlDbType.VarChar)).Value = tv_cod;
                                cmd.Parameters.Add(new SqlParameter("@VA_COD", SqlDbType.VarChar)).Value = ta_cod;
                                cmd.Parameters.Add(new SqlParameter("@PR_DAT_VEN", SqlDbType.DateTime)).Value = data_Ven;
                                // Adicione quaisquer parâmetros necessários para a stored procedure, se houver

                                //SqlConnection.Open();

                                using (SqlDataReader dr = cmd.ExecuteReader())
                                {
                                    while (dr.Read())
                                    {
                                        Decimal valororiginal = Decimal.Parse(dr["valorNominal"].ToString());
                                        string valorNominal = valororiginal.ToString("F2", CultureInfo.InvariantCulture);
                                        

                                        ReqBoleto_Inter boleto = new ReqBoleto_Inter
                                        {


                                            seuNumero= dr["seuNumero"].ToString(),
                                            valorNominal = valorNominal,
                                            dataVencimento = dr["dataVencimento"].ToString(),
                                            numDiasAgenda = dr["numDiasAgenda"].ToString(),

                                            pagador = new ReqBoleto_Inter.Pagador
                                            {
                                                cpfCnpj = dr["pagador_cpfCnpj"].ToString(),
                                                tipoPessoa = dr["pagador_tipoPessoa"].ToString(),
                                                nome = dr["pagador_nome"].ToString(),
                                                endereco = dr["pagador_endereco"].ToString(),
                                                cidade = dr["pagador_cidade"].ToString(),
                                                uf = dr["pagador_uf"].ToString(),
                                                cep = dr["pagador_cep"].ToString(),
                                                email = dr["pagador_email"].ToString(),
                                                numero = dr["pagador_numero"].ToString(),
                                                complemento = dr["pagador_complemento"].ToString(),
                                                bairro = dr["pagador_bairro"].ToString(),
                                            },

                                            multa = new ReqBoleto_Inter.Multa
                                            {
                                                codigo = dr["multa_codigo"].ToString(),
                                                taxa = dr["multa_taxa"].ToString().Replace(',', '.'),
                                            },

                                            mora = new ReqBoleto_Inter.Mora
                                            {
                                                codigo = dr["mora_codigo"].ToString(),
                                                taxa = dr["mora_taxa"].ToString().Replace(',', '.')
                                            }                                           


                                        };
                                        
                                        var stringdata = JsonConvert.SerializeObject(boleto);
                                        CodsolicitacaoInter codsolicitacao = await API.BoletoAPI_INTER.CadastrarBoleto(boleto, token, Linha.Cells[5].Value.ToString());
                                        RespConsulta_Inter respBoleto = await API.BoletoAPI_INTER.consultarBoleto(codsolicitacao, token, Linha.Cells[5].Value.ToString());
                                        if (respBoleto != null)
                                        {
                                            T_BOLETO_PR t_BOLETO_PR = new T_BOLETO_PR
                                            {
                                                CL_COD = Linha.Cells[3].Value.ToString(),
                                                CR_COD = Linha.Cells[1].Value.ToString() + Linha.Cells[2].Value.ToString(),
                                                PR_DAT_VEN = DateTime.Parse(dr["dataVencimento"].ToString()),
                                                CC_NUMERO = Linha.Cells[5].Value.ToString(),
                                                PR_VALOR_PARC = Decimal.Parse(dr["valorNominal"].ToString()),
                                                BO_COD_SOLICITAÇÃO = codsolicitacao.codigoSolicitacao,
                                                BO_STATUS = "ENVIADO",
                                                BO_DAT_HORA = DateTime.Now                                                

                                            };
                                            try
                                            {
                                                SwUtil.InserirBoleto(t_BOLETO_PR);
                                            }
                                            catch
                                            {
                                                MessageBox.Show("Erro ao inserir no banco de dados.");
                                            }
                                            MessageBox.Show("Venda " + ta_cod + " Enviado com sucesso!");
                                        }
                                        else
                                        {
                                            //MessageBox.Show("Erro ao enviar boletos!");
                                        }
                                        // Faça o que você deseja com a instância de BoletoVenda
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro para gerar reqBoleto");
                            Console.WriteLine("Ocorreu um erro: " + ex.Message);
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Erro: Insira o Banco no arquivo de configuração");
                }
            }
            try
            {

                this.Cursor = Cursors.WaitCursor;
                MontaGrid(sSql, sOrderBy);

            }
            catch
            {
                MessageBox.Show("Data incorreta!");

            }
            this.Cursor = Cursors.Default;


        }
        private void ENTER_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //SendKeys.Send("{TAB}");
            {
                SendKeys.Send((e.Shift ? "+" : "") + "{TAB}");
                e.SuppressKeyPress = true;
            }


        }
        private void ENTER_KeyDown_pesquisar(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //SendKeys.Send("{TAB}");
            {
                btn_pesquisar_Click(sender, e);
            }


        }
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix)
                    if (ix != e.Index) checkedListBox1.SetItemChecked(ix, false);
            }
        }
        private void consultarSituaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSitBoletos frmSitBoletos = new FrmSitBoletos();
            frmSitBoletos.ShowDialog();
        }
        private void txtDataInicio_Validating(object sender, CancelEventArgs e)
        {
            if (txt_data_ini.Text == "h" || txt_data_ini.Text == "H")
            {
                txt_data_ini.Text = DateTime.Now.ToShortDateString();

            };
            if (txt_data_ini.Text != "")
            {
                try
                {
                    DateTime dataAux = Convert.ToDateTime(txt_data_ini.Text);
                    txt_data_ini.Text = dataAux.ToShortDateString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data Invalida - " + ex.Message, "SwErro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }

            };

            //MessageBox.Show(string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(txtDataInicio.Text)));
        }
        private int firstSelectedRowIndex = -1;

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0) // Substitua por seu índice de coluna de checkbox
            {
                if (Control.ModifierKeys == Keys.Shift)
                {
                    if (firstSelectedRowIndex == -1)
                    {
                        firstSelectedRowIndex = e.RowIndex;
                    }
                    else
                    {
                        bool firstChecked = Convert.ToBoolean(dataGridView1.Rows[firstSelectedRowIndex].Cells["checkBoxColumn"].Value);
                        for (int i = Math.Min(firstSelectedRowIndex, e.RowIndex); i <= Math.Max(firstSelectedRowIndex, e.RowIndex); i++)
                        {
                            dataGridView1.Rows[i].Cells["checkBoxColumn"].Value = firstChecked;
                            
                        }
                        firstSelectedRowIndex = -1;
                    }
                }
            }
        }

        private void txtDataFim_Validating(object sender, CancelEventArgs e)
        {
            if (txt_data_fim.Text == "h" || txt_data_fim.Text == "H")
            {
                txt_data_fim.Text = DateTime.Now.ToShortDateString();

            };
            if (txt_data_fim.Text != "")
            {
                try
                {
                    DateTime dataAux = Convert.ToDateTime(txt_data_fim.Text);
                    txt_data_fim.Text = dataAux.ToShortDateString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data Invalida - " + ex.Message, "SwErro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }

            };

        }
        private void cbxSituação_Leave(object sender, EventArgs e)
        {
            btn_pesquisar_Click(sender, e);

        }

        private async void btn_Cancelar_click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Certeza que deseja cancelar boletos?", "Confirmação", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                Token token = new Token();
                if (Program.banco == "BB")
                {

                    token = await API.BoletoAPIBB.GerarToken();
                }
                else if (Program.banco == "INTER")
                {
                    token = await API.BoletoAPI_INTER.GerarToken();
                }
                else { }

                foreach (DataGridViewRow Linha in dataGridView1.Rows)
                {
                    if (Program.banco == "BB")
                    {
                        DataGridViewCheckBoxCell celula = Linha.Cells[0] as DataGridViewCheckBoxCell;
                        if (celula.Value != null && celula.Value.ToString() == "True")
                        {

                            try
                            {
                                using (SqlCommand cmd = new SqlCommand("pa_API_BB_BoletoVenda", SqlConnection))
                                {
                                    string? tv_cod = Linha.Cells[1].Value.ToString();
                                    string? ta_cod = Linha.Cells[2].Value.ToString();
                                    string? data_Ven = Linha.Cells[8].Value.ToString();
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.Add(new SqlParameter("@TV_COD", SqlDbType.VarChar)).Value = tv_cod;
                                    cmd.Parameters.Add(new SqlParameter("@VA_COD", SqlDbType.VarChar)).Value = ta_cod;
                                    cmd.Parameters.Add(new SqlParameter("@PR_DAT_VEN", SqlDbType.DateTime)).Value = data_Ven;
                                    string? status = Linha.Cells[11].Value.ToString();

                                    // Adicione quaisquer parâmetros necessários para a stored procedure, se houver

                                    //SqlConnection.Open();

                                    using (SqlDataReader dr = cmd.ExecuteReader())
                                    {
                                        while (dr.Read())
                                        {
                                            if (status == "ENVIADO")
                                            {
                                                string nossoNumero = (string)dr["numeroTituloCliente"];
                                                string numeroConvenio = (string)dr["numeroConvenio"];
                                                ReqCancelar req = new ReqCancelar
                                                {


                                                    numeroConvenio = int.Parse(dr["numeroConvenio"].ToString()),

                                                };


                                                RespCancelar respCancelar = await API.BoletoAPIBB.CancelarBoleto(nossoNumero, req, token);
                                                if (respCancelar != null)
                                                {
                                                    MessageBox.Show("Venda " + ta_cod + " cancelado com sucesso!");
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Erro ao cancelar boleto " + Linha.Cells[2].Value.ToString());
                                                }
                                                // Faça o que você deseja com a instância de BoletoVenda



                                                RespConsultaBoleto respConsulta = await API.BoletoAPIBB.consultarBoleto(nossoNumero, numeroConvenio, token);
                                                if (respConsulta != null)
                                                {
                                                    int chave = (int)respConsulta.codigoEstadoTituloCobranca; // Substitua pelo número da chave que você deseja acessar
                                                    string estadoCobranca;

                                                    if (Program.Dicionario_Status.TryGetValue(chave, out estadoCobranca))
                                                    {
                                                        T_BOLETO_PR t_BOLETO_PR = new T_BOLETO_PR
                                                        {
                                                            CL_COD = Linha.Cells[3].Value.ToString(),
                                                            CR_COD = Linha.Cells[1].Value.ToString() + Linha.Cells[2].Value.ToString(),
                                                            PR_DAT_VEN = (DateTime)dr["dataVencimento"],
                                                            CC_NUMERO = Linha.Cells[5].Value.ToString(),
                                                            PR_VALOR_PARC = Decimal.Parse(dr["valorOriginal"].ToString()),
                                                            BO_NUM_TITULO_CLIENTE = dr["numeroTituloCliente"] != DBNull.Value && dr["numeroTituloCliente"] != null ? dr["numeroTituloCliente"].ToString() : string.Empty,
                                                            BO_STATUS = estadoCobranca,
                                                            BO_DAT_HORA = DateTime.Now
                                                        };
                                                        try
                                                        {
                                                            SwUtil.InserirBoleto(t_BOLETO_PR);
                                                        }
                                                        catch
                                                        {
                                                            MessageBox.Show("Erro ao inserir no banco de dados.");
                                                        }


                                                    }
                                                    else
                                                    {

                                                    }


                                                }
                                                else
                                                {
                                                    MessageBox.Show("Erro ao consultar boleto " + Linha.Cells[2].Value.ToString());
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Ocorreu um erro: " + ex.Message);
                            }

                        }
                    }
                    else if (Program.banco == "INTER")
                    {
                        DataGridViewCheckBoxCell celula = Linha.Cells[0] as DataGridViewCheckBoxCell;
                        if (celula.Value != null && celula.Value.ToString() == "True")
                        {

                            try
                            {
                                using (SqlCommand cmd = new SqlCommand("pa_API_INTER_BoletoVenda", SqlConnection))
                                {
                                    string? tv_cod = Linha.Cells[1].Value.ToString();
                                    string? ta_cod = Linha.Cells[2].Value.ToString();
                                    string? data_Ven = Linha.Cells[8].Value.ToString();
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.Add(new SqlParameter("@TV_COD", SqlDbType.VarChar)).Value = tv_cod;
                                    cmd.Parameters.Add(new SqlParameter("@VA_COD", SqlDbType.VarChar)).Value = ta_cod;
                                    cmd.Parameters.Add(new SqlParameter("@PR_DAT_VEN", SqlDbType.DateTime)).Value = data_Ven;


                                    using (SqlDataReader dr = cmd.ExecuteReader())
                                    {
                                        while (dr.Read())
                                        {

                                            CodsolicitacaoInter codsolicitacao = new CodsolicitacaoInter
                                            {
                                                codigoSolicitacao = dr["BO_COD_SOLICITAÇÃO"].ToString()
                                            };
                                            ReqCancelarInter cancelarInter = new ReqCancelarInter
                                            {
                                                motivoCancelamento = "motivo cancelamento"
                                            };

                                            bool respCancelar = await API.BoletoAPI_INTER.CancelarBoleto(cancelarInter, codsolicitacao, token, Linha.Cells[5].Value.ToString());
                                            if (respCancelar != false)
                                            {
                                                MessageBox.Show("Venda " + ta_cod + " cancelado com sucesso!");
                                            }
                                            else
                                            {
                                                MessageBox.Show("Erro ao cancelar boleto" + Linha.Cells[2].Value.ToString());
                                            }
                                            RespConsulta_Inter respConsulta = await API.BoletoAPI_INTER.consultarBoleto(codsolicitacao, token, Linha.Cells[5].Value.ToString());
                                            if (respConsulta != null)
                                            {
                                                //int chave = respConsulta.cobranca.situacao; // Substitua pelo número da chave que você deseja acessar
                                                string estadoCobranca = respConsulta.cobranca.situacao;

                                                T_BOLETO_PR t_BOLETO_PR = new T_BOLETO_PR
                                                {
                                                    CL_COD = Linha.Cells[3].Value.ToString(),
                                                    CR_COD = Linha.Cells[1].Value.ToString() + Linha.Cells[2].Value.ToString(),
                                                    PR_DAT_VEN = DateTime.Parse(dr["dataVencimento"].ToString()),
                                                    CC_NUMERO = Linha.Cells[5].Value.ToString(),
                                                    PR_VALOR_PARC = Decimal.Parse(dr["valorNominal"].ToString()),
                                                    BO_COD_SOLICITAÇÃO = dr["BO_COD_SOLICITAÇÃO"] != DBNull.Value && dr["BO_COD_SOLICITAÇÃO"] != null ? dr["BO_COD_SOLICITAÇÃO"].ToString() : string.Empty,
                                                    BO_STATUS = estadoCobranca,
                                                    BO_DAT_HORA = DateTime.Now
                                                };
                                                try
                                                {
                                                    SwUtil.InserirBoleto(t_BOLETO_PR);
                                                }
                                                catch
                                                {
                                                    MessageBox.Show("Erro ao inserir no banco de dados.");
                                                }





                                            }
                                            else
                                            {
                                                MessageBox.Show("Erro ao consultar boleto " + Linha.Cells[2].Value.ToString());
                                            }
                                            // Faça o que você deseja com a instância de BoletoVenda
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Ocorreu um erro: " + ex.Message);
                            }

                        }


                    }
                    else
                    {
                        MessageBox.Show("Erro: Insira o Banco no arquivo de configuração");
                    }
                }

                    try
                    {


                        MontaGrid(sSql, sOrderBy);
                        //this.Cursor = Cursors.Default;
                    }
                    catch
                    {
                        MessageBox.Show("Data incorreta!");

                    }

                
            }
            else
            {
                // Código para lidar com o não
            }
        }

        private async void btn_checar_status(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Token token = new Token();
            if (Program.banco == "BB")
            {

                token = await API.BoletoAPIBB.GerarToken();
            }
            else if (Program.banco == "INTER")
            {
                token = await API.BoletoAPI_INTER.GerarToken();
            }
            else { }

            foreach (DataGridViewRow Linha in dataGridView1.Rows)
            {
                this.Cursor = Cursors.WaitCursor;
                if (Program.banco == "BB")
                {
                    DataGridViewCheckBoxCell celula = Linha.Cells[0] as DataGridViewCheckBoxCell;
                    if (celula.Value != null && celula.Value.ToString() == "True")
                    {

                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("pa_API_BB_BoletoVenda", SqlConnection))
                            {
                                string? tv_cod = Linha.Cells[1].Value.ToString();
                                string? ta_cod = Linha.Cells[2].Value.ToString();
                                string? data_Ven = Linha.Cells[8].Value.ToString();
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add(new SqlParameter("@TV_COD", SqlDbType.VarChar)).Value = tv_cod;
                                cmd.Parameters.Add(new SqlParameter("@VA_COD", SqlDbType.VarChar)).Value = ta_cod;
                                cmd.Parameters.Add(new SqlParameter("@PR_DAT_VEN", SqlDbType.DateTime)).Value = data_Ven;


                                using (SqlDataReader dr = cmd.ExecuteReader())
                                {
                                    while (dr.Read())
                                    {

                                        string nossoNumero = (string)dr["numeroTituloCliente"];
                                        string numeroConvenio = (string)dr["numeroConvenio"];


                                        RespConsultaBoleto respConsulta = await API.BoletoAPIBB.consultarBoleto(nossoNumero, numeroConvenio, token);
                                        if (respConsulta != null)
                                        {
                                            int chave = (int)respConsulta.codigoEstadoTituloCobranca; // Substitua pelo número da chave que você deseja acessar
                                            string estadoCobranca;

                                            if (Program.Dicionario_Status.TryGetValue(chave, out estadoCobranca))
                                            {
                                                T_BOLETO_PR t_BOLETO_PR = new T_BOLETO_PR
                                                {
                                                    CL_COD = Linha.Cells[3].Value.ToString(),
                                                    CR_COD = Linha.Cells[1].Value.ToString() + Linha.Cells[2].Value.ToString(),
                                                    PR_DAT_VEN = (DateTime)dr["dataVencimento"],
                                                    CC_NUMERO = Linha.Cells[5].Value.ToString(),
                                                    PR_VALOR_PARC = Decimal.Parse(dr["valorOriginal"].ToString()),
                                                    BO_NUM_TITULO_CLIENTE = dr["numeroTituloCliente"] != DBNull.Value && dr["numeroTituloCliente"] != null ? dr["numeroTituloCliente"].ToString() : string.Empty,
                                                    BO_STATUS = estadoCobranca,
                                                    BO_DAT_HORA = DateTime.Now
                                                };
                                                try
                                                {
                                                    SwUtil.InserirBoleto(t_BOLETO_PR);
                                                }
                                                catch
                                                {
                                                    MessageBox.Show("Erro ao inserir no banco de dados.");
                                                }


                                            }
                                            else
                                            {

                                            }


                                        }
                                        else
                                        {
                                            MessageBox.Show("Erro ao consultar boleto " + Linha.Cells[2].Value.ToString());
                                        }
                                        // Faça o que você deseja com a instância de BoletoVenda
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ocorreu um erro: " + ex.Message);
                        }

                    }
                }
                else if (Program.banco == "INTER")
                {
                    DataGridViewCheckBoxCell celula = Linha.Cells[0] as DataGridViewCheckBoxCell;
                    if (celula.Value != null && celula.Value.ToString() == "True")
                    {

                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("pa_API_INTER_BoletoVenda", SqlConnection))
                            {
                                string? tv_cod = Linha.Cells[1].Value.ToString();
                                string? ta_cod = Linha.Cells[2].Value.ToString();
                                string? data_Ven = Linha.Cells[8].Value.ToString();
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add(new SqlParameter("@TV_COD", SqlDbType.VarChar)).Value = tv_cod;
                                cmd.Parameters.Add(new SqlParameter("@VA_COD", SqlDbType.VarChar)).Value = ta_cod;
                                cmd.Parameters.Add(new SqlParameter("@PR_DAT_VEN", SqlDbType.DateTime)).Value = data_Ven;


                                using (SqlDataReader dr = cmd.ExecuteReader())
                                {
                                    while (dr.Read())
                                    {

                                        CodsolicitacaoInter codsolicitacao = new CodsolicitacaoInter
                                        {
                                            codigoSolicitacao = dr["BO_COD_SOLICITAÇÃO"].ToString()
                                        };


                                        RespConsulta_Inter respConsulta = await API.BoletoAPI_INTER.consultarBoleto(codsolicitacao, token, Linha.Cells[5].Value.ToString());
                                        if (respConsulta != null)
                                        {
                                            //int chave = respConsulta.cobranca.situacao; // Substitua pelo número da chave que você deseja acessar
                                            string estadoCobranca = respConsulta.cobranca.situacao;

                                            T_BOLETO_PR t_BOLETO_PR = new T_BOLETO_PR
                                            {
                                                CL_COD = Linha.Cells[3].Value.ToString(),
                                                CR_COD = Linha.Cells[1].Value.ToString() + Linha.Cells[2].Value.ToString(),
                                                PR_DAT_VEN = DateTime.Parse(dr["dataVencimento"].ToString()),
                                                CC_NUMERO = Linha.Cells[5].Value.ToString(),
                                                PR_VALOR_PARC = Decimal.Parse(dr["valorNominal"].ToString()),
                                                BO_COD_SOLICITAÇÃO = dr["BO_COD_SOLICITAÇÃO"] != DBNull.Value && dr["BO_COD_SOLICITAÇÃO"] != null ? dr["BO_COD_SOLICITAÇÃO"].ToString() : string.Empty,
                                                BO_STATUS = estadoCobranca,
                                                BO_DAT_HORA = DateTime.Now
                                            };
                                            try
                                            {
                                                SwUtil.InserirBoleto(t_BOLETO_PR);
                                            }
                                            catch
                                            {
                                                MessageBox.Show("Erro ao inserir no banco de dados.");
                                            }





                                        }
                                        else
                                        {
                                            MessageBox.Show("Erro ao consultar boleto " + Linha.Cells[2].Value.ToString());
                                        }
                                        // Faça o que você deseja com a instância de BoletoVenda
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ocorreu um erro: " + ex.Message);
                        }

                    }

                }
                else
                {
                    MessageBox.Show("Erro: Insira o Banco no arquivo de configuração");
                }
            }
                try
                {

                    this.Cursor = Cursors.WaitCursor;
                    MontaGrid(sSql, sOrderBy);

                }
                catch
                {
                    MessageBox.Show("Data incorreta!");

                }
            

        }
    }
}