public class Song implements Comparable<Song> {
    private int id;
    private String titulo;
    private String artista;
    private int duracion; // en segundos
    private int popularidad; // 0-100
    
    // Constantes de validación
    private static final int DURACION_MINIMA = 10; // 10 segundos
    private static final int DURACION_MAXIMA = 7200; // 2 horas
    private static final int TITULO_MIN_LENGTH = 1;
    private static final int TITULO_MAX_LENGTH = 100;
    private static final int ARTISTA_MIN_LENGTH = 1;
    private static final int ARTISTA_MAX_LENGTH = 50;
    
    public Song(int id, String titulo, String artista, int duracion, int popularidad) {
        // Validación de ID
        if (id <= 0) {
            throw new IllegalArgumentException("El ID debe ser un número positivo mayor a 0");
        }
        
        // Validación de título
        if (titulo == null || titulo.trim().isEmpty()) {
            throw new IllegalArgumentException("El título no puede estar vacío");
        }
        titulo = titulo.trim();
        
        if (titulo.length() < TITULO_MIN_LENGTH || titulo.length() > TITULO_MAX_LENGTH) {
            throw new IllegalArgumentException("El título debe tener entre " + TITULO_MIN_LENGTH + 
                                             " y " + TITULO_MAX_LENGTH + " caracteres");
        }
        
        if (!contieneAlMenosUnaLetra(titulo)) {
            throw new IllegalArgumentException("El título debe contener al menos una letra");
        }
        
        // Validación de artista
        if (artista == null || artista.trim().isEmpty()) {
            throw new IllegalArgumentException("El artista no puede estar vacío");
        }
        artista = artista.trim();
        
        if (artista.length() < ARTISTA_MIN_LENGTH || artista.length() > ARTISTA_MAX_LENGTH) {
            throw new IllegalArgumentException("El artista debe tener entre " + ARTISTA_MIN_LENGTH + 
                                             " y " + ARTISTA_MAX_LENGTH + " caracteres");
        }
        
        if (!contieneAlMenosUnaLetra(artista)) {
            throw new IllegalArgumentException("El artista debe contener al menos una letra");
        }
        
        // Validación de duración
        if (duracion < DURACION_MINIMA) {
            throw new IllegalArgumentException("La duración debe ser al menos " + DURACION_MINIMA + " segundos");
        }
        if (duracion > DURACION_MAXIMA) {
            throw new IllegalArgumentException("La duración no puede exceder " + DURACION_MAXIMA + 
                                             " segundos (2 horas)");
        }
        
        // Validación de popularidad
        if (popularidad < 0 || popularidad > 100) {
            throw new IllegalArgumentException("La popularidad debe estar entre 0 y 100");
        }
        
        this.id = id;
        this.titulo = titulo;
        this.artista = artista;
        this.duracion = duracion;
        this.popularidad = popularidad;
    }
    
    // Método auxiliar para validar que contiene al menos una letra
    private boolean contieneAlMenosUnaLetra(String texto) {
        for (char c : texto.toCharArray()) {
            if (Character.isLetter(c)) {
                return true;
            }
        }
        return false;
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
