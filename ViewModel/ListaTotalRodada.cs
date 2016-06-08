using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace GettingStarted
{
	public class ListaTotalRodada
    {
		private ObservableCollection<OrderInfoRodada> orderInfoRodada;

		public ObservableCollection<OrderInfoRodada> OrderInfoCollection {
			get { return orderInfoRodada; }
			set { this.orderInfoRodada = value; }
		}

		public ListaTotalRodada()
		{
			orderInfoRodada = new ObservableCollection<OrderInfoRodada> ();
			this.GenerateOrders ();
		}
   

       
        public DataTable dadosdat;

        static DataTable GetTabledat()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("posicao", typeof(int));
            table.Columns.Add("escudo", typeof(string));
            table.Columns.Add("nometime", typeof(string));
            table.Columns.Add("total", typeof(string));


            string posicao;
            string escudo;
            string nometime;
            string pontos;

            string jsonstring = BuscaValores();

            JArray v = JArray.Parse(jsonstring);

            int total = v.Count;
            int pos = 1;

            while (total > 0)
            {
                total = total - 1;
               
                nometime = (v[total]["nometime"].ToString());
                escudo = (v[total]["escudo"].ToString());
                pontos = (v[total]["total"].ToString()).Replace(".", ",");
                posicao = pos.ToString();
                pos++;

                table.Rows.Add(posicao,escudo,nometime,pontos);


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
                string pontos = row["total"].ToString();
                string pos = row["posicao"].ToString();
                //  double pontos = Convert.ToDouble(row["total"]);

                orderInfoRodada.Add(new OrderInfoRodada(pos, escudo, time,pontos));

                cod = cod + 1;

            }


        
        }
        static string BuscaValores()

        {

            using (var client = new WebClient())
            {
                var rss = client.DownloadString("http://s1-novacloud.cloudapp.net/cartola/rodada.php");
                return rss;
            }

           
      
        }
    }
}

