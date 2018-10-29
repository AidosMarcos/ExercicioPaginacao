using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaginationWebApp.ViewModels
{
	public class PaginasViewModel
	{
		[Required]
		public int CurrentPage { get; set; }
		[Required]
		public int TotalPages { get; set; }
		[Required]
		public int Boundaries { get; set; }
		[Required]
		public int Around { get; set; }

		public string Resultado { get; set; }
		public string[] ResultadoArray { get; set; }
	}
}
