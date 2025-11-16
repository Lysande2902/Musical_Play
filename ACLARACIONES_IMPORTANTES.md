# ⚠️ Aclaraciones Importantes sobre el Sistema

## 🔑 Criterio de Unicidad: ID

### ¿Qué hace único a una canción?

**El ID es el ÚNICO criterio de unicidad en el sistema.**

- El árbol se organiza por **ID** (número entero único)
- Dos canciones con el mismo ID **NO pueden coexistir**
- Dos canciones con el mismo título/artista **SÍ pueden coexistir** si tienen IDs diferentes

---

## 📋 Casos de Uso Explicados

### ✅ Caso 1: Canciones con mismo nombre, diferente artista

```
Canción 1:
- ID: 7
- Título: "Imagine"
- Artista: "John Lennon"

Canción 2:
- ID: 10
- Título: "Imagine"
- Artista: "Ariana Grande"

Resultado: ✓ AMBAS SE PERMITEN (IDs diferentes)
```

**Explicación:** Son dos canciones diferentes porque tienen IDs únicos. El sistema las trata como entidades completamente separadas.

### ✅ Caso 2: Covers o versiones diferentes

```
Canción 1:
- ID: 15
- Título: "Hallelujah"
- Artista: "Leonard Cohen"

Canción 2:
- ID: 20
- Título: "Hallelujah"
- Artista: "Jeff Buckley"

Resultado: ✓ AMBAS SE PERMITEN (IDs diferentes)
```

### ❌ Caso 3: ID duplicado (RECHAZADO)

```
Canción 1 (ya existe):
- ID: 5
- Título: "Stairway to Heaven"
- Artista: "Led Zeppelin"

Intento de insertar:
- ID: 5
- Título: "Hotel California"
- Artista: "Eagles"

Resultado: ✗ RECHAZADO - Ya existe una canción con ID 5
```

**Explicación:** El ID 5 ya está en uso. No importa que el título y artista sean diferentes.

### ❌ Caso 4: Misma canción, mismo ID (RECHAZADO)

```
Canción 1 (ya existe):
- ID: 3
- Título: "Bohemian Rhapsody"
- Artista: "Queen"

Intento de insertar:
- ID: 3
- Título: "Bohemian Rhapsody"
- Artista: "Queen"

Resultado: ✗ RECHAZADO - Ya existe una canción con ID 3
```

---

## 🎯 ¿Por qué se usa solo el ID?

### Razones Técnicas:

1. **Eficiencia del ABB**
   - Los ABB requieren un criterio de ordenamiento único y comparable
   - Los números enteros (ID) son perfectos para esto
   - Comparar strings (título/artista) sería más lento

2. **Simplicidad**
   - Un solo campo para comparar
   - Búsquedas O(log n) en caso promedio
   - Implementación estándar de ABB

3. **Flexibilidad**
   - Permite múltiples versiones de la misma canción
   - Permite covers y remixes
   - Permite canciones con nombres similares

---

## 🔄 Escenarios del Mundo Real

### Escenario 1: Playlist Personal

```
Usuario agrega:
1. ID: 1 - "Yesterday" - The Beatles (original)
2. ID: 2 - "Yesterday" - Boyce Avenue (cover)
3. ID: 3 - "Yesterday" - En Vogue (cover)

✓ Todas se agregan correctamente
```

### Escenario 2: Biblioteca Musical

```
Biblioteca tiene:
1. ID: 100 - "Imagine" - John Lennon (1971)
2. ID: 101 - "Imagine" - John Lennon (Remaster 2010)
3. ID: 102 - "Imagine" - Pentatonix (cover)

✓ Todas coexisten sin problema
```

### Escenario 3: Error del Usuario

```
Usuario intenta agregar:
1. ID: 5 - "Song A" - Artist X  ✓ Agregado
2. ID: 5 - "Song B" - Artist Y  ✗ RECHAZADO

Mensaje: "✗ Error: Ya existe una canción con el ID 5"
```

---

## 🛡️ Validaciones Implementadas

### 1. Validación de ID Duplicado

**Ubicación:** `BinarySearchTree.insertarRecursivo()`

```java
// Java
if (comparacion == 0) {
    // ID duplicado, no insertar
    return null;
}
```

```csharp
// C#
if (comparacion == 0)
{
    // ID duplicado, no insertar
    return null;
}
```

**Comportamiento:**
- Retorna `null` cuando encuentra un ID igual
- El método público `insertar()` retorna `false`
- El `PlaylistManager` muestra mensaje de error

