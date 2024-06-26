﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using System.Diagnostics;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models;
using TaskBoardApp.Models.Home;

namespace TaskBoardApp.Controllers
{
	public class HomeController : Controller
	{ 
		private readonly TaskBoardAppDbContext _data;
		public HomeController(TaskBoardAppDbContext data)
		{
			_data = data;
		}

		
		public IActionResult Index()
		{
			var taskBoards = _data
				.Boards
				.Select(b => b.Name)
				.Distinct().ToList();

			var tasksCounts = new List<HomeBoardModel>();
			foreach (var boardName in taskBoards) 
			{
				var tasksInBoard = _data.Tasks.Where(t => t.Board.Name == boardName).Count();
				tasksCounts.Add(new HomeBoardModel()
				{
					BoardName = boardName,
					TasksCount = tasksInBoard
				});
			}

			var userTasksCount = -1;

			if (User.Identity.IsAuthenticated) 
			{
				var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
				userTasksCount = _data.Tasks.Where(t => t.OwnerId == currentUserId).Count();
			}

			var homeModel = new HomeViewModel()
			{
				AllTasksCount = _data.Tasks.Count(),
				BoardsWithTasksCount = tasksCounts,
				UserTasksCount = userTasksCount
			};


			return View(homeModel);
		}
	
	}
}
