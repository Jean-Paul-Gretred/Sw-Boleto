using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwBoleto
{
    public partial class FrmMostraGrid : Form
    {
        public string sDadoSel;

        public FrmMostraGrid()
        {
            InitializeComponent();
        }

        public void MostraGrid(SqlDataReader dr)
        {
            //string teste;
            //dataGridView1.DataSource= rr;
            //teste = (string) dataGridView1.Rows[10].Cells[5].Value;
            //OleDbDataReader dr = cmd.ExecuteReader();

            int iColunas = dr.FieldCount;

            for (int i = 0; i < iColunas; i++)
            {
                dataGridView1.Columns.Add(dr.GetName(i).ToString(), dr.GetName(i).ToString());
                //dataGridView1.Columns[i].Width = dr.GetName(i).Length;
            }

            //define um array de strings com iColunas
            //string[] sLinhaDados = new string[iColunas]; // MLUCIO 10 01 2023
            Object[] oLinhaDados = new Object[iColunas]; // MLUCIO 10 01 2023


            //percorre o DataRead
            while (dr.Read())
            {
                //percorre cada uma das colunas
                for (int I = 0; I < iColunas; I++)
                {
                    if (dr.IsDBNull(I))
                    {
                        //sLinhaDados[I] = ""; // MLUCIO 10 01 2023
                        oLinhaDados[I] = ""; // MLUCIO 10 01 2023
                    }
                    else
                    {
                        //MessageBox.Show(dr.GetString(I).Length.ToString());
                        //if (dataGridView1.Columns[I].Width < dr.GetString(I).Length)
                        //{
                        //    dataGridView1.Columns[I].Width = dr.GetString(I).Length;
                        //}

                        //verifica o tipo de dados da coluna
                        if (dr.GetFieldType(I).ToString() == "System.Int32")
                        {
                            //sLinhaDados[I] = dr.GetInt32(I).ToString(); // MLUCIO 10 01 2023
                            oLinhaDados[I] = dr.GetInt32(I); // MLUCIO 10 01 2023
                        }
                        if (dr.GetFieldType(I).ToString() == "System.String")
                        {
                            //sLinhaDados[I] = dr.GetString(I).ToString(); // MLUCIO 10 01 2023
                            oLinhaDados[I] = dr.GetString(I).ToString(); // MLUCIO 10 01 2023
                        }
                        if (dr.GetFieldType(I).ToString() == "System.DateTime")
                        {
                            //sLinhaDados[I] = dr.GetDateTime(I).ToString(); // MLUCIO 10 01 2023
                            oLinhaDados[I] = dr.GetDateTime(I); //.ToString(); // MLUCIO 10 01 2023

                        }
                        if (dr.GetFieldType(I).ToString() == "System.Decimal")
                        {
                            //sLinhaDados[I] = dr.GetDecimal(I).ToString(); // MLUCIO 10 01 2023
                            oLinhaDados[I] = dr.GetDecimal(I); // MLUCIO 10 01 2023
                        }
                        else
                        {
                            //sLinhaDados[I] = dr.GetDecimal(I).ToString();
                            //MessageBox.Show(dr.GetFieldType(I).ToString());
                        }
                    }
                }
                //atribui a linha ao datagridview
                //dataGridView1.Rows.Add(sLinhaDados); // MLUCIO 10 01 2023
                dataGridView1.Rows.Add(oLinhaDados); // MLUCIO 10 01 2023

            }
        }


        private void FrmMostraGrid_Load(object sender, EventArgs e)
        {
            sDadoSel = "";
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            sDadoSel = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            this.Close();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sDadoSel = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                this.Close();
            }
            if (e.KeyCode == Keys.Escape)
            {
                sDadoSel = "";
                this.Close();
            }
        }


    }
}
