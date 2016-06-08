using System;
using System.ComponentModel;

namespace GettingStarted
{
	

	    public class OrderInfoRodada
    {
        private string posicao;
        private string time;
        private string escudo;
        private string pontos;

        public string Posicao
        {
            get { return posicao; }
            set { this.posicao = value; }
        }

        public string Escudo
        {
            get { return this.escudo; }
            set { this.escudo = value; }
        }

        public string Time
        {
            get { return time; }
            set { this.time = value; }
        }

      
     
        public string Pontos
        {
            get { return pontos; }
            set { this.pontos = value; }
        }

        public OrderInfoRodada(string Posicao, string escudo, string time, string pontos)
        {
            this.Posicao = Posicao;
            this.Escudo = escudo;
            this.Time = time;
            this.Pontos = pontos;
        }



    }

}

