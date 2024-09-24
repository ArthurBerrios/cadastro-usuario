using PrjCadastroDeUsuarios.AcessoBd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrjCadastroDeUsuarios
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            //Atenção: Falta validar as caixas de TexBox!!!//Instancia a classe ClsBanco (neste momento o método//construtor é executado//*** Importante: o using precisará ser declarado para poder utilizar a classe ClsBanco que//está dentro da pasta AcessoBD --> using EXE039_BD005.AcessoBD;
            ClsBanco objBanco = new ClsBanco();
            //Transfere os dados das caixas de texto para as propriedades//sets da classe
            objBanco.CodUsuario = Convert.ToInt32(txtCodigo.Text);
            objBanco.Senha = Convert.ToInt32(txtSenha.Text);
            objBanco.NomeUsuario = txtNome.Text;

            int status;
            status = objBanco.Gravar();
            //Verifica o retorno da gravação 
            if(status!=0)
            {
                MessageBox.Show("Gravação bem sucedida!!", "SUCESSO"):

            }
            else
            {
                MessageBox.Show("Erro na gravação", "*** ERRO ***");
            }
            LimparCampos();
            // Observe o parametro "This" ao final. Indica que estamos//transferindo o formulário atual (FrmUsuarios) como//parametropara o formulário "FrmConsulta".//No momento da escrita desta instrução um erro será sinalizado//pois, no momento, o FrmConsulta não está "preparado" para//receber dados de parametro. Esta implementação do//parametro será feita logo em seguida no próprio formulário//FrmConsulta
             FrmConsulta MyFrmConsulta = new FrmConsulta(this);
            MyFrmConsulta.ShowDialog();
        }
        private void LimparCampos()
        {
            txtCodigo.Text = "";
            txtSenha.Text = "";
            txtNome.Text = "";
            txtCodigo.Focus();
        }

        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            //Atenção: Falta validar as caixas de TexBox!!!
            //Instancia a classe ClsBanco (neste momento o método
            //construtor é executado    
            //*** Importante: o using precisará ser declarado para poder utilizar a classe //ClsBanco que
            //está dentro da pasta AcessoBD --> using EXE039_BD005.AcessoBD;
            ClsBanco objBanco = new ClsBanco();
            //Transfere os dados das caixas de texto para as propriedades//sets da classe.
            objBanco.CodUsuario = Convert.ToInt32(txtCodigo.Text);
            objBanco.Senha = Convert.ToInt32(txtSenha.Text);
            objBanco.NomeUsuario = txtNome.Text;
            //executa o método "Alterar" da classe ClsBanco.
            //*** Neste momento o método não existe, porém, o Visual Studio
            //exibe a opção de cria-lo. E nós utilizaremos esta opção
            //exibe a opção de cria-lo. E nós utilizaremos esta opção
            int status;
            status = objBanco.Alterar();
            //Verifica o retorno da alteração
            if (status != 0)
            {
                MessageBox.Show("Alteração bem sucedida!!", "SUCESSO");
               
            }
            else {
                MessageBox.Show("Erro na alteração dos dados!!", "*** ERRO ***");
        
            }
            LimparCampos();
        }
        //IMPORTANTE: Este método de "Excluir" somente poderá ser
        //executado após a realização de uma consulta,//com o preenchimento das caixas de texto.
        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            //Atenção: Falta validar as caixas de TexBox!!!
            //Instancia a classe ClsBanco (neste momento o métodoconstrutor é executado
            //*** Importante: o using precisará ser declarado para poder utilizar a classe //ClsBanco que
            //está dentro da pasta AcessoBD --> using EXE039_BD005.AcessoBD;
            ClsBanco objBanco = new ClsBanco();
            //Transfere os dados das caixas de texto para as propriedades
            //sets da classe. Para a EXCLUSÃO, somente o código é necessário 
            objBanco.CodUsuario = Convert.ToInt32(txtCodigo.Text);

            //executa o método "Excluir" da classe ClsBanco.
            //*** Neste momento o método não existe, porém, o Visual Studioexibe a opção de cria-lo. 
            //E nós utilizaremos esta opçãode criação e faremos os ajustes necessários
            int status;
            status = objBanco.Excluir();

            //Verifica o retorno da exclusão
            if (status != 0)
            {
                MessageBox.Show("Exclusão bem sucedida!!", "SUCESSO");
            }
            else {
                MessageBox.Show('Erro na exclusão do usuário!!", "***ERRO * **");
            }
            LimparCampos();
        }

    }
}
