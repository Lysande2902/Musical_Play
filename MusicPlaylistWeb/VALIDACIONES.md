# 🛡️ Validaciones Implementadas - Aplicación Web

## 📋 Resumen de Validaciones

Este documento detalla **todas las validaciones** implementadas en la aplicación web para garantizar la integridad de los datos.

---

## 🔒 Capas de Validación

### 1. **Validación en Cliente (HTML5 + JavaScript)**
- Primera línea de defensa
- Feedback inmediato al usuario
- Previene envío de datos inválidos

### 2. **Validación en Modelo (Song.cs)**
- Validaciones en constructor
- Excepciones descriptivas
- Garantiza integridad de objetos

### 3. **Validación en Servicio (PlaylistService.cs)**
- Try-catch para operaciones
- Manejo de errores
- Retorno de valores seguros

### 4. **Validación en Controlador (HomeController.cs)**
- ModelState validation
- TempData para mensajes
- Redirección apropiada

---

## 📝 Validaciones por Campo

### 1. ID de Canción

#### ❌ **NO SE ACEPTA:**
- Letras: `"abc"`, `"a1"`, `"1a"`
- Decimales: `1.5`, `3.14`, `5.99`
- Negativos: `-1`, `-100`
- Cero: `0`
- Espacios: `" "`, `"  "`
- Vacío: `""`

#### ✅ **SE ACEPTA:**
- Números enteros positivos: `1`, `5`, `100`, `9999`

#### 🔧 **Validaciones Implementadas:**

**HTML5:**
```html
<input type="number" 
       min="1" 
       step="1"
       pattern="[0-9]+"
       required />
```

**JavaScript:**
```javascript
// Prevenir letras al escribir
input.addEventListener('keypress', function(e) {
    if (e.key < '0' || e.key > '9') {
        e.preventDefault();
    }
});

// Validar al enviar
if (!/^\d+$/.test(id) || parseInt(id) <= 0) {
    alert('❌ El ID debe ser un número entero positivo');
    return false;
}
```

**C# (Modelo):**
```csharp
if (id <= 0)
    throw new ArgumentException("El ID debe ser un número positivo mayor a 0.");
```

**Validación Adicional:**
- No se permiten IDs duplicados (validado en BinarySearchTree)

---

### 2. Título de Canción

#### ❌ **NO SE ACEPTA:**
- Vacío: `""`
- Solo espacios: `"   "`, `"  "`
- Null: `null`
- Más de 100 caracteres

#### ✅ **SE ACEPTA:**
- Cualquier texto con al menos un carácter no-espacio
- Ejemplos: `"Bohemian Rhapsody"`, `"Hotel California"`, `"Imagine"`
- Letras, números, símbolos: `"Song #1"`, `"Rock & Roll"`

#### 🔧 **Validaciones Implementadas:**

**HTML5:**
```html
<input type="text" 
       required 
       minlength="1"
       maxlength="100"
       pattern=".*\S+.*" />
```

**JavaScript:**
```javascript
if (titulo.trim().length === 0) {
    alert('❌ El título no puede estar vacío o contener solo espacios.');
    return false;
}
```

**C# (Modelo):**
```csharp
if (string.IsNullOrWhiteSpace(titulo))
    throw new ArgumentException("El título no puede estar vacío.");

Titulo = titulo.Trim(); // Elimina espacios al inicio/final
```

---

### 3. Artista

#### ❌ **NO SE ACEPTA:**
- Vacío: `""`
- Solo espacios: `"   "`
- Null: `null`
- Más de 100 caracteres

#### ✅ **SE ACEPTA:**
- Cualquier texto con al menos un carácter no-espacio
- Ejemplos: `"Queen"`, `"Led Zeppelin"`, `"The Beatles"`
- Letras, números, símbolos: `"AC/DC"`, `"Guns N' Roses"`

#### 🔧 **Validaciones Implementadas:**

**HTML5:**
```html
<input type="text" 
       required 
       minlength="1"
       maxlength="100"
       pattern=".*\S+.*" />
```

**JavaScript:**
```javascript
if (artista.trim().length === 0) {
    alert('❌ El artista no puede estar vacío o contener solo espacios.');
    return false;
}
```

**C# (Modelo):**
```csharp
if (string.IsNullOrWhiteSpace(artista))
    throw new ArgumentException("El artista no puede estar vacío.");

Artista = artista.Trim();
```

---

### 4. Duración (en segundos)

#### ❌ **NO SE ACEPTA:**
- Letras: `"abc"`, `"5min"`, `"3:00"`
- Decimales: `180.5`, `3.14`
- Negativos: `-100`, `-1`
- Cero: `0`
- Mayor a 7200 (2 horas): `7201`, `10000`

#### ✅ **SE ACEPTA:**
- Números enteros de 1 a 7200
- Ejemplos: `180` (3:00), `354` (5:54), `482` (8:02)

#### 🔧 **Validaciones Implementadas:**

**HTML5:**
```html
<input type="number" 
       min="1" 
       max="7200"
       step="1"
       pattern="[0-9]+"
       required />
```

**JavaScript:**
```javascript
// Prevenir letras
input.addEventListener('keypress', function(e) {
    if (e.key < '0' || e.key > '9') {
        e.preventDefault();
    }
});

// Validar rango
if (!/^\d+$/.test(duracion) || parseInt(duracion) <= 0 || parseInt(duracion) > 7200) {
    alert('❌ La duración debe ser un número entero positivo entre 1 y 7200 segundos');
    return false;
}
```

**C# (Modelo):**
```csharp
if (duracion <= 0)
    throw new ArgumentException("La duración debe ser mayor a 0 segundos.");
```

**Formato de Visualización:**
```csharp
public string DuracionFormateada
{
    get
    {
        int minutos = Duracion / 60;
        int segundos = Duracion % 60;
        return $"{minutos}:{segundos:D2}";
    }
}
```

---

### 5. Popularidad

#### ❌ **NO SE ACEPTA:**
- Letras: `"abc"`, `"alta"`, `"media"`
- Decimales: `95.5`, `3.14`, `99.9`
- Negativos: `-1`, `-100`
- Mayor a 100: `101`, `150`, `200`

#### ✅ **SE ACEPTA:**
- Números enteros de 0 a 100 (inclusive)
- Ejemplos: `0`, `50`, `85`, `95`, `100`

#### 🔧 **Validaciones Implementadas:**

**HTML5:**
```html
<input type="number" 
       min="0" 
       max="100"
       step="1"
       pattern="[0-9]{1,3}"
       required />
```

**JavaScript:**
```javascript
// Prevenir letras
input.addEventListener('keypress', function(e) {
    if (e.key < '0' || e.key > '9') {
        e.preventDefault();
    }
});

// Validar rango
if (!/^\d+$/.test(popularidad) || parseInt(popularidad) < 0 || parseInt(popularidad) > 100) {
    alert('❌ La popularidad debe ser un número entero entre 0 y 100');
    return false;
}
```

**C# (Modelo):**
```csharp
if (popularidad < 0 || popularidad > 100)
    throw new ArgumentException($"La popularidad debe estar entre 0 y 100. Valor recibido: {popularidad}");
```

---

## 🚫 Prevención de Ataques

### 1. Prevención de Entrada de Letras en Campos Numéricos

**JavaScript:**
```javascript
const camposNumericos = ['Id', 'Duracion', 'Popularidad'];
camposNumericos.forEach(function(campo) {
    document.getElementById(campo).addEventListener('keypress', function(e) {
        // Solo permitir números (0-9)
        if (e.key < '0' || e.key > '9') {
            e.preventDefault();
        }
    });
});
```

### 2. Prevención de Pegar Texto Inválido

**JavaScript:**
```javascript
input.addEventListener('paste', function(e) {
    const pasteData = e.clipboardData.getData('text');
    if (!/^\d+$/.test(pasteData)) {
        e.preventDefault();
        alert('❌ Solo se permiten números enteros en este campo.');
    }
});
```

### 3. Validación de Espacios en Blanco

**JavaScript:**
```javascript
if (titulo.trim().length === 0) {
    alert('❌ El título no puede estar vacío o contener solo espacios.');
    return false;
}
```

**C#:**
```csharp
if (string.IsNullOrWhiteSpace(titulo))
    throw new ArgumentException("El título no puede estar vacío.");
```

---

## 📊 Tabla Resumen de Validaciones

| Campo | Tipo | Acepta | No Acepta | Rango |
|-------|------|--------|-----------|-------|
| **ID** | int | 1, 5, 100 | 0, -1, "abc", 1.5 | > 0 |
| **Título** | string | "Imagine" | "", "   ", null | 1-100 chars |
| **Artista** | string | "Queen" | "", "   ", null | 1-100 chars |
| **Duración** | int | 180, 482 | 0, -1, "5min", 3.14 | 1-7200 |
| **Popularidad** | int | 0, 50, 100 | -1, 101, "alta", 99.5 | 0-100 |

---

## ✅ Ejemplos de Validación

### Ejemplo 1: ID Válido
```
Entrada: 5
Resultado: ✓ Aceptado
```

### Ejemplo 2: ID Inválido (Letra)
```
Entrada: "abc"
Resultado: ❌ Rechazado
Mensaje: "El ID debe ser un número entero positivo"
```

### Ejemplo 3: ID Inválido (Decimal)
```
Entrada: 5.5
Resultado: ❌ Rechazado (prevenido por keypress)
Mensaje: Solo se permiten números enteros
```

### Ejemplo 4: Título Válido
```
Entrada: "Bohemian Rhapsody"
Resultado: ✓ Aceptado
```

### Ejemplo 5: Título Inválido (Solo Espacios)
```
Entrada: "   "
Resultado: ❌ Rechazado
Mensaje: "El título no puede estar vacío o contener solo espacios"
```

### Ejemplo 6: Popularidad Válida
```
Entrada: 95
Resultado: ✓ Aceptado
```

### Ejemplo 7: Popularidad Inválida (Fuera de Rango)
```
Entrada: 150
Resultado: ❌ Rechazado
Mensaje: "La popularidad debe ser un número entero entre 0 y 100"
```

---

## 🎯 Feedback Visual

### Estados de Validación

**CSS:**
```css
.form-control:invalid {
    border-color: #ff3b30;  /* Rojo para inválido */
}

.form-control:valid {
    border-color: var(--spotify-green);  /* Verde para válido */
}
```

### Mensajes de Ayuda

Cada campo incluye un mensaje de ayuda:
```html
<small class="form-text">
    Solo números enteros positivos (sin decimales ni letras)
</small>
```

### Alertas de Error

```javascript
alert('❌ El ID debe ser un número entero positivo.\nEjemplo: 1, 5, 100');
```

---

## 🔍 Pruebas de Validación

### Casos de Prueba Recomendados

#### ID:
- ✅ Probar: 1, 5, 100
- ❌ Probar: 0, -1, "abc", 1.5, ""

#### Título:
- ✅ Probar: "Imagine", "Song #1"
- ❌ Probar: "", "   ", null

#### Artista:
- ✅ Probar: "Queen", "AC/DC"
- ❌ Probar: "", "   ", null

#### Duración:
- ✅ Probar: 180, 482, 7200
- ❌ Probar: 0, -1, 7201, "5min", 3.14

#### Popularidad:
- ✅ Probar: 0, 50, 100
- ❌ Probar: -1, 101, "alta", 99.5

---

## 📚 Resumen

### ✅ Validaciones Implementadas:

1. **HTML5 Attributes:**
   - `type="number"` - Solo números
   - `required` - Campo obligatorio
   - `min` / `max` - Rango de valores
   - `step="1"` - Solo enteros
   - `pattern` - Expresión regular
   - `minlength` / `maxlength` - Longitud de texto

2. **JavaScript:**
   - Prevención de letras en campos numéricos
   - Prevención de pegar texto inválido
   - Validación antes de enviar formulario
   - Alertas descriptivas

3. **C# (Modelo):**
   - Validaciones en constructor
   - Excepciones con mensajes descriptivos
   - Trim automático de strings

4. **C# (Controlador):**
   - Try-catch para capturar errores
   - TempData para mensajes de éxito/error
   - Redirección apropiada

### 🎯 Resultado:

**Todas las validaciones están implementadas en múltiples capas** para garantizar que:
- ❌ No se acepten letras donde se esperan números
- ❌ No se acepten decimales donde se esperan enteros
- ❌ No se acepten valores fuera de rango
- ❌ No se acepten campos vacíos
- ✅ Solo se acepten datos válidos y seguros

---

**Última actualización:** Noviembre 2025
