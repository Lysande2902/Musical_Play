# 🎵 Sistema de Playlist Musical con Árbol Binario de Búsqueda (ABB)

## 📋 Información del Proyecto

**Equipo:**
- Yeng Lee Salas Jimenez
- Flor Maribel Ku May
- Jose Octavio Hernandez Tec

**Grupo:** 4 E  
**Programa:** DSM (Desarrollo de Software Multiplataforma)  
**Fecha:** Noviembre 2025

---

## 📖 Descripción

Sistema de gestión de playlist musical implementado con **Árbol Binario de Búsqueda (ABB) Balanceado** en tres versiones:
- **Aplicación Web** (ASP.NET Core MVC) - ⭐ Versión Principal
- **Consola C#** (.NET)
- **Consola Java**

El sistema permite organizar 18 canciones de manera eficiente con altura óptima de 5 niveles, realizar búsquedas rápidas O(log n) y visualizar la estructura del árbol mediante diferentes recorridos.

---

## 🎯 Funcionalidades Implementadas

### Operaciones Básicas del ABB (12/12 Requeridas)
1. ✅ **Imprimir** elementos del árbol
2. ✅ **Buscar** canciones por ID
3. ✅ **Insertar** canciones en el árbol
4. ✅ **Eliminar** canciones del árbol
5. ✅ **Recorrido por Niveles** (Amplitud/BFS)
6. ✅ **Recorrido Preorden** (Nodo → Izquierdo → Derecho)
7. ✅ **Recorrido Postorden** (Izquierdo → Derecho → Nodo)
8. ✅ **Recorrido Inorden** (Izquierdo → Nodo → Derecho) - Orden ascendente
9. ✅ **Número de niveles** del árbol (altura)
10. ✅ **Nivel de un nodo específico**
11. ✅ **Buscar por Artista** (Operación Libre 1)
12. ✅ **Top Canciones Populares** (Operación Libre 2)

### Funcionalidades BONUS (Aplicación Web)
13. ✅ **Buscar por Nivel** - Encuentra todas las canciones en un nivel específico
14. ✅ **Editar Canciones** - Modificar datos de canciones existentes
15. ✅ **Persistencia JSON** - Guardado automático de cambios
16. ✅ **Visualización Jerárquica** - Estructura del árbol con niveles
17. ✅ **Estadísticas Avanzadas** - Análisis completo del árbol
18. ✅ **Validaciones Robustas** - Prevención de errores y duplicados

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

### 🌐 Aplicación Web (Principal) - ASP.NET Core MVC
```
MusicPlaylistWeb/
├── Controllers/
│   └── HomeController.cs            # 13 acciones (CRUD + búsquedas)
├── Models/
│   ├── Song.cs                      # Modelo con validaciones
│   └── Node.cs                      # Nodo del árbol
├── DataStructures/
│   └── BinarySearchTree.cs          # ABB Balanceado (18 nodos, altura 5)
├── Services/
│   ├── PlaylistService.cs           # Lógica de negocio
│   └── JsonPersistenceService.cs    # Persistencia automática
├── Views/Home/
│   ├── Index.cshtml                 # Lista/Imprimir
│   ├── Agregar.cshtml               # Insertar
│   ├── Editar.cshtml                # Modificar
│   ├── Buscar.cshtml                # Búsqueda por ID
│   ├── Recorridos.cshtml            # 4 recorridos
│   ├── Estadisticas.cshtml          # Niveles/Altura
│   ├── BuscarPorArtista.cshtml      # Op. Libre 1
│   ├── TopPopulares.cshtml          # Op. Libre 2
│   ├── BuscarPorNivel.cshtml        # BONUS
│   └── Ayuda.cshtml                 # Documentación
├── wwwroot/css/
│   └── site.css                     # Tema Spotify
├── Data/
│   └── playlist.json                # 18 canciones balanceadas
└── *.md                             # Documentación técnica
```

### 💻 Consola C#
```
MusicPlaylistCSharp/
├── Models/
│   ├── Song.cs                      # Modelo de canción
│   └── Node.cs                      # Nodo del árbol
├── DataStructures/
│   └── BinarySearchTree.cs          # Implementación del ABB
├── Managers/
│   └── PlaylistManager.cs           # Gestor de playlist
└── Program.cs                       # Interfaz de usuario
```

### ☕ Consola Java
```
music-playlist-java/
├── src/
│   ├── models/
│   │   ├── Song.java                # Modelo de canción
│   │   └── Node.java                # Nodo del árbol
│   ├── datastructures/
│   │   └── BinarySearchTree.java    # Implementación del ABB
│   ├── managers/
│   │   └── PlaylistManager.java     # Gestor de playlist
│   └── Main.java                    # Interfaz de usuario
└── equipo.txt                       # Información del equipo
```

---

## 🚀 Cómo Ejecutar

### 🌐 Aplicación Web (Recomendado)

```bash
cd MusicPlaylistWeb
dotnet run
```

Luego abrir en el navegador: `https://localhost:5001`

**Características:**
- ✅ Interfaz moderna con tema Spotify
- ✅ Diseño responsive (móvil y desktop)
- ✅ Árbol balanceado con 18 canciones
- ✅ Altura óptima: 5 niveles
- ✅ Persistencia automática en JSON
- ✅ 13 operaciones completas + BONUS

### 💻 Consola C#

```bash
cd MusicPlaylistCSharp
dotnet run
```

### ☕ Consola Java

```bash
cd music-playlist-java
javac -d bin src/**/*.java
java -cp bin Main
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

## 🌳 Árbol Balanceado Profesional

### Estructura Actual (Aplicación Web)

```
                    10 (Secreto de Amor)
                   /  \
                  /    \
                 5      15 (Feel Special)
                / \     / \
               3   7   12  18 (God's Menu)
              / \ / \ / \ / \
             1  4 6 8 11 13 16 20
            /     \         \
           2       9        14
```

### Métricas de Balance

| Métrica | Valor | Estado |
|---------|-------|--------|
| **Nodos totales** | 18 | ✅ |
| **Altura** | 5 niveles | ✅ Óptimo |
| **Altura teórica** | ⌈log₂(19)⌉ = 5 | ✅ Coincide |
| **Factor de balance** | ≤ 1 | ✅ Balanceado |
| **Eficiencia** | 100% | ✅ Máxima |

### Distribución por Niveles

- **Nivel 0:** 1 nodo (raíz)
- **Nivel 1:** 2 nodos
- **Nivel 2:** 4 nodos
- **Nivel 3:** 8 nodos
- **Nivel 4:** 3 nodos

**Total: 18 nodos perfectamente distribuidos** ✅

### ¿Por qué NO está ordenado el JSON?

El JSON tiene el orden `10, 5, 15, 3, 7, 12, 18...` **intencionalmente** para crear un árbol balanceado.

- **JSON ordenado (1,2,3...)** = Árbol degenerado (altura 18) ❌
- **JSON estratégico** = Árbol balanceado (altura 5) ✅

## 🧪 Datos de Prueba

### Aplicación Web (18 canciones balanceadas)

| ID | Título | Artista | Duración | Popularidad |
|----|--------|---------|----------|-------------|
| 1 | Back In Black | AC/DC | 4:15 | 97 |
| 2 | Sweet Child O' Mine | Guns N' Roses | 5:56 | 99 |
| 3 | Hero | Skillet | 3:03 | 92 |
| 4 | Highway to Hell | AC/DC | 3:28 | 96 |
| 5 | Monster | Skillet | 2:57 | 95 |
| 6 | Bohemian Rhapsody | Queen | 5:54 | 100 |
| 7 | November Rain | Guns N' Roses | 8:57 | 98 |
| 8 | Feel Invincible | Skillet | 3:43 | 90 |
| 9 | Stairway to Heaven | Led Zeppelin | 8:02 | 99 |
| 10 | Secreto de Amor | Joan Sebastian | 4:05 | 93 |
| 11 | Hotel California | Eagles | 6:31 | 98 |
| 12 | Fancy | TWICE | 3:36 | 98 |
| 13 | Tatuajes | Joan Sebastian | 3:54 | 91 |
| 14 | Imagine | John Lennon | 3:03 | 97 |
| 15 | Feel Special | TWICE | 3:27 | 96 |
| 16 | Smells Like Teen Spirit | Nirvana | 5:01 | 96 |
| 18 | God's Menu | Stray Kids | 2:50 | 97 |
| 20 | Back Door | Stray Kids | 2:53 | 94 |

### Consolas (7 canciones clásicas)

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

### Aplicación Web (Árbol Balanceado)

| Operación | Complejidad | Rendimiento Real |
|-----------|-------------|------------------|
| Insertar | O(log n) | O(5) - 5 comparaciones máx |
| Buscar | O(log n) | O(5) - 5 comparaciones máx |
| Eliminar | O(log n) | O(5) - 5 comparaciones máx |
| Recorrido Inorden | O(n) | O(18) - visita 18 nodos |
| Recorrido Preorden | O(n) | O(18) - visita 18 nodos |
| Recorrido Postorden | O(n) | O(18) - visita 18 nodos |
| Recorrido por Niveles | O(n) | O(18) - visita 18 nodos |
| Obtener Altura | O(n) | O(18) - visita 18 nodos |
| Obtener Nivel | O(log n) | O(5) - 5 comparaciones máx |
| Buscar por Artista | O(n) | O(18) - recorrido completo |
| Top Populares | O(n log n) | O(18 log 18) - inorden + sort |
| Buscar por Nivel | O(n) | O(18) - recorrido completo |

**Eficiencia:** 100% vs árbol óptimo teórico ✅

### Comparación: Balanceado vs Desbalanceado

| Métrica | Balanceado | Desbalanceado | Mejora |
|---------|------------|---------------|--------|
| Altura | 5 niveles | 18 niveles | 72% |
| Búsqueda | O(5) | O(18) | 72% |
| Eficiencia | 100% | 28% | 72% |

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
- **Yeng Lee Salas Jimenez**
- **Flor Maribel Ku May**
- **Jose Octavio Hernandez Tec**

---

## 📞 Contacto

Para preguntas o sugerencias sobre el proyecto, contactar a los integrantes del equipo.

---

**Última actualización:** Noviembre 2025
