# Sistema de Playlist Musical con Árbol Binario de Búsqueda (ABB)

## 📋 Información del Proyecto

**Equipo:**
- Yeng Lee Salas Jimenez
- Nombre Completo del Integrante 2
- Nombre Completo del Integrante 3

**Grupo:** 4 E  
**Programa:** DSM (Desarrollo de Software Multiplataforma)  
**Fecha:** Noviembre 2025

---

## 📖 Descripción

Sistema de gestión de playlist musical implementado con Árbol Binario de Búsqueda (ABB) en dos lenguajes de programación: **Java** y **C#**. El sistema permite organizar canciones de manera eficiente, realizar búsquedas rápidas y visualizar la estructura del árbol mediante diferentes recorridos.

---

## 🎯 Funcionalidades Implementadas

### Operaciones Básicas del ABB
1. ✅ **Insertar** canciones en el árbol
2. ✅ **Buscar** canciones por ID
3. ✅ **Eliminar** canciones del árbol
4. ✅ **Imprimir** elementos del árbol

### Recorridos del Árbol
5. ✅ **Recorrido Inorden** (Izquierdo → Nodo → Derecho) - Orden ascendente
6. ✅ **Recorrido Preorden** (Nodo → Izquierdo → Derecho)
7. ✅ **Recorrido Postorden** (Izquierdo → Derecho → Nodo)
8. ✅ **Recorrido por Niveles** (Amplitud/BFS)

### Operaciones de Análisis
9. ✅ **Número de niveles** del árbol (altura)
10. ✅ **Nivel de un nodo específico**
11. ✅ **Visualización estructurada** del árbol
12. ✅ **Estadísticas completas** (cantidad de canciones, altura)

---

## 📏 Reglas de Validación

### 1. ID de Canción
- **Tipo:** Número entero (int)
- **Rango:** Mayor a 0 (positivo)
- **Único:** No se permiten IDs duplicados
- **Ejemplos válidos:** 1, 5, 100, 9999
- **Ejemplos inválidos:** 0, -1, -100, "abc", 3.14

### 2. Título de Canción
- **Tipo:** Texto (string)
- **Restricciones:** 
  - No puede estar vacío
  - No puede contener solo espacios en blanco
  - Se eliminan espacios al inicio y final automáticamente
- **Ejemplos válidos:** "Bohemian Rhapsody", "Hotel California", "Imagine"
- **Ejemplos inválidos:** "", "   ", null

### 3. Artista
- **Tipo:** Texto (string)
- **Restricciones:**
  - No puede estar vacío
  - No puede contener solo espacios en blanco
  - Se eliminan espacios al inicio y final automáticamente
- **Ejemplos válidos:** "Queen", "Led Zeppelin", "The Beatles"
- **Ejemplos inválidos:** "", "   ", null

### 4. Duración
- **Tipo:** Número entero (int)
- **Unidad:** Segundos
- **Rango:** Mayor a 0
- **Formato de visualización:** mm:ss (minutos:segundos)
- **Ejemplos válidos:** 180 (3:00), 354 (5:54), 482 (8:02)
- **Ejemplos inválidos:** 0, -100, "5min", 3.14, "abc"

### 5. Popularidad
- **Tipo:** Número entero (int)
- **Rango:** 0 a 100 (inclusive)
- **Ejemplos válidos:** 0, 50, 85, 100
- **Ejemplos inválidos:** -1, 101, 150, "alta", 99.5

---

## 🚫 Manejo de Errores

### Errores de Validación

#### ID Inválido
```
✗ Error: El ID debe ser un número positivo mayor a 0.
```

#### ID Duplicado
```
✗ Error: Ya existe una canción con el ID 5
```

#### Título Vacío
```
✗ Error: El título no puede estar vacío o contener solo espacios.
```

#### Artista Vacío
```
✗ Error: El artista no puede estar vacío o contener solo espacios.
```

#### Duración Inválida
```
✗ Error: La duración debe ser mayor a 0 segundos.
✗ Error: La duración debe ser un número entero.
```

#### Popularidad Fuera de Rango
```
✗ Error: La popularidad debe estar entre 0 y 100. Valor recibido: 150
```

### Errores de Operación

#### Canción No Encontrada
```
✗ No se encontró ninguna canción con el ID 10
```

#### Árbol Vacío
```
✗ La playlist está vacía.
```

#### Entrada No Numérica
```
✗ Error: Debe ingresar un número válido.
```

