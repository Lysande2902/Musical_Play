using System.Text.Json;
using MusicPlaylistWeb.Models;

namespace MusicPlaylistWeb.Services
{
    public class JsonPersistenceService
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _options;

        public JsonPersistenceService()
        {
            _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "playlist.json");
            _options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true
            };

            // Asegurar que el directorio existe
            var directory = Path.GetDirectoryName(_filePath);
            if (directory != null && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public List<Song> CargarCanciones()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    return new List<Song>();
                }

                var json = File.ReadAllText(_filePath);
                var data = JsonSerializer.Deserialize<PlaylistData>(json, _options);
                return data?.Canciones ?? new List<Song>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar canciones: {ex.Message}");
                return new List<Song>();
            }
        }

        public bool GuardarCanciones(List<Song> canciones)
        {
            try
            {
                var data = new PlaylistData { Canciones = canciones };
                var json = JsonSerializer.Serialize(data, _options);
                File.WriteAllText(_filePath, json);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar canciones: {ex.Message}");
                return false;
            }
        }

        private class PlaylistData
        {
            public List<Song> Canciones { get; set; } = new List<Song>();
        }
    }
}
