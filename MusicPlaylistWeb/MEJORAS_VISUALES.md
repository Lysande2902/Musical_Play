# 🎨 Mejoras Visuales y Documentación - Aplicación Web ABB

## ✨ Mejoras Implementadas

### 1. **Tooltips Informativos en el Menú** 🔍

Cada opción del menú ahora muestra una cajita informativa al pasar el mouse:

```html
<a class="tooltip-link">
    Agregar Canción
    <span class="tooltip-text">Insertar un elemento en el árbol</span>
</a>
```

**Características:**
- ✅ Aparecen al hacer hover
- ✅ Diseño estilo Spotify (verde y negro)
- ✅ Animación suave
- ✅ Explican qué hace cada operación

### 2. **Info Boxes en Cada Página** 📦

Cada página principal tiene una caja informativa que explica:
- Número de operación (1-12)
- Método C# utilizado
- Complejidad algorítmica
- Bibliotecas y técnicas
- Descripción detallada

**Ejemplo:**
```html
<div class="info-box">
    <div class="info-box-title">
        <span class="info-box-icon">📝</span>
        Operación 3: Insertar un elemento en el árbol
    </div>
    <div class="info-box-content">
        <strong>Método C#:</strong> <code>Insertar(Song cancion)</code>
        <strong>Complejidad:</strong> O(log n) promedio
    </div>
</div>
```

### 3. **Página de Ayuda Completa** 📚

Nueva página `/Home/Ayuda` con:
- ✅ Explicación de las 12 operaciones
- ✅ Lenguaje y tecnologías utilizadas
- ✅ Métodos C# específicos
- ✅ Complejidad de cada operación
- ✅ Bibliotecas utilizadas
- ✅ Conceptos de POO aplicados

### 4. **Identificación de Operaciones Libres** 🆕

Las operaciones 11 y 12 están claramente marcadas:
- Badge naranja "Libre"
- Emoji 🆕 en títulos
- Explicación de que son operaciones extras

---

## 💻 Lenguaje y Tecnologías

### **Lenguaje Principal**
- **C# 12** - Lenguaje de programación moderno y orientado a objetos

### **Framework**
- **ASP.NET Core 9.0 MVC** - Framework web de Microsoft
  - **M**odel: Song.cs, Node.cs
  - **V**iew: Razor Pages (.cshtml)
  - **C**ontroller: HomeController.cs

### **Frontend**
- **Razor Pages** - Motor de plantillas de ASP.NET
- **HTML5** - Estructura y validaciones
- **CSS3** - Estilos personalizados estilo Spotify
- **JavaScript** - Validaciones en cliente

### **Paradigma**
- **POO (Programación Orientada a Objetos)**
  - Encapsulación
  - Herencia (IComparable)
  - Polimorfismo (ToString, CompareTo)
  - Abstracción (Interfaces)

---

## 📚 Bibliotecas y Métodos C# Utilizados

### **System.Collections.Generic**
```csharp
using System.Collections.Generic;

List<Song> canciones = new List<Song>();
Queue<Node> cola = new Queue<Node>();
```

**Métodos:**
- `List<T>.Add()` - Agregar elementos
- `List<T>.Count` - Contar elementos
- `Queue<T>.Enqueue()` - Agregar a la cola
- `Queue<T>.Dequeue()` - Sacar de la cola

### **System.Linq**
```csharp
using System.Linq;

var topCanciones = canciones
    .OrderByDescending(c => c.Popularidad)
    .ThenBy(c => c.Titulo)
    .Take(10)
    .ToList();
```

**Métodos:**
- `OrderByDescending()` - Ordenar descendente
- `ThenBy()` - Ordenamiento secundario
- `Take()` - Limitar resultados
- `ToList()` - Convertir a lista

### **System (Métodos Básicos)**
```csharp
// Validaciones
string.IsNullOrWhiteSpace(texto)
string.Trim()
string.Contains(substring)
string.ToLower()

// Matemáticas
Math.Max(a, b)

// Comparaciones
int.CompareTo(otro)
```

### **Interfaces Implementadas**
```csharp
public class Song : IComparable<Song>
{
    public int CompareTo(Song? otra)
    {
        return this.Id.CompareTo(otra.Id);
    }
}
```

---

## 🎯 Conceptos de POO Aplicados

### 1. **Encapsulación**
```csharp
public class Song
{
    private int id;  // Campo privado
    
    public int Id    // Propiedad pública
    { 
        get { return id; } 
        set { id = value; } 
    }
}
```

### 2. **Herencia (Interfaces)**
```csharp
public class Song : IComparable<Song>
{
    // Implementa la interfaz IComparable
}
```

### 3. **Polimorfismo**
```csharp
public override string ToString()
{
    // Sobrescribe el método de Object
    return $"[ID: {Id}] {Titulo} - {Artista}";
}
```

### 4. **Abstracción**
```csharp
public interface IComparable<T>
{
    int CompareTo(T? other);
}
```

