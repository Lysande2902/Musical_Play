# 🎵 Sistema de Playlist Musical con ABB - Resumen Completo

## 📋 Información del Equipo

**Integrantes:**
- Yeng Lee Salas Jimenez
- [Nombre del Integrante 2]
- [Nombre del Integrante 3]

**Grupo:** 4 E  
**Programa:** DSM (Desarrollo de Software Multiplataforma)  
**Fecha:** Noviembre 2025

---

## ✅ Operaciones Implementadas (12 Total)

### Operaciones Básicas (10)
1. ✅ **Imprimir** los elementos del árbol
2. ✅ **Buscar** un elemento en el árbol (por ID)
3. ✅ **Insertar** un elemento en el árbol
4. ✅ **Borrar** un elemento del árbol
5. ✅ **Recorrido en anchura** (amplitud o por niveles)
6. ✅ **Recorrido en Preorden**
7. ✅ **Recorrido en Postorden**
8. ✅ **Recorrido en Inorden**
9. ✅ **Número de niveles** del árbol (altura)
10. ✅ **Nivel de un nodo** en específico

### Operaciones Libres (2)
11. ✅ **Buscar por Artista** - Búsqueda parcial de canciones por nombre de artista
12. ✅ **Top Populares** - Obtener las N canciones más populares ordenadas por popularidad

---

## 🚀 Tres Implementaciones Completas

### 1. 💻 Aplicación de Consola - Java
**Ubicación:** `music-playlist-java/`

**Características:**
- Menú interactivo con 12 opciones
- Validaciones robustas
- Manejo de excepciones
- Datos de prueba precargados

**Ejecutar:**
```bash
javac -d music-playlist-java/bin music-playlist-java/src/*.java
java -cp music-playlist-java/bin Main
```

---

### 2. 💻 Aplicación de Consola - C#
**Ubicación:** `MusicPlaylistCSharp/`

**Características:**
- Menú interactivo con 12 opciones
- Validaciones en múltiples capas
- Manejo exhaustivo de errores
- Mensajes descriptivos

**Ejecutar:**
```bash
dotnet run --project MusicPlaylistCSharp/MusicPlaylistCSharp.csproj
```

---

### 3. 🌐 Aplicación Web - ASP.NET Core MVC
**Ubicación:** `MusicPlaylistWeb/`

