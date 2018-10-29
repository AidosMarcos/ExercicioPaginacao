using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaginationWebApp.ViewModels
{
	public class PaginasViewModel
	{
		public int CurrentPage { get; set; }
		public int TotalPages { get; set; }
		public int Boundaries { get; set; }
		public int Around { get; set; }
		public string Resultado { get; set; }
		public string[] ResultadoArray { get; set; }
	}
}
