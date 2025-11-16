namespace MusicPlaylistWeb.Models
{
    public class Song : IComparable<Song>
    {
        // Constantes de validación
        private const int DURACION_MINIMA = 10; // 10 segundos
        private const int DURACION_MAXIMA = 7200; // 2 horas
        private const int TITULO_MIN_LENGTH = 1;
        private const int TITULO_MAX_LENGTH = 100;
        private const int ARTISTA_MIN_LENGTH = 1;
        private const int ARTISTA_MAX_LENGTH = 50;

        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Artista { get; set; } = string.Empty;
        public int Duracion { get; set; } // en segundos
        public int Popularidad { get; set; } // 0-100

        public Song() { }

        public Song(int id, string titulo, string artista, int duracion, int popularidad)
        {
            // Validación de ID
            if (id <= 0)
                throw new ArgumentException("El ID debe ser un número positivo mayor a 0.");

            // Validación de título
            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("El título no puede estar vacío.");

            titulo = titulo.Trim();

            if (titulo.Length < TITULO_MIN_LENGTH || titulo.Length > TITULO_MAX_LENGTH)
                throw new ArgumentException($"El título debe tener entre {TITULO_MIN_LENGTH} y {TITULO_MAX_LENGTH} caracteres.");

            if (!ContieneAlMenosUnaLetra(titulo))
                throw new ArgumentException("El título debe contener al menos una letra.");

            // Validación de artista
            if (string.IsNullOrWhiteSpace(artista))
                throw new ArgumentException("El artista no puede estar vacío.");

            artista = artista.Trim();

            if (artista.Length < ARTISTA_MIN_LENGTH || artista.Length > ARTISTA_MAX_LENGTH)
                throw new ArgumentException($"El artista debe tener entre {ARTISTA_MIN_LENGTH} y {ARTISTA_MAX_LENGTH} caracteres.");

            if (!ContieneAlMenosUnaLetra(artista))
                throw new ArgumentException("El artista debe contener al menos una letra.");

            // Validación de duración
            if (duracion < DURACION_MINIMA)
                throw new ArgumentException($"La duración debe ser al menos {DURACION_MINIMA} segundos.");

            if (duracion > DURACION_MAXIMA)
                throw new ArgumentException($"La duración no puede exceder {DURACION_MAXIMA} segundos (2 horas).");

            // Validación de popularidad
            if (popularidad < 0 || popularidad > 100)
                throw new ArgumentException($"La popularidad debe estar entre 0 y 100. Valor recibido: {popularidad}");

            Id = id;
            Titulo = titulo;
            Artista = artista;
            Duracion = duracion;
            Popularidad = popularidad;
        }

        // Método auxiliar para validar que contiene al menos una letra
        private static bool ContieneAlMenosUnaLetra(string texto)
        {
            return texto.Any(char.IsLetter);
        }

        public string DuracionFormateada
        {
            get
            {
                int minutos = Duracion / 60;
                int segundos = Duracion % 60;
                return $"{minutos}:{segundos:D2}";
            }
        }

        public int CompareTo(Song? otra)
        {
            if (otra == null) return 1;
            return Id.CompareTo(otra.Id);
        }

        public override string ToString()
        {
            return $"[ID: {Id}] {Titulo} - {Artista} | Duración: {DuracionFormateada} | Popularidad: {Popularidad}/100";
        }
    }
}