**Características:**
- ✅ Interfaz web moderna y responsiva
- ✅ Diseño estilo Spotify (verde #1DB954 y negro #191414)
- ✅ Arquitectura MVC con POO
- ✅ Validaciones en cliente y servidor
- ✅ Navegación intuitiva
- ✅ Visualización de estadísticas
- ✅ Animaciones y efectos visuales

**Páginas Implementadas:**
1. **Inicio** - Lista de todas las canciones con estadísticas
2. **Agregar Canción** - Formulario con validaciones
3. **Buscar por ID** - Búsqueda individual con nivel del nodo
4. **Buscar por Artista** - Operación Libre 1
5. **Top Populares** - Operación Libre 2
6. **Recorridos** - Los 4 tipos de recorrido en grid
7. **Estadísticas** - Altura y estructura del árbol

**Ejecutar:**
```bash
dotnet run --project MusicPlaylistWeb/MusicPlaylistWeb.csproj
```
Luego abrir: `https://localhost:5001` o `http://localhost:5000`

---

## 🎨 Diseño Web (Estilo Spotify)

### Colores Principales
- **Verde Spotify:** `#1DB954`
- **Negro Spotify:** `#191414`
- **Gris Oscuro:** `#121212`
- **Gris:** `#282828`

### Características del Diseño
- ✅ Navbar sticky con logo y menú
- ✅ Cards con hover effects
- ✅ Barra de popularidad visual
- ✅ Alertas de éxito/error
- ✅ Grid responsivo
- ✅ Iconos y emojis
- ✅ Transiciones suaves
- ✅ Footer informativo

---

## 🏗️ Arquitectura POO

### Principios Aplicados

#### 1. Encapsulación
```csharp
public class Song
{
    private int id;
    public int Id { get; set; }  // Propiedades con get/set
}
```

#### 2. Abstracción
```csharp
public interface IComparable<Song>
{
    int CompareTo(Song? otra);
}
```

#### 3. Herencia
```csharp
public class Song : IComparable<Song>
{
    // Implementación de interfaz
}
```

#### 4. Polimorfismo
```csharp
public override string ToString()
{
    // Sobrescritura de método
}
```

### Estructura de Capas (Web)

```
┌─────────────────────────────────┐
│     Vista (Razor Pages)         │  ← Presentación
├─────────────────────────────────┤
│     Controlador (MVC)           │  ← Lógica de control
├─────────────────────────────────┤
│     Servicio (Business Logic)   │  ← Lógica de negocio
├─────────────────────────────────┤
│     Estructura de Datos (ABB)   │  ← Algoritmos
├─────────────────────────────────┤
│     Modelo (Song, Node)         │  ← Datos
└─────────────────────────────────┘
```

---

## 📊 Validaciones Implementadas

### Reglas de Validación

| Campo | Tipo | Validación | Ejemplo Válido | Ejemplo Inválido |
|-------|------|------------|----------------|------------------|
| **ID** | int | > 0, único | 1, 5, 100 | 0, -1, "abc" |
| **Título** | string | No vacío | "Imagine" | "", "   " |
| **Artista** | string | No vacío | "Queen" | "", null |
| **Duración** | int | > 0 | 180, 482 | 0, -100 |
| **Popularidad** | int | 0-100 | 50, 95 | -1, 101 |

### Capas de Validación

1. **Cliente (HTML5):** `required`, `min`, `max`
2. **Modelo:** Validaciones en constructor con excepciones
3. **Servicio:** Try-catch y manejo de errores
4. **Controlador:** ModelState y TempData

---

## 🧪 Datos de Prueba

Las tres aplicaciones incluyen 7 canciones clásicas precargadas:

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

## 📈 Complejidad de Operaciones

| Operación | Complejidad | Notas |
|-----------|-------------|-------|
| Insertar | O(log n) / O(n) | Promedio / Peor caso |
| Buscar por ID | O(log n) / O(n) | Promedio / Peor caso |
| Eliminar | O(log n) / O(n) | Promedio / Peor caso |
| **Buscar por Artista** | O(n) | Recorre todo el árbol |
| **Top Populares** | O(n log n) | Recorrido + ordenamiento |
| Recorridos | O(n) | Visita todos los nodos |
| Obtener Altura | O(n) | Recorre todo el árbol |
| Obtener Nivel | O(log n) / O(n) | Promedio / Peor caso |

---

## 📁 Estructura del Proyecto

```
Act2_Trinas/
├── music-playlist-java/          # Aplicación Java
│   ├── src/
│   │   ├── Song.java
│   │   ├── Node.java
│   │   ├── BinarySearchTree.java
│   │   ├── PlaylistManager.java
│   │   └── Main.java
│   ├── bin/
│   ├── equipo.txt
│   └── README.md
│
├── MusicPlaylistCSharp/          # Aplicación C# Consola
│   ├── Models/
│   ├── DataStructures/
│   ├── Managers/
│   ├── Program.cs
│   ├── equipo.txt
│   └── README.md
│
├── MusicPlaylistWeb/             # Aplicación Web
│   ├── Models/
│   ├── DataStructures/
│   ├── Services/
│   ├── Controllers/
│   ├── Views/
│   ├── wwwroot/css/
│   ├── Program.cs
│   ├── equipo.txt
│   └── README.md
│
├── .kiro/specs/                  # Especificaciones
│   └── music-playlist-abb/
│       ├── requirements.md
│       ├── design.md
│       └── tasks.md
│
├── README.md                     # Documentación general
└── RESUMEN_PROYECTO.md          # Este archivo
```

---

## 🎯 Características Destacadas

### Aplicación Web (Principal)

1. **Diseño Profesional**
   - Inspirado en Spotify
   - Colores verde y negro
   - Interfaz moderna y limpia

2. **Funcionalidad Completa**
   - Todas las 12 operaciones implementadas
   - Navegación intuitiva
   - Feedback visual inmediato

3. **Arquitectura Sólida**
   - Patrón MVC
   - POO en todas las capas
   - Separación de responsabilidades

4. **Validaciones Robustas**
   - Cliente y servidor
   - Mensajes descriptivos
   - Manejo de errores exhaustivo

5. **Experiencia de Usuario**
   - Responsive design
   - Animaciones suaves
   - Visualización clara de datos

---

## 🚀 Cómo Probar

### Opción 1: Aplicación Web (Recomendado)
```bash
cd MusicPlaylistWeb
dotnet run
# Abrir: https://localhost:5001
```

### Opción 2: Consola Java
```bash
cd music-playlist-java
javac -d bin src/*.java
java -cp bin Main
```

### Opción 3: Consola C#
```bash
cd MusicPlaylistCSharp
dotnet run
```

---

## 📝 Documentación Adicional

- **README.md** - Documentación general con todas las validaciones
- **music-playlist-java/README.md** - Específico de Java
- **MusicPlaylistCSharp/README.md** - Específico de C# consola
- **MusicPlaylistWeb/README.md** - Específico de aplicación web
- **.kiro/specs/** - Especificaciones técnicas detalladas

---

## ✨ Conclusión

Este proyecto implementa un **Sistema de Playlist Musical** completo utilizando **Árbol Binario de Búsqueda (ABB)** con:

✅ **12 operaciones** (10 básicas + 2 libres)  
✅ **3 implementaciones** (Java, C# consola, C# web)  
✅ **Diseño profesional** estilo Spotify  
✅ **Arquitectura POO** sólida  
✅ **Validaciones robustas** en múltiples capas  
✅ **Documentación completa**  

**La aplicación web es la implementación principal** con interfaz moderna, dinámica y completamente funcional.

---

**Desarrollado por:** Equipo 4 E - DSM  
**Fecha:** Noviembre 2025  
**Tecnologías:** Java, C#, ASP.NET Core MVC, HTML5, CSS3
