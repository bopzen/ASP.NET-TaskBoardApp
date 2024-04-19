using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Diagnostics.Contracts;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Task;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly TaskBoardAppDbContext _data;
        public TaskController(TaskBoardAppDbContext data)
        {
            _data = data;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            TaskFormModel taskModel = new TaskFormModel()
            {
                Boards = GetBoards()
            };
            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel model)
        {
			if (!GetBoards().Any(b => b.Id == model.BoardId))
            {
                ModelState.AddModelError(nameof(model.BoardId), "Board does not exist.");
            }

            string currntUserId = GetUserId();

            //if (!ModelState.IsValid)
            //{
            //    model.Boards = GetBoards();

            //    return View(model);
            //}

            Task task = new Task()
            {
                Title = model.Title,
                Description = model.Description,
                CreatedOn = DateTime.UtcNow,
                BoardId = model.BoardId,
                OwnerId = currntUserId,
            };

            await _data.Tasks.AddAsync(task);
            await _data.SaveChangesAsync();

            var boards = _data.Boards;

            return RedirectToAction("All", "Board");
        }

        public async Task<IActionResult> Details(int id)
        {
            var task = await _data
                .Tasks
                .Where(t => t.Id == id)
                .Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.ToString("dd/MM/yyy HH:mm"),
                    Board = t.Board.Name,
                    Owner = t.User.UserName,
                })
                .FirstOrDefaultAsync();

            if (task == null)
            {
                return BadRequest();
            }

            return View(task);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var task = await _data.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskFormModel taskModel = new TaskFormModel()
            {
				Title = task.Title,
			    Description = task.Description,
			    BoardId = task.BoardId,
                Boards = GetBoards()
		    };
            return View(taskModel);

		}


		[HttpPost]
        public async Task<IActionResult> Edit(int id, TaskFormModel taskModel)
        {
            var task = await _data.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

			if (!GetBoards().Any(b => b.Id == taskModel.BoardId))
			{
				ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
			}

            //if (!ModelState.IsValid)
            //{
            //    taskModel.Boards = GetBoards();
            //    return View(taskModel);
            //}

            task.Title = taskModel.Title;
            task.Description = taskModel.Description;
            task.BoardId = taskModel.BoardId;

            await _data.SaveChangesAsync();
            return RedirectToAction("All", "Board");

		}

        public async Task<IActionResult> Delete(int id)
        {
			var task = await _data.Tasks.FindAsync(id);

			if (task == null)
			{
				return BadRequest();
			}

			string currentUserId = GetUserId();
			if (currentUserId != task.OwnerId)
			{
				return Unauthorized();
			}

			TaskViewModel taskModel = new TaskViewModel()
			{
                Id = task.Id,
				Title = task.Title,
				Description = task.Description,

			};
			return View(taskModel);
		}

        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel taskModel)
        {
			var task = await _data.Tasks.FindAsync(taskModel.Id);

			if (task == null)
			{
				return BadRequest();
			}

			string currentUserId = GetUserId();
			if (currentUserId != task.OwnerId)
			{
				return Unauthorized();
			}

            _data.Tasks.Remove(task);
            await _data.SaveChangesAsync();
            return RedirectToAction("All", "Board");
		}






			private IEnumerable<TaskBoardModel> GetBoards()
        {
            return _data.Boards
                .Select(b => new TaskBoardModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                });

        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
