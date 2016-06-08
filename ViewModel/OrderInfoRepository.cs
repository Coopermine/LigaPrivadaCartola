using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Net;

namespace GettingStarted
{
	public class OrderInfoRepository
	{
		private ObservableCollection<Ordem> orderInfo;

		public ObservableCollection<Ordem> OrderInfoCollection {
			get { return orderInfo; }
			set { this.orderInfo = value; }
		}

		public OrderInfoRepository ()
		{
			orderInfo = new ObservableCollection<Ordem> ();
			this.GenerateOrders ();
		}
        static DataTable GetTable()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("codigo", typeof(int));
            table.Columns.Add("escudo", typeof(string));
            table.Columns.Add("time", typeof(string));
            table.Columns.Add("posicao", typeof(string));
            table.Columns.Add("nome", typeof(string));
            table.Columns.Add("pontos", typeof(double));

            // Here we add five DataRows.
            table.Rows.Add(1, "VAS", "BAR DO BETO", "SAG", "Nene", "2,2");
            table.Rows.Add(2, "VAS", "BAR DO BETO", "SAG", "Andrezinho", "6,24");
            table.Rows.Add(3, "VAS", "ALVARO FC", "SAG", "Ricardinho", "8,2");
            table.Rows.Add(4, "VAS", "ALVARO FC", "SAG", "Luan", "7,8");
            table.Rows.Add(5, "VAS", "ALVARO FC", "SAG", "Grafite", "7,2");

            return table;
        }

        public DataTable dados;
        public DataTable dadosdat;

        static DataTable GetTabledat()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("nomejogador", typeof(string));
            table.Columns.Add("nometime", typeof(string));
            table.Columns.Add("escudo", typeof(string));
            table.Columns.Add("jogador_pontos", typeof(double));
            table.Columns.Add("jogador_posicao", typeof(string));
            table.Columns.Add("clube_escudo", typeof(string));
            table.Columns.Add("slug", typeof(string));

          

            string datnometime;
            string datescudo;
            string datjogador_pontos;
            string datjogador_posicao;
            string datclube_escudo;
            string datslug;
            string nomejogador;

            string jsonstring = BuscaValores();

            JArray v = JArray.Parse(jsonstring);

            int total = v.Count;
        
            while (total > 0)
            {
                total = total - 1;

                nomejogador = (v[total]["jogador_apelido"].ToString());
                datnometime = (v[total]["nometime"].ToString());
                datescudo = v[total]["escudo"].ToString();
                datjogador_pontos =  v[total]["jogador_pontos"].ToString().Replace(".", ",");
                datjogador_posicao = v[total]["jogador_posicao"].ToString();
                datclube_escudo = v[total]["clube_escudo"].ToString();
                datslug = v[total]["slug"].ToString();

                table.Rows.Add(nomejogador, datnometime, datescudo, datjogador_pontos, datjogador_posicao, datclube_escudo, datslug);


            }

            return table;
        }

   




        private void GenerateOrders ()
		{

          dadosdat = GetTabledat();
            Int32 cod = 1;
            foreach (DataRow row in dadosdat.Rows)
            {
                // ... Write value of first field as integer.
                
                string escudo = row["escudo"].ToString();
                string time = row["nometime"].ToString();
                string nome = row["nomejogador"].ToString();
                double pontos = Convert.ToDouble(row["jogador_pontos"]);
                string posicao = row["jogador_posicao"].ToString();
            
                orderInfo.Add(new Ordem(cod, escudo, time, posicao, nome, pontos));

                cod = cod + 1;

            }


        
        }
        static string BuscaValores()

        {
            WebRequest request = WebRequest.Create(
              "http://s1-novacloud.cloudapp.net/cartola/get.php");
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            return (responseFromServer);
            // Clean up the streams and the response.
            reader.Close();
            response.Close();
        }
    }
}

