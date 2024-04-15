using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TaskBoardApp.Data.DataConstraints.Task;

namespace TaskBoardApp.Data.Models
{
	public class Task
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(TaskMaxTitle)]
		public string Title { get; set; }

		[Required]
		[MaxLength(TaskMaxDescription)]
		public string Description { get; set; }

		public DateTime CreatedOn { get; set; }

		public int BoardId { get; set; }

		public virtual Board Board { get; set; }

		[Required]
		public string OwnerId { get; set; } = null!;
		public virtual IdentityUser User { get; set; } = null!;
	}
}
