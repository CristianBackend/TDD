namespace MaquinaCafeProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
                // Inicialización de los componentes de la máquina de café
                var cafetera = new Cafetera();
                cafetera.SetCantidadDeCafe(100);

                var vasosPequenos = new Vaso();
                vasosPequenos.SetCantidadVasos(10);
                vasosPequenos.SetContenido(3);

                var vasosMedianos = new Vaso();
                vasosMedianos.SetCantidadVasos(10);
                vasosMedianos.SetContenido(5);

                var vasosGrandes = new Vaso();
                vasosGrandes.SetCantidadVasos(10);
                vasosGrandes.SetContenido(7);

                var azucarero = new Azucarero();
                azucarero.SetCantidadDeAzucar(20);

                var maquinaCafe = new MaquinaCafe(cafetera, vasosPequenos, vasosMedianos, vasosGrandes, azucarero);

                // Interacción con el usuario
                Console.WriteLine("¡Bienvenido a la Máquina de Café!");

                while (true)
                {
                    Console.WriteLine("\nPor favor, seleccione una opción:");
                    Console.WriteLine("1. Preparar un café");
                    Console.WriteLine("2. Salir");
                    Console.Write("Ingrese su opción (1 o 2): ");
                    string opcion = Console.ReadLine();

                    if (opcion == "1")
                    {
                        PrepararCafe(maquinaCafe);
                    }
                    else if (opcion == "2")
                    {
                        Console.WriteLine("Gracias por usar la Máquina de Café. ¡Adiós!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Opción inválida. Por favor, intente de nuevo.");
                    }
                }
            }

            static void PrepararCafe(MaquinaCafe maquinaCafe)
            {
                Console.WriteLine("\nSeleccione el tamaño del vaso:");
                Console.WriteLine("1. Pequeño (3 oz)");
                Console.WriteLine("2. Mediano (5 oz)");
                Console.WriteLine("3. Grande (7 oz)");
                Console.Write("Ingrese el número del tamaño del vaso: ");
                string tamaño = Console.ReadLine();

                string tipoDeVaso = tamaño switch
                {
                    "1" => "pequeño",
                    "2" => "mediano",
                    "3" => "grande",
                    _ => null
                };

                if (tipoDeVaso == null)
                {
                    Console.WriteLine("Tamaño inválido. Volviendo al menú principal.");
                    return;
                }

                Console.Write("\nIngrese la cantidad de cucharadas de azúcar (0-5): ");
                if (!int.TryParse(Console.ReadLine(), out int azucar) || azucar < 0 || azucar > 5)
                {
                    Console.WriteLine("Cantidad de azúcar inválida. Volviendo al menú principal.");
                    return;
                }

                string mensaje = maquinaCafe.GetVasoDeCafe(tipoDeVaso, 1, azucar);
                Console.WriteLine($"\n{mensaje}");
            }
    }
        }

