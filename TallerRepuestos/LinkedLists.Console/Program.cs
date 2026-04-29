using DoubleList;

var list = new DoubleLinkedList<string>();
var option = string.Empty;
var value = string.Empty;

do
{
    option = Menu();
    switch (option)
    {
        case "1":
            Console.Write("Ingrese un repuesto: ");
            value = Console.ReadLine() ?? string.Empty;
            list.Add(value);
            break;

        case "2":
            list.ShowForward();
            break;

        case "3":
            list.ShowReverse();
            break;

        case "4":
            list.Sort();
            Console.WriteLine("Lista ordenada descendentemente.");
            break;

        case "5":
            var modes = list.GetModes();
            Console.WriteLine("Moda(s): " + string.Join(", ", modes));
            break;

        case "6":
            list.ShowChart();
            break;

        case "7":
            Console.Write("Ingrese un repuesto a buscar: ");
            value = Console.ReadLine() ?? string.Empty;
            Console.WriteLine(list.Exists(value)
                ? $"'{value}' existe en el inventario."
                : $"'{value}' NO existe en el inventario.");
            break;

        case "8":
            Console.Write("Ingrese el repuesto a eliminar (primera ocurrencia): ");
            value = Console.ReadLine() ?? string.Empty;
            if (list.Exists(value))
            {
                list.RemoveFirst(value);
                Console.WriteLine($"'{value}' eliminado correctamente.");
            }
            else
            {
                Console.WriteLine($"'{value}' NO existe en el inventario.");
            }
            break;

        case "9":
            Console.Write("Ingrese el repuesto a eliminar (todas las ocurrencias): ");
            value = Console.ReadLine() ?? string.Empty;
            if (list.Exists(value))
            {
                list.RemoveAll(value);
                Console.WriteLine($"Todas las ocurrencias de '{value}' eliminadas.");
            }
            else
            {
                Console.WriteLine($"'{value}' NO existe en el inventario.");
            }
            break;

        case "0":
            Console.WriteLine("Saliendo...");
            break;

        default:
            Console.WriteLine("Opción inválida. Intente de nuevo.");
            break;
    }
} while (option != "0");

string Menu()
{
    Console.WriteLine("\n=== Inventario Repuestos Chevrolet ===");
    Console.WriteLine("1. Adicionar repuesto");
    Console.WriteLine("2. Mostrar hacia adelante");
    Console.WriteLine("3. Mostrar hacia atrás");
    Console.WriteLine("4. Ordenar descendentemente");
    Console.WriteLine("5. Mostrar moda(s)");
    Console.WriteLine("6. Mostrar gráfico");
    Console.WriteLine("7. Existe");
    Console.WriteLine("8. Eliminar una ocurrencia");
    Console.WriteLine("9. Eliminar todas las ocurrencias");
    Console.WriteLine("0. Salir");
    Console.Write("Seleccione una opción: ");
    return Console.ReadLine() ?? string.Empty;
}