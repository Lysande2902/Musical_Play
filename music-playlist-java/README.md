# Sistema de Playlist Musical - Implementación Java

## 🎵 Proyecto ABB en Java

Este es el proyecto de Árbol Binario de Búsqueda implementado en **Java** para gestionar una playlist musical.

---

## 📋 Requisitos

- **Java JDK:** 8 o superior
- **Sistema Operativo:** Windows, Linux, macOS

---

## 🚀 Compilación y Ejecución

### Opción 1: Compilar y Ejecutar (Recomendado)

```bash
# Compilar todos los archivos
javac -d bin src/*.java

# Ejecutar el programa
java -cp bin Main
```

### Opción 2: Compilar con Encoding UTF-8

```bash
# Compilar con encoding UTF-8 para caracteres especiales
javac -encoding UTF-8 -d bin src/*.java

# Ejecutar con encoding UTF-8
java -Dfile.encoding=UTF-8 -cp bin Main
```

---

## 📁 Estructura de Archivos

```
music-playlist-java/
├── src/
│   ├── Song.java                # Modelo de canción con validaciones
│   ├── Node.java                # Nodo del árbol binario
│   ├── BinarySearchTree.java    # Implementación del ABB
│   ├── PlaylistManager.java     # Gestor de alto nivel
│   └── Main.java                # Interfaz de usuario (menú)
├── bin/                         # Archivos compilados (.class)
├── equipo.txt                   # Información del equipo
└── README.md                    # Este archivo
```

---

## 🔧 Clases Principales

### 1. Song.java
**Responsabilidad:** Modelo de datos de una canción

**Atributos:**
- `id` (int): Identificador único
- `titulo` (String): Nombre de la canción
- `artista` (String): Nombre del artista
- `duracion` (int): Duración en segundos
- `popularidad` (int): Puntuación 0-100

**Validaciones:**
- ID > 0
- Título y artista no vacíos
- Duración > 0
- Popularidad entre 0 y 100

### 2. Node.java
**Responsabilidad:** Nodo del árbol binario

**Atributos:**
- `cancion` (Song): Canción almacenada
- `izquierdo` (Node): Hijo izquierdo
- `derecho` (Node): Hijo derecho

### 3. BinarySearchTree.java
**Responsabilidad:** Implementación del ABB

**Métodos principales:**
- `insertar(Song)`: Inserta una canción
- `buscar(int)`: Busca por ID
- `eliminar(int)`: Elimina una canción
- `recorridoInorden()`: Retorna lista ordenada
- `recorridoPreorden()`: Retorna lista en preorden
- `recorridoPostorden()`: Retorna lista en postorden
- `recorridoPorNiveles()`: Retorna lista por niveles (BFS)
- `obtenerAltura()`: Retorna altura del árbol
- `obtenerNivelDeNodo(int)`: Retorna nivel de un nodo
- `imprimirArbol()`: Visualiza estructura del árbol

### 4. PlaylistManager.java
**Responsabilidad:** Gestión de alto nivel y validaciones

**Métodos principales:**
- `agregarCancion(Song)`: Agrega con validaciones
- `buscarCancion(int)`: Busca y muestra información
- `eliminarCancion(int)`: Elimina con confirmación
- `mostrarPlaylistOrdenada()`: Muestra recorrido inorden
- `mostrarTodosLosRecorridos()`: Muestra los 4 recorridos
- `mostrarEstadisticas()`: Muestra altura y cantidad
- `consultarNivelCancion(int)`: Consulta nivel específico

### 5. Main.java
**Responsabilidad:** Interfaz de usuario

**Funcionalidades:**
- Menú interactivo con 12 opciones
- Captura de entrada con validación
- Manejo de excepciones
- Carga de datos de prueba

---

## 📏 Reglas de Validación (Java)

### Tipos de Datos Aceptados

| Campo | Tipo Java | Validación | Ejemplo Válido | Ejemplo Inválido |
|-------|-----------|------------|----------------|------------------|
| ID | `int` | > 0, único | 5, 100 | 0, -1, "abc" |
| Título | `String` | No vacío | "Imagine" | "", "   " |
| Artista | `String` | No vacío | "Queen" | "", null |
| Duración | `int` | > 0 | 180, 482 | 0, -100, "5min" |
| Popularidad | `int` | 0-100 | 50, 95 | -1, 101, "alta" |

