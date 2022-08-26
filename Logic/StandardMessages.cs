using ProjetoFinalTecnicas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalTecnicas.Logic
{
    public class StandardMessages : IStandardMessages
    {
        public void PrintEllipsis()
        {
            var ellipsis = "...";
            for (int i = 0; i < ellipsis.Length; i++)
            {
                Console.Write(ellipsis[i]);
                Thread.Sleep(500);
            }
        }
    }
}
