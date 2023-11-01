using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// Classe de exceção personalizada
namespace xadrez_console.tabuleiro
{
    public class TabuleiroException : Exception
    {
        public TabuleiroException(string massage) : base(massage){

        }
    }
}