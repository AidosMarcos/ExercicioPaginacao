using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaginationApp
{
    public class Program
    {
        static void Main(string[] args)
        {

        }

        /// <summary>
        ///     Criar um metodo que gera paginação para um footer
        /// </summary>
        /// <param name="currentPage">Pagina atual a ser exibida</param>
        /// <param name="totalPages">Numero total de paginas</param>
        /// <param name="boundaries">Quantidade de paginas a mostrar no inicio e fim</param>
        /// <param name="around">Quantidade de paginas a mostrar a volta da currentPage</param>
        public static string Paginaçao(int currentPage, int totalPages, int boundaries, int around)
        {
            string resultado = "";

            var paginas = new List<int>();

			var limites = (boundaries >= 0 && around >= 0);
			var valorPaginas = (currentPage > 0 && currentPage <= totalPages);

            //verificar se a currentPage é maior que 0 e menor ou igual que totalPages
            if (valorPaginas && limites)
            {
                paginas.Add(currentPage);
            }
            else
            {
                return "Dados inseridos não podem ser usados.";
            }

            //Adicionar as boundaries iniciais
            for (int i = 1; i <= boundaries && i < currentPage; i++)
            {
                //adicionar i se numero i ainda não existir na lista
                if (!paginas.Contains(i))
                {
                    paginas.Add(i);
                }
            }

            //Adicionar as boundaries finais
            for (int i = totalPages; i > (totalPages - boundaries) && i > currentPage; i--)
            {
                //adicionar i se numero i ainda não existir na lista
                if (!paginas.Contains(i))
                {
                    paginas.Add(i);
                }
            }

            //Adicionar os around antes de currentPage
            for (int i = currentPage - around; i < currentPage; i++)
            {
                //adicionar i se ainda existir na lista e verificar que i é maior que 1 caso o valor de (currentPage - around) seja menor que 0
                if (!paginas.Contains(i) && i >= 1)
                {
                    paginas.Add(i);
                }
            }

            //Adicionar os around depois de currentPage
            for (int i = currentPage + around; i > currentPage; i--)
            {
                //adicionar i se ainda existir na lista e verificar que i é menor que totalPages caso o valor de (currentPage + around) seja maior que totalPages
                if (!paginas.Contains(i) && i <= totalPages)
                {
                    paginas.Add(i);
                }
            }

            //Ordenar a lista por ordem crescente
            paginas = paginas.OrderBy(item => item).ToList();

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

    }

}
