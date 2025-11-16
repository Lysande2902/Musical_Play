import java.util.ArrayList;
import java.util.LinkedList;
import java.util.Queue;

public class BinarySearchTree {
    private Node raiz;
    
    public BinarySearchTree() {
        this.raiz = null;
    }
    
    // Método público de inserción
    public boolean insertar(Song cancion) {
        if (cancion == null) {
            return false;
        }
        
        // Si el árbol está vacío, crear la raíz
        if (raiz == null) {
            raiz = new Node(cancion);
            return true;
        }
        
        // Intentar insertar recursivamente
        Node resultado = insertarRecursivo(raiz, cancion);
        return resultado != null;
    }
    
    // Método privado recursivo de inserción
    private Node insertarRecursivo(Node nodo, Song cancion) {
        // Caso base: encontramos la posición para insertar
        if (nodo == null) {
            return new Node(cancion);
        }
        
        // Comparar IDs
        int comparacion = cancion.compareTo(nodo.getCancion());
        
        if (comparacion < 0) {
            // Insertar en subárbol izquierdo
            nodo.setIzquierdo(insertarRecursivo(nodo.getIzquierdo(), cancion));
        } else if (comparacion > 0) {
            // Insertar en subárbol derecho
            nodo.setDerecho(insertarRecursivo(nodo.getDerecho(), cancion));
        } else {
            // ID duplicado, no insertar
            return null;
        }
        
        return nodo;
    }
    
    // Método público de búsqueda
    public Song buscar(int id) {
        Node nodoEncontrado = buscarRecursivo(raiz, id);
        return (nodoEncontrado != null) ? nodoEncontrado.getCancion() : null;
    }
    
    // Método privado recursivo de búsqueda
    private Node buscarRecursivo(Node nodo, int id) {
        // Caso base: árbol vacío o no encontrado
        if (nodo == null) {
            return null;
        }
        
        int idNodo = nodo.getCancion().getId();
        
        if (id == idNodo) {
            // Encontrado
            return nodo;
        } else if (id < idNodo) {
            // Buscar en subárbol izquierdo
            return buscarRecursivo(nodo.getIzquierdo(), id);
        } else {
            // Buscar en subárbol derecho
            return buscarRecursivo(nodo.getDerecho(), id);
        }
    }
    
    // Método público de eliminación
    public boolean eliminar(int id) {
        if (raiz == null) {
            return false;
        }
        
        int tamanoAntes = contarNodos();
        raiz = eliminarRecursivo(raiz, id);
        int tamanoDespues = contarNodos();
        
        return tamanoDespues < tamanoAntes;
    }
    
    // Método privado recursivo de eliminación
    private Node eliminarRecursivo(Node nodo, int id) {
        if (nodo == null) {
            return null;
        }
        
        int idNodo = nodo.getCancion().getId();
        
        if (id < idNodo) {
            // Buscar en subárbol izquierdo
            nodo.setIzquierdo(eliminarRecursivo(nodo.getIzquierdo(), id));
        } else if (id > idNodo) {
            // Buscar en subárbol derecho
            nodo.setDerecho(eliminarRecursivo(nodo.getDerecho(), id));
        } else {
            // Nodo encontrado, proceder a eliminar
            
            // Caso 1: Nodo sin hijos (hoja)
            if (nodo.getIzquierdo() == null && nodo.getDerecho() == null) {
                return null;
            }
            
            // Caso 2: Nodo con un solo hijo
            if (nodo.getIzquierdo() == null) {
                return nodo.getDerecho();
            }
            if (nodo.getDerecho() == null) {
                return nodo.getIzquierdo();
            }
            
            // Caso 3: Nodo con dos hijos
            // Encontrar el sucesor inorden (menor del subárbol derecho)
            Node sucesor = obtenerMinimo(nodo.getDerecho());
            nodo.setCancion(sucesor.getCancion());
            nodo.setDerecho(eliminarRecursivo(nodo.getDerecho(), sucesor.getCancion().getId()));
        }
        
        return nodo;
    }
    
    // Método auxiliar para encontrar el nodo con el valor mínimo
    private Node obtenerMinimo(Node nodo) {
        while (nodo.getIzquierdo() != null) {
            nodo = nodo.getIzquierdo();
        }
        return nodo;
    }
    
    // Método auxiliar para contar nodos
    private int contarNodos() {
        return contarNodosRecursivo(raiz);
    }
    
    private int contarNodosRecursivo(Node nodo) {
        if (nodo == null) {
            return 0;
        }
        return 1 + contarNodosRecursivo(nodo.getIzquierdo()) + contarNodosRecursivo(nodo.getDerecho());
    }
    
    // Recorrido Inorden (Izquierdo → Nodo → Derecho)
    public ArrayList<Song> recorridoInorden() {
        ArrayList<Song> resultado = new ArrayList<>();
        inordenRecursivo(raiz, resultado);
        return resultado;
    }
    
