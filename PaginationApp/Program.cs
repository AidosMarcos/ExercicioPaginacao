using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaginacaoNetStandard;

namespace PaginationApp
{
    public class Program
    {
        static void Main()
        {
			var paginacao = new PaginacaoStandard();
			Console.WriteLine(paginacao.Paginar(10, 20, 2, 2)); // Chamada do metodo para testar
        }
    }
}
