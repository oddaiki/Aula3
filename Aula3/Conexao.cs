using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Aula3
{
    internal class Conexao
    {
        static private string servidor = "";
        static private string banco = "bd_aula3";
        static private string usuario = "root";
        static private string senha = "cursoads";

        static public string strConn = $"server={servidor};" +
        $"database={banco}; User Id={usuario};" +
        $"password={senha}";

        MySqlConnection cn;

        private bool Conectar()
        {
            bool result;
            try
            {
                cn= new MySqlConnection(strConn);
                cn.Open();
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        private void Desconecar()
        {
            if(cn.State == System.Data.ConnectionState.Open)
            {
                cn.Close();
            }
        }
        public bool Executar(String sql)
        {
            bool resultado;
            if (Conectar())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
                    resultado = true;
                }
                catch
                {
                    resultado = false;
                }
                finally
                {
                    Desconectar();
                }
                return resultado;
            }
        }
    }
}
