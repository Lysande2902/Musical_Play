using MusicPlaylistWeb.DataStructures;
using MusicPlaylistWeb.Models;

namespace MusicPlaylistWeb.Services
{
    public class PlaylistService
    {
        private readonly BinarySearchTree arbol;
        private readonly JsonPersistenceService persistencia;
        private readonly object lockObject = new object();

        public PlaylistService()
        {
            arbol = new BinarySearchTree();
            persistencia = new JsonPersistenceService();
            CargarDesdeJSON();
        }

        public (bool exito, string mensaje) AgregarCancion(Song cancion)
        {
            lock (lockObject)
            {
                try
                {
                    // Validar título + artista duplicados
                    var existente = arbol.BuscarPorTituloYArtista(cancion.Titulo, cancion.Artista);
                    if (existente != null)
                    {
                        return (false, $"Ya existe una canción con el mismo título y artista (ID: {existente.Id})");
                    }

                    bool insertado = arbol.Insertar(cancion);
                    if (insertado)
                    {
                        GuardarEnJSON();
                        return (true, "Canción agregada exitosamente");
                    }
                    return (false, $"Ya existe una canción con el ID {cancion.Id}");
                }
                catch (Exception ex)
                {
                    return (false, $"Error: {ex.Message}");
                }
            }
        }

        public Song? BuscarCancion(int id)
        {
            try
            {
                return arbol.Buscar(id);
            }
            catch
            {
                return null;
            }
        }

        public Song? BuscarPorTituloYArtista(string titulo, string artista)
        {
            return arbol.BuscarPorTituloYArtista(titulo, artista);
        }

        public int SugerirProximoID()
        {
            return arbol.SugerirProximoID();
        }

        public List<Song> BuscarPorTitulo(string titulo)
        {
            return arbol.BuscarPorTitulo(titulo);
        }

        public List<Song> BuscarPorArtista(string artista)
        {
            return arbol.BuscarPorArtista(artista);
        }

        public List<Song> ObtenerTopPopulares(int cantidad = 5)
        {
            return arbol.ObtenerTopPopulares(cantidad);
        }

        public bool EliminarCancion(int id)
        {
            lock (lockObject)
            {
                try
                {
                    bool eliminado = arbol.Eliminar(id);
                    if (eliminado)
                    {
                        GuardarEnJSON();
                    }
                    return eliminado;
                }
                catch
                {
                    return false;
                }
            }
        }

        public (bool exito, string mensaje) EditarCancion(int idOriginal, Song cancionEditada)
        {
            lock (lockObject)
            {
                try
                {
                    // Buscar la canción original
                    var original = arbol.Buscar(idOriginal);
                    if (original == null)
                    {
                        return (false, "Canción no encontrada");
                    }

                    // Si cambió el ID, verificar que el nuevo ID no exista
                    if (idOriginal != cancionEditada.Id)
                    {
                        var existeNuevoId = arbol.Buscar(cancionEditada.Id);
                        if (existeNuevoId != null)
                        {
                            return (false, $"Ya existe una canción con el ID {cancionEditada.Id}");
                        }
                    }

                    // Si cambió título o artista, verificar duplicados
                    if (original.Titulo != cancionEditada.Titulo || original.Artista != cancionEditada.Artista)
                    {
                        var existente = arbol.BuscarPorTituloYArtista(cancionEditada.Titulo, cancionEditada.Artista);
                        if (existente != null && existente.Id != idOriginal)
                        {
                            return (false, $"Ya existe una canción con ese título y artista (ID: {existente.Id})");
                        }
                    }

                    // Eliminar la canción original
                    arbol.Eliminar(idOriginal);

                    // Insertar la canción editada
                    bool insertado = arbol.Insertar(cancionEditada);
                    if (insertado)
                    {
                        GuardarEnJSON();
                        return (true, "Canción editada exitosamente");
                    }

                    // Si falla, revertir (reinsertar original)
                    arbol.Insertar(original);
                    return (false, "Error al editar la canción");
                }
                catch (Exception ex)
                {
                    return (false, $"Error: {ex.Message}");
                }
            }
        }

        public List<Song> ObtenerTodasLasCanciones()
        {
            return arbol.RecorridoInorden();
        }

        public List<Song> RecorridoInorden()
        {
            return arbol.RecorridoInorden();
        }

        public List<Song> RecorridoPreorden()
        {
            return arbol.RecorridoPreorden();
        }

        public List<Song> RecorridoPostorden()
        {
            return arbol.RecorridoPostorden();
        }

        public List<Song> RecorridoPorNiveles()
        {
            return arbol.RecorridoPorNiveles();
        }

        public int ObtenerAltura()
        {
            return arbol.ObtenerAltura();
        }

        public int ObtenerNivelDeNodo(int id)
        {
            try
            {
                return arbol.ObtenerNivelDeNodo(id);
            }
            catch
            {
                return -1;
            }
        }

        public int ContarCanciones()
        {
            return arbol.ContarNodos();
        }

        public bool EstaVacia()
        {
            return arbol.EstaVacio();
        }

        public List<TreeNodeInfo> ObtenerEstructuraArbol()
        {
            return arbol.ObtenerEstructuraArbol();
        }

        public List<Song> BuscarPorNivel(int nivel)
        {
            return arbol.BuscarPorNivel(nivel);
        }

        private void CargarDesdeJSON()
        {
            try
            {
                var canciones = persistencia.CargarCanciones();
                foreach (var cancion in canciones)
                {
                    try
                    {
                        arbol.Insertar(cancion);
                    }
                    catch
                    {
                        // Ignorar errores de inserción
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar desde JSON: {ex.Message}");
            }
        }

        private void GuardarEnJSON()
        {
            try
            {
                var canciones = arbol.RecorridoInorden();
                persistencia.GuardarCanciones(canciones);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar en JSON: {ex.Message}");
            }
        }
    }
}
