using System;
using System.Collections.Generic;
//Clase para identificar contactos
public class Contacto
{
    public string? Nombre { get; set; }
    public string? Telefono { get; set; }

}
// Clase para manejar la agenda de contactos
public class Agendac
{
    private List<Contacto> contactos = new List<Contacto>();
    //Método para agregar un contacto nuevo
    public void AgregarContacto(Contacto c)
    {
        contactos.Add(c);
        Console.WriteLine(" Contacto agregado correctamente");
    }
    // Método que muestra todos la lista de contactos
    public void MostrarContactos()
    {
        Console.WriteLine("\n Lista de Contactos: ");
        if (contactos.Count == 0)
        {
            Console.WriteLine(" No hay contactos en la agenda");
            return;
        }
        foreach (var c in contactos)
        {
            Console.WriteLine($"Nombre: {c.Nombre}, Teléfono: {c.Telefono}");

        }

    }
    // Método para buscar contactos mediante el nombre
    public void BuscarNombre(string nombre)
    {
        var encontrados = contactos.FindAll(c => 
            !string.IsNullOrEmpty(c.Nombre) && 
            c.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase));
        if (encontrados.Count == 0)
        {
            Console.WriteLine(" No se encontraron contactos con ese nombre.");
        }
        else
        {
            Console.WriteLine($"\n Resultados para \"{nombre}\":");
            foreach (var c in encontrados)
            {
                Console.WriteLine($"Nombre: {c.Nombre}, Teléfono: {c.Telefono}");
            }
        }
    }
}
// Clase principal para ejecitar el programa
class Program
{
    static void Main()
    {
        Agendac agenda = new Agendac();
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\n--- Agenda Telefónica ---");
            Console.WriteLine("1. Agregar contacto");
            Console.WriteLine("2. Mostrar contactos");
            Console.WriteLine("3. Buscar contacto por nombre");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine() ?? "";

            switch (opcion)
            {
                case "1":
                    Contacto c = new Contacto();
                    Console.Write("Ingrese nombre: ");
                    c.Nombre = Console.ReadLine();
                    Console.Write("Ingrese teléfono: ");
                    c.Telefono = Console.ReadLine();
                    agenda.AgregarContacto(c);
                    break;
                case "2":
                    agenda.MostrarContactos();
                    break;
                case "3":
                    Console.Write("Ingrese nombre a buscar: ");
                    string nombre = Console.ReadLine() ?? "";
                    agenda.BuscarNombre(nombre);
                    break;
                case "4":
                    continuar = false;
                    Console.WriteLine(" Gracias por usar la Agenda Telefónica.");
                    break;
                default:
                    Console.WriteLine(" Opción inválida, intente de nuevo.");
                    break;
            }
        }
    }
}