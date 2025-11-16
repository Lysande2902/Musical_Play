# Sistema de Playlist Musical - Implementación C#

## 🎵 Proyecto ABB en C#

Este es el proyecto de Árbol Binario de Búsqueda implementado en **C#** para gestionar una playlist musical.

---

## 📋 Requisitos

- **.NET SDK:** 9.0 o superior (también compatible con .NET 6.0+)
- **Sistema Operativo:** Windows, Linux, macOS

### Verificar Instalación de .NET
```bash
dotnet --version
```

---

## 🚀 Compilación y Ejecución

### Opción 1: Ejecutar Directamente (Recomendado)

```bash
# Ejecutar el proyecto (compila automáticamente)
dotnet run --project MusicPlaylistCSharp.csproj
```

### Opción 2: Compilar y Ejecutar por Separado

```bash
# Compilar el proyecto
dotnet build MusicPlaylistCSharp.csproj

# Ejecutar el ejecutable compilado
dotnet bin/Debug/net9.0/MusicPlaylistCSharp.dll
```

### Opción 3: Compilar en Release

```bash
# Compilar en modo Release (optimizado)
dotnet build -c Release MusicPlaylistCSharp.csproj

# Ejecutar
dotnet bin/Release/net9.0/MusicPlaylistCSharp.dll
```

---

## 📁 Estructura de Archivos

```
MusicPlaylistCSharp/
├── Models/
│   ├── Song.cs                      # Modelo de canción con validaciones
│   └── Node.cs                      # Nodo del árbol binario
├── DataStructures/
│   └── BinarySearchTree.cs          # Implementación del ABB
├── Managers/
│   └── PlaylistManager.cs           # Gestor de alto nivel
├── Program.cs                       # Interfaz de usuario (menú)
├── MusicPlaylistCSharp.csproj       # Archivo de proyecto .NET
├── bin/                             # Archivos compilados
├── obj/                             # Archivos temporales de compilación
├── equipo.txt                       # Información del equipo
└── README.md                        # Este archivo
```

---

## 🔧 Clases Principales

### 1. Models/Song.cs
**Namespace:** `MusicPlaylistCSharp.Models`  
**Responsabilidad:** Modelo de datos de una canción

**Propiedades:**
- `Id` (int): Identificador único (solo lectura)
- `Titulo` (string): Nombre de la canción (solo lectura)
- `Artista` (string): Nombre del artista (solo lectura)
- `Duracion` (int): Duración en segundos (solo lectura)
- `Popularidad` (int): Puntuación 0-100 (solo lectura)

**Validaciones en Constructor:**
```csharp
if (id <= 0)
    throw new ArgumentException("El ID debe ser un número positivo mayor a 0.");

if (string.IsNullOrWhiteSpace(titulo))
    throw new ArgumentException("El título no puede estar vacío...");

if (popularidad < 0 || popularidad > 100)
    throw new ArgumentException($"La popularidad debe estar entre 0 y 100...");
```

**Interfaces Implementadas:**
- `IComparable<Song>`: Para comparación por ID

### 2. Models/Node.cs
**Namespace:** `MusicPlaylistCSharp.Models`  
**Responsabilidad:** Nodo del árbol binario

**Propiedades:**
- `Cancion` (Song): Canción almacenada
- `Izquierdo` (Node?): Hijo izquierdo (nullable)
- `Derecho` (Node?): Hijo derecho (nullable)

### 3. DataStructures/BinarySearchTree.cs
**Namespace:** `MusicPlaylistCSharp.DataStructures`  
**Responsabilidad:** Implementación del ABB con manejo robusto de errores

**Métodos Públicos:**
- `Insertar(Song)`: Inserta una canción (lanza excepciones si es nula)
- `Buscar(int)`: Busca por ID (valida ID > 0)
- `Eliminar(int)`: Elimina una canción (valida ID > 0)
- `RecorridoInorden()`: Retorna `List<Song>` ordenada
- `RecorridoPreorden()`: Retorna `List<Song>` en preorden
- `RecorridoPostorden()`: Retorna `List<Song>` en postorden
- `RecorridoPorNiveles()`: Retorna `List<Song>` por niveles (BFS)
- `ObtenerAltura()`: Retorna altura del árbol
- `ObtenerNivelDeNodo(int)`: Retorna nivel de un nodo (valida ID > 0)
- `EstaVacio()`: Verifica si el árbol está vacío
- `ContarNodosPublico()`: Cuenta total de nodos
- `ImprimirArbol()`: Visualiza estructura del árbol

