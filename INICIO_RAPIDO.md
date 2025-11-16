# 🚀 Inicio Rápido - Playlist Musical ABB

## ⚡ Ejecutar la Aplicación Web (Recomendado)

```bash
# 1. Navegar al directorio
cd MusicPlaylistWeb

# 2. Ejecutar la aplicación
dotnet run

# 3. Abrir en el navegador
# https://localhost:5001
# o
# http://localhost:5000
```

---

## 🎯 Qué Encontrarás

### Aplicación Web (MusicPlaylistWeb/)
- ✅ Interfaz moderna estilo Spotify (verde y negro)
- ✅ 12 operaciones completas del ABB
- ✅ 2 operaciones libres extras
- ✅ Diseño responsivo y dinámico
- ✅ Validaciones en tiempo real

### Menú de Navegación
1. **Inicio** - Ver todas las canciones
2. **Agregar Canción** - Formulario de inserción
3. **Buscar** - Buscar por ID
4. **Buscar por Artista** - Operación Libre 1
5. **Top Populares** - Operación Libre 2
6. **Recorridos** - Ver los 4 recorridos
7. **Estadísticas** - Altura y estructura del árbol

---

## 📊 Operaciones Implementadas

### Básicas (10)
1. Imprimir elementos
2. Buscar por ID
3. Insertar
4. Eliminar
5. Recorrido por niveles
6. Recorrido Preorden
7. Recorrido Postorden
8. Recorrido Inorden
9. Número de niveles
10. Nivel de nodo específico

### Libres (2)
11. **Buscar por Artista** - Búsqueda parcial
12. **Top Populares** - Ranking por popularidad

---

## 🎨 Diseño

**Colores:**
- Verde: #1DB954 (Spotify)
- Negro: #191414
- Gris: #282828

**Características:**
- Navbar sticky
- Cards con hover
- Animaciones suaves
- Barra de popularidad visual
- Responsive design

---

## 📝 Datos de Prueba

La aplicación incluye 7 canciones clásicas:
- Bohemian Rhapsody (Queen)
- Hey Jude (The Beatles)
- Hotel California (Eagles)
- Smells Like Teen Spirit (Nirvana)
- Stairway to Heaven (Led Zeppelin)
- Sweet Child O' Mine (Guns N' Roses)
- Imagine (John Lennon)

---

## 🔧 Requisitos

- .NET SDK 9.0 o superior
- Navegador web moderno

### Verificar instalación:
```bash
dotnet --version
```

---

## 💡 Consejos

1. **Agregar canciones:** Usa IDs únicos y positivos
2. **Popularidad:** Debe estar entre 0 y 100
3. **Duración:** En segundos (ej: 180 = 3:00)
4. **Buscar artista:** Búsqueda parcial (ej: "Queen" o "que")
5. **Top Populares:** Muestra las 10 más populares

---

## 🐛 Solución Rápida de Problemas

### Puerto ocupado:
```bash
dotnet run --urls="http://localhost:5005"
```

### Recompilar:
```bash
dotnet clean
dotnet build
dotnet run
```

---

## 📚 Más Información

- **RESUMEN_PROYECTO.md** - Resumen completo
- **MusicPlaylistWeb/README.md** - Documentación detallada
- **README.md** - Documentación general

---

## 👥 Equipo

- Yeng Lee Salas Jimenez
- [Integrante 2]
- [Integrante 3]

**Grupo:** 4 E | **Programa:** DSM

---

**¡Disfruta de tu Playlist Musical!** 🎵