    private void inordenRecursivo(Node nodo, ArrayList<Song> resultado) {
        if (nodo != null) {
            inordenRecursivo(nodo.getIzquierdo(), resultado);
            resultado.add(nodo.getCancion());
            inordenRecursivo(nodo.getDerecho(), resultado);
        }
    }
    
    // Recorrido Preorden (Nodo → Izquierdo → Derecho)
    public ArrayList<Song> recorridoPreorden() {
        ArrayList<Song> resultado = new ArrayList<>();
        preordenRecursivo(raiz, resultado);
        return resultado;
    }
    
    private void preordenRecursivo(Node nodo, ArrayList<Song> resultado) {
        if (nodo != null) {
            resultado.add(nodo.getCancion());
            preordenRecursivo(nodo.getIzquierdo(), resultado);
            preordenRecursivo(nodo.getDerecho(), resultado);
        }
    }
    
    // Recorrido Postorden (Izquierdo → Derecho → Nodo)
    public ArrayList<Song> recorridoPostorden() {
        ArrayList<Song> resultado = new ArrayList<>();
        postordenRecursivo(raiz, resultado);
        return resultado;
    }
    
    private void postordenRecursivo(Node nodo, ArrayList<Song> resultado) {
        if (nodo != null) {
            postordenRecursivo(nodo.getIzquierdo(), resultado);
            postordenRecursivo(nodo.getDerecho(), resultado);
            resultado.add(nodo.getCancion());
        }
    }
    
    // Recorrido por Niveles (BFS)
    public ArrayList<Song> recorridoPorNiveles() {
        ArrayList<Song> resultado = new ArrayList<>();
        
        if (raiz == null) {
            return resultado;
        }
        
        Queue<Node> cola = new LinkedList<>();
        cola.add(raiz);
        
        while (!cola.isEmpty()) {
            Node nodoActual = cola.poll();
            resultado.add(nodoActual.getCancion());
            
            if (nodoActual.getIzquierdo() != null) {
                cola.add(nodoActual.getIzquierdo());
            }
            if (nodoActual.getDerecho() != null) {
                cola.add(nodoActual.getDerecho());
            }
        }
        
        return resultado;
    }
    
    // Obtener altura del árbol
    public int obtenerAltura() {
        return alturaRecursiva(raiz);
    }
    
    private int alturaRecursiva(Node nodo) {
        if (nodo == null) {
            return 0;
        }
        
        int alturaIzq = alturaRecursiva(nodo.getIzquierdo());
        int alturaDer = alturaRecursiva(nodo.getDerecho());
        
        return 1 + Math.max(alturaIzq, alturaDer);
    }
    
    // Obtener nivel de un nodo específico
    public int obtenerNivelDeNodo(int id) {
        return nivelRecursivo(raiz, id, 0);
    }
    
    private int nivelRecursivo(Node nodo, int id, int nivelActual) {
        if (nodo == null) {
            return -1; // No encontrado
        }
        
        int idNodo = nodo.getCancion().getId();
        
        if (id == idNodo) {
            return nivelActual;
        } else if (id < idNodo) {
            return nivelRecursivo(nodo.getIzquierdo(), id, nivelActual + 1);
        } else {
            return nivelRecursivo(nodo.getDerecho(), id, nivelActual + 1);
        }
    }
    
    public boolean estaVacio() {
        return raiz == null;
    }
    
    // Contar nodos públicamente
    public int contarNodosPublico() {
        return contarNodos();
    }
    
    // Imprimir árbol con estructura visual
    public void imprimirArbol() {
        if (raiz == null) {
            System.out.println("El árbol está vacío.");
            return;
        }
        
        System.out.println("\n=== ESTRUCTURA DEL ÁRBOL ===");
        imprimirArbolRecursivo(raiz, "", true);
        System.out.println("\nAltura: " + obtenerAltura() + " niveles");
        System.out.println("Total de canciones: " + contarNodos());
        System.out.println("============================\n");
    }
    
    private void imprimirArbolRecursivo(Node nodo, String prefijo, boolean esUltimo) {
        if (nodo != null) {
            System.out.println(prefijo + (esUltimo ? "└── " : "├── ") + 
                             "[" + nodo.getCancion().getId() + "] " + 
                             nodo.getCancion().getTitulo());
            
            String nuevoPrefijo = prefijo + (esUltimo ? "    " : "│   ");
            
            if (nodo.getIzquierdo() != null || nodo.getDerecho() != null) {
                if (nodo.getIzquierdo() != null) {
                    imprimirArbolRecursivo(nodo.getIzquierdo(), nuevoPrefijo, 
                                         nodo.getDerecho() == null);
                }
                if (nodo.getDerecho() != null) {
                    imprimirArbolRecursivo(nodo.getDerecho(), nuevoPrefijo, true);
                }
            }
        }
    }
}
