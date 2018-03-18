using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tome
{
    class Search
    {
        /// <summary>
        /// Executa uma pesquisa utilizando a API do Google 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>

        public static string Execute(string query)
        {
            try
            {
                const string apiKey = "AIzaSyCNAEY4TPrpQz94V7PGxg3YHqfrmkd-aFc";
                const string searchEngineId = "000804540536440671013:jgpbnqsfxcs";
                var customSearchService = new CustomsearchService(new BaseClientService.Initializer { ApiKey = apiKey });
                var listRequest = customSearchService.Cse.List(query);
                listRequest.Cx = searchEngineId;
                string consulta = null;

                //Console.WriteLine("Start...");
                // IList<Result> paging = new List<Result>();
                // var count = 0;
                //  while (paging != null && count <= 1)
                {
                    // Console.WriteLine($"Page {count}");
                    listRequest.Start = 0;
                    // paging =
                    Result t = listRequest.Execute().Items[0];
                    //if (paging != null)
                    // foreach (var item in paging)
                    consulta += "Título : " + t.Title + Environment.NewLine + "Link : " + t.Link +
                                        Environment.NewLine + Environment.NewLine;
                    // count++;

                }

                return consulta;
            }
            catch (Exception e)
            {
                throw new LimiteExcedidoException("Ultrapassei o limite de consultas diárias");
            }
        }

    }

    class LimiteExcedidoException : Exception
    {
        public LimiteExcedidoException()
        {
        }

        public LimiteExcedidoException(string message) : base(message)
        {
        }

        public LimiteExcedidoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LimiteExcedidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

}