### 2. Flujo Completo de Validación

```
Usuario ingresa datos
    ↓
Validación de tipos (int, string)
    ↓
Validación de rangos (ID > 0, popularidad 0-100)
    ↓
Creación del objeto Song
    ↓
Intento de inserción en ABB
    ↓
Verificación de ID duplicado
    ↓
    ├─ ID único → ✓ Insertar
    └─ ID duplicado → ✗ Rechazar
```

---

## 🤔 Preguntas Frecuentes

### P1: ¿Puedo tener dos canciones con el mismo título?
**R:** Sí, siempre que tengan IDs diferentes.

### P2: ¿Puedo tener dos canciones del mismo artista con el mismo título?
**R:** Sí, siempre que tengan IDs diferentes. Esto es útil para remasters, versiones en vivo, etc.

### P3: ¿Qué pasa si intento agregar una canción con un ID que ya existe?
**R:** El sistema rechaza la inserción y muestra: "✗ Error: Ya existe una canción con el ID X"

### P4: ¿Cómo sé qué IDs están disponibles?
**R:** Puedes:
- Ver la playlist ordenada (opción 4) para ver todos los IDs usados
- Usar IDs secuenciales (1, 2, 3, ...)
- Usar IDs con espacios (10, 20, 30, ...)

### P5: ¿Por qué no se valida título + artista como único?
**R:** Porque:
- Es más complejo de implementar
- Sería más lento (comparar strings)
- Limitaría la flexibilidad (no permitiría covers)
- El ABB estándar usa un solo campo de comparación

### P6: ¿Puedo cambiar el criterio de ordenamiento?
**R:** Sí, pero requeriría modificar:
- El método `compareTo()` en Song
- La lógica de comparación en el ABB
- Las validaciones de duplicados

---

## 💡 Recomendaciones de Uso

### Para Evitar Confusiones:

1. **Usa IDs secuenciales**
   ```
   1, 2, 3, 4, 5, ...
   ```

2. **Usa IDs con espacios**
   ```
   10, 20, 30, 40, 50, ...
   ```
   (Permite insertar entre ellos después: 15, 25, etc.)

3. **Usa IDs por categoría**
   ```
   Rock: 1000-1999
   Pop: 2000-2999
   Jazz: 3000-3999
   ```

4. **Documenta tus IDs**
   - Lleva un registro de qué IDs has usado
   - Usa la opción "Mostrar playlist ordenada" para ver IDs existentes

---

## 🔧 Si Necesitas Validación Adicional

### Opción 1: Validar Título + Artista Manualmente

Antes de agregar una canción, busca si ya existe una con el mismo título y artista:

```
1. Ver playlist ordenada
2. Verificar visualmente si existe
3. Si no existe, agregar con nuevo ID
```

### Opción 2: Modificar el Código (Avanzado)

Agregar un método de búsqueda por título y artista:

```java
public boolean existeCancion(String titulo, String artista) {
    ArrayList<Song> todas = recorridoInorden();
    for (Song s : todas) {
        if (s.getTitulo().equalsIgnoreCase(titulo) && 
            s.getArtista().equalsIgnoreCase(artista)) {
            return true;
        }
    }
    return false;
}
```

Luego validar antes de insertar:
```java
if (existeCancion(titulo, artista)) {
    System.out.println("✗ Ya existe una canción con ese título y artista");
    return;
}
```

---

## 📊 Resumen Visual

```
┌─────────────────────────────────────────────────────────┐
│                  CRITERIO DE UNICIDAD                   │
├─────────────────────────────────────────────────────────┤
│                                                         │
│  ✓ ID único          → Canción única                   │
│  ✗ ID duplicado      → Rechazado                       │
│                                                         │
│  ✓ Título duplicado  → Permitido (si ID diferente)     │
│  ✓ Artista duplicado → Permitido (si ID diferente)     │
│  ✓ Ambos duplicados  → Permitido (si ID diferente)     │
│                                                         │
└─────────────────────────────────────────────────────────┘
```

---

## ✅ Conclusión

El sistema **SÍ valida correctamente los IDs duplicados** y los rechaza.

El sistema **NO valida título + artista duplicados** porque:
- No es el criterio de unicidad del ABB
- Permite flexibilidad (covers, versiones, remasters)
- Es el comportamiento estándar de un ABB

Si necesitas validación adicional de título + artista, se puede agregar como una capa extra de validación en el `PlaylistManager`, pero no es parte de la lógica estándar del ABB.

---

**Última actualización:** Noviembre 2025
