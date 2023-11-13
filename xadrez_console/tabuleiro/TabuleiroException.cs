using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// Classe de exceção personalizada
namespace tabuleiro
{
    class TabuleiroException : Exception
    {
        public TabuleiroException(string massage) : base(massage){

        }
    }
}