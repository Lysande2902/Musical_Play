using System;
using System.Collections.Generic;
using MusicPlaylistCSharp.Models;

namespace MusicPlaylistCSharp.DataStructures
{
    public class BinarySearchTree
    {
        private Node? raiz;

        public BinarySearchTree()
        {
            this.raiz = null;
        }

        // Método público de inserción con validación
        public bool Insertar(Song cancion)
        {
            if (cancion == null)
            {
                throw new ArgumentNullException(nameof(cancion), "No se puede insertar una canción nula.");
            }

            try
            {
                // Si el árbol está vacío, crear la raíz
                if (raiz == null)
                {
                    raiz = new Node(cancion);
                    return true;
                }

                // Intentar insertar recursivamente
                var resultado = InsertarRecursivo(raiz, cancion);
                return resultado != null;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al insertar la canción: {ex.Message}", ex);
            }
        }

        // Método privado recursivo de inserción
        private Node? InsertarRecursivo(Node nodo, Song cancion)
        {
            // Caso base: encontramos la posición para insertar
            if (nodo == null)
            {
                return new Node(cancion);
            }

            // Comparar IDs
            int comparacion = cancion.CompareTo(nodo.Cancion);

            if (comparacion < 0)
            {
                // Insertar en subárbol izquierdo
                nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, cancion);
            }
            else if (comparacion > 0)
            {
                // Insertar en subárbol derecho
                nodo.Derecho = InsertarRecursivo(nodo.Derecho, cancion);
            }
            else
            {
                // ID duplicado, no insertar
                return null;
            }

            return nodo;
        }

        // Método público de búsqueda con validación
        public Song? Buscar(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El ID debe ser un número positivo.", nameof(id));
            }

