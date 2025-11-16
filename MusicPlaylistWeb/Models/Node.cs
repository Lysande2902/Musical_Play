namespace MusicPlaylistWeb.Models
{
    public class Node
    {
        public Song Cancion { get; set; }
        public Node? Izquierdo { get; set; }
        public Node? Derecho { get; set; }

        public Node(Song cancion)
        {
            if (cancion == null)
                throw new ArgumentNullException(nameof(cancion), "La canción no puede ser nula.");

            Cancion = cancion;
            Izquierdo = null;
            Derecho = null;
        }
    }
}
