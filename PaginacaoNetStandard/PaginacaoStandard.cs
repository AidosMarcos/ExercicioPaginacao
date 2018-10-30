using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaginacaoNetStandard
{

	public class PaginacaoStandard
	{
		public const string ResultadoInvalido = "Dados inseridos não podem ser usados.";

		/// <summary>
		///     Criar um metodo que gera paginação para um footer
		/// </summary>
		/// <param name="currentPage">Pagina atual a ser exibida</param>
		/// <param name="totalPages">Numero total de paginas</param>
		/// <param name="boundaries">Quantidade de paginas a mostrar no inicio e fim</param>
		/// <param name="around">Quantidade de paginas a mostrar a volta da currentPage</param>
		public string Paginar(int currentPage, int totalPages, int boundaries, int around)
		{
			var resultado = string.Empty;

			var limitesValidos = (boundaries >= 0 && around >= 0);
			var PaginasValidas = (currentPage > 0 && currentPage <= totalPages);

			//verificar se a currentPage é maior que 0 e menor ou igual que totalPages
			if (PaginasValidas && limitesValidos)
			{
				var paginas = ObterListaPaginas(currentPage, totalPages, boundaries, around);

				resultado = ObterResultadoPaginas(totalPages, paginas);
			}
			else
			{
				resultado = ResultadoInvalido;
			}

			return resultado;
		}

		private List<int> ObterListaPaginas(int currentPage, int totalPages, int boundaries, int around)
		{
			try
			{
				var paginas = new List<int>();
				//Adicionar a currentpage
				paginas.Add(currentPage);

				//Adicionar as boundaries iniciais
				paginas.AddRange(Enumerable.Range(1, boundaries));

				//Adicionar as boundaries finais
				paginas.AddRange(Enumerable.Range((totalPages - boundaries) + 1, boundaries));

				//Adicionar os valores around antes da currentPage
				paginas.AddRange(Enumerable.Range(currentPage - around, around));

				//Adicionar os valores around depois da currentPage
				paginas.AddRange(Enumerable.Range(currentPage + 1, around));

				//Ordenar e selecionar apenas os valores que queremos na nossa lista
				paginas = paginas.OrderBy(item => item)
					.Distinct()//Ter a certeza que não repito valores na lista
					.Where(item => item <= totalPages && item > 0)//apenas aqueles entre 1 e totalpages
					.ToList();

				return paginas;
			}
			catch (Exception)
			{
				return null;
			}
		}


		private string ObterResultadoPaginas(int totalPages, List<int> paginas)
		{
			//
			if (paginas == null)
			{
				return ResultadoInvalido;
			}

			try
			{
				var paginasString = new StringBuilder();

				//verificar se o primeiro item na lista de paginas é maior que 1, sim for adicionar ...
				paginasString.Append(paginas.First() > 1 ? "... " : "");

				var paginaAnterior = paginas.First();

				foreach (var pagina in paginas) //
				{   // caso a diferença entre a pagina actual e anterior for maior que 1
					if (pagina - paginaAnterior > 1) 
					{
						paginasString.Append($"... {pagina} "); // adicionar ... porque exite uma "gap"
					}
					else
					{
						paginasString.Append($"{pagina} "); // se não apenas adicionar a pagina
					}
					paginaAnterior = pagina;
				}

				//verificar se ultimo item de paginas é menos que totalPages, se for adicionar ...
				paginasString.Append(paginas.Last() < totalPages ? "... " : "");

				return paginasString.ToString().Trim();
			}
			catch (Exception)
			{
				return ResultadoInvalido;
			}
		}

	}
}
