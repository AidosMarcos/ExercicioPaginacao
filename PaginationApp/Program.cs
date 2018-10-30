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
			Console.WriteLine(paginacao.Paginar(10, 1000000000, 50,50 )); // Chamada do metodo para testar
        }
    }
}
