	using System;
	using System.Linq;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	using DreamsAI.Data;
	using DreamsAI.Models;
	using Microsoft.Extensions.Configuration;

	namespace DreamsAI.Controllers
	{
		public class DreamsController : Controller
		{
			private readonly ApplicationDbContext _context;
			private readonly OpenAIClient _openAIClient;

			public DreamsController(ApplicationDbContext context, IConfiguration configuration)
			{
				_context = context;

				// Зареждане на API ключа от конфигурационния файл
				var apiKey = configuration["OpenAI:ApiKey"];
				_openAIClient = new OpenAIClient(apiKey);
			}

			// GET: Dreams
			public async Task<IActionResult> Index(string searchString)
			{
				var dreams = from d in _context.Dream select d;

				if (!string.IsNullOrEmpty(searchString))
				{
					dreams = dreams.Where(d => d.Title.Contains(searchString) || d.Description.Contains(searchString));
				}

				return View(await dreams.ToListAsync());
			}

			// GET: Dreams/Details/5
			public async Task<IActionResult> Details(int? id)
			{
				if (id == null)
				{
					return NotFound();
				}

				var dream = await _context.Dream
					.FirstOrDefaultAsync(m => m.Id == id);
				if (dream == null)
				{
					return NotFound();
				}

				return View(dream);
			}

			// GET: Dreams/Create
			public IActionResult Create()
			{
				return View();
			}

			// POST: Dreams/Create
			[HttpPost]
			[ValidateAntiForgeryToken]
			public async Task<IActionResult> Create(Dream dream)
			{
				if (ModelState.IsValid)
				{
					// Извикване на AI API за анализ на съня
					if (!string.IsNullOrEmpty(dream.Description))
					{
						//dream.Analysis = await  _openAIClient.AnalyzeDreamAsync(dream.Description);
					}

					// Задаване на CreatedAt
					dream.CreatedAt = DateTime.Now;

					// Запазване на съня в базата данни
					_context.Add(dream);
					await _context.SaveChangesAsync();

					return RedirectToAction(nameof(Index));
				}

				return View(dream);
			}

			// GET: Dreams/ManageDreams (показва сънищата, сортирани по категория)
			public async Task<IActionResult> ManageDreams()
			{
				var dreams = await _context.Dream
					.OrderBy(d => d.Category) // Сортиране по категория
					.ToListAsync();

				return View(dreams);
			}

			// GET: Dreams/Edit/5
			public async Task<IActionResult> Edit(int? id)
			{
				if (id == null)
				{
					return NotFound();
				}

				var dream = await _context.Dream.FindAsync(id);
				if (dream == null)
				{
					return NotFound();
				}
				return View(dream);
			}

			// POST: Dreams/Edit/5
			[HttpPost]
			[ValidateAntiForgeryToken]
			public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,CreatedAt,Time,Category,Analysis")] Dream dream)
			{
				if (id != dream.Id)
				{
					return NotFound();
				}

				if (ModelState.IsValid)
				{
					try
					{
						// Проверка дали описанието е променено и извикване на AI API за нов анализ
						if (!string.IsNullOrEmpty(dream.Description))
						{
							// dream.Analysis = await _openAIClient.AnalyzeDreamAsync(dream.Description);
						}

						// Актуализиране на съня в базата данни
						_context.Update(dream);
						await _context.SaveChangesAsync();
					}
					catch (DbUpdateConcurrencyException)
					{
						if (!DreamExists(dream.Id))
						{
							return NotFound();
						}
						else
						{
							throw;
						}
					}

					return RedirectToAction(nameof(Index));
				}

				return View(dream);
			}

			// GET: Dreams/Delete/5
			public async Task<IActionResult> Delete(int? id)
			{
				if (id == null)
				{
					return NotFound();
				}

				var dream = await _context.Dream
					.FirstOrDefaultAsync(m => m.Id == id);
				if (dream == null)
				{
					return NotFound();
				}

				return View(dream);
			}

			// POST: Dreams/Delete/5
			[HttpPost, ActionName("Delete")]
			[ValidateAntiForgeryToken]
			public async Task<IActionResult> DeleteConfirmed(int id)
			{
				var dream = await _context.Dream.FindAsync(id);
				if (dream != null)
				{
					_context.Dream.Remove(dream);
				}

				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}

			private bool DreamExists(int id)
			{
				return _context.Dream.Any(e => e.Id == id);
			}
		}
	}