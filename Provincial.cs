using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ModelosCentralita;


namespace ModelosCentralita
{
    public class Provincial:Llamada
    {
        // Atributos

        protected FranjaHoraria franja;


        // constructor

        public Provincial(float duracion, FranjaHoraria franja, string destino, string origen)
            : base(duracion, destino, origen)
        {
            this.franja = franja;
        }

        public Provincial (FranjaHoraria franja, Llamada ll1) : base(ll1.Duracion, ll1.NroDestino, ll1.NroOrigen)
        {
        }


        // Metodos

        private float CalcularCosto()
        {
            float multiplicador = 0f;

            switch (this.franja)
            {
                case FranjaHoraria.franja_1:
                    multiplicador = 0.99f;
                    break;
                case FranjaHoraria.franja_2:
                    multiplicador = 1.25f;
                    break;
                case FranjaHoraria.franja_3:
                    multiplicador = 0.66f;
                    break;

             }

            return base.Duracion * multiplicador;
        }

            // Propiedad

            public override float CostoLlamada
        {
            get => this.CalcularCosto();
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("\t\t---LLAMADA PROVINCIAL----");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"Franja Horaria: {this.franja}");
            sb.AppendLine($"Costo de la llamada: {CostoLlamada}");

            return sb.ToString();
        }


        // Metodo ToString
        public override string ToString()
        {
            return Mostrar();
        }

        // Metodo equals

        public override bool Equals(object? obj)
        {
            return obj is Provincial;
        }

    }
}
