public class Song implements Comparable<Song> {
    private int id;
    private String titulo;
    private String artista;
    private int duracion; // en segundos
    private int popularidad; // 0-100
    
    public Song(int id, String titulo, String artista, int duracion, int popularidad) {
        // Validaciones
        if (id <= 0) {
            throw new IllegalArgumentException("El ID debe ser positivo");
        }
        if (titulo == null || titulo.trim().isEmpty()) {
            throw new IllegalArgumentException("El título no puede estar vacío");
        }
        if (artista == null || artista.trim().isEmpty()) {
            throw new IllegalArgumentException("El artista no puede estar vacío");
        }
        if (duracion <= 0) {
            throw new IllegalArgumentException("La duración debe ser mayor a 0");
        }
        if (popularidad < 0 || popularidad > 100) {
            throw new IllegalArgumentException("La popularidad debe estar entre 0 y 100");
        }
        
        this.id = id;
        this.titulo = titulo;
        this.artista = artista;
        this.duracion = duracion;
        this.popularidad = popularidad;
    }
    
    // Getters
    public int getId() {
        return id;
    }
    
    public String getTitulo() {
        return titulo;
    }
    
    public String getArtista() {
        return artista;
    }
    
    public int getDuracion() {
        return duracion;
    }
    
    public int getPopularidad() {
        return popularidad;
    }
    
    @Override
    public int compareTo(Song otra) {
        return Integer.compare(this.id, otra.id);
    }
    
    @Override
    public String toString() {
        int minutos = duracion / 60;
        int segundos = duracion % 60;
        return String.format("[ID: %d] %s - %s | Duración: %d:%02d | Popularidad: %d/100",
                id, titulo, artista, minutos, segundos, popularidad);
    }
}
