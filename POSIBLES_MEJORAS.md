# 🔧 Lista de Posibles Cambios y Mejoras

## 📊 Estado Actual del Sistema

### ✅ Lo que YA funciona correctamente:
- Validación de IDs duplicados (rechaza correctamente)
- Validación de tipos de datos (int, string)
- Validación de rangos (ID > 0, popularidad 0-100)
- Todas las operaciones del ABB
- Todos los recorridos
- Manejo de excepciones básico

---

## 🎯 Mejoras Propuestas

### 🔴 PRIORIDAD ALTA - Validaciones Críticas

#### 1. Validación de Título + Artista Duplicados
**Problema:** Actualmente se pueden agregar múltiples canciones con el mismo título y artista (pero diferente ID).

**Ejemplo del problema:**
```
✓ ID: 1, "Imagine", "John Lennon"
✓ ID: 2, "Imagine", "John Lennon"  ← Duplicado lógico
```

**Solución propuesta:**
- Agregar método `buscarPorTituloYArtista()` en BinarySearchTree
- Validar antes de insertar en PlaylistManager
- Mostrar advertencia o rechazar según preferencia

**Impacto:** Medio
**Dificultad:** Baja
**Tiempo estimado:** 30 minutos

---

#### 2. Validación de Caracteres Especiales en Título/Artista
**Problema:** No se validan caracteres especiales o números en campos de texto.

**Ejemplo del problema:**
```
✓ Título: "123456"  ← Solo números
✓ Artista: "@#$%"   ← Solo símbolos
✓ Título: ""        ← Vacío (ya se valida)
```

**Solución propuesta:**
- Validar que título y artista contengan al menos una letra
- Permitir números y símbolos, pero no exclusivamente
- Regex: `^(?=.*[a-zA-Z]).+$`

**Impacto:** Bajo
**Dificultad:** Baja
**Tiempo estimado:** 20 minutos

---

#### 3. Validación de Longitud de Strings
**Problema:** No hay límite de longitud para título y artista.

**Ejemplo del problema:**
```
✓ Título: "A" (muy corto)
✓ Título: "AAAA...AAAA" (1000 caracteres - muy largo)
```

**Solución propuesta:**
- Título: mínimo 1, máximo 100 caracteres
- Artista: mínimo 1, máximo 50 caracteres

**Impacto:** Bajo
**Dificultad:** Muy baja
**Tiempo estimado:** 15 minutos

---

#### 4. Validación de Duración Máxima Razonable
**Problema:** Se puede ingresar cualquier duración positiva.

**Ejemplo del problema:**
```
✓ Duración: 999999 segundos (277 horas)
✓ Duración: 1 segundo (muy corto)
```

**Solución propuesta:**
- Duración mínima: 10 segundos
- Duración máxima: 7200 segundos (2 horas)
- Advertencia para duraciones inusuales

**Impacto:** Bajo
**Dificultad:** Muy baja
**Tiempo estimado:** 10 minutos

---

### 🟡 PRIORIDAD MEDIA - Mejoras de Usabilidad

#### 5. Sugerencia de ID Disponible
**Problema:** El usuario debe adivinar qué IDs están disponibles.

**Solución propuesta:**
- Método `sugerirProximoID()` que retorne el ID más alto + 1
- Mostrar sugerencia al agregar canción
- Ejemplo: "ID sugerido: 8 (puedes usar otro)"

**Impacto:** Alto (mejora experiencia)
**Dificultad:** Baja
**Tiempo estimado:** 20 minutos

---

#### 6. Búsqueda por Título o Artista
**Problema:** Solo se puede buscar por ID.

**Solución propuesta:**
- Agregar opción "Buscar por título"
- Agregar opción "Buscar por artista"
- Mostrar todas las coincidencias (búsqueda parcial)

**Impacto:** Alto (mejora funcionalidad)
**Dificultad:** Media
**Tiempo estimado:** 45 minutos

---

#### 7. Confirmación antes de Eliminar
**Problema:** La eliminación es inmediata sin confirmación.

**Solución propuesta:**
```
¿Está seguro de eliminar esta canción?
[ID: 5] Stairway to Heaven - Led Zeppelin
(S/N):
```

**Impacto:** Medio (previene errores)
**Dificultad:** Muy baja
**Tiempo estimado:** 10 minutos

---

#### 8. Editar Canción Existente
**Problema:** No se puede modificar una canción, solo eliminar y agregar.

**Solución propuesta:**
- Nueva opción "Editar canción"
- Buscar por ID
- Permitir modificar título, artista, duración, popularidad
- Mantener el mismo ID

**Impacto:** Alto (nueva funcionalidad)
**Dificultad:** Media
**Tiempo estimado:** 40 minutos

---

#### 9. Exportar/Importar Playlist
**Problema:** Los datos se pierden al cerrar el programa.

