import java.util.ArrayList;

public class PlaylistManager {
    private final BinarySearchTree arbol;
    
    public PlaylistManager() {
        this.arbol = new BinarySearchTree();
    }
    
    // Agregar canción con validaciones mejoradas
    public void agregarCancion(Song cancion) {
        if (cancion == null) {
            System.out.println("✗ Error: La canción no puede ser nula.");
            return;
        }
        
        // Validar si ya existe una canción con el mismo título y artista
        Song existente = arbol.buscarPorTituloYArtista(cancion.getTitulo(), cancion.getArtista());
        if (existente != null) {
            System.out.println("⚠ ADVERTENCIA: Ya existe una canción con el mismo título y artista:");
            System.out.println("  " + existente.toString());
            System.out.println("  ¿Desea agregar esta versión de todas formas? (Tiene un ID diferente)");
            System.out.println("  Nota: Esto es útil para covers, remasters o versiones en vivo.");
        }
        
        boolean insertado = arbol.insertar(cancion);
        
        if (insertado) {
            System.out.println("✓ Canción agregada exitosamente!");
            System.out.println("  " + cancion.toString());
        } else {
            System.out.println("✗ Error: Ya existe una canción con el ID " + cancion.getId());
        }
    }
    
    // Sugerir próximo ID disponible
    public int sugerirProximoID() {
        return arbol.sugerirProximoID();
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
    
    // Eliminar canción por ID (con confirmación)
    public boolean eliminarCancionConConfirmacion(int id, java.util.Scanner scanner) {
        Song cancion = arbol.buscar(id);
        
        if (cancion == null) {
            System.out.println("\n✗ No se encontró ninguna canción con el ID " + id);
            return false;
        }
        
        System.out.println("\n⚠ CONFIRMACIÓN DE ELIMINACIÓN");
        System.out.println("═══════════════════════════════════════");
        System.out.println("Está a punto de eliminar:");
        System.out.println("  " + cancion.toString());
        System.out.println("═══════════════════════════════════════");
        System.out.print("¿Está seguro? (S/N): ");
        
        String respuesta = scanner.nextLine().trim().toUpperCase();
        
        if (respuesta.equals("S") || respuesta.equals("SI") || respuesta.equals("SÍ")) {
            boolean eliminado = arbol.eliminar(id);
            
            if (eliminado) {
                System.out.println("✓ Canción eliminada exitosamente!");
                return true;
            } else {
                System.out.println("✗ Error al eliminar la canción.");
                return false;
            }
        } else {
            System.out.println("✗ Eliminación cancelada.");
            return false;
        }
    }
    
    // Eliminar canción sin confirmación (para compatibilidad)
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
    
    // Buscar canciones por título
    public void buscarPorTitulo(String titulo) {
        if (titulo == null || titulo.trim().isEmpty()) {
            System.out.println("\n✗ Debe ingresar un título para buscar.");
            return;
        }
        
        ArrayList<Song> resultados = arbol.buscarPorTitulo(titulo);
        
        if (resultados.isEmpty()) {
            System.out.println("\n✗ No se encontraron canciones con el título: \"" + titulo + "\"");
        } else {
            System.out.println("\n✓ Se encontraron " + resultados.size() + " canción(es) con \"" + titulo + "\":");
            System.out.println("═══════════════════════════════════════════════════════════");
            for (int i = 0; i < resultados.size(); i++) {
                System.out.println((i + 1) + ". " + resultados.get(i).toString());
            }
            System.out.println("═══════════════════════════════════════════════════════════\n");
        }
    }
    
    // Buscar canciones por artista
    public void buscarPorArtista(String artista) {
        if (artista == null || artista.trim().isEmpty()) {
            System.out.println("\n✗ Debe ingresar un artista para buscar.");
            return;
        }
        
        ArrayList<Song> resultados = arbol.buscarPorArtista(artista);
        
        if (resultados.isEmpty()) {
            System.out.println("\n✗ No se encontraron canciones del artista: \"" + artista + "\"");
        } else {
            System.out.println("\n✓ Se encontraron " + resultados.size() + " canción(es) de \"" + artista + "\":");
            System.out.println("═══════════════════════════════════════════════════════════");
            for (int i = 0; i < resultados.size(); i++) {
                System.out.println((i + 1) + ". " + resultados.get(i).toString());
            }
            System.out.println("═══════════════════════════════════════════════════════════\n");
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
    
    // Mostrar todos los recorridos (MEJORADO)
    public void mostrarTodosLosRecorridos() {
        if (arbol.estaVacio()) {
            System.out.println("\n✗ La playlist está vacía.");
            return;
        }
        
        System.out.println("\n╔══════════════════════════════════════════════════════════════╗");
        System.out.println("║              RECORRIDOS DEL ÁRBOL BINARIO                    ║");
        System.out.println("╚══════════════════════════════════════════════════════════════╝\n");
        
        // Inorden
        System.out.println("┌─────────────────────────────────────────────────────────────┐");
        System.out.println("│ 1️⃣  RECORRIDO INORDEN (Izquierdo → Nodo → Derecho)         │");
        System.out.println("│    Orden: ASCENDENTE por ID                                 │");
        System.out.println("│    Uso: Mostrar elementos ordenados                         │");
        System.out.println("└─────────────────────────────────────────────────────────────┘");
        ArrayList<Song> inorden = arbol.recorridoInorden();
        mostrarListaCancionesConIDs(inorden);
        
        // Preorden
        System.out.println("\n┌─────────────────────────────────────────────────────────────┐");
        System.out.println("│ 2️⃣  RECORRIDO PREORDEN (Nodo → Izquierdo → Derecho)        │");
        System.out.println("│    Orden: RAÍZ primero, luego subárboles                    │");
        System.out.println("│    Uso: Copiar estructura del árbol                         │");
        System.out.println("└─────────────────────────────────────────────────────────────┘");
        ArrayList<Song> preorden = arbol.recorridoPreorden();
        mostrarListaCancionesConIDs(preorden);
        
        // Postorden
        System.out.println("\n┌─────────────────────────────────────────────────────────────┐");
        System.out.println("│ 3️⃣  RECORRIDO POSTORDEN (Izquierdo → Derecho → Nodo)       │");
        System.out.println("│    Orden: HOJAS primero, raíz al final                      │");
        System.out.println("│    Uso: Eliminar árbol, calcular expresiones                │");
        System.out.println("└─────────────────────────────────────────────────────────────┘");
        ArrayList<Song> postorden = arbol.recorridoPostorden();
        mostrarListaCancionesConIDs(postorden);
        
        // Por niveles
        System.out.println("\n┌─────────────────────────────────────────────────────────────┐");
        System.out.println("│ 4️⃣  RECORRIDO POR NIVELES (Amplitud/BFS)                   │");
        System.out.println("│    Orden: NIVEL por NIVEL, izquierda a derecha             │");
        System.out.println("│    Uso: Búsqueda por niveles, árbol de decisiones          │");
        System.out.println("└─────────────────────────────────────────────────────────────┘");
        ArrayList<Song> niveles = arbol.recorridoPorNiveles();
        mostrarListaCancionesConIDs(niveles);
        
        System.out.println("\n╔══════════════════════════════════════════════════════════════╗");
        System.out.println("║ Total de canciones: " + String.format("%-42d", arbol.contarNodosPublico()) + "║");
        System.out.println("║ Altura del árbol: " + String.format("%-44d", arbol.obtenerAltura()) + "║");
        System.out.println("╚══════════════════════════════════════════════════════════════╝\n");
    }
    
    private void mostrarListaCancionesConIDs(ArrayList<Song> canciones) {
        for (int i = 0; i < canciones.size(); i++) {
            Song s = canciones.get(i);
            System.out.printf("  %2d. [ID:%3d] %-30s - %-20s\n", 
                            i + 1, s.getId(), 
                            truncar(s.getTitulo(), 30), 
                            truncar(s.getArtista(), 20));
        }
    }
    
    private String truncar(String texto, int maxLength) {
        if (texto.length() <= maxLength) {
            return texto;
        }
        return texto.substring(0, maxLength - 3) + "...";
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
    
    // Consultar nivel de una canción (MEJORADO)
    public void consultarNivelCancion(int id) {
        Song cancion = arbol.buscar(id);
        
        if (cancion == null) {
            System.out.println("\n✗ No se encontró ninguna canción con el ID " + id);
            return;
        }
        
        int nivel = arbol.obtenerNivelDeNodo(id);
        int alturaTotal = arbol.obtenerAltura();
        
        System.out.println("\n╔════════════════════════════════════════════════╗");
        System.out.println("║        INFORMACIÓN DE NIVEL DEL NODO          ║");
        System.out.println("╠════════════════════════════════════════════════╣");
        System.out.println("║ Canción: " + String.format("%-38s", cancion.getTitulo()) + "║");
        System.out.println("║ Artista: " + String.format("%-38s", cancion.getArtista()) + "║");
        System.out.println("║ ID: " + String.format("%-43d", cancion.getId()) + "║");
        System.out.println("╠════════════════════════════════════════════════╣");
        System.out.println("║ Nivel en el árbol: " + String.format("%-27d", nivel) + "║");
        System.out.println("║ Altura total del árbol: " + String.format("%-23d", alturaTotal) + "║");
        System.out.println("║ Profundidad relativa: " + String.format("%.1f%%", (nivel * 100.0 / (alturaTotal - 1))) + String.format("%26s", "") + "║");
        System.out.println("╠════════════════════════════════════════════════╣");
        
        // Mostrar posición visual
        System.out.println("║ Posición en el árbol:                         ║");
        if (nivel == 0) {
            System.out.println("║   🌳 RAÍZ (Nivel 0)                            ║");
        } else if (nivel == alturaTotal - 1) {
            System.out.println("║   🍃 HOJA (Nivel más profundo)                ║");
        } else {
            System.out.println("║   🌿 NODO INTERMEDIO (Nivel " + nivel + ")                   ║");
        }
        
        System.out.println("╠════════════════════════════════════════════════╣");
        System.out.println("║ Nota: La raíz está en el nivel 0              ║");
        System.out.println("╚════════════════════════════════════════════════╝\n");
    }
    
    // Verificar si está vacía
    public boolean estaVacia() {
        return arbol.estaVacio();
    }
}