            try
            {
                Node? nodoEncontrado = BuscarRecursivo(raiz, id);
                return nodoEncontrado?.Cancion;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al buscar la canción con ID {id}: {ex.Message}", ex);
            }
        }

        // Método privado recursivo de búsqueda
        private Node? BuscarRecursivo(Node? nodo, int id)
        {
            // Caso base: árbol vacío o no encontrado
            if (nodo == null)
            {
                return null;
            }

            int idNodo = nodo.Cancion.Id;

            if (id == idNodo)
            {
                // Encontrado
                return nodo;
            }
            else if (id < idNodo)
            {
                // Buscar en subárbol izquierdo
                return BuscarRecursivo(nodo.Izquierdo, id);
            }
            else
            {
                // Buscar en subárbol derecho
                return BuscarRecursivo(nodo.Derecho, id);
            }
        }

        // Método público de eliminación con validación
        public bool Eliminar(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El ID debe ser un número positivo.", nameof(id));
            }

            if (raiz == null)
            {
                return false;
            }

            try
            {
                int tamanoAntes = ContarNodos();
                raiz = EliminarRecursivo(raiz, id);
                int tamanoDespues = ContarNodos();

                return tamanoDespues < tamanoAntes;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al eliminar la canción con ID {id}: {ex.Message}", ex);
            }
        }

        // Método privado recursivo de eliminación
        private Node? EliminarRecursivo(Node? nodo, int id)
        {
            if (nodo == null)
            {
                return null;
            }

            int idNodo = nodo.Cancion.Id;

            if (id < idNodo)
            {
                // Buscar en subárbol izquierdo
                nodo.Izquierdo = EliminarRecursivo(nodo.Izquierdo, id);
            }
            else if (id > idNodo)
            {
                // Buscar en subárbol derecho
                nodo.Derecho = EliminarRecursivo(nodo.Derecho, id);
            }
            else
            {
                // Nodo encontrado, proceder a eliminar

                // Caso 1: Nodo sin hijos (hoja)
                if (nodo.Izquierdo == null && nodo.Derecho == null)
                {
                    return null;
                }

                // Caso 2: Nodo con un solo hijo
                if (nodo.Izquierdo == null)
                {
                    return nodo.Derecho;
                }
                if (nodo.Derecho == null)
                {
                    return nodo.Izquierdo;
                }

                // Caso 3: Nodo con dos hijos
                // Encontrar el sucesor inorden (menor del subárbol derecho)
                Node sucesor = ObtenerMinimo(nodo.Derecho);
                nodo.Cancion = sucesor.Cancion;
                nodo.Derecho = EliminarRecursivo(nodo.Derecho, sucesor.Cancion.Id);
            }

            return nodo;
        }

        // Método auxiliar para encontrar el nodo con el valor mínimo
        private Node ObtenerMinimo(Node nodo)
        {
            if (nodo == null)
            {
                throw new ArgumentNullException(nameof(nodo), "El nodo no puede ser nulo.");
            }

            while (nodo.Izquierdo != null)
            {
                nodo = nodo.Izquierdo;
            }
            return nodo;
        }

        // Método auxiliar para contar nodos
        private int ContarNodos()
        {
            return ContarNodosRecursivo(raiz);
        }

        private int ContarNodosRecursivo(Node? nodo)
        {
            if (nodo == null)
            {
                return 0;
            }
            return 1 + ContarNodosRecursivo(nodo.Izquierdo) + ContarNodosRecursivo(nodo.Derecho);
        }

        // Recorrido Inorden (Izquierdo → Nodo → Derecho)
        public List<Song> RecorridoInorden()
        {
            List<Song> resultado = new List<Song>();
            InordenRecursivo(raiz, resultado);
            return resultado;
        }

        private void InordenRecursivo(Node? nodo, List<Song> resultado)
        {
            if (nodo != null)
            {
                InordenRecursivo(nodo.Izquierdo, resultado);
                resultado.Add(nodo.Cancion);
                InordenRecursivo(nodo.Derecho, resultado);
            }
        }

        // Recorrido Preorden (Nodo → Izquierdo → Derecho)
        public List<Song> RecorridoPreorden()
        {
            List<Song> resultado = new List<Song>();
            PreordenRecursivo(raiz, resultado);
            return resultado;
        }

        private void PreordenRecursivo(Node? nodo, List<Song> resultado)
        {
            if (nodo != null)
            {
                resultado.Add(nodo.Cancion);
                PreordenRecursivo(nodo.Izquierdo, resultado);
                PreordenRecursivo(nodo.Derecho, resultado);
            }
        }

        // Recorrido Postorden (Izquierdo → Derecho → Nodo)
        public List<Song> RecorridoPostorden()
        {
            List<Song> resultado = new List<Song>();
            PostordenRecursivo(raiz, resultado);
            return resultado;
        }

        private void PostordenRecursivo(Node? nodo, List<Song> resultado)
        {
            if (nodo != null)
            {
                PostordenRecursivo(nodo.Izquierdo, resultado);
                PostordenRecursivo(nodo.Derecho, resultado);
                resultado.Add(nodo.Cancion);
            }
        }

        // Recorrido por Niveles (BFS)
        public List<Song> RecorridoPorNiveles()
        {
            List<Song> resultado = new List<Song>();

            if (raiz == null)
            {
                return resultado;
            }

            Queue<Node> cola = new Queue<Node>();
            cola.Enqueue(raiz);

            while (cola.Count > 0)
            {
                Node nodoActual = cola.Dequeue();
                resultado.Add(nodoActual.Cancion);

                if (nodoActual.Izquierdo != null)
                {
                    cola.Enqueue(nodoActual.Izquierdo);
                }
                if (nodoActual.Derecho != null)
                {
                    cola.Enqueue(nodoActual.Derecho);
                }
            }

            return resultado;
        }

        // Obtener altura del árbol
        public int ObtenerAltura()
        {
            return AlturaRecursiva(raiz);
        }

        private int AlturaRecursiva(Node? nodo)
        {
            if (nodo == null)
            {
                return 0;
            }

            int alturaIzq = AlturaRecursiva(nodo.Izquierdo);
            int alturaDer = AlturaRecursiva(nodo.Derecho);

            return 1 + Math.Max(alturaIzq, alturaDer);
        }

        // Obtener nivel de un nodo específico
        public int ObtenerNivelDeNodo(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El ID debe ser un número positivo.", nameof(id));
            }

            return NivelRecursivo(raiz, id, 0);
        }

        private int NivelRecursivo(Node? nodo, int id, int nivelActual)
        {
            if (nodo == null)
            {
                return -1; // No encontrado
            }

            int idNodo = nodo.Cancion.Id;

            if (id == idNodo)
            {
                return nivelActual;
            }
            else if (id < idNodo)
            {
                return NivelRecursivo(nodo.Izquierdo, id, nivelActual + 1);
            }
            else
            {
                return NivelRecursivo(nodo.Derecho, id, nivelActual + 1);
            }
        }

        public bool EstaVacio()
        {
            return raiz == null;
        }

        // Contar nodos públicamente
        public int ContarNodosPublico()
        {
            return ContarNodos();
        }

        // Imprimir árbol con estructura visual
        public void ImprimirArbol()
        {
            if (raiz == null)
            {
                Console.WriteLine("El árbol está vacío.");
                return;
            }

            Console.WriteLine("\n=== ESTRUCTURA DEL ÁRBOL ===");
            ImprimirArbolRecursivo(raiz, "", true);
            Console.WriteLine($"\nAltura: {ObtenerAltura()} niveles");
            Console.WriteLine($"Total de canciones: {ContarNodos()}");
            Console.WriteLine("============================\n");
        }

        private void ImprimirArbolRecursivo(Node? nodo, string prefijo, bool esUltimo)
        {
            if (nodo != null)
            {
                Console.WriteLine(prefijo + (esUltimo ? "└── " : "├── ") +
                                $"[{nodo.Cancion.Id}] {nodo.Cancion.Titulo}");

                string nuevoPrefijo = prefijo + (esUltimo ? "    " : "│   ");

                if (nodo.Izquierdo != null || nodo.Derecho != null)
                {
                    if (nodo.Izquierdo != null)
                    {
                        ImprimirArbolRecursivo(nodo.Izquierdo, nuevoPrefijo,
                                             nodo.Derecho == null);
                    }
                    if (nodo.Derecho != null)
                    {
                        ImprimirArbolRecursivo(nodo.Derecho, nuevoPrefijo, true);
                    }
                }
            }
        }
    }
}
