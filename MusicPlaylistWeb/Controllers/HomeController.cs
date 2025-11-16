using Microsoft.AspNetCore.Mvc;
using MusicPlaylistWeb.Models;
using MusicPlaylistWeb.Services;

namespace MusicPlaylistWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly PlaylistService _playlistService;

        public HomeController(PlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        public IActionResult Index()
        {
            var canciones = _playlistService.ObtenerTodasLasCanciones();
            ViewBag.TotalCanciones = _playlistService.ContarCanciones();
            ViewBag.Altura = _playlistService.ObtenerAltura();
            return View(canciones);
        }

        [HttpGet]
        public IActionResult Agregar()
        {
            ViewBag.IdSugerido = _playlistService.SugerirProximoID();
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Song cancion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var (exito, mensaje) = _playlistService.AgregarCancion(cancion);
                    if (exito)
                    {
                        TempData["Success"] = $"✓ {mensaje}";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Error"] = $"✗ {mensaje}";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"✗ Error: {ex.Message}";
            }

            ViewBag.IdSugerido = _playlistService.SugerirProximoID();
            return View(cancion);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var cancion = _playlistService.BuscarCancion(id);
            if (cancion == null)
            {
                TempData["Error"] = $"✗ No se encontró la canción con ID {id}";
                return RedirectToAction("Index");
            }
            return View(cancion);
        }

        [HttpPost]
        public IActionResult Editar(int idOriginal, Song cancion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var (exito, mensaje) = _playlistService.EditarCancion(idOriginal, cancion);
                    if (exito)
                    {
                        TempData["Success"] = $"✓ {mensaje}";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Error"] = $"✗ {mensaje}";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"✗ Error: {ex.Message}";
            }

            return View(cancion);
        }

        [HttpGet]
        public IActionResult Buscar(int? id)
        {
            if (id.HasValue && id.Value > 0)
            {
                var cancion = _playlistService.BuscarCancion(id.Value);
                if (cancion != null)
                {
                    ViewBag.Nivel = _playlistService.ObtenerNivelDeNodo(id.Value);
                    return View(cancion);
                }
                TempData["Error"] = $"✗ No se encontró ninguna canción con el ID {id.Value}";
            }
            return View();
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            try
            {
                bool eliminado = _playlistService.EliminarCancion(id);
                if (eliminado)
                {
                    TempData["Success"] = "✓ Canción eliminada exitosamente!";
                }
                else
                {
                    TempData["Error"] = "✗ No se pudo eliminar la canción.";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"✗ Error: {ex.Message}";
            }

            return RedirectToAction("Index");
        }

        public IActionResult Recorridos()
        {
            ViewBag.Inorden = _playlistService.RecorridoInorden();
            ViewBag.Preorden = _playlistService.RecorridoPreorden();
            ViewBag.Postorden = _playlistService.RecorridoPostorden();
            ViewBag.PorNiveles = _playlistService.RecorridoPorNiveles();
            return View();
        }

        public IActionResult Estadisticas()
        {
            ViewBag.TotalCanciones = _playlistService.ContarCanciones();
            ViewBag.Altura = _playlistService.ObtenerAltura();
            ViewBag.Estructura = _playlistService.ObtenerEstructuraArbol();
            return View();
        }

        [HttpGet]
        public IActionResult BuscarPorArtista(string? artista)
        {
            if (!string.IsNullOrWhiteSpace(artista))
            {
                var resultados = _playlistService.BuscarPorArtista(artista);
                ViewBag.Artista = artista;
                return View(resultados);
            }
            return View(new List<Song>());
        }

        public IActionResult TopPopulares()
        {
            var topCanciones = _playlistService.ObtenerTopPopulares(10);
            return View(topCanciones);
        }

        [HttpGet]
        public IActionResult BuscarPorNivel(int? nivel)
        {
            if (nivel.HasValue && nivel.Value >= 0)
            {
                var resultados = _playlistService.BuscarPorNivel(nivel.Value);
                ViewBag.Nivel = nivel.Value;
                ViewBag.AlturaMaxima = _playlistService.ObtenerAltura();
                return View(resultados);
            }
            ViewBag.AlturaMaxima = _playlistService.ObtenerAltura();
            return View(new List<Song>());
        }

        public IActionResult Ayuda()
        {
            return View();
        }
    }
}