**Solución propuesta:**
- Guardar playlist en archivo CSV o JSON
- Cargar playlist desde archivo
- Opciones: "Guardar playlist" y "Cargar playlist"

**Impacto:** Alto (persistencia de datos)
**Dificultad:** Media-Alta
**Tiempo estimado:** 60 minutos

---

### 🟢 PRIORIDAD BAJA - Mejoras Estéticas

#### 10. Colores en Consola
**Problema:** Todo el texto es del mismo color.

**Solución propuesta:**
- Verde para éxitos (✓)
- Rojo para errores (✗)
- Amarillo para advertencias
- Azul para información

**Impacto:** Bajo (estético)
**Dificultad:** Baja
**Tiempo estimado:** 30 minutos

---

#### 11. Formato de Tabla para Listados
**Problema:** Los listados son simples líneas de texto.

**Solución propuesta:**
```
╔════╦═══════════════════════╦═══════════════╦══════════╦═════════════╗
║ ID ║ Título                ║ Artista       ║ Duración ║ Popularidad ║
╠════╬═══════════════════════╬═══════════════╬══════════╬═════════════╣
║  1 ║ Bohemian Rhapsody     ║ Queen         ║ 5:54     ║ 98/100      ║
║  2 ║ Hey Jude              ║ The Beatles   ║ 7:11     ║ 97/100      ║
╚════╩═══════════════════════╩═══════════════╩══════════╩═════════════╝
```

**Impacto:** Medio (mejor visualización)
**Dificultad:** Media
**Tiempo estimado:** 45 minutos

---

#### 12. Barra de Progreso para Operaciones
**Problema:** No hay feedback visual en operaciones largas.

**Solución propuesta:**
```
Cargando canciones de prueba...
[████████████████████] 100% (7/7)
```

**Impacto:** Bajo (estético)
**Dificultad:** Media
**Tiempo estimado:** 30 minutos

---

### 🔵 PRIORIDAD OPCIONAL - Funcionalidades Avanzadas

#### 13. Estadísticas Avanzadas
**Problema:** Solo se muestran estadísticas básicas.

**Solución propuesta:**
- Canción más popular
- Canción más larga/corta
- Artista con más canciones
- Promedio de popularidad
- Promedio de duración

**Impacto:** Medio (información útil)
**Dificultad:** Baja
**Tiempo estimado:** 30 minutos

---

#### 14. Filtros y Ordenamiento
**Problema:** No se pueden filtrar canciones.

**Solución propuesta:**
- Filtrar por rango de popularidad (ej: 80-100)
- Filtrar por rango de duración
- Ordenar por popularidad (no solo por ID)
- Ordenar por duración

**Impacto:** Alto (nueva funcionalidad)
**Dificultad:** Media-Alta
**Tiempo estimado:** 60 minutos

---

#### 15. Balanceo Automático del Árbol
**Problema:** El árbol puede desbalancearse (tipo lista).

**Solución propuesta:**
- Implementar AVL Tree o Red-Black Tree
- Rotaciones automáticas
- Mantener altura balanceada

**Impacto:** Alto (mejor rendimiento)
**Dificultad:** Alta
**Tiempo estimado:** 120+ minutos

---

#### 16. Múltiples Playlists
**Problema:** Solo se puede tener una playlist.

**Solución propuesta:**
- Crear múltiples playlists
- Cambiar entre playlists
- Copiar/mover canciones entre playlists

**Impacto:** Alto (nueva funcionalidad)
**Dificultad:** Alta
**Tiempo estimado:** 90 minutos

---

#### 17. Modo Aleatorio (Shuffle)
**Problema:** No hay forma de reproducir en orden aleatorio.

**Solución propuesta:**
- Generar orden aleatorio de reproducción
- Mantener historial de reproducción
- Evitar repeticiones

**Impacto:** Medio (funcionalidad de playlist)
**Dificultad:** Baja
**Tiempo estimado:** 25 minutos

---

#### 18. Búsqueda Difusa (Fuzzy Search)
**Problema:** La búsqueda debe ser exacta.

**Solución propuesta:**
- Buscar por similitud de texto
- Tolerar errores de escritura
- Ejemplo: "Imagin" encuentra "Imagine"

**Impacto:** Alto (mejor búsqueda)
**Dificultad:** Alta
**Tiempo estimado:** 90 minutos

---

## 🐛 Correcciones de Bugs Potenciales

### Bug 1: Overflow en Duración
**Problema:** Duración muy grande puede causar overflow en cálculos.

**Solución:**
- Validar duración máxima
- Usar long en lugar de int si es necesario

**Prioridad:** Baja
**Tiempo:** 10 minutos

---

### Bug 2: Caracteres Unicode en Consola
**Problema:** Algunos caracteres (✓, ✗, →) pueden no mostrarse en todas las consolas.

