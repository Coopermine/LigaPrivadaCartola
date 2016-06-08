using System;
using System.ComponentModel;

namespace GettingStarted
{
	
    
    public class Ordem
    {
        private int codigo;
        private string time;
        private string jogador;
        private string posicao;
        private string escudo;
        private double pontos;

        public int Codigo
        {
            get { return codigo; }
            set { this.codigo = value; }
        }

        public string Time
        {
            get { return time; }
            set { this.time = value; }
        }

        public string Jogador
        {
            get { return jogador; }
            set { this.jogador = value; }
        }

        public string Posicao
        {
            get { return this.posicao; }
            set { this.posicao = value; }
        }

        public string Escudo
        {
            get { return this.escudo; }
            set { this.escudo = value; }
        }

        public double Pontos
        {
            get { return pontos; }
            set { this.pontos = value; }
        }

        public Ordem(int Codigo, string escudo, string time, string posicao, string jogador, double pontos)
        {
            this.Codigo = codigo;
            this.Escudo = escudo;
            this.Time = time;
            this.Posicao = posicao;
            this.Jogador = jogador;
            this.Pontos = pontos;
        }



    }

}

