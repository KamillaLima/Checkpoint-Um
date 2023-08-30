using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint.Excecao
{
    internal class AumentoSalarioException : Exception
    {
        public AumentoSalarioException(String mensagem) : base(mensagem) { }

        public AumentoSalarioException(double valor) : base($"O valor da porcentagem de aumento do salário ({valor}%)" +
            $" deve ser positivo!")
        { }
    }
}
