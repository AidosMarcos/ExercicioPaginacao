using System;
using System.Collections.Generic;
using System.Linq;

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
				var paginas = PaginasLista(currentPage, totalPages, boundaries, around);

				resultado = PaginasResultado(totalPages, resultado, paginas);
			}
			else
			{
				resultado = ResultadoInvalido;
			}

			return resultado;
		}

		private string PaginasResultado(int totalPages, string resultado, List<int> paginas)
		{
			var paginaAnterior = 1;

			//Passar a string correctamente para a variavel e adicionar as ...
			foreach (var pagina in paginas)
			{
				//Se a diferença entra a pagina atual e a anterior for maior que 1 significa que exite uma falha na sequencia de numeros então adiciona ...
				if (pagina - paginaAnterior > 1)
				{
					resultado += "... ";
				}
				paginaAnterior = pagina;

				//Adicionar espaços entre os numeros, menos no ultimo, para facilitar leitura do output
				if (pagina == paginas.Last())
				{
					resultado += pagina;
					//Em case de ainda haver numeros até totalPages, visto não os querermos mostrar adicionamos ...
					if (totalPages - pagina > 1)
					{
						resultado += " ...";
					}
				}
				else
				{
					resultado += pagina + " ";
				}
			}

			return resultado;
		}

		private List<int> PaginasLista(int currentPage, int totalPages, int boundaries, int around)
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

			//Ordenar e remover os valores iguais e selecionar apenas aqueles que ficam dentro dos valores que queremos na nossa lista
			paginas = paginas.OrderBy(item => item)
				.Distinct()
				.Where(item => item <= totalPages && item > 0)
				.ToList();

			return paginas;
		}
	}
}
