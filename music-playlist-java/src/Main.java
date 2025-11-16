import java.util.Scanner;
import java.util.InputMismatchException;

public class Main {
    private static PlaylistManager manager;
    private static Scanner scanner;
    
    public static void main(String[] args) {
        manager = new PlaylistManager();
        scanner = new Scanner(System.in);
        
        mostrarBienvenida();
        menuPrincipal();
        
        scanner.close();
    }
    
    private static void mostrarBienvenida() {
        System.out.println("===========================================");
        System.out.println("   SISTEMA DE PLAYLIST MUSICAL - ABB");
        System.out.println("===========================================");
        System.out.println("Equipo: Yeng Lee Salas Jimenez, [Integrante 2], [Integrante 3]");
        System.out.println("Grupo: 4 E | Programa: DSM");
        System.out.println("===========================================\n");
    }
    
    private static void menuPrincipal() {
        int opcion = -1;
        
        do {
            mostrarMenu();
            
            try {
                System.out.print("Seleccione una opción: ");
                opcion = scanner.nextInt();
                scanner.nextLine(); // Limpiar buffer
                
                System.out.println();
                procesarOpcion(opcion);
                
                if (opcion != 0) {
                    System.out.print("\nPresione Enter para continuar...");
                    scanner.nextLine();
                }
                
            } catch (InputMismatchException e) {
                System.out.println("\n✗ Error: Debe ingresar un número válido.");
                scanner.nextLine(); // Limpiar buffer
                System.out.print("\nPresione Enter para continuar...");
                scanner.nextLine();
            }
            
        } while (opcion != 0);
        
        System.out.println("\n¡Gracias por usar el Sistema de Playlist Musical!");
        System.out.println("===========================================\n");
    }
    
    private static void mostrarMenu() {
        System.out.println("\n╔═══════════════════════════════════════════╗");
        System.out.println("║           MENÚ PRINCIPAL                  ║");
        System.out.println("╠═══════════════════════════════════════════╣");
        System.out.println("║ GESTIÓN DE CANCIONES                      ║");
        System.out.println("║  1. Agregar canción                       ║");
        System.out.println("║  2. Buscar canción por ID                 ║");
        System.out.println("║  3. Buscar por título                     ║");
        System.out.println("║  4. Buscar por artista                    ║");
        System.out.println("║  5. Eliminar canción                      ║");
        System.out.println("╠═══════════════════════════════════════════╣");
        System.out.println("║ VISUALIZACIÓN                             ║");
        System.out.println("║  6. Mostrar playlist ordenada (Inorden)   ║");
        System.out.println("║  7. Mostrar todos los recorridos          ║");
        System.out.println("╠═══════════════════════════════════════════╣");
        System.out.println("║ ANÁLISIS                                  ║");
        System.out.println("║  8. Consultar nivel de una canción        ║");
        System.out.println("║  9. Mostrar estadísticas completas        ║");
        System.out.println("╠═══════════════════════════════════════════╣");
        System.out.println("║ UTILIDADES                                ║");
        System.out.println("║ 10. Cargar canciones de prueba            ║");
        System.out.println("║  0. Salir                                 ║");
        System.out.println("╚═══════════════════════════════════════════╝");
    }
    
    private static void procesarOpcion(int opcion) {
        switch (opcion) {
            case 1:
                agregarCancion();
                break;
            case 2:
                buscarCancion();
                break;
            case 3:
                buscarPorTitulo();
                break;
            case 4:
                buscarPorArtista();
                break;
            case 5:
                eliminarCancion();
                break;
            case 6:
                manager.mostrarPlaylistOrdenada();
                break;
            case 7:
                manager.mostrarTodosLosRecorridos();
                break;
            case 8:
                consultarNivel();
                break;
            case 9:
                manager.mostrarEstadisticas();
                break;
            case 10:
                cargarCancionesDePrueba();
                break;
            case 0:
                // Salir
                break;
            default:
                System.out.println("✗ Opción inválida. Por favor, seleccione una opción del menú.");
        }
    }
    
    private static void agregarCancion() {
        System.out.println("\n╔═══════════════════════════════════════════╗");
        System.out.println("║         AGREGAR NUEVA CANCIÓN             ║");
        System.out.println("╚═══════════════════════════════════════════╝\n");
        
        try {
            // Sugerir ID
            int idSugerido = manager.sugerirProximoID();
            System.out.println("💡 ID sugerido: " + idSugerido + " (puedes usar otro)");
            
            System.out.print("ID: ");
            int id = scanner.nextInt();
            scanner.nextLine();
            
            System.out.print("Título (1-100 caracteres): ");
            String titulo = scanner.nextLine();
            
            System.out.print("Artista (1-50 caracteres): ");
            String artista = scanner.nextLine();
            
            System.out.print("Duración en segundos (10-7200): ");
            int duracion = scanner.nextInt();
            
            System.out.print("Popularidad (0-100): ");
            int popularidad = scanner.nextInt();
            scanner.nextLine();
            
            Song cancion = new Song(id, titulo, artista, duracion, popularidad);
            manager.agregarCancion(cancion);
            
        } catch (InputMismatchException e) {
            System.out.println("\n✗ Error: Formato de entrada inválido.");
            scanner.nextLine();
        } catch (IllegalArgumentException e) {
            System.out.println("\n✗ Error de validación: " + e.getMessage());
        }
    }
    
