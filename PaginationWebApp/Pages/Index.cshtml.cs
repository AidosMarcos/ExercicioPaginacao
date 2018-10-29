using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PaginacaoNetStandard;
using PaginationWebApp.ViewModels;

namespace PaginationWebApp.Pages
{
	public class IndexModel : PageModel
	{
		public PaginacaoStandard _paginacao;

		[BindProperty]
		public PaginasViewModel PaginasVM { get; set; }

		//Usando dependecy injection para ter acesso a class que criei
		public IndexModel(PaginacaoStandard paginacao)
		{
			_paginacao = paginacao;
		}

		/// <summary>
		/// Metodo que responde ao post request to form
		/// Recebe os dados e corre o metodo e guarda o resultado
		/// </summary>
		public void OnPost()
		{
			PaginasVM.Resultado = _paginacao.Paginar(PaginasVM.CurrentPage, PaginasVM.TotalPages, PaginasVM.Boundaries, PaginasVM.Around);
			//apenas fazer o split caso o resultado seja valido
			if (PaginasVM.Resultado != "Dados inseridos não podem ser usados.")
			{
				PaginasVM.ResultadoArray = PaginasVM.Resultado.Split(" ");
			}
			else
			{
				PaginasVM.ResultadoArray = null;
			}

		}
	}
}
