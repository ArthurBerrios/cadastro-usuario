using PrjCadastroDeUsuarios.AcessoBd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrjCadastroDeUsuarios
{
    public partial class FrmConsulta : Form
    {
        //Declaração de um objeto do tipo "FrmUsuarios"
        FrmUsuarios instanciaDoForm1;
        //O parametro (FrmUsuarios frm1) foi inserido, com o objetivo de
        //informar que o formulário FrmConsulta receberá um formulário
        //como parametro
        
        public FrmConsulta(FrmUsuarios frm1)
        {
            InitializeComponent();
            //instrucao incluida
            instanciaDoForm1 = frm1;
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            //Gera a instancia da classe "ClsBanco".
            //Neste momento o construtor é executado e o banco aberto
            ClsBanco objeto = new ClsBanco();
            //declara uma variavel do tipo byte
            byte tipoConsulta = 1;
            if(RdoCodigo.Checked == true)
            {
                tipoConsulta = 2;
                txtNome.Text = "";

            }
            else if
                {
                tipoConsulta = 3;
                txtCodigo.Text = "";
            }
            //tenta converter o conteúdo da caixa de texto TxtCodigo
            //se der erro (nada foi preenchido), o código seráZero
            int codigo;
            try
            {
                codigo = Convert.ToInt32(txtCodigo.Text);
            }
            catch(Exception)
            {
                codigo = 0;
            }
            //OBS: No momento em que a instrução abaixo é digitada
            //um erro ocorrerá, informando que o método "ConsultarDados"
            //não existe. O método poderá ser criado pelo próprio Visual
            //Studio e "ajustado" manualmente
            dgvLista.DataSource = objeto.ConsultarDados(tipoConsulta, codigo, txtNome.Text);
            if(dgvLista.RowCount ==0)
            {
                MessageBox.Show("Nenhum usuario encontrado!!", "Atenção");
            }
        }

        private void DgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //importante: No Form1 (FrmUsuarios) precisamos alterar as propriedades/
            //MODIFIERS dos textbox para public para permissão de acesso
            instanciaDoForm1.txtCodigo.Text = dgvLista.CurrentRow.Cells[0].Value.ToString();
            instanciaDoForm1.txtSenha.Text = dgvLista.CurrentRow.Cells[1].Value.ToString();
            instanciaDoForm1.txtNome.Text = dgvLista.CurrentRow.Cells[2].Value.ToString();

            this.Close();
        }
    }
}
