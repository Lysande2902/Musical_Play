# 🎵 Sistema de Playlist Musical - Aplicación Web

## Árbol Binario de Búsqueda (ABB) con ASP.NET Core MVC

**Equipo:** Yeng Lee Salas Jimenez, [Integrante 2], [Integrante 3]  
**Grupo:** 4 E | **Programa:** DSM  
**Tecnología:** ASP.NET Core 9.0 MVC

---

## 🌟 Características

### ✅ Operaciones Básicas del ABB
1. ✅ **Imprimir** elementos del árbol
2. ✅ **Buscar** elemento por ID
3. ✅ **Insertar** elemento en el árbol
4. ✅ **Borrar** elemento del árbol
5. ✅ **Recorrido en Amplitud** (por niveles/BFS)
6. ✅ **Recorrido Preorden**
7. ✅ **Recorrido Postorden**
8. ✅ **Recorrido Inorden**
9. ✅ **Número de niveles** del árbol (altura)
10. ✅ **Nivel de un nodo** específico

### 🆕 Operaciones Libres (Extras)
11. ✅ **Buscar por Artista** - Búsqueda parcial de canciones por nombre de artista
12. ✅ **Top Populares** - Obtener las N canciones más populares ordenadas

---

## 🎨 Diseño

**Estilo:** Inspirado en Spotify  
**Colores:**
- Verde principal: `#1DB954` (Spotify Green)
- Negro: `#191414` (Spotify Black)
- Gris oscuro: `#121212`
- Gris: `#282828`

**Características del diseño:**
- ✅ Interfaz moderna y responsiva
- ✅ Animaciones suaves
- ✅ Tarjetas con hover effects
- ✅ Barra de popularidad visual
- ✅ Iconos y emojis para mejor UX

---

## 🏗️ Arquitectura (POO)

### Estructura del Proyecto

```
MusicPlaylistWeb/
├── Models/                      # Modelos de datos
│   ├── Song.cs                  # Clase Song (IComparable)
│   └── Node.cs                  # Clase Node del árbol
├── DataStructures/              # Estructuras de datos
│   └── BinarySearchTree.cs      # Implementación del ABB
├── Services/                    # Capa de servicios
│   └── PlaylistService.cs       # Lógica de negocio
├── Controllers/                 # Controladores MVC
│   └── HomeController.cs        # Controlador principal
├── Views/                       # Vistas Razor
│   ├── Home/
│   │   ├── Index.cshtml         # Página principal
│   │   ├── Agregar.cshtml       # Formulario agregar
│   │   ├── Buscar.cshtml        # Buscar por ID
│   │   ├── BuscarPorArtista.cshtml  # Operación Libre 1
│   │   ├── TopPopulares.cshtml  # Operación Libre 2
│   │   ├── Recorridos.cshtml    # Todos los recorridos
│   │   └── Estadisticas.cshtml  # Estadísticas del árbol
│   └── Shared/
│       └── _Layout.cshtml       # Layout principal
└── wwwroot/                     # Archivos estáticos
    └── css/
        └── site.css             # Estilos personalizados
```

### Principios de POO Aplicados

#### 1. **Encapsulación**
```csharp
public class Song
{
    public int Id { get; set; }          // Propiedades públicas
    public string Titulo { get; set; }
    // Validaciones en constructor
}
```

#### 2. **Abstracción**
```csharp
public interface IComparable<Song>
{
    int CompareTo(Song? otra);
}
```

#### 3. **Herencia**
```csharp
public class Song : IComparable<Song>
{
    // Implementación de interfaz
}
```

#### 4. **Polimorfismo**
```csharp
public override string ToString()
{
    // Sobrescritura de método
}
```

---

## 🚀 Cómo Ejecutar

### Requisitos Previos
- .NET SDK 9.0 o superior
- Navegador web moderno

### Pasos

1. **Compilar el proyecto:**
```bash
dotnet build MusicPlaylistWeb/MusicPlaylistWeb.csproj
```

2. **Ejecutar la aplicación:**
```bash
dotnet run --project MusicPlaylistWeb/MusicPlaylistWeb.csproj
```

3. **Abrir en el navegador:**
```
https://localhost:5001
```
o
```
http://localhost:5000
```

---

## 📱 Funcionalidades de la Aplicación

### 1. Página Principal (Index)
- Lista todas las canciones ordenadas (Inorden)
- Muestra estadísticas: total de canciones y altura del árbol
- Botones para ver detalles y eliminar
- Barra visual de popularidad

### 2. Agregar Canción
- Formulario con validaciones
- Campos: ID, Título, Artista, Duración, Popularidad
- Validación en cliente y servidor

### 3. Buscar por ID
- Campo de búsqueda por ID
- Muestra información completa de la canción
- Indica el nivel del nodo en el árbol

### 4. Buscar por Artista (Operación Libre 1)
- Búsqueda parcial por nombre de artista
- Muestra todas las coincidencias
- Búsqueda case-insensitive

### 5. Top Populares (Operación Libre 2)
- Lista las 10 canciones más populares
- Ordenadas por popularidad descendente
- Numeración de ranking (#1, #2, etc.)

### 6. Recorridos
- Muestra los 4 tipos de recorrido:
  - Inorden (orden ascendente)
  - Preorden
  - Postorden
  - Por Niveles (BFS)
- Vista en grid responsivo

### 7. Estadísticas
- Total de canciones
- Altura del árbol
- Visualización de la estructura del árbol por niveles

---

## 🔧 Validaciones Implementadas

### Validación de Datos

| Campo | Validación | Mensaje de Error |
|-------|------------|------------------|
| **ID** | > 0, único | "El ID debe ser positivo" / "Ya existe" |
| **Título** | No vacío | "El título no puede estar vacío" |
| **Artista** | No vacío | "El artista no puede estar vacío" |
| **Duración** | > 0 | "La duración debe ser mayor a 0" |
| **Popularidad** | 0-100 | "Debe estar entre 0 y 100" |

### Validación en Múltiples Capas

1. **Cliente (HTML5):**
   - `required`, `min`, `max` attributes
   
2. **Modelo (Song.cs):**
   - Validaciones en constructor
   - Excepciones descriptivas

3. **Servicio (PlaylistService.cs):**
   - Try-catch para operaciones
   - Retorno de valores seguros

4. **Controlador (HomeController.cs):**
   - ModelState validation
   - TempData para mensajes

---

## 📊 Datos de Prueba

La aplicación carga automáticamente 7 canciones clásicas:

| ID | Título | Artista | Duración | Popularidad |
|----|--------|---------|----------|-------------|
| 1 | Bohemian Rhapsody | Queen | 5:54 | 98 |
| 2 | Hey Jude | The Beatles | 7:11 | 97 |
| 3 | Hotel California | Eagles | 6:31 | 92 |
| 4 | Smells Like Teen Spirit | Nirvana | 5:01 | 94 |
| 5 | Stairway to Heaven | Led Zeppelin | 8:02 | 95 |
| 6 | Sweet Child O' Mine | Guns N' Roses | 5:56 | 93 |
| 7 | Imagine | John Lennon | 3:03 | 96 |

---

## 🎯 Operaciones Libres Detalladas

### Operación Libre 1: Buscar por Artista

**Descripción:** Permite buscar canciones por nombre de artista (búsqueda parcial).

**Implementación:**
```csharp
public List<Song> BuscarPorArtista(string artista)
{
    List<Song> resultados = new List<Song>();
    BuscarPorArtistaRecursivo(raiz, artista.ToLower(), resultados);
    return resultados;
}
```

**Características:**
- Búsqueda case-insensitive
- Búsqueda parcial (contiene)
- Recorre todo el árbol
- Retorna lista de coincidencias

**Ejemplo de uso:**
- Buscar "Queen" → Encuentra "Bohemian Rhapsody"
- Buscar "Led" → Encuentra "Stairway to Heaven"

### Operación Libre 2: Top Populares

**Descripción:** Obtiene las N canciones más populares ordenadas.

**Implementación:**
```csharp
public List<Song> ObtenerTopPopulares(int cantidad)
{
    List<Song> todasLasCanciones = RecorridoInorden();
    return todasLasCanciones
        .OrderByDescending(c => c.Popularidad)
        .ThenBy(c => c.Titulo)
        .Take(cantidad)
        .ToList();
}
```

**Características:**
- Ordena por popularidad descendente
- Desempate por título alfabético
- Cantidad configurable
- Usa LINQ para ordenamiento

**Ejemplo de uso:**
- Top 5 → Muestra las 5 más populares
- Top 10 → Muestra las 10 más populares

---

## 🔍 Complejidad de Operaciones

| Operación | Complejidad | Descripción |
|-----------|-------------|-------------|
| Insertar | O(log n) promedio, O(n) peor caso | Depende del balance del árbol |
| Buscar por ID | O(log n) promedio, O(n) peor caso | Búsqueda binaria |
| Eliminar | O(log n) promedio, O(n) peor caso | Incluye búsqueda + reorganización |
| Buscar por Artista | O(n) | Recorre todo el árbol |
| Top Populares | O(n log n) | Recorrido + ordenamiento |
| Recorridos | O(n) | Visita todos los nodos |
| Obtener Altura | O(n) | Recorre todo el árbol |
| Obtener Nivel | O(log n) promedio, O(n) peor caso | Búsqueda binaria |

---

## 🌐 Tecnologías Utilizadas

- **Backend:** ASP.NET Core 9.0 MVC
- **Frontend:** Razor Pages, HTML5, CSS3
- **Lenguaje:** C# 12
- **Patrón:** MVC (Model-View-Controller)
- **Arquitectura:** POO (Programación Orientada a Objetos)

---

## 📝 Notas Técnicas

### Singleton Service
El `PlaylistService` se registra como Singleton para mantener el estado del árbol entre requests:

```csharp
builder.Services.AddSingleton<PlaylistService>();
```

### Inyección de Dependencias
El controlador recibe el servicio por constructor:

```csharp
public HomeController(PlaylistService playlistService)
{
    _playlistService = playlistService;
}
```

### TempData para Mensajes
Se usa TempData para mostrar mensajes de éxito/error:

```csharp
TempData["Success"] = "✓ Canción agregada exitosamente!";
TempData["Error"] = "✗ Error al agregar la canción.";
```

---

## 🐛 Solución de Problemas

### Puerto ya en uso
```bash
# Cambiar puerto en Properties/launchSettings.json
# o usar:
dotnet run --urls="http://localhost:5005"
```

### Estilos no se cargan
```bash
# Verificar que existe wwwroot/css/site.css
# Limpiar y recompilar:
dotnet clean
dotnet build
```

### Datos no persisten
**Nota:** Los datos se almacenan en memoria. Al reiniciar la aplicación, se cargan los datos de prueba iniciales.

---

## 📚 Referencias

- [ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/)
- [Razor Syntax](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/razor)
- [Binary Search Tree](https://en.wikipedia.org/wiki/Binary_search_tree)

---

## 👥 Equipo de Desarrollo

- **Yeng Lee Salas Jimenez**
- **[Integrante 2]**
- **[Integrante 3]**

**Grupo:** 4 E  
**Programa:** DSM (Desarrollo de Software Multiplataforma)  
**Fecha:** Noviembre 2025

---

**¡Disfruta de tu Playlist Musical con ABB!** 🎵🌳