---

## 🔧 Estructura del Proyecto

### Proyecto Java
```
music-playlist-java/
├── src/
│   ├── Song.java                    # Modelo de canción
│   ├── Node.java                    # Nodo del árbol
│   ├── BinarySearchTree.java        # Implementación del ABB
│   ├── PlaylistManager.java         # Gestor de playlist
│   └── Main.java                    # Interfaz de usuario
└── equipo.txt                       # Información del equipo
```

### Proyecto C#
```
MusicPlaylistCSharp/
├── Models/
│   ├── Song.cs                      # Modelo de canción
│   └── Node.cs                      # Nodo del árbol
├── DataStructures/
│   └── BinarySearchTree.cs          # Implementación del ABB
├── Managers/
│   └── PlaylistManager.cs           # Gestor de playlist
├── Program.cs                       # Interfaz de usuario
├── MusicPlaylistCSharp.csproj       # Archivo de proyecto
└── equipo.txt                       # Información del equipo
```

---

## 🚀 Cómo Ejecutar

### Proyecto Java

#### Compilar:
```bash
javac -d music-playlist-java/bin music-playlist-java/src/*.java
```

#### Ejecutar:
```bash
java -cp music-playlist-java/bin Main
```

### Proyecto C#

#### Compilar:
```bash
dotnet build MusicPlaylistCSharp/MusicPlaylistCSharp.csproj
```

#### Ejecutar:
```bash
dotnet run --project MusicPlaylistCSharp/MusicPlaylistCSharp.csproj
```

---

## 📱 Uso del Sistema

### Menú Principal

```
===========================================
           MENÚ PRINCIPAL
===========================================
1.  Agregar canción
2.  Buscar canción por ID
3.  Eliminar canción
4.  Mostrar playlist ordenada (Inorden)
5.  Mostrar recorrido Preorden
6.  Mostrar recorrido Postorden
7.  Mostrar recorrido por Niveles
8.  Mostrar todos los recorridos
9.  Mostrar altura del árbol
10. Consultar nivel de una canción
11. Mostrar estadísticas completas
12. Cargar canciones de prueba
0.  Salir
===========================================
```

### Ejemplo de Uso

#### 1. Agregar una Canción
```
Seleccione una opción: 1

--- AGREGAR CANCIÓN ---

ID: 5
Título: Stairway to Heaven
Artista: Led Zeppelin
Duración (segundos): 482
Popularidad (0-100): 95

✓ Canción agregada exitosamente!
  [ID: 5] Stairway to Heaven - Led Zeppelin | Duración: 8:02 | Popularidad: 95/100
```

#### 2. Buscar una Canción
```
Seleccione una opción: 2

--- BUSCAR CANCIÓN ---

Ingrese el ID de la canción: 5

✓ Canción encontrada:
  [ID: 5] Stairway to Heaven - Led Zeppelin | Duración: 8:02 | Popularidad: 95/100
  Nivel en el árbol: 0
```

