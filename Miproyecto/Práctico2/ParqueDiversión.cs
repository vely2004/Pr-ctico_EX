//Simula una línea de espera para una atracción en un parque de diversiones.
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
// Esta clase representa a una persona que quiere subirse al juego del parque.
class Persona
{
    public string Nombre { get; set; }
    public Persona(string nombre)
    {
        Nombre = nombre;
    }
}
//Clase que representa los asientos de la atracción o juego.
class Juego
{
    //Cola para guardar asientos en orden de llegada
    private Queue<Persona> cola = new Queue<Persona>();
    //Lista para almacenar personas que ya están sentadas en la atracción
    private List<Persona> asientos = new List<Persona>();
    //Constante que define la cantidad máxima de asientos
    private const int CapacidadMax = 30;
    //Método para registrar una persona en la cola
    public void RegistrarPersona(string nombre)
    {
        if (asientos.Count < CapacidadMax)
        {
            Persona nueva = new Persona(nombre);
            cola.Enqueue(nueva);
            Console.WriteLine($"{nombre} se ha registrado en la cola ");
        }
        else
        {
            Console.WriteLine($"No hay más asientos disponibles. {nombre} no puede entrar.");
        }
    }
    //Método para asignar los asientos disponibles a las personas de la cola
    public void AsignarAsientos()
    {
        // Mientras haya personas en cola y espacio en los asientos
        if (cola.Count == 0)
        {
            Console.WriteLine("No hay personas para subir al juego.");
            return;
        }
        while (cola.Count > 0 && asientos.Count < CapacidadMax)
            {
                Persona p = cola.Dequeue();
                asientos.Add(p);
                Console.WriteLine($" {p.Nombre} se ha asignado un asiento");
            }
        //En caso de asiento llenos completamente
        if (asientos.Count == CapacidadMax)
        {
            Console.WriteLine("Todos los asientos han sido ocupados");
        }
    }
    // Método que muestra el estado actual de la atracción o juego
    public void MostrarEstado()
    {
        Console.WriteLine($"\n Personas registradas: {asientos.Count + cola.Count}");
        Console.WriteLine($"Asientos ocupados: {asientos.Count}");
        Console.WriteLine($"Asientos disponibles: {CapacidadMax - asientos.Count}");
        //Muestra orden de ingreso de quienes ya subieron
        Console.WriteLine("\n Orden de ingreso:");
        for (int i = 0; i < asientos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {asientos[i].Nombre}");
        }
        //Muestra quienes siguen esperando en la cola
        Console.WriteLine("\n Personas esperando: ");
        foreach (var persona in cola)
        {
            Console.WriteLine($"- {persona.Nombre}");
        }
    }
}
//Clase que contiene main para ejecutar el programa
class Program
{
    static void Main()
    {
        Juego juego = new Juego();
        bool continuar = true;
        //Bucle del menú
        while (continuar)
        {
            //Menú principal
            Console.WriteLine("\n------Sistema de asignación------");
            Console.WriteLine("1. Registrar Persona");
            Console.WriteLine("2. Asignar asientos");
            Console.WriteLine("3. Mostrar Registro");
            Console.WriteLine("4. Salir");
            Console.WriteLine("Selecciona una opción");
            string opcion = Console.ReadLine() ?? "";
            //Evaluación de opción ingresada
            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese nombre de la persona: ");
                    string nombre = Console.ReadLine() ?? "";
                    juego.RegistrarPersona(nombre);
                    break;
                case "2":
                    juego.AsignarAsientos();
                    break;
                case "3":
                    juego.MostrarEstado();
                    break;
                case "4":
                    continuar = false;
                    Console.WriteLine("Gracias por usar el sistema.");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción Inválida");
                    break;
            }

        }
    }
}
