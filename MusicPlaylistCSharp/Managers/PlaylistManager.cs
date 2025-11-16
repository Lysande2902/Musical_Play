using System;
using System.Collections.Generic;
using MusicPlaylistCSharp.DataStructures;
using MusicPlaylistCSharp.Models;

namespace MusicPlaylistCSharp.Managers
{
    public class PlaylistManager
    {
        private readonly BinarySearchTree arbol;

        public PlaylistManager()
        {
            this.arbol = new BinarySearchTree();
        }

        // Agregar canción con validaciones y manejo de errores
        public void AgregarCancion(Song cancion)
        {
            try
            {
                if (cancion == null)
                {
                    Console.WriteLine("✗ Error: La canción no puede ser nula.");
                    return;
                }

                bool insertado = arbol.Insertar(cancion);

                if (insertado)
                {
                    Console.WriteLine("✓ Canción agregada exitosamente!");
                    Console.WriteLine($"  {cancion}");
                }
                else
                {
                    Console.WriteLine($"✗ Error: Ya existe una canción con el ID {cancion.Id}");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"✗ Error de validación: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"✗ Error de operación: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error inesperado: {ex.Message}");
            }
        }

        // Buscar canción por ID con manejo de errores
        public void BuscarCancion(int id)
        {
            try
            {
                Song? cancion = arbol.Buscar(id);

                if (cancion != null)
                {
                    Console.WriteLine("\n✓ Canción encontrada:");
                    Console.WriteLine($"  {cancion}");
                    
                    int nivel = arbol.ObtenerNivelDeNodo(id);
                    Console.WriteLine($"  Nivel en el árbol: {nivel}");
                }
                else
                {
                    Console.WriteLine($"\n✗ No se encontró ninguna canción con el ID {id}");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"✗ Error de validación: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"✗ Error de operación: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error inesperado: {ex.Message}");
            }
        }

        // Eliminar canción por ID con manejo de errores
        public void EliminarCancion(int id)
        {
            try
            {
                Song? cancion = arbol.Buscar(id);

                if (cancion == null)
                {
                    Console.WriteLine($"\n✗ No se encontró ninguna canción con el ID {id}");
                    return;
                }

                Console.WriteLine($"\nEliminando: {cancion}");
                bool eliminado = arbol.Eliminar(id);

                if (eliminado)
                {
                    Console.WriteLine("✓ Canción eliminada exitosamente!");
                }
                else
                {
                    Console.WriteLine("✗ Error al eliminar la canción.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"✗ Error de validación: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"✗ Error de operación: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error inesperado: {ex.Message}");
            }
        }

        // Mostrar playlist ordenada (Inorden)
        public void MostrarPlaylistOrdenada()
        {
            try
            {
                if (arbol.EstaVacio())
                {
                    Console.WriteLine("\n✗ La playlist está vacía.");
                    return;
                }

                Console.WriteLine("\n=== PLAYLIST ORDENADA (Inorden) ===");
                List<Song> canciones = arbol.RecorridoInorden();

                for (int i = 0; i < canciones.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {canciones[i]}");
                }
                Console.WriteLine("===================================\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error al mostrar la playlist: {ex.Message}");
            }
        }

        // Mostrar todos los recorridos
        public void MostrarTodosLosRecorridos()
        {
            try
            {
                if (arbol.EstaVacio())
                {
                    Console.WriteLine("\n✗ La playlist está vacía.");
                    return;
                }

                Console.WriteLine("\n========== RECORRIDOS DEL ÁRBOL ==========\n");

                // Inorden
                Console.WriteLine("--- INORDEN (Izq → Nodo → Der) ---");
                List<Song> inorden = arbol.RecorridoInorden();
                MostrarListaCanciones(inorden);

                // Preorden
                Console.WriteLine("\n--- PREORDEN (Nodo → Izq → Der) ---");
                List<Song> preorden = arbol.RecorridoPreorden();
                MostrarListaCanciones(preorden);

                // Postorden
                Console.WriteLine("\n--- POSTORDEN (Izq → Der → Nodo) ---");
                List<Song> postorden = arbol.RecorridoPostorden();
                MostrarListaCanciones(postorden);

                // Por niveles
                Console.WriteLine("\n--- POR NIVELES (Amplitud/BFS) ---");
                List<Song> niveles = arbol.RecorridoPorNiveles();
                MostrarListaCanciones(niveles);

                Console.WriteLine("\n==========================================\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error al mostrar los recorridos: {ex.Message}");
            }
        }

        private void MostrarListaCanciones(List<Song> canciones)
        {
            for (int i = 0; i < canciones.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {canciones[i]}");
            }
        }

        // Mostrar estadísticas
        public void MostrarEstadisticas()
        {
            try
            {
                if (arbol.EstaVacio())
                {
                    Console.WriteLine("\n✗ La playlist está vacía.");
                    return;
                }

                Console.WriteLine("\n========== ESTADÍSTICAS ==========");
                Console.WriteLine($"Total de canciones: {arbol.ContarNodosPublico()}");
                Console.WriteLine($"Altura del árbol: {arbol.ObtenerAltura()} niveles");
                Console.WriteLine("==================================\n");

                arbol.ImprimirArbol();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error al mostrar estadísticas: {ex.Message}");
            }
        }

        // Consultar nivel de una canción
        public void ConsultarNivelCancion(int id)
        {
            try
            {
                Song? cancion = arbol.Buscar(id);

                if (cancion == null)
                {
                    Console.WriteLine($"\n✗ No se encontró ninguna canción con el ID {id}");
                    return;
                }

                int nivel = arbol.ObtenerNivelDeNodo(id);
                Console.WriteLine("\n--- INFORMACIÓN DE NIVEL ---");
                Console.WriteLine($"Canción: {cancion.Titulo} - {cancion.Artista}");
                Console.WriteLine($"Nivel en el árbol: {nivel}");
                Console.WriteLine("(La raíz está en el nivel 0)");
                Console.WriteLine("----------------------------\n");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"✗ Error de validación: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error inesperado: {ex.Message}");
            }
        }

        // Verificar si está vacía
        public bool EstaVacia()
        {
            return arbol.EstaVacio();
        }
    }
}