#### 3. Visualizar Estructura del Árbol
```
Seleccione una opción: 11

========== ESTADÍSTICAS ==========
Total de canciones: 7
Altura del árbol: 4 niveles
==================================

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

## 🧪 Datos de Prueba

El sistema incluye 7 canciones clásicas del rock precargadas (opción 12):

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

## 📊 Complejidad de Operaciones

| Operación | Caso Promedio | Peor Caso |
|-----------|---------------|-----------|
| Insertar | O(log n) | O(n) |
| Buscar | O(log n) | O(n) |
| Eliminar | O(log n) | O(n) |
| Recorrido Inorden | O(n) | O(n) |
| Recorrido Preorden | O(n) | O(n) |
| Recorrido Postorden | O(n) | O(n) |
| Recorrido por Niveles | O(n) | O(n) |
| Obtener Altura | O(n) | O(n) |
| Obtener Nivel | O(log n) | O(n) |

**Nota:** El peor caso O(n) ocurre cuando el árbol está completamente desbalanceado (tipo lista).

---

## 🔍 Casos de Prueba Recomendados

### Pruebas de Inserción
1. ✅ Insertar en árbol vacío
2. ✅ Insertar múltiples canciones en orden aleatorio
3. ✅ Intentar insertar ID duplicado (debe rechazar)
4. ✅ Insertar con datos inválidos (debe rechazar)

### Pruebas de Búsqueda
1. ✅ Buscar en árbol vacío
2. ✅ Buscar canción existente (raíz, hoja, nodo intermedio)
3. ✅ Buscar canción inexistente
4. ✅ Buscar con ID inválido (negativo, cero)

### Pruebas de Eliminación
1. ✅ Eliminar nodo hoja
2. ✅ Eliminar nodo con un hijo (izquierdo y derecho)
3. ✅ Eliminar nodo con dos hijos
4. ✅ Eliminar raíz
5. ✅ Eliminar de árbol vacío

### Pruebas de Recorridos
1. ✅ Recorridos en árbol vacío
2. ✅ Recorridos con un solo nodo
3. ✅ Recorridos con árbol balanceado
4. ✅ Recorridos con árbol desbalanceado
5. ✅ Verificar orden correcto de cada recorrido

### Pruebas de Validación
1. ✅ ID negativo o cero
2. ✅ Título vacío o solo espacios
3. ✅ Artista vacío o solo espacios
4. ✅ Duración negativa o cero
5. ✅ Popularidad < 0 o > 100
6. ✅ Entrada no numérica donde se espera número
7. ✅ Entrada con decimales donde se espera entero

---

## 🛡️ Características de Seguridad

### Validaciones Implementadas

#### Capa de Modelo (Song)
- Validación de todos los atributos en el constructor
- Excepciones descriptivas para cada tipo de error
- Trim automático de strings para eliminar espacios

#### Capa de Estructura de Datos (BinarySearchTree)
- Validación de parámetros nulos
- Validación de IDs antes de operaciones
- Manejo de casos especiales (árbol vacío, nodo no encontrado)

#### Capa de Gestión (PlaylistManager)
- Try-catch específicos para cada tipo de excepción
- Mensajes de error claros y útiles
- Validación adicional antes de llamar al ABB

#### Capa de Interfaz (Main/Program)
- Validación de entrada del usuario con TryParse
- Manejo de entradas vacías o inválidas
- Try-catch global para errores críticos
- Validación de strings vacíos antes de crear objetos

---

## 📝 Notas Técnicas

### Criterio de Ordenamiento
- El árbol se organiza por **ID de canción** (campo numérico único)
- IDs menores van al subárbol izquierdo
- IDs mayores van al subárbol derecho
- El recorrido Inorden muestra las canciones en orden ascendente por ID

### Eliminación de Nodos
El sistema implementa los 3 casos de eliminación:
1. **Nodo sin hijos (hoja):** Se elimina directamente
2. **Nodo con un hijo:** Se reemplaza por su único hijo
3. **Nodo con dos hijos:** Se reemplaza por su sucesor inorden (menor del subárbol derecho)

### Formato de Duración
- Entrada: Segundos (número entero)
- Visualización: mm:ss (minutos:segundos con padding de ceros)
- Ejemplo: 482 segundos → 8:02

---

## 🐛 Solución de Problemas

### Error: "package does not exist" (Java)
**Solución:** Los archivos Java están en el directorio `src/` sin estructura de paquetes. Compilar todos juntos:
```bash
javac -d music-playlist-java/bin music-playlist-java/src/*.java
```

### Error: "Framework not found" (C#)
**Solución:** El proyecto requiere .NET 9.0. Verificar instalación:
```bash
dotnet --version
```

### Error: Caracteres especiales no se muestran correctamente
**Solución:** Ambos proyectos configuran UTF-8 automáticamente. Si persiste el problema:
- **Java:** Agregar `-Dfile.encoding=UTF-8` al ejecutar
- **C#:** Ya configurado con `Console.OutputEncoding = System.Text.Encoding.UTF8`

---

## 📚 Referencias

- **Estructura de Datos:** Árbol Binario de Búsqueda (ABB)
- **Algoritmos de Recorrido:** Inorden, Preorden, Postorden, BFS
- **Patrones de Diseño:** Composite, Template Method
- **Principios SOLID:** Single Responsibility, Open/Closed

---

## 📄 Licencia

Proyecto académico para el curso de Estructuras de Datos.  
Grupo 4 E - DSM - 2025

---

## 👥 Contribuciones

Este proyecto fue desarrollado en equipo por:
- **Yeng Lee Salas Jimenez** - Implementación y documentación
- **Nombre Integrante 2** - Pruebas y Depuración
- **Nombre Integrante 3** - Documentación y Diseño

---

## 📞 Contacto

Para preguntas o sugerencias sobre el proyecto, contactar a los integrantes del equipo.

---

**Última actualización:** Noviembre 2025
