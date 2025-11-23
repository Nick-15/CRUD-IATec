using CRUD_IATec.Application.DTOs;
using CRUD_IATec.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_IATec.Controllers
{
    public class EstoquesController : Controller
    {
        private readonly IEstoqueService _estoqueService;

        public EstoquesController(IEstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        // GET: Estoques
        public async Task<IActionResult> Index()
        {
            var estoques = await _estoqueService.ObterTodosAsync();
            return View(estoques);
        }

        // GET: Estoques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estoque = await _estoqueService.ObterPorIdAsync(id.Value);

            if (estoque == null)
            {
                return NotFound();
            }

            return View(estoque);
        }

        // GET: Estoques/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estoques/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CriarEstoqueDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            try
            {
                await _estoqueService.CriarAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Erro ao criar estoque: {ex.Message}");
                return View(dto);
            }
        }

        // GET: Estoques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estoque = await _estoqueService.ObterPorIdAsync(id.Value);

            if (estoque == null)
            {
                return NotFound();
            }

            var dto = new AtualizarEstoqueDTO
            {
                NomeProduto = estoque.NomeProduto,
                Quantidade = estoque.Quantidade,
                Preco = estoque.Preco
            };

            ViewData["Id"] = estoque.Id;
            return View(dto);
        }

        // POST: Estoques/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AtualizarEstoqueDTO dto)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Id"] = id;
                return View(dto);
            }

            try
            {
                await _estoqueService.AtualizarAsync(id, dto);
                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Erro ao atualizar estoque: {ex.Message}");
                ViewData["Id"] = id;
                return View(dto);
            }
        }

        // GET: Estoques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estoque = await _estoqueService.ObterPorIdAsync(id.Value);

            if (estoque == null)
            {
                return NotFound();
            }

            return View(estoque);
        }

        // POST: Estoques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _estoqueService.DeletarAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Erro ao deletar estoque: {ex.Message}");
                return RedirectToAction(nameof(Delete), new { id });
            }
        }
    }
}