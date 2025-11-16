using MusicPlaylistWeb.Models;

namespace MusicPlaylistWeb.DataStructures
{
    public class BinarySearchTree
    {
        private Node? raiz;

        public BinarySearchTree()
        {
            raiz = null;
        }

        // Insertar
        public bool Insertar(Song cancion)
        {
            if (cancion == null)
                throw new ArgumentNullException(nameof(cancion));

            if (raiz == null)
            {
                raiz = new Node(cancion);
                return true;
            }

            var resultado = InsertarRecursivo(raiz, cancion);
            return resultado != null;
        }

        private Node? InsertarRecursivo(Node? nodo, Song cancion)
        {
            if (nodo == null)
                return new Node(cancion);

            int comparacion = cancion.CompareTo(nodo.Cancion);

            if (comparacion < 0)
                nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, cancion);
            else if (comparacion > 0)
                nodo.Derecho = InsertarRecursivo(nodo.Derecho, cancion);
            else
                return null; // Duplicado

            return nodo;
        }

        // Buscar por ID
        public Song? Buscar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser positivo.");

            Node? nodoEncontrado = BuscarRecursivo(raiz, id);
            return nodoEncontrado?.Cancion;
        }

        private Node? BuscarRecursivo(Node? nodo, int id)
        {
            if (nodo == null)
                return null;

            if (id == nodo.Cancion.Id)
                return nodo;
            else if (id < nodo.Cancion.Id)
                return BuscarRecursivo(nodo.Izquierdo, id);
            else
                return BuscarRecursivo(nodo.Derecho, id);
        }

        // Buscar canción por título y artista (para validar duplicados)
        public Song? BuscarPorTituloYArtista(string titulo, string artista)
        {
            return BuscarPorTituloYArtistaRecursivo(raiz, titulo.Trim().ToLower(), artista.Trim().ToLower());
        }

        private Song? BuscarPorTituloYArtistaRecursivo(Node? nodo, string titulo, string artista)
        {
            if (nodo == null)
                return null;

            // Buscar en todo el árbol (inorden)
            var encontrado = BuscarPorTituloYArtistaRecursivo(nodo.Izquierdo, titulo, artista);
            if (encontrado != null)
                return encontrado;

            // Verificar nodo actual
            if (nodo.Cancion.Titulo.Trim().ToLower() == titulo &&
                nodo.Cancion.Artista.Trim().ToLower() == artista)
                return nodo.Cancion;

            // Buscar en subárbol derecho
            return BuscarPorTituloYArtistaRecursivo(nodo.Derecho, titulo, artista);
        }

        // Sugerir próximo ID disponible
        public int SugerirProximoID()
        {
            if (raiz == null)
                return 1;
            return ObtenerMaximoID(raiz) + 1;
        }

        private int ObtenerMaximoID(Node nodo)
        {
            if (nodo.Derecho == null)
                return nodo.Cancion.Id;
            return ObtenerMaximoID(nodo.Derecho);
        }

        // Buscar canciones por título (búsqueda parcial)
        public List<Song> BuscarPorTitulo(string tituloBusqueda)
        {
            if (string.IsNullOrWhiteSpace(tituloBusqueda))
                return new List<Song>();

            List<Song> resultados = new List<Song>();
            BuscarPorTituloRecursivo(raiz, tituloBusqueda.Trim().ToLower(), resultados);
            return resultados;
        }

        private void BuscarPorTituloRecursivo(Node? nodo, string tituloBusqueda, List<Song> resultados)
        {
            if (nodo == null)
                return;

            BuscarPorTituloRecursivo(nodo.Izquierdo, tituloBusqueda, resultados);

            if (nodo.Cancion.Titulo.ToLower().Contains(tituloBusqueda))
                resultados.Add(nodo.Cancion);

            BuscarPorTituloRecursivo(nodo.Derecho, tituloBusqueda, resultados);
        }

        // OPERACIÓN LIBRE 1: Buscar por artista (búsqueda parcial)
        public List<Song> BuscarPorArtista(string artista)
        {
            if (string.IsNullOrWhiteSpace(artista))
                return new List<Song>();

            List<Song> resultados = new List<Song>();
            BuscarPorArtistaRecursivo(raiz, artista.ToLower(), resultados);
            return resultados;
        }

        private void BuscarPorArtistaRecursivo(Node? nodo, string artista, List<Song> resultados)
        {
            if (nodo == null)
                return;

            if (nodo.Cancion.Artista.ToLower().Contains(artista))
                resultados.Add(nodo.Cancion);

            BuscarPorArtistaRecursivo(nodo.Izquierdo, artista, resultados);
            BuscarPorArtistaRecursivo(nodo.Derecho, artista, resultados);
        }

        // OPERACIÓN LIBRE 2: Obtener Top N canciones más populares
        public List<Song> ObtenerTopPopulares(int cantidad)
        {
            if (cantidad <= 0)
                return new List<Song>();

            List<Song> todasLasCanciones = RecorridoInorden();
            return todasLasCanciones
                .OrderByDescending(c => c.Popularidad)
                .ThenBy(c => c.Titulo)
                .Take(cantidad)
                .ToList();
        }

        // Eliminar
        public bool Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser positivo.");

            if (raiz == null)
                return false;

            int tamanoAntes = ContarNodos();
            raiz = EliminarRecursivo(raiz, id);
            int tamanoDespues = ContarNodos();

            return tamanoDespues < tamanoAntes;
        }

        private Node? EliminarRecursivo(Node? nodo, int id)
        {
            if (nodo == null)
                return null;

            if (id < nodo.Cancion.Id)
                nodo.Izquierdo = EliminarRecursivo(nodo.Izquierdo, id);
            else if (id > nodo.Cancion.Id)
                nodo.Derecho = EliminarRecursivo(nodo.Derecho, id);
            else
            {
                // Nodo encontrado
                if (nodo.Izquierdo == null && nodo.Derecho == null)
                    return null;

                if (nodo.Izquierdo == null)
                    return nodo.Derecho;
                if (nodo.Derecho == null)
                    return nodo.Izquierdo;

                Node sucesor = ObtenerMinimo(nodo.Derecho);
                nodo.Cancion = sucesor.Cancion;
                nodo.Derecho = EliminarRecursivo(nodo.Derecho, sucesor.Cancion.Id);
            }

            return nodo;
        }

        private Node ObtenerMinimo(Node nodo)
        {
            while (nodo.Izquierdo != null)
                nodo = nodo.Izquierdo;
            return nodo;
        }

        // Recorrido Inorden
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

        // Recorrido Preorden
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

        // Recorrido Postorden
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

        // Recorrido por Niveles (Amplitud)
        public List<Song> RecorridoPorNiveles()
        {
            List<Song> resultado = new List<Song>();

            if (raiz == null)
                return resultado;

            Queue<Node> cola = new Queue<Node>();
            cola.Enqueue(raiz);

            while (cola.Count > 0)
            {
                Node nodoActual = cola.Dequeue();
                resultado.Add(nodoActual.Cancion);

                if (nodoActual.Izquierdo != null)
                    cola.Enqueue(nodoActual.Izquierdo);
                if (nodoActual.Derecho != null)
                    cola.Enqueue(nodoActual.Derecho);
            }

            return resultado;
        }

        // Obtener altura (número de niveles)
        public int ObtenerAltura()
        {
            return AlturaRecursiva(raiz);
        }

        private int AlturaRecursiva(Node? nodo)
        {
            if (nodo == null)
                return 0;

            int alturaIzq = AlturaRecursiva(nodo.Izquierdo);
            int alturaDer = AlturaRecursiva(nodo.Derecho);

            return 1 + Math.Max(alturaIzq, alturaDer);
        }

        // Obtener nivel de un nodo específico
        public int ObtenerNivelDeNodo(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser positivo.");

            return NivelRecursivo(raiz, id, 0);
        }

        private int NivelRecursivo(Node? nodo, int id, int nivelActual)
        {
            if (nodo == null)
                return -1;

            if (id == nodo.Cancion.Id)
                return nivelActual;
            else if (id < nodo.Cancion.Id)
                return NivelRecursivo(nodo.Izquierdo, id, nivelActual + 1);
            else
                return NivelRecursivo(nodo.Derecho, id, nivelActual + 1);
        }

        public bool EstaVacio()
        {
            return raiz == null;
        }

        public int ContarNodos()
        {
            return ContarNodosRecursivo(raiz);
        }

        private int ContarNodosRecursivo(Node? nodo)
        {
            if (nodo == null)
                return 0;
            return 1 + ContarNodosRecursivo(nodo.Izquierdo) + ContarNodosRecursivo(nodo.Derecho);
        }

        // Obtener estructura del árbol para visualización
        public List<TreeNodeInfo> ObtenerEstructuraArbol()
        {
            List<TreeNodeInfo> estructura = new List<TreeNodeInfo>();
            ObtenerEstructuraRecursiva(raiz, 0, estructura);
            return estructura;
        }

        private void ObtenerEstructuraRecursiva(Node? nodo, int nivel, List<TreeNodeInfo> estructura)
        {
            if (nodo != null)
            {
                estructura.Add(new TreeNodeInfo
                {
                    Id = nodo.Cancion.Id,
                    Titulo = nodo.Cancion.Titulo,
                    Nivel = nivel
                });

                ObtenerEstructuraRecursiva(nodo.Izquierdo, nivel + 1, estructura);
                ObtenerEstructuraRecursiva(nodo.Derecho, nivel + 1, estructura);
            }
        }

        // Buscar canciones por nivel específico
        public List<Song> BuscarPorNivel(int nivelBuscado)
        {
            if (nivelBuscado < 0)
                return new List<Song>();

            List<Song> resultados = new List<Song>();
            BuscarPorNivelRecursivo(raiz, 0, nivelBuscado, resultados);
            return resultados;
        }

        private void BuscarPorNivelRecursivo(Node? nodo, int nivelActual, int nivelBuscado, List<Song> resultados)
        {
            if (nodo == null)
                return;

            if (nivelActual == nivelBuscado)
            {
                resultados.Add(nodo.Cancion);
            }

            BuscarPorNivelRecursivo(nodo.Izquierdo, nivelActual + 1, nivelBuscado, resultados);
            BuscarPorNivelRecursivo(nodo.Derecho, nivelActual + 1, nivelBuscado, resultados);
        }
    }

    public class TreeNodeInfo
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public int Nivel { get; set; }
    }
}