### Excepciones Lanzadas

```java
// ID inválido
throw new IllegalArgumentException("El ID debe ser positivo");

// Título vacío
throw new IllegalArgumentException("El título no puede estar vacío");

// Popularidad fuera de rango
throw new IllegalArgumentException("La popularidad debe estar entre 0 y 100");
```

---

## 🧪 Pruebas Manuales

### Caso 1: Inserción Exitosa
```
Opción: 1
ID: 5
Título: Stairway to Heaven
Artista: Led Zeppelin
Duración: 482
Popularidad: 95

Resultado esperado: ✓ Canción agregada exitosamente!
```

### Caso 2: ID Duplicado
```
Opción: 1
ID: 5 (ya existe)
...

Resultado esperado: ✗ Error: Ya existe una canción con el ID 5
```

### Caso 3: Validación de Popularidad
```
Opción: 1
ID: 10
Título: Test
Artista: Test
Duración: 100
Popularidad: 150

Resultado esperado: ✗ Error: La popularidad debe estar entre 0 y 100
```

### Caso 4: Entrada No Numérica
```
Opción: 1
ID: abc

Resultado esperado: ✗ Error: Formato de entrada inválido.
```

### Caso 5: Recorrido Inorden
```
Opción: 12 (Cargar datos de prueba)
Opción: 4 (Mostrar playlist ordenada)

Resultado esperado: Lista de canciones ordenadas por ID ascendente
```

---

## 🐛 Solución de Problemas Comunes

### Error: "class not found"
```bash
# Asegúrate de compilar primero
javac -d bin src/*.java

# Luego ejecutar desde la raíz del proyecto
java -cp bin Main
```

### Error: "InputMismatchException"
**Causa:** Entrada no numérica donde se espera número  
**Solución:** El programa maneja esto automáticamente, solo presiona Enter y vuelve a intentar

### Error: Caracteres especiales (✓, ✗) no se muestran
```bash
# Ejecutar con encoding UTF-8
java -Dfile.encoding=UTF-8 -cp bin Main
```

### Error: "IllegalArgumentException"
**Causa:** Datos inválidos al crear una canción  
**Solución:** Verifica que los datos cumplan las reglas de validación

---

## 📊 Ejemplo de Salida

```
===========================================
   SISTEMA DE PLAYLIST MUSICAL - ABB
===========================================
Equipo: Yeng Lee Salas Jimenez, [Integrante 2], [Integrante 3]
Grupo: 4 E | Programa: DSM
===========================================

=== ESTRUCTURA DEL ÁRBOL ===
└── [5] Stairway to Heaven
    ├── [3] Hotel California
    │   ├── [1] Bohemian Rhapsody
    │   │   └── [2] Hey Jude
    │   └── [4] Smells Like Teen Spirit
    └── [7] Imagine
        └── [6] Sweet Child O' Mine

Altura: 4 niveles
Total de canciones: 7
============================
```

---

## 📝 Notas de Implementación

### Manejo de Excepciones
- `IllegalArgumentException`: Validaciones de datos
- `InputMismatchException`: Entrada no numérica
- Try-catch en Main.java para capturar errores de entrada

### Comparación de Canciones
```java
@Override
public int compareTo(Song otra) {
    return Integer.compare(this.id, otra.id);
}
```

### Recorrido por Niveles (BFS)
```java
Queue<Node> cola = new LinkedList<>();
cola.add(raiz);

while (!cola.isEmpty()) {
    Node nodoActual = cola.poll();
    // Procesar nodo...
}
```

---

## 🎓 Conceptos Aplicados

- **Árbol Binario de Búsqueda (ABB)**
- **Recursión** (inserción, búsqueda, eliminación, recorridos)
- **Cola (Queue)** para recorrido por niveles
- **Comparable Interface** para comparación de objetos
- **Exception Handling** para validaciones
- **Scanner** para entrada de usuario

---

## 📚 Referencias

- [Java Documentation](https://docs.oracle.com/en/java/)
- [Binary Search Tree](https://en.wikipedia.org/wiki/Binary_search_tree)
- [Tree Traversal](https://en.wikipedia.org/wiki/Tree_traversal)

---

**Desarrollado por:** Equipo 4 E - DSM  
**Fecha:** Noviembre 2025
