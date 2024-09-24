using System;
//Observe a inclusão do NameSpace para acessar Banco de Dados   
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrjCadastroDeUsuarios.AcessoBd
{
    class ClsBanco
    {
       
        //Declaração da "variável" que contém informações//sobre o Banco de Dados: tipo, nome, caminho...
        string strConexao = Properties.Settings.Default.ConexaoBD;
        //Declaração da "variável" (objeto) de Conexão
        OleDbConnection conn = null;
        //Declaração dos campos (que constam na tabela de usuarios)//OBS: O atributo "private" é opcional. Se nada for declarado//o "private" é assumido!!
        private int codUsuario;
        private int senha;
        private string nomeUsuario;

        //Declaração das "propriedades" (Gets/Sets).//Botão direito sobre cada campo declarado acima, ações rápidas e //refatoração --> Encapsular Campos
        public int CodUsuario { get => codUsuario; set => codUsuario = value; }
        public int Senha { get => senha; set => senha = value; }
        public string NomeUsuario { get => nomeUsuario; set => nomeUsuario = value; }

        public int Gravar()
        {
            //declaração do objeto/variável "command"
            OleDbCommand comando = new OleDbCommand();
            comando.CommandType = CommandType.Text;

            //declaração dos parametros/variáveis que serão utilizadas//no comando SQL. Os parâmetros recebem os dados dos Gets
            comando.Parameters.Add("@varCodigo", oleDbType: OleDbType.Integer).Value = CodUsuario;
            comando.Parameters.Add("@varNome", oleDbType: OleDbType.Integer).Value = nomeUsuario;
            comando.Parameters.Add("@varSenha", oleDbType: OleDbType.Integer).Value = senha;

            //comando SQL
            comando.CommandText = "Insert into Usuarios (CodUsuario, Senha, NomeUsuario) values (@varCodigo, @varSenha, @varNome)";
            comando.Connection = conn;
            //executa a instrução
            int status = comando.ExecuteNonQuery();
            //fecha o banco
            conn.Close();
            return status;
        }

       public DataTable ConsultarDados(byte tipoConsulta, int codigo, string nome)
        {
            OleDbCommand comando = new OleDbCommand();
            comando.CommandType = CommandType.Text;
            string strSql = "Select * from Usuarios";
            // tipoConsulta = 1 --> lista geral// tipoConsulta= 2 --> Consulta por código// tipoConsulta = 3 --> Consulta por qualquer parte do nome
            if (tipoConsulta == 2)
            {
                comando.Parameters.Add("@varCodigo", oleDbType: OleDbType.Integer).Value = codigo;
                strSql += " where CodUsuario = @varCodigo";
            }
            else if(tipoConsulta == 3)
                {
                comando.Parameters.Add("@varNome", oleDbType: OleDbType.VarChar, 50).Value = "%" + nome + "%";
                strSql += " where NomeUsuario like @varNome";
            }
            strSql += " order by CodUsuario";
            //atribui a variavel strSql ao comando
            comando.CommandType = CommandType.Text;
            comando.CommandText = strSql;

            comando.Connection = conn;

            DataSet myDataset = new DataSet();
            //cria e executa o comando SQL para preencher o Dateset
            OleDbDataAdapter myAdapter = new OleDbDataAdapter(comando);
            myAdapter.Fill(myDataset, "tabelaDataset");
            conn.Close();
            return myDataset.Tables["tabelaDataset"];

        }

        public int Alterar()
        {

            comando.CommandType = CommandType.Text;
            //declaração dos parametros/variáveis que serão utilizadasno comando SQL
            comando.Parameters.Add("@varSenha", oleDbType: OleDbType.Integer).Value = senha;
            comando.Parameters.Add("@varNome", oleDbType: OleDbType.VarChar, 50).Value = nomeUsuario;
            comando.Parameters.Add("@varCodigo", oleDbType: OleDbType.Integer).Value = codUsuario;
            //Observe que os parametros DEVERÃO ser declaradosna mesma ordem em que serão utlizados na 
            //instrução SQL. Achave primária "CodUsuario" não poder seralterada, mas será utilizada no SQL //com uma condição "where".

        }





        //Declaração do método construtor. Método executado automaticamente//no momento em que a classe é "instanciada". Abertura do Banco de Dados
        public ClsBanco()
        {
            conn = new OleDbConnection(strConexao);
            try
            {
                conn.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao abrir o arquivo" + ex.ToString(), "ATENÇÃO");
            }
       
        }

        internal int Excluir()
        {
            throw new NotImplementedException();
        }
    }
}
