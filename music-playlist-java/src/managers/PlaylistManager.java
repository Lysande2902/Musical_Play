import java.util.ArrayList;

public class PlaylistManager {
    private BinarySearchTree arbol;
    
    public PlaylistManager() {
        this.arbol = new BinarySearchTree();
    }
    
    // Agregar canción con validaciones
    public void agregarCancion(Song cancion) {
        if (cancion == null) {
            System.out.println("✗ Error: La canción no puede ser nula.");
            return;
        }
        
        boolean insertado = arbol.insertar(cancion);
        
        if (insertado) {
            System.out.println("✓ Canción agregada exitosamente!");
            System.out.println("  " + cancion.toString());
        } else {
            System.out.println("✗ Error: Ya existe una canción con el ID " + cancion.getId());
        }
    }
    
    // Buscar canción por ID
    public void buscarCancion(int id) {
        Song cancion = arbol.buscar(id);
        
        if (cancion != null) {
            System.out.println("\n✓ Canción encontrada:");
            System.out.println("  " + cancion.toString());
            System.out.println("  Nivel en el árbol: " + arbol.obtenerNivelDeNodo(id));
        } else {
            System.out.println("\n✗ No se encontró ninguna canción con el ID " + id);
        }
    }
    
    // Eliminar canción por ID
    public void eliminarCancion(int id) {
        Song cancion = arbol.buscar(id);
        
        if (cancion == null) {
            System.out.println("\n✗ No se encontró ninguna canción con el ID " + id);
            return;
        }
        
        System.out.println("\nEliminando: " + cancion.toString());
        boolean eliminado = arbol.eliminar(id);
        
        if (eliminado) {
            System.out.println("✓ Canción eliminada exitosamente!");
        } else {
            System.out.println("✗ Error al eliminar la canción.");
        }
    }
    
    // Mostrar playlist ordenada (Inorden)
    public void mostrarPlaylistOrdenada() {
        if (arbol.estaVacio()) {
            System.out.println("\n✗ La playlist está vacía.");
            return;
        }
        
        System.out.println("\n=== PLAYLIST ORDENADA (Inorden) ===");
        ArrayList<Song> canciones = arbol.recorridoInorden();
        
        for (int i = 0; i < canciones.size(); i++) {
            System.out.println((i + 1) + ". " + canciones.get(i).toString());
        }
        System.out.println("===================================\n");
    }
    
    // Mostrar todos los recorridos
    public void mostrarTodosLosRecorridos() {
        if (arbol.estaVacio()) {
            System.out.println("\n✗ La playlist está vacía.");
            return;
        }
        
        System.out.println("\n========== RECORRIDOS DEL ÁRBOL ==========\n");
        
        // Inorden
        System.out.println("--- INORDEN (Izq → Nodo → Der) ---");
        ArrayList<Song> inorden = arbol.recorridoInorden();
        mostrarListaCanciones(inorden);
        
        // Preorden
        System.out.println("\n--- PREORDEN (Nodo → Izq → Der) ---");
        ArrayList<Song> preorden = arbol.recorridoPreorden();
        mostrarListaCanciones(preorden);
        
        // Postorden
        System.out.println("\n--- POSTORDEN (Izq → Der → Nodo) ---");
        ArrayList<Song> postorden = arbol.recorridoPostorden();
        mostrarListaCanciones(postorden);
        
        // Por niveles
        System.out.println("\n--- POR NIVELES (Amplitud/BFS) ---");
        ArrayList<Song> niveles = arbol.recorridoPorNiveles();
        mostrarListaCanciones(niveles);
        
        System.out.println("\n==========================================\n");
    }
    
    private void mostrarListaCanciones(ArrayList<Song> canciones) {
        for (int i = 0; i < canciones.size(); i++) {
            System.out.println((i + 1) + ". " + canciones.get(i).toString());
        }
    }
    
    // Mostrar estadísticas
    public void mostrarEstadisticas() {
        if (arbol.estaVacio()) {
            System.out.println("\n✗ La playlist está vacía.");
            return;
        }
        
        System.out.println("\n========== ESTADÍSTICAS ==========");
        System.out.println("Total de canciones: " + arbol.contarNodosPublico());
        System.out.println("Altura del árbol: " + arbol.obtenerAltura() + " niveles");
        System.out.println("==================================\n");
        
        arbol.imprimirArbol();
    }
    
    // Consultar nivel de una canción
    public void consultarNivelCancion(int id) {
        Song cancion = arbol.buscar(id);
        
        if (cancion == null) {
            System.out.println("\n✗ No se encontró ninguna canción con el ID " + id);
            return;
        }
        
        int nivel = arbol.obtenerNivelDeNodo(id);
        System.out.println("\n--- INFORMACIÓN DE NIVEL ---");
        System.out.println("Canción: " + cancion.getTitulo() + " - " + cancion.getArtista());
        System.out.println("Nivel en el árbol: " + nivel);
        System.out.println("(La raíz está en el nivel 0)");
        System.out.println("----------------------------\n");
    }
    
    // Verificar si está vacía
    public boolean estaVacia() {
        return arbol.estaVacio();
    }
}
