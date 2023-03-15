using Dapper;
using MySqlConnector;
using System.Collections.Generic;
using System.Data;

namespace ContaOnline.Repository
{
    public static class Db
    {
        private static string _conexao = "server=localhost;port=3306;database=contadb;user=root;password=root;";

        private static MySqlConnection ObterConexao()
        {
            var cn = new MySqlConnection(_conexao);
            return cn;
        }

        public static int Executar(string query, object param, CommandType commandType = CommandType.StoredProcedure)
        {
            int total;
            using (var cn = ObterConexao())
            {
                total = cn.Execute(query, param, commandType: commandType);
            }
            return total;
        }

        public static T QueryEntidade<T>(string query, object param, CommandType commandType = CommandType.StoredProcedure)
        {
            T retorno;

            using (var cn = ObterConexao())
            {
                retorno = cn.QueryFirstOrDefault<T>(query, param, commandType: commandType);
            }
            return retorno;
        }

        public static IEnumerable<T> QueryColecao<T>(string query, object param, CommandType commandType = CommandType.StoredProcedure)
        {
            IEnumerable<T> retorno;
            using (var cn = ObterConexao())
            {
                retorno = cn.Query<T>(query, param, commandType: commandType);
            }
            return retorno;
        }
    }
}
