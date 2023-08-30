using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint.Excecao
{
    internal class TipoFuncionarioException :Exception
    {
        public TipoFuncionarioException(String mensagem) : base(mensagem) { }

        public TipoFuncionarioException() : base($"Esse funcionário não possui essa função disponível! ")
        { }
    }
}
