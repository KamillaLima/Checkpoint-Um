using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint.Excecao
{
    internal class FuncionarioNaoExisteException:Exception
    {
        public FuncionarioNaoExisteException() : base($"Sem funcionários cadastrados na base de dados da empresa")
        { }
    }
}
