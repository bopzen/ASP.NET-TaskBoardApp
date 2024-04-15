using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Board;

namespace TaskBoardApp.Controllers
{
	public class BoardController : Controller
	{
		private readonly TaskBoardAppDbContext _data;

		public BoardController(TaskBoardAppDbContext data)
		{
			_data = data;
		}

		public async Task<IActionResult> All()
		{
			var boards = await _data
				.Boards
				.Select(b => new BoardViewModel()
				{
					Id = b.Id,
					Name = b.Name,
					Tasks = b.Tasks
						.Select(t => new Models.Task.TaskViewModel() 
						{ 
							Id = t.Id,
							Title = t.Title,
							Description = t.Description,
							Owner = t.User.UserName
						})
				}).ToListAsync();
			return View(boards);
		}

		public async Task<IActionResult> Index()
		{
			return View();
		}
	}
}
