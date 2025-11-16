# 🌳 Estructura del Árbol Balanceado

## Fecha: 15 de noviembre de 2025

## Nuevo Orden de Inserción

He reorganizado el JSON para crear un árbol más balanceado con **múltiples nodos por nivel**.

### Orden de inserción:
```
10, 5, 15, 3, 7, 12, 17, 1, 4, 6, 8, 11, 13, 16, 18, 2, 9, 14, 19
```

## Estructura del Árbol Resultante

```
                    10 (Secreto de Amor)
                   /  \
                  /    \
                 /      \
                5        15 (Feel Special)
               / \       / \
              /   \     /   \
             3     7   12    17 (Back Door)
            / \   / \ / \   / \
           1   4 6  8 11 13 16 18 (God's Menu)
          /       \         \    \
         2         9        14   19 (Confident)
```

## Distribución por Niveles

### Nivel 0 (Raíz)
- **1 nodo:** ID 10

### Nivel 1
- **2 nodos:** ID 5, ID 15

### Nivel 2
- **4 nodos:** ID 3, ID 7, ID 12, ID 17

### Nivel 3
- **8 nodos:** ID 1, ID 4, ID 6, ID 8, ID 11, ID 13, ID 16, ID 18

### Nivel 4
- **4 nodos:** ID 2, ID 9, ID 14, ID 19

## Características del Árbol

### ✅ Ventajas de esta estructura:
1. **Balanceado:** Altura mínima para 19 nodos
2. **Múltiples nodos por nivel:** Cada nivel (excepto raíz) tiene varios nodos
3. **Búsqueda eficiente:** O(log n) en promedio
4. **Visualización clara:** Se ve como un árbol "real" con ramas

### 📊 Estadísticas:
- **Total de nodos:** 19 canciones
- **Altura del árbol:** 5 niveles (0 a 4)
- **Nodos por nivel:**
  - Nivel 0: 1 nodo
  - Nivel 1: 2 nodos
  - Nivel 2: 4 nodos
  - Nivel 3: 8 nodos
  - Nivel 4: 4 nodos

### 🎯 Comparación con estructura anterior:

**Antes (orden secuencial 1,2,3,4...):**
```
1
 \
  2
   \
    3
     \
      4 (y así sucesivamente...)
```
- Altura: 19 niveles
- Nodos por nivel: 1 en cada nivel
- Forma: Lista enlazada (degenerado)

**Ahora (orden balanceado):**
```
        10
       /  \
      5    15
     / \   / \
    3   7 12  17
   (etc...)
```
- Altura: 5 niveles
- Nodos por nivel: 1, 2, 4, 8, 4
- Forma: Árbol binario balanceado

## Cómo se logró el balance

### Técnica utilizada: Inserción en orden medio
1. Empezar con un valor medio (10)
2. Insertar valores menores y mayores alternadamente
3. Distribuir los valores para llenar niveles uniformemente

### Fórmula para árbol perfecto:
Para un árbol con `n` nodos, la altura óptima es `⌈log₂(n+1)⌉`
- Con 19 nodos: altura óptima = ⌈log₂(20)⌉ = 5 ✅

## Recorridos del Nuevo Árbol

### Inorden (Izq → Nodo → Der):
```
1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19
```
**Resultado:** Orden ascendente (como debe ser en un ABB)

### Preorden (Nodo → Izq → Der):
```
10, 5, 3, 1, 2, 4, 7, 6, 8, 9, 15, 12, 11, 13, 14, 17, 16, 18, 19
```
**Resultado:** Raíz primero, luego subárboles

### Postorden (Izq → Der → Nodo):
```
2, 1, 4, 3, 6, 9, 8, 7, 5, 11, 14, 13, 12, 16, 19, 18, 17, 15, 10
```
**Resultado:** Hojas primero, raíz al final

### Por Niveles (BFS):
```
10, 5, 15, 3, 7, 12, 17, 1, 4, 6, 8, 11, 13, 16, 18, 2, 9, 14, 19
```
**Resultado:** Nivel por nivel, izquierda a derecha

## Búsqueda por Nivel - Ejemplos

### Nivel 0:
- **1 canción:** Secreto de Amor (ID 10)

### Nivel 1:
- **2 canciones:** Monster (ID 5), Feel Special (ID 15)

### Nivel 2:
- **4 canciones:** Hero (ID 3), November Rain (ID 7), Fancy (ID 12), Back Door (ID 17)

### Nivel 3:
- **8 canciones:** Back In Black (ID 1), Highway to Hell (ID 4), Bohemian Rhapsody (ID 6), Feel Invincible (ID 8), Hotel California (ID 11), Tatuajes (ID 13), Smells Like Teen Spirit (ID 16), God's Menu (ID 18)

### Nivel 4:
- **4 canciones:** Sweet Child O' Mine (ID 2), Stairway to Heaven (ID 9), Imagine (ID 14), Confident (ID 19)

## Complejidad de Operaciones

### Con árbol balanceado:
- **Búsqueda:** O(log n) = O(log 19) ≈ 4-5 comparaciones
- **Inserción:** O(log n) = O(log 19) ≈ 4-5 comparaciones
- **Eliminación:** O(log n) = O(log 19) ≈ 4-5 comparaciones

### Con árbol degenerado (anterior):
- **Búsqueda:** O(n) = O(19) = hasta 19 comparaciones
- **Inserción:** O(n) = O(19) = hasta 19 comparaciones
- **Eliminación:** O(n) = O(19) = hasta 19 comparaciones

## Visualización Mejorada

Ahora cuando uses la funcionalidad "Buscar por Nivel", verás:
- ✅ Nivel 0: 1 canción
- ✅ Nivel 1: 2 canciones (izquierda y derecha de la raíz)
- ✅ Nivel 2: 4 canciones (distribución balanceada)
- ✅ Nivel 3: 8 canciones (nivel más poblado)
- ✅ Nivel 4: 4 canciones (hojas del árbol)

## Conclusión

Este nuevo orden de inserción crea un **árbol binario de búsqueda balanceado** que:
1. Tiene múltiples nodos por nivel
2. Mantiene la propiedad de ABB (inorden = orden ascendente)
3. Optimiza las operaciones de búsqueda
4. Se ve como un árbol "real" con estructura jerárquica clara

**¡Ahora tu árbol tiene la estructura que esperabas!** 🎉
