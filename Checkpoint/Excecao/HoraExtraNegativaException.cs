using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint.Excecao
{
    internal class HoraExtraNegativaException : Exception
    {
        public HoraExtraNegativaException(String mensagem) : base(mensagem) { }

        public HoraExtraNegativaException(double aumento) : base($"O valor da hora extra ({aumento}) deve ser maior do que zero ")
        { }
    }
}
