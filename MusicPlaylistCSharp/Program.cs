using System;
using MusicPlaylistCSharp.Managers;
using MusicPlaylistCSharp.Models;

class Program
{
    private static PlaylistManager? manager;

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        try
        {
            manager = new PlaylistManager();
            MostrarBienvenida();
            MenuPrincipal();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n✗ Error crítico en la aplicación: {ex.Message}");
            Console.WriteLine("La aplicación se cerrará.");
        }
    }

    private static void MostrarBienvenida()
    {
        Console.WriteLine("===========================================");
        Console.WriteLine("   SISTEMA DE PLAYLIST MUSICAL - ABB");
        Console.WriteLine("===========================================");
        Console.WriteLine("Equipo: Yeng Lee Salas Jimenez, [Integrante 2], [Integrante 3]");
        Console.WriteLine("Grupo: 4 E | Programa: DSM");
        Console.WriteLine("===========================================\n");
    }

    private static void MenuPrincipal()
    {
        int opcion = -1;

        do
        {
            MostrarMenu();

            try
            {
                Console.Write("Seleccione una opción: ");
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("\n✗ Error: Debe ingresar una opción.");
                    EsperarEnter();
                    continue;
                }

                if (!int.TryParse(input, out opcion))
                {
                    Console.WriteLine("\n✗ Error: Debe ingresar un número válido.");
                    EsperarEnter();
                    continue;
                }

                Console.WriteLine();
                ProcesarOpcion(opcion);

                if (opcion != 0)
                {
                    EsperarEnter();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\n✗ Error: Formato de entrada inválido.");
                EsperarEnter();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Error inesperado: {ex.Message}");
                EsperarEnter();
            }

        } while (opcion != 0);

        Console.WriteLine("\n¡Gracias por usar el Sistema de Playlist Musical!");
        Console.WriteLine("===========================================\n");
    }

    private static void MostrarMenu()
    {
        Console.WriteLine("\n===========================================");
        Console.WriteLine("           MENÚ PRINCIPAL");
        Console.WriteLine("===========================================");
        Console.WriteLine("1.  Agregar canción");
        Console.WriteLine("2.  Buscar canción por ID");
        Console.WriteLine("3.  Eliminar canción");
        Console.WriteLine("4.  Mostrar playlist ordenada (Inorden)");
        Console.WriteLine("5.  Mostrar recorrido Preorden");
        Console.WriteLine("6.  Mostrar recorrido Postorden");
        Console.WriteLine("7.  Mostrar recorrido por Niveles");
        Console.WriteLine("8.  Mostrar todos los recorridos");
        Console.WriteLine("9.  Mostrar altura del árbol");
        Console.WriteLine("10. Consultar nivel de una canción");
        Console.WriteLine("11. Mostrar estadísticas completas");
        Console.WriteLine("12. Cargar canciones de prueba");
        Console.WriteLine("0.  Salir");
        Console.WriteLine("===========================================");
    }

    private static void ProcesarOpcion(int opcion)
    {
        if (manager == null)
        {
            Console.WriteLine("✗ Error: El gestor de playlist no está inicializado.");
            return;
        }

        switch (opcion)
        {
            case 1:
                AgregarCancion();
                break;
            case 2:
                BuscarCancion();
                break;
            case 3:
                EliminarCancion();
                break;
            case 4:
                manager.MostrarPlaylistOrdenada();
                break;
            case 5:
                MostrarRecorridoPreorden();
                break;
            case 6:
                MostrarRecorridoPostorden();
                break;
            case 7:
                MostrarRecorridoPorNiveles();
                break;
            case 8:
                manager.MostrarTodosLosRecorridos();
                break;
            case 9:
                MostrarAltura();
                break;
            case 10:
                ConsultarNivel();
                break;
            case 11:
                manager.MostrarEstadisticas();
                break;
            case 12:
                CargarCancionesDePrueba();
                break;
            case 0:
                // Salir
                break;
            default:
                Console.WriteLine("✗ Opción inválida. Por favor, seleccione una opción del menú.");
                break;
        }
    }

    private static void AgregarCancion()
    {
        Console.WriteLine("--- AGREGAR CANCIÓN ---\n");

        try
        {
            Console.Write("ID: ");
            string? idInput = Console.ReadLine();
            if (!int.TryParse(idInput, out int id))
            {
                Console.WriteLine("\n✗ Error: El ID debe ser un número entero.");
                return;
            }

            Console.Write("Título: ");
            string? titulo = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(titulo))
            {
                Console.WriteLine("\n✗ Error: El título no puede estar vacío.");
                return;
            }

            Console.Write("Artista: ");
            string? artista = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(artista))
            {
                Console.WriteLine("\n✗ Error: El artista no puede estar vacío.");
                return;
            }

            Console.Write("Duración (segundos): ");
            string? duracionInput = Console.ReadLine();
            if (!int.TryParse(duracionInput, out int duracion))
            {
                Console.WriteLine("\n✗ Error: La duración debe ser un número entero.");
                return;
            }

            Console.Write("Popularidad (0-100): ");
            string? popularidadInput = Console.ReadLine();
            if (!int.TryParse(popularidadInput, out int popularidad))
            {
                Console.WriteLine("\n✗ Error: La popularidad debe ser un número entero.");
                return;
            }

            Song cancion = new Song(id, titulo, artista, duracion, popularidad);
            manager?.AgregarCancion(cancion);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"\n✗ Error de validación: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n✗ Error inesperado: {ex.Message}");
        }
    }

    private static void BuscarCancion()
    {
        Console.WriteLine("--- BUSCAR CANCIÓN ---\n");

        try
        {
            Console.Write("Ingrese el ID de la canción: ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("\n✗ Error: Debe ingresar un número válido.");
                return;
            }

            manager?.BuscarCancion(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n✗ Error: {ex.Message}");
        }
    }

    private static void EliminarCancion()
    {
        Console.WriteLine("--- ELIMINAR CANCIÓN ---\n");

        try
        {
            Console.Write("Ingrese el ID de la canción a eliminar: ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("\n✗ Error: Debe ingresar un número válido.");
                return;
            }

            manager?.EliminarCancion(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n✗ Error: {ex.Message}");
        }
    }

    private static void MostrarRecorridoPreorden()
    {
        if (manager?.EstaVacia() == true)
        {
            Console.WriteLine("\n✗ La playlist está vacía.");
            return;
        }

        Console.WriteLine("\n=== RECORRIDO PREORDEN ===");
        Console.WriteLine("(Nodo → Izquierdo → Derecho)\n");

        manager?.MostrarTodosLosRecorridos();
    }

    private static void MostrarRecorridoPostorden()
    {
        if (manager?.EstaVacia() == true)
        {
            Console.WriteLine("\n✗ La playlist está vacía.");
            return;
        }

        Console.WriteLine("\n=== RECORRIDO POSTORDEN ===");
        Console.WriteLine("(Izquierdo → Derecho → Nodo)\n");

        manager?.MostrarTodosLosRecorridos();
    }

    private static void MostrarRecorridoPorNiveles()
    {
        if (manager?.EstaVacia() == true)
        {
            Console.WriteLine("\n✗ La playlist está vacía.");
            return;
        }

        Console.WriteLine("\n=== RECORRIDO POR NIVELES ===");
        Console.WriteLine("(Amplitud / BFS)\n");

        manager?.MostrarTodosLosRecorridos();
    }

    private static void MostrarAltura()
    {
        if (manager?.EstaVacia() == true)
        {
            Console.WriteLine("\n✗ La playlist está vacía.");
            return;
        }

        manager?.MostrarEstadisticas();
    }

    private static void ConsultarNivel()
    {
        Console.WriteLine("--- CONSULTAR NIVEL DE CANCIÓN ---\n");

        try
        {
            Console.Write("Ingrese el ID de la canción: ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("\n✗ Error: Debe ingresar un número válido.");
                return;
            }

            manager?.ConsultarNivelCancion(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n✗ Error: {ex.Message}");
        }
    }

    private static void CargarCancionesDePrueba()
    {
        Console.WriteLine("--- CARGANDO CANCIONES DE PRUEBA ---\n");

        try
        {
            Song[] cancionesPrueba = {
                new Song(5, "Stairway to Heaven", "Led Zeppelin", 482, 95),
                new Song(3, "Hotel California", "Eagles", 391, 92),
                new Song(7, "Imagine", "John Lennon", 183, 96),
                new Song(1, "Bohemian Rhapsody", "Queen", 354, 98),
                new Song(4, "Smells Like Teen Spirit", "Nirvana", 301, 94),
                new Song(6, "Sweet Child O' Mine", "Guns N' Roses", 356, 93),
                new Song(2, "Hey Jude", "The Beatles", 431, 97)
            };

            int agregadas = 0;
            foreach (Song cancion in cancionesPrueba)
            {
                try
                {
                    manager?.AgregarCancion(cancion);
                    agregadas++;
                }
                catch
                {
                    // Ignorar errores de duplicados
                }
            }

            Console.WriteLine($"\n✓ Se cargaron {agregadas} canciones de prueba.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n✗ Error al cargar canciones de prueba: {ex.Message}");
        }
    }

    private static void EsperarEnter()
    {
        Console.Write("\nPresione Enter para continuar...");
        Console.ReadLine();
    }
}