    private static void buscarCancion() {
        System.out.println("--- BUSCAR CANCIÓN ---\n");
        
        try {
            System.out.print("Ingrese el ID de la canción: ");
            int id = scanner.nextInt();
            scanner.nextLine();
            
            manager.buscarCancion(id);
            
        } catch (InputMismatchException e) {
            System.out.println("\n✗ Error: Debe ingresar un número válido.");
            scanner.nextLine();
        }
    }
    
    private static void buscarPorTitulo() {
        System.out.println("\n--- BUSCAR POR TÍTULO ---\n");
        
        try {
            System.out.print("Ingrese el título (o parte del título): ");
            String titulo = scanner.nextLine();
            
            manager.buscarPorTitulo(titulo);
            
        } catch (Exception e) {
            System.out.println("\n✗ Error: " + e.getMessage());
        }
    }
    
    private static void buscarPorArtista() {
        System.out.println("\n--- BUSCAR POR ARTISTA ---\n");
        
        try {
            System.out.print("Ingrese el artista (o parte del nombre): ");
            String artista = scanner.nextLine();
            
            manager.buscarPorArtista(artista);
            
        } catch (Exception e) {
            System.out.println("\n✗ Error: " + e.getMessage());
        }
    }
    
    private static void eliminarCancion() {
        System.out.println("\n--- ELIMINAR CANCIÓN ---\n");
        
        try {
            System.out.print("Ingrese el ID de la canción a eliminar: ");
            int id = scanner.nextInt();
            scanner.nextLine();
            
            manager.eliminarCancionConConfirmacion(id, scanner);
            
        } catch (InputMismatchException e) {
            System.out.println("\n✗ Error: Debe ingresar un número válido.");
            scanner.nextLine();
        }
    }
    
    private static void mostrarRecorridoPreorden() {
        if (manager.estaVacia()) {
            System.out.println("\n✗ La playlist está vacía.");
            return;
        }
        
        System.out.println("\n=== RECORRIDO PREORDEN ===");
        System.out.println("(Nodo → Izquierdo → Derecho)\n");
        
        // Usar el método del manager que ya existe
        manager.mostrarTodosLosRecorridos();
    }
    
    private static void mostrarRecorridoPostorden() {
        if (manager.estaVacia()) {
            System.out.println("\n✗ La playlist está vacía.");
            return;
        }
        
        System.out.println("\n=== RECORRIDO POSTORDEN ===");
        System.out.println("(Izquierdo → Derecho → Nodo)\n");
        
        manager.mostrarTodosLosRecorridos();
    }
    
    private static void mostrarRecorridoPorNiveles() {
        if (manager.estaVacia()) {
            System.out.println("\n✗ La playlist está vacía.");
            return;
        }
        
        System.out.println("\n=== RECORRIDO POR NIVELES ===");
        System.out.println("(Amplitud / BFS)\n");
        
        manager.mostrarTodosLosRecorridos();
    }
    
    private static void mostrarAltura() {
        if (manager.estaVacia()) {
            System.out.println("\n✗ La playlist está vacía.");
            return;
        }
        
        manager.mostrarEstadisticas();
    }
    
    private static void consultarNivel() {
        System.out.println("--- CONSULTAR NIVEL DE CANCIÓN ---\n");
        
        try {
            System.out.print("Ingrese el ID de la canción: ");
            int id = scanner.nextInt();
            scanner.nextLine();
            
            manager.consultarNivelCancion(id);
            
        } catch (InputMismatchException e) {
            System.out.println("\n✗ Error: Debe ingresar un número válido.");
            scanner.nextLine();
        }
    }
    
    private static void cargarCancionesDePrueba() {
        System.out.println("--- CARGANDO CANCIONES DE PRUEBA ---\n");
        
        Song[] cancionesPrueba = {
            new Song(5, "Stairway to Heaven", "Led Zeppelin", 482, 95),
            new Song(3, "Hotel California", "Eagles", 391, 92),
            new Song(7, "Imagine", "John Lennon", 183, 96),
            new Song(1, "Bohemian Rhapsody", "Queen", 354, 98),
            new Song(4, "Smells Like Teen Spirit", "Nirvana", 301, 94),
            new Song(6, "Sweet Child O' Mine", "Guns N' Roses", 356, 93),
            new Song(2, "Hey Jude", "The Beatles", 431, 97)
        };
        
        int agregadas = 0;
        for (Song cancion : cancionesPrueba) {
            try {
                manager.agregarCancion(cancion);
                agregadas++;
            } catch (Exception e) {
                // Ignorar errores de duplicados
            }
        }
        
        System.out.println("\n✓ Se cargaron " + agregadas + " canciones de prueba.");
    }
}
