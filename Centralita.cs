using System;
using System.Collections.Generic;
using System.Text;
using ModelosCentralita;

namespace ModelosCentralita
{
    public class Centralita
    {
        private List<Llamada> listaDeLlamadas;
        private string razonSocial = string.Empty;

        public Centralita()
        {
            listaDeLlamadas = new List<Llamada>();
        }

        public Centralita(string razonSocial) : this()
        {
            this.razonSocial = razonSocial;
        }


        //Propiedad de lista
        public List<Llamada> ListaDeLlamadas { get => listaDeLlamadas; }

        // Metodo CalcularGanancia

        private float CalcularGanancia(TipoLlamada tipo)
        {
            float gananciaTotal = 0;

            foreach (Llamada llamada in this.listaDeLlamadas)
            {
                switch (tipo)
                {
                    case TipoLlamada.Local:
                        if (llamada is Local)
                        {
                            Local l = (Local)llamada;
                            gananciaTotal += l.CostoLlamada;
                        }
                        break;

                    case TipoLlamada.Provincial:
                        if (llamada is Provincial)
                        {
                            Provincial p = (Provincial)llamada;
                            gananciaTotal += p.CostoLlamada;
                        }
                        break;

                    case TipoLlamada.Todas:
                        if (llamada is Local)
                        {
                            gananciaTotal += ((Local)llamada).CostoLlamada;
                        }
                        else if (llamada is Provincial)
                        {
                            gananciaTotal += ((Provincial)llamada).CostoLlamada;
                        }
                        break;
                }
            }

            return gananciaTotal;
        }


        // Properties del metodo CalcularGanancia

        public float GananciaPorLocal
        {
            get => this.CalcularGanancia(TipoLlamada.Local);
        }

        public float GananciaPorProvincial
        {
            get => this.CalcularGanancia(TipoLlamada.Provincial);
        }

        public float GananciaPorTotal
        {
            get => this.CalcularGanancia(TipoLlamada.Todas);
        }


        // Metodo OrdenarPorDuracion

        public void OrdenarLlamadas()
        {
            this.listaDeLlamadas.Sort(Llamada.OrdenarPorDuracion);
        }


        // Metodo Mostrar

        protected string Mostrar()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine($"Razón Social: {this.razonSocial}");
            sb.AppendLine($"Facturación Total: {this.GananciaPorTotal}");
            sb.AppendLine($"Facturación Local: {this.GananciaPorLocal}");
            sb.AppendLine($"Facturación Provincial: {this.GananciaPorProvincial}");
            sb.AppendLine("========================================");
            sb.AppendLine("DETALLE DE LLAMADAS:");

            // 2. Recorremos la lista y dejamos que cada objeto se muestre solo
            foreach (Llamada llamada in this.listaDeLlamadas)
            {
                // Llamamos al Mostrar() que le corresponda a cada objeto
                sb.AppendLine(llamada.ToString());

                // Validamos para poner los guiones donde corresponda según el tipo
                if (llamada is Local)
                {
                    sb.AppendLine($"Ganancia provincial: --------");
                }
                else if (llamada is Provincial)
                {
                    sb.AppendLine($"Ganancia local: --------");
                }

                sb.AppendLine("----------------------------------------");
            }

            return sb.ToString();
        }


        // Metodo ToString
        public override string ToString()
        {
            return Mostrar();
        }

        // Metodo Agregar Llamada

        private void AgregarLlamada(Llamada nuevaLlamada)
        {
            this.ListaDeLlamadas.Add(nuevaLlamada);
        }

        public static bool operator ==(Centralita c, Llamada llamada)
        {
            bool bandera = false;
            
            foreach(Llamada item in c.ListaDeLlamadas)
            {
                if (item == llamada)
                {
                    bandera = true;
                    break;
                }
            }
            return bandera;
        }

        public static bool operator !=(Centralita c, Llamada llamada)
        {
            return !(c == llamada);
        }


        // Sobrecarga de operador +

        public static Centralita operator +(Centralita c, Llamada nuevallamada)
        {
            if (c != nuevallamada)
            {
                c.AgregarLlamada(nuevallamada);
            }

            return c;
        }
    }
}

