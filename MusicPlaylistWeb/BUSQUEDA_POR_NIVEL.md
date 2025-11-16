# 🔍 Búsqueda por Nivel en el Árbol Binario

## Descripción
Nueva funcionalidad que permite buscar y visualizar todas las canciones que se encuentran en un nivel específico del árbol binario de búsqueda.

## Implementación

### 1. Método en BinarySearchTree.cs
```csharp
public List<Song> BuscarPorNivel(int nivelBuscado)
```
- **Complejidad:** O(n) - Recorre todos los nodos del árbol
- **Funcionamiento:** Utiliza recursión para recorrer el árbol y recolectar nodos en el nivel especificado
- **Parámetros:** 
  - `nivelBuscado`: Nivel del árbol (0 = raíz, 1 = hijos de raíz, etc.)
- **Retorna:** Lista de canciones encontradas en ese nivel

### 2. Método en PlaylistService.cs
```csharp
public List<Song> BuscarPorNivel(int nivel)
```
- Expone la funcionalidad del árbol a través del servicio

### 3. Acción en HomeController.cs
```csharp
[HttpGet]
public IActionResult BuscarPorNivel(int? nivel)
```
- Maneja las peticiones GET con el parámetro `nivel`
- Proporciona información adicional como la altura máxima del árbol
- Retorna la vista con los resultados

### 4. Vista BuscarPorNivel.cshtml
- Formulario de búsqueda con validación de rango
- Muestra información contextual sobre niveles válidos
- Tabla de resultados con todas las canciones del nivel
- Estadísticas del nivel (cantidad, popularidad promedio, duración total)
- Alertas informativas cuando no hay resultados

## Características

### Validaciones
- ✅ Nivel mínimo: 0 (raíz)
- ✅ Nivel máximo: altura del árbol - 1
- ✅ Muestra altura actual del árbol
- ✅ Mensajes claros cuando el nivel está vacío

### Información Mostrada
Para cada canción encontrada:
- ID
- Título
- Artista
- Duración formateada
- Barra de popularidad visual
- Badge indicando el nivel
- Botones de acción (Editar, Detalles)

### Estadísticas del Nivel
- Cantidad de canciones en el nivel
- Popularidad promedio
- Duración total de todas las canciones

## Navegación
- Nuevo enlace en el menú principal: "Buscar por Nivel"
- Enlace desde la página de Estadísticas
- Integrado con el resto de funcionalidades

## Casos de Uso

### Ejemplo 1: Buscar en la raíz
```
Nivel: 0
Resultado: 1 canción (el nodo raíz del árbol)
```

### Ejemplo 2: Buscar en nivel intermedio
```
Nivel: 2
Resultado: Todas las canciones que están a 2 niveles de profundidad desde la raíz
```

### Ejemplo 3: Nivel vacío
```
Nivel: 10 (si la altura es menor)
Resultado: Mensaje indicando que el nivel no existe o está vacío
```

## Aclaración sobre el Conteo de Canciones

### ✅ El conteo es CORRECTO
- **Total en JSON:** 18 canciones
- **Total mostrado:** 18 canciones
- El sistema cuenta correctamente todos los nodos del árbol

### Verificación
Puedes verificar el conteo manualmente:
```powershell
Get-Content "MusicPlaylistWeb/Data/playlist.json" | ConvertFrom-Json | Select-Object -ExpandProperty canciones | Measure-Object
```

## Mejoras Visuales

### Página de Estadísticas
- ✅ Agregada tarjeta con "Rango de Niveles"
- ✅ Alert informativo con enlace directo a búsqueda por nivel
- ✅ Información clara sobre la distribución de nodos

### Estilos
- Badges de nivel con gradiente morado
- Alertas con colores distintivos (éxito, advertencia, información)
- Formulario responsive con validación visual
- Estadísticas resumidas con diseño de tarjetas

## Complejidad Algorítmica

### Búsqueda por Nivel
- **Tiempo:** O(n) - Debe visitar todos los nodos para verificar su nivel
- **Espacio:** O(h) - Profundidad de la recursión (altura del árbol)

### Comparación con otras búsquedas
- Búsqueda por ID: O(log n) en árbol balanceado
- Búsqueda por título/artista: O(n) - recorrido completo
- Búsqueda por nivel: O(n) - recorrido completo

## Integración con el Sistema

Esta funcionalidad se integra perfectamente con:
- ✅ Sistema de navegación existente
- ✅ Estilos globales de la aplicación
- ✅ Validaciones del modelo
- ✅ Servicio de persistencia JSON
- ✅ Estructura del árbol binario

## Fecha de Implementación
15 de noviembre de 2025
