public class Node {
    private Song cancion;
    private Node izquierdo;
    private Node derecho;
    
    public Node(Song cancion) {
        this.cancion = cancion;
        this.izquierdo = null;
        this.derecho = null;
    }
    
    // Getters
    public Song getCancion() {
        return cancion;
    }
    
    public Node getIzquierdo() {
        return izquierdo;
    }
    
    public Node getDerecho() {
        return derecho;
    }
    
    // Setters
    public void setCancion(Song cancion) {
        this.cancion = cancion;
    }
    
    public void setIzquierdo(Node izquierdo) {
        this.izquierdo = izquierdo;
    }
    
    public void setDerecho(Node derecho) {
        this.derecho = derecho;
    }
}
