using ModelosCentralita;

namespace MainCentralita
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Crear una Centralita con una razón social.
            Console.WriteLine("1. Creando la Centralita con razón social...");
            Centralita c = new Centralita("Central Telefónica Asamblea");

            // 2. Crear al menos dos llamadas Local y dos Provincial, 
            // utilizando también los constructores que reciben una Llamada.
            Console.WriteLine("2. Creando las llamadas (Locales y Provinciales)...");

            // Llamadas Locales: (duracion, nroDestino, nroOrigen, costo)
            Local l1 = new Local(30.5f, "222222", "111111", 2.5f);
            Local l2 = new Local(15.0f, "444444", "333333", 1.2f);

            // Llamadas Provinciales: (duracion, franja, destino, origen)
            Provincial p1 = new Provincial(45.0f, FranjaHoraria.franja_1, "666666", "555555");

            // Usando el constructor que recibe la franja y una Llamada base (por ejemplo, l1)
            Provincial p2 = new Provincial(FranjaHoraria.franja_3, l1);

            // 3. Agregar las llamadas a la lista de la centralita
            //Console.WriteLine("3. Agregando las llamadas a la centralita...");
            //c.ListaDeLlamadas.Add(l1);
            //c.ListaDeLlamadas.Add(l2);
            //c.ListaDeLlamadas.Add(p1);
            //c.ListaDeLlamadas.Add(p2);


            // Agrego las llamadas a la lista que estan comentadas en el punto 3 con el operador +

            c += l1;
            c += l2;
            c += p1;
            c += p2;

            // Intento añadir una llamada repetida

            c += l2;

            // Comparo una llamada para verificar si el objeto llamada esta dentro de centralita
            Console.WriteLine("Comparo un objeto del tipo llamada con el objeto Centralita");
            if (c == l1)
            {
                Console.WriteLine("La llamada esta dentro de la lista");
            }

            // 4.a. Mostrar la primer centralita.
            Console.WriteLine("\n4. Mostrando la centralita sin ordenar con 4 llamadas");
            Console.WriteLine("========================================");
            Console.WriteLine(c.ToString());

            // Defino una nueva llamada
            Local l3 = new Local(50.0f, "999999", "888888", 3.0f);

            // Ahora comparo la nueva llamada con la lista de Centralita

            Console.WriteLine("Comparo la nueva llamada con la Centralita (si no esta, la agregamos)");

            if(c != l3)
            {
                Console.WriteLine("La nueva llamada no esta dentro de Centralita");
                c += l3;
            }

            // 4.b. Mostrar la centralita final antes y después de ordenar las llamadas.
            Console.WriteLine("\n4. Mostrando la centralita final ANTES de ordenar:");
            Console.WriteLine("========================================");
            Console.WriteLine(c.ToString());

            Console.WriteLine("Ordenando las llamadas por duración...");
            c.OrdenarLlamadas();

            Console.WriteLine("\nMostrando la centralita DESPUÉS de ordenar:");
            Console.WriteLine("========================================");
            Console.WriteLine(c.ToString());

            // 5. Verificar manualmente costos y ganancias.
            Console.WriteLine("5. Verificación de costos y ganancias finalizada.");
            Console.WriteLine("\nFin de la prueba. Presioná una tecla para salir.");
            Console.ReadKey();



        }
    }
}
