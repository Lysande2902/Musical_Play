using System;

namespace MusicPlaylistCSharp.Models
{
    public class Song : IComparable<Song>
    {
        private int id;
        private string titulo;
        private string artista;
        private int duracion; // en segundos
        private int popularidad; // 0-100

        public Song(int id, string titulo, string artista, int duracion, int popularidad)
        {
            // Validaciones con mensajes descriptivos
            if (id <= 0)
            {
                throw new ArgumentException("El ID debe ser un número positivo mayor a 0.");
            }

            if (string.IsNullOrWhiteSpace(titulo))
            {
                throw new ArgumentException("El título no puede estar vacío o contener solo espacios.");
            }

            if (string.IsNullOrWhiteSpace(artista))
            {
                throw new ArgumentException("El artista no puede estar vacío o contener solo espacios.");
            }

            if (duracion <= 0)
            {
                throw new ArgumentException("La duración debe ser mayor a 0 segundos.");
            }

            if (popularidad < 0 || popularidad > 100)
            {
                throw new ArgumentException($"La popularidad debe estar entre 0 y 100. Valor recibido: {popularidad}");
            }

            this.id = id;
            this.titulo = titulo.Trim();
            this.artista = artista.Trim();
            this.duracion = duracion;
            this.popularidad = popularidad;
        }

        // Propiedades con getters públicos
        public int Id => id;
        public string Titulo => titulo;
        public string Artista => artista;
        public int Duracion => duracion;
        public int Popularidad => popularidad;

        // Implementación de IComparable para comparar por ID
        public int CompareTo(Song? otra)
        {
            if (otra == null) return 1;
            return this.id.CompareTo(otra.id);
        }

        // Sobrescribir ToString para formato legible
        public override string ToString()
        {
            int minutos = duracion / 60;
            int segundos = duracion % 60;
            return $"[ID: {id}] {titulo} - {artista} | Duración: {minutos}:{segundos:D2} | Popularidad: {popularidad}/100";
        }

        // Sobrescribir Equals y GetHashCode para comparaciones correctas
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Song other = (Song)obj;
            return id == other.id;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }
    }
}