### 5. **Composición**
```csharp
public class Node
{
    public Song Cancion { get; set; }  // Node contiene Song
    public Node? Izquierdo { get; set; }
    public Node? Derecho { get; set; }
}

public class BinarySearchTree
{
    private Node? raiz;  // BinarySearchTree contiene Node
}
```

---

## 📋 Resumen de las 12 Operaciones

### **Operaciones Básicas (1-10)**

| # | Operación | Método C# | Complejidad |
|---|-----------|-----------|-------------|
| 1 | Imprimir elementos | `RecorridoInorden()` | O(n) |
| 2 | Buscar elemento | `Buscar(int id)` | O(log n) |
| 3 | Insertar elemento | `Insertar(Song)` | O(log n) |
| 4 | Borrar elemento | `Eliminar(int id)` | O(log n) |
| 5 | Recorrido amplitud | `RecorridoPorNiveles()` | O(n) |
| 6 | Recorrido Preorden | `RecorridoPreorden()` | O(n) |
| 7 | Recorrido Postorden | `RecorridoPostorden()` | O(n) |
| 8 | Recorrido Inorden | `RecorridoInorden()` | O(n) |
| 9 | Número de niveles | `ObtenerAltura()` | O(n) |
| 10 | Nivel de nodo | `ObtenerNivelDeNodo(int)` | O(log n) |

### **Operaciones Libres (11-12)**

| # | Operación | Método C# | Bibliotecas |
|---|-----------|-----------|-------------|
| 11 | Buscar por Artista | `BuscarPorArtista(string)` | string.Contains() |
| 12 | Top Populares | `ObtenerTopPopulares(int)` | System.Linq |

---

## 🎨 Elementos Visuales Agregados

### **Tooltips**
- Aparecen al hacer hover en el menú
- Fondo gris oscuro con borde verde
- Animación suave de fade-in
- Flecha apuntando al elemento

### **Info Boxes**
- Fondo degradado gris
- Borde izquierdo verde
- Icono emoji descriptivo
- Título en verde Spotify
- Contenido en gris claro

### **Operation Cards** (Página de Ayuda)
- Número de operación en círculo verde
- Hover effect con borde verde
- Badge de tipo (Básica/Libre)
- Información detallada

### **Colores Spotify**
- Verde: `#1DB954`
- Negro: `#191414`
- Gris oscuro: `#121212`
- Gris: `#282828`
- Gris claro: `#b3b3b3`

---

## 📄 Archivos Modificados/Creados

### **Nuevos Archivos**
1. ✅ `Views/Home/Ayuda.cshtml` - Página de ayuda completa
2. ✅ `MEJORAS_VISUALES.md` - Este documento

### **Archivos Modificados**
1. ✅ `Views/Shared/_Layout.cshtml` - Tooltips en menú
2. ✅ `wwwroot/css/site.css` - Estilos para tooltips e info boxes
3. ✅ `Controllers/HomeController.cs` - Acción Ayuda()
4. ✅ `Views/Home/Index.cshtml` - Info box agregado
5. ✅ `Views/Home/Agregar.cshtml` - Info box agregado
6. ✅ `Views/Home/BuscarPorArtista.cshtml` - Info box agregado
7. ✅ `Views/Home/TopPopulares.cshtml` - Info box agregado
8. ✅ `Views/Home/Recorridos.cshtml` - Info box agregado
9. ✅ `Views/Home/Estadisticas.cshtml` - Info box agregado

---

## 🚀 Cómo Ver las Mejoras

1. **Ejecutar la aplicación:**
```bash
cd MusicPlaylistWeb
dotnet run
```

2. **Abrir en navegador:**
```
https://localhost:5001
```

3. **Explorar:**
- Pasar el mouse sobre las opciones del menú → Ver tooltips
- Visitar cada página → Ver info boxes
- Ir a "❓ Ayuda" → Ver documentación completa

---

## ✅ Resultado Final

**Antes:**
- Menú simple sin explicaciones
- Páginas sin contexto
- No se identificaban las operaciones libres

**Después:**
- ✅ Tooltips informativos en cada opción
- ✅ Info boxes explicativos en cada página
- ✅ Página de ayuda completa con las 12 operaciones
- ✅ Identificación clara de operaciones libres (11-12)
- ✅ Documentación de lenguaje (C#), bibliotecas y POO
- ✅ Diseño consistente estilo Spotify

---

## 📚 Documentación Adicional

- **README.md** - Documentación general
- **MusicPlaylistWeb/README.md** - Documentación de la aplicación web
- **VALIDACIONES.md** - Documentación de validaciones
- **RESUMEN_PROYECTO.md** - Resumen completo del proyecto
- **INICIO_RAPIDO.md** - Guía de inicio rápido

---

**Equipo:** Yeng Lee Salas Jimenez | **Grupo:** 4 E | **Programa:** DSM  
**Lenguaje:** C# 12 | **Framework:** ASP.NET Core 9.0 MVC | **Paradigma:** POO