**Excepciones Lanzadas:**
- `ArgumentNullException`: Cuando se pasa una canción nula
- `ArgumentException`: Cuando el ID es inválido (≤ 0)
- `InvalidOperationException`: Errores durante operaciones del árbol

### 4. Managers/PlaylistManager.cs
**Namespace:** `MusicPlaylistCSharp.Managers`  
**Responsabilidad:** Gestión de alto nivel con manejo exhaustivo de errores

**Métodos Públicos:**
- `AgregarCancion(Song)`: Agrega con try-catch múltiple
- `BuscarCancion(int)`: Busca y muestra información
- `EliminarCancion(int)`: Elimina con confirmación
- `MostrarPlaylistOrdenada()`: Muestra recorrido inorden
- `MostrarTodosLosRecorridos()`: Muestra los 4 recorridos
- `MostrarEstadisticas()`: Muestra altura y cantidad
- `ConsultarNivelCancion(int)`: Consulta nivel específico
- `EstaVacia()`: Verifica si está vacía

**Manejo de Errores:**
```csharp
try
{
    // Operación
}
catch (ArgumentException ex)
{
    Console.WriteLine($"✗ Error de validación: {ex.Message}");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"✗ Error de operación: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"✗ Error inesperado: {ex.Message}");
}
```

### 5. Program.cs
**Responsabilidad:** Interfaz de usuario con validación robusta

**Características:**
- Menú interactivo con 12 opciones
- Validación de entrada con `TryParse`
- Validación de strings vacíos
- Try-catch global para errores críticos
- Encoding UTF-8 configurado automáticamente

---

## 📏 Reglas de Validación (C#)

### Tipos de Datos Aceptados

| Campo | Tipo C# | Validación | Ejemplo Válido | Ejemplo Inválido |
|-------|---------|------------|----------------|------------------|
| ID | `int` | > 0, único | 5, 100 | 0, -1, "abc" |
| Título | `string` | No vacío/whitespace | "Imagine" | "", "   ", null |
| Artista | `string` | No vacío/whitespace | "Queen" | "", "   ", null |
| Duración | `int` | > 0 | 180, 482 | 0, -100, "5min" |
| Popularidad | `int` | 0-100 | 50, 95 | -1, 101, "alta" |

### Validación de Entrada en Program.cs

```csharp
// Validación de entero
if (!int.TryParse(input, out int id))
{
    Console.WriteLine("\n✗ Error: El ID debe ser un número entero.");
    return;
}

// Validación de string
if (string.IsNullOrWhiteSpace(titulo))
{
    Console.WriteLine("\n✗ Error: El título no puede estar vacío.");
    return;
}
```

### Excepciones del Sistema

```csharp
// ArgumentException - Datos inválidos
throw new ArgumentException("El ID debe ser un número positivo mayor a 0.");

// ArgumentNullException - Parámetro nulo
throw new ArgumentNullException(nameof(cancion), "La canción no puede ser nula.");

// InvalidOperationException - Error de operación
throw new InvalidOperationException($"Error al insertar la canción: {ex.Message}", ex);
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

### Caso 2: Validación de Entrada No Numérica
```
Opción: 1
ID: abc

Resultado esperado: ✗ Error: El ID debe ser un número entero.
```

### Caso 3: Validación de Popularidad
```
Opción: 1
ID: 10
Título: Test
Artista: Test
Duración: 100
Popularidad: 150

Resultado esperado: ✗ Error de validación: La popularidad debe estar entre 0 y 100. Valor recibido: 150
```

### Caso 4: ID Duplicado
```
Opción: 1
ID: 5 (ya existe)
...

