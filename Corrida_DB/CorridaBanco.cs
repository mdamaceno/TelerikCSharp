using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrida_DB
{
    public class CorridaBanco
    {
        private static CorridaModel _instance = null;

        private static string StringConexao = "persist security info=false;server=localhost;database=calendariocorridas;uid=root;pwd=aluno";
        public static CorridaModel Model
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CorridaModel(StringConexao);
                }

                return _instance;
            }
        }
    }
}