**Solución:**
- Detectar soporte de Unicode
- Usar alternativas ASCII si es necesario
- Ejemplo: ✓ → [OK], ✗ → [ERROR]

**Prioridad:** Baja
**Tiempo:** 20 minutos

---

### Bug 3: Trim en Strings
**Problema:** Ya se hace trim, pero podría haber espacios múltiples internos.

**Solución:**
- Normalizar espacios internos
- "Song    Name" → "Song Name"

**Prioridad:** Muy baja
**Tiempo:** 10 minutos

---

## 📋 Resumen por Prioridad

### 🔴 ALTA (Implementar primero)
1. ✅ Validación de Título + Artista duplicados (30 min)
2. ✅ Validación de caracteres especiales (20 min)
3. ✅ Validación de longitud de strings (15 min)
4. ✅ Validación de duración razonable (10 min)

**Total tiempo alta prioridad: ~75 minutos**

---

### 🟡 MEDIA (Implementar después)
5. ✅ Sugerencia de ID disponible (20 min)
6. ✅ Búsqueda por título/artista (45 min)
7. ✅ Confirmación antes de eliminar (10 min)
8. ✅ Editar canción existente (40 min)
9. ✅ Exportar/Importar playlist (60 min)

**Total tiempo media prioridad: ~175 minutos**

---

### 🟢 BAJA (Opcional)
10. Colores en consola (30 min)
11. Formato de tabla (45 min)
12. Barra de progreso (30 min)

**Total tiempo baja prioridad: ~105 minutos**

---

### 🔵 AVANZADO (Si hay tiempo)
13. Estadísticas avanzadas (30 min)
14. Filtros y ordenamiento (60 min)
15. Balanceo automático (120+ min)
16. Múltiples playlists (90 min)
17. Modo aleatorio (25 min)
18. Búsqueda difusa (90 min)

**Total tiempo avanzado: ~415 minutos**

---

## 🎯 Recomendación de Implementación

### Fase 1: Validaciones Críticas (75 min)
```
✓ Título + Artista duplicados
✓ Caracteres especiales
✓ Longitud de strings
✓ Duración razonable
```

### Fase 2: Mejoras de Usabilidad (115 min)
```
✓ Sugerencia de ID
✓ Búsqueda por título/artista
✓ Confirmación de eliminación
✓ Editar canción
```

### Fase 3: Persistencia (60 min)
```
✓ Exportar/Importar playlist
```

### Fase 4: Estética (Opcional)
```
✓ Colores
✓ Tablas
✓ Barras de progreso
```

---

## 💡 Sugerencias Adicionales

### Para el Proyecto Académico:
- **Implementar Fase 1** (validaciones) es suficiente para demostrar buen manejo de errores
- **Fase 2** (usabilidad) mejora significativamente la experiencia
- **Fase 3** (persistencia) es un plus importante
- **Fase 4** (estética) es opcional pero impresiona

### Para Producción Real:
- Implementar todas las fases
- Agregar tests unitarios
- Agregar logging
- Agregar documentación de API

---

## 📊 Matriz de Decisión

| Mejora | Impacto | Dificultad | Tiempo | Prioridad |
|--------|---------|------------|--------|-----------|
| Título+Artista duplicados | Alto | Baja | 30m | 🔴 Alta |
| Caracteres especiales | Medio | Baja | 20m | 🔴 Alta |
| Longitud strings | Bajo | Muy baja | 15m | 🔴 Alta |
| Duración razonable | Bajo | Muy baja | 10m | 🔴 Alta |
| Sugerencia ID | Alto | Baja | 20m | 🟡 Media |
| Búsqueda título/artista | Alto | Media | 45m | 🟡 Media |
| Confirmación eliminar | Medio | Muy baja | 10m | 🟡 Media |
| Editar canción | Alto | Media | 40m | 🟡 Media |
| Exportar/Importar | Alto | Media-Alta | 60m | 🟡 Media |
| Colores consola | Bajo | Baja | 30m | 🟢 Baja |
| Formato tabla | Medio | Media | 45m | 🟢 Baja |
| Estadísticas avanzadas | Medio | Baja | 30m | 🔵 Opcional |
| Balanceo automático | Alto | Alta | 120m+ | 🔵 Opcional |

---

## ❓ ¿Qué Implementar?

**Para tu proyecto académico, recomiendo:**

### Mínimo Viable (75 min):
- Validación Título + Artista duplicados
- Validación caracteres especiales
- Validación longitud strings
- Validación duración razonable

### Recomendado (190 min):
- Todo lo anterior +
- Sugerencia de ID
- Búsqueda por título/artista
- Confirmación de eliminación
- Editar canción

### Ideal (250 min):
- Todo lo anterior +
- Exportar/Importar playlist

---

**¿Cuáles de estas mejoras quieres que implemente?**
