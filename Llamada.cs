using System.Text;
namespace ModelosCentralita

{
    public class Llamada
    {
        // Atributos

        protected float duracion;
        protected string nroDestino;
        protected string nroOrigen;

        // Propiedades de Lectura
        public float Duracion { get => duracion;}
        public string NroDestino { get => nroDestino; }
        public string NroOrigen { get => nroOrigen;}

        // Constructor
        public Llamada(float duracion, string nroDestino, string nroOrigen)
        {
            this.duracion = duracion;
            this.nroDestino = nroDestino;
            this.nroOrigen = nroOrigen;
        }

        // Metodo Mostrar

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Numero de origen: {NroOrigen}");
            sb.AppendLine($"Numero de destino: {NroDestino}");
            sb.AppendLine($"Duracion: {Duracion}");

            return sb.ToString();
        }

        // Metodo estatico ordenar

        public static int OrdenarPorDuracion(Llamada llamada1, Llamada llamada2)
        {
            int retorno;

            if(llamada1.Duracion < llamada2.Duracion)
            {
                retorno = -1;
            }
            else if (llamada1.Duracion == llamada2.Duracion)
            {
                retorno = 0;
            }
            else
            {
                retorno = 1;
            }
            return retorno;
        }
    }
}