Resultado esperado: ✗ Error: Ya existe una canción con el ID 5
```

### Caso 5: Búsqueda de Canción Inexistente
```
Opción: 2
ID: 999

Resultado esperado: ✗ No se encontró ninguna canción con el ID 999
```

---

## 🐛 Solución de Problemas Comunes

### Error: ".NET SDK not found"
```bash
# Verificar instalación
dotnet --version

# Si no está instalado, descargar de:
# https://dotnet.microsoft.com/download
```

### Error: "Framework not found"
**Causa:** El proyecto requiere .NET 9.0 pero tienes otra versión  
**Solución:** Editar `MusicPlaylistCSharp.csproj` y cambiar:
```xml
<TargetFramework>net9.0</TargetFramework>
```
Por tu versión instalada (ej: `net6.0`, `net7.0`, `net8.0`)

### Warning: "Possible null reference"
**Causa:** Warnings de nullable reference types (C# 8.0+)  
**Solución:** Estos son solo warnings, no afectan la ejecución. El código maneja correctamente los nulos.

### Error: "The type or namespace name could not be found"
```bash
# Limpiar y recompilar
dotnet clean
dotnet build
```

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

## 📝 Características Específicas de C#

### Nullable Reference Types
```csharp
public Node? Izquierdo { get; set; }  // Puede ser null
public Song Cancion { get; set; }      // No puede ser null
```

### Properties con Get-Only
```csharp
public int Id => id;  // Solo lectura desde fuera de la clase
```

### String Interpolation
```csharp
Console.WriteLine($"✗ Error: Ya existe una canción con el ID {cancion.Id}");
```

### Pattern Matching
```csharp
if (nodoEncontrado?.Cancion != null)
{
    // Usar nodoEncontrado.Cancion
}
```

### Collection Initializers
```csharp
Song[] cancionesPrueba = {
    new Song(5, "Stairway to Heaven", "Led Zeppelin", 482, 95),
    new Song(3, "Hotel California", "Eagles", 391, 92),
    // ...
};
```

---

## 🎓 Conceptos Aplicados

- **Árbol Binario de Búsqueda (ABB)**
- **Recursión** (inserción, búsqueda, eliminación, recorridos)
- **Generics** (`List<Song>`, `Queue<Node>`)
- **Nullable Reference Types** (C# 8.0+)
- **Properties** (get/set)
- **Interfaces** (`IComparable<T>`)
- **Exception Handling** (try-catch-finally)
- **Namespaces** para organización de código
- **LINQ** (opcional, no usado pero disponible)

---

## 🔒 Seguridad y Validación

### Capas de Validación

1. **Capa de Entrada (Program.cs)**
   - Validación con `TryParse`
   - Verificación de strings vacíos
   - Try-catch para capturar errores

2. **Capa de Modelo (Song.cs)**
   - Validación en constructor
   - Excepciones descriptivas
   - Trim automático de strings

3. **Capa de Estructura (BinarySearchTree.cs)**
   - Validación de parámetros
   - Manejo de casos especiales
   - Excepciones específicas

4. **Capa de Gestión (PlaylistManager.cs)**
   - Try-catch múltiple
   - Mensajes de error claros
   - Validación adicional

---

## 📚 Referencias

- [C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [.NET API Browser](https://docs.microsoft.com/en-us/dotnet/api/)
- [Binary Search Tree](https://en.wikipedia.org/wiki/Binary_search_tree)
- [Exception Handling Best Practices](https://docs.microsoft.com/en-us/dotnet/standard/exceptions/best-practices-for-exceptions)

---

## 🆚 Diferencias con la Versión Java

| Característica | Java | C# |
|----------------|------|-----|
| Propiedades | Getters/Setters | Properties (get/set) |
| Colecciones | `ArrayList` | `List<T>` |
| Nullable | `@Nullable` | `?` operator |
| Namespaces | `package` | `namespace` |
| Convenciones | camelCase | PascalCase |
| Excepciones | Checked/Unchecked | Solo Unchecked |

---

**Desarrollado por:** Equipo 4 E - DSM  
**Fecha:** Noviembre 2025
