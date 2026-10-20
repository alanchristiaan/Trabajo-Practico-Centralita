using System.Text;
namespace ModelosCentralita

{
    public abstract class Llamada
    {
        // Atributos

        protected float duracion;
        protected string nroDestino;
        protected string nroOrigen;


        // Propiedades de Lectura
        public float Duracion { get => duracion;}
        public string NroDestino { get => nroDestino; }
        public string NroOrigen { get => nroOrigen;}
        public abstract float CostoLlamada { get; }

        // Constructor
        public Llamada(float duracion, string nroDestino, string nroOrigen)
        {
            this.duracion = duracion;
            this.nroDestino = nroDestino;
            this.nroOrigen = nroOrigen;
        }

        // Metodo Mostrar

        public virtual string Mostrar()
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

        // Sobrecarga de operadores == y !=

        public static bool operator ==(Llamada ll1, Llamada ll2)
        {
            bool bandera = false;

            if (ll1 is not null && ll2 is not null)
            {
                bandera = ll1.Equals(ll2) && ll1.NroOrigen == ll2.NroOrigen && ll1.NroDestino == ll2.NroDestino;
            }
            else if(ll1 is null && ll2 is null)
            {
                bandera = true;
            }
            return bandera;
        }

        public static bool operator !=(Llamada ll1, Llamada ll2)
        {
            return !(ll1 == ll2);
        }

        
    }
}
