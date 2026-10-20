using System;
using System.Collections.Generic;
using System.Text;
using ModelosCentralita;

namespace ModelosCentralita
{
    public class Local:Llamada
    {
        // Atributos
        protected float costo;


        // Constructor

        public Local (float duracion, string nroDestino, string nroOrigen, float costo):base(duracion, nroDestino, nroOrigen)
        {
            this.costo = costo;
        }

        public Local (Llamada llamada1, float costo): this(llamada1.Duracion, llamada1.NroDestino, llamada1.NroOrigen, costo)
        {
        }


        // Metodo CalcularCosto

        private float CalcularCosto()
        {
            return this.Duracion * this.costo;
        }

        // Propiedad de metodo
        public float CostoLlamada
        {
            get => this.CalcularCosto();
        }

        // Metodo Mostrar

        public new string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("\t\t---LLAMADA LOCAL----");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"Costo de la llamada: {CostoLlamada}");

            return sb.ToString();
        }
    }
}
