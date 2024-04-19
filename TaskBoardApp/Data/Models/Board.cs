using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstraints.Board;

namespace TaskBoardApp.Data.Models
{
	public class Board
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(BoardMaxName)]
		public string Name { get; set; } = null!;
		public virtual IEnumerable<Task> Tasks { get; set; }
			= new List<Task>();
	}
}
