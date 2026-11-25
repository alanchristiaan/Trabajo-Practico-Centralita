using ModelosCentralita;


namespace CentralitaExcepciones
{
    public class Excepciones
    {

        static void Main(string[] args)
        {

            Centralita c = new Centralita("Central Telefonica Asamblea Excepciones");
            Local l1 = new Local(25.5f, "1168497391", "1154789423", 2.9f);

            // Agregamos la llamada a la centralita c += l1
            c += l1;


            Console.WriteLine("CENTRALITA EXCEPCIONES");

            // -------------------------------------------------------------------------
            // PUNTO 2: Prueba de llamada duplicada (Operador +)
            // -------------------------------------------------------------------------
            try
            {
                Console.WriteLine("Intentamos añadir una llamada a la lista: c += l2");
                c += l1; // Intentamos agregar una llamada que ya existe
            }
            catch (CentralitaException ex)
            {
                Console.WriteLine("Al no poder añadirla va a desplegar los siguientes mensajes");
                Console.WriteLine($"- Mensaje: {ex.Message}");
                Console.WriteLine($"- Clase: {ex.NombreClase}");
                Console.WriteLine($"- Método: {ex.NombreMetodo}");
            }
            // -------------------------------------------------------------------------
            // PRUEBA 2: Duración negativa en constructor
            // -------------------------------------------------------------------------

            Console.WriteLine("Intentamos agregar una llamada con duracion negativa: \n Local lDuracionNegativa = new Local(-10.0f, \"222222\", \"111111\", 2.5f);");
            try
            {
                Local lDuracionNegativa = new Local(-10.0f, "222222", "111111", 2.5f);
            }
            catch (CentralitaException ex)
            {
                Console.WriteLine($"[Duracion negativa atrapada]:");
                Console.WriteLine($"- Mensaje: {ex.Message}");
                Console.WriteLine($"- Clase: {ex.NombreClase}");
                Console.WriteLine($"- Metodo : {ex.NombreMetodo}");
            }

            // -------------------------------------------------------------------------
            // PRUEBA 3: Costo negativo en constructor
            // -------------------------------------------------------------------------

            Console.WriteLine("Intentamos agregar una llamada con costo negativo: \nLocal lCostoNegativo = new Local(15.0f, \"222222\", \"111111\", -1.5f);");
            try
            {
                Local lCostoNegativo = new Local(15.0f, "222222", "111111", -1.5f);
            }
            catch (CentralitaException ex)
            {
                Console.WriteLine($"[Costo inválido atrapado]:");
                Console.WriteLine($"- Mensaje: {ex.Message}");
                Console.WriteLine($"- Clase: {ex.NombreClase}");
                Console.WriteLine($"- Metodo : {ex.NombreMetodo}");
            }

            // -------------------------------------------------------------------------
            // PRUEBA 4: Propagacion y encapsulamiento
            // -------------------------------------------------------------------------

            // Instanciamos una centralita y una llamada y agregamos la llamada a la centralita


            Console.WriteLine("Instanciamos una nueva centralita y una nueva llamada y añadimos la llamada a la centralita");
            Centralita c2 = new Centralita("Nueva centralita asamblea");
            Provincial llamadaProv = new Provincial(42.5f, FranjaHoraria.franja_2, "1145678900", "1133445566");

            c2 += llamadaProv;


            // intentamos agregar nuevamente la llamada a la centralita pero con el metodo registrar llamada
            try
            {
                RegistrarLlamada(c2, l1);
                RegistrarLlamada(c2, llamadaProv);
                Console.WriteLine("Ambas se cargaron en centralita2.");
            }
            catch (CentralitaException ex)
            {
                Console.WriteLine($"Falló el registro en centralita2: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Cierre del intento sobre centralita2.");
                Console.WriteLine($"centralita 2: {c2.ToString()}");
            }

            // -------------------------------------------------------------------------
            // PRUEBA 5; Inner Exception
            // -------------------------------------------------------------------------

            Console.WriteLine("Prueba 5: inner exception");
            try
            {
                ProbarConversacionInvalida("abc123");
            }
            catch (CentralitaException ex)
            {
                Console.WriteLine($"Mensaje: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Tipo original: {ex.InnerException.GetType()}");
                }
            }

        }

        // -------------------------------------------------------------------------
        // PRUEBA 5; Inner Exception
        // -------------------------------------------------------------------------

        // Agregamos un metodo auxiliar llamado ProbarConversacionInvalida(string dato) fuera del main y luego probamos un pedido dentro del main
        static float ProbarConversacionInvalida(string dato)
        {
            try
            {
                return float.Parse(dato);
            }
            catch (FormatException ex)
            {
                throw new CentralitaException("Error al convertir el dato a numero", "Program", "ProbarConversionInvalida", ex);
            }
        }
        static void RegistrarLlamada (Centralita centralita, Llamada llamada)
        {
            centralita += llamada;
        }

        


       
    }
}
