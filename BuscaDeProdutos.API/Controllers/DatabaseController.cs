using MySqlConnector;

namespace DesafioBootcamp.Controllers;

public class DatabaseController
{
    private string caminho = "server=localhost;uid=root;pwd=;database=php_dados;";
    private MySqlConnection conexao;

    public MySqlConnection Conexao() {
        return this.conexao;
    }

    public Bd_conecao() {

        try
        {
            conexao = new MySqlConnection(caminho);
            conexao.Open();
            //MessageBox.Show("Conectado com sucesso...");
        }
        catch (Exception)
        {
            MessageBox.Show("Erro de conexão");
        }
        finally {
            conexao.Close();
        }
    }

    public void gravar(int codigo, string nome) {
        this.conexao.Open();
        string query = "INSERT INTO famosos (codigo, nome) VALUES ("+codigo+", '"+nome+"')";
        this.conexao.Close();
    }
}