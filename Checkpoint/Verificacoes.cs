using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint
{
    internal class Verificacoes
    {
        public static bool CampoVazio(string informacao)
        {
            return !string.IsNullOrEmpty(informacao);
        }

        public static bool CampoValores(double valor)
        {
            return valor >= 0;
        }
        public static bool ValidacaoTipoFuncionario(string tipoFuncionario)
        {
            if (CampoVazio(tipoFuncionario))
            {
                return tipoFuncionario == "CLT" || tipoFuncionario == "PJ";
            }
            else
            {
                return false;
            }
        }
        public static bool ValidacaoGenero(string generoStr)
        {

            if (CampoVazio(generoStr))
            {
                return generoStr == "M" || generoStr == "F" || generoStr == "O";
            }
            else
            {
                return false;
            }
        }

        public static bool ValidacaoTipoCargo(string cargo)
        {
            if (CampoVazio(cargo))
            {
                return cargo == "S" || cargo == "N";
            }
            else
            {
                return false;
            }
        }

        public static bool CnpjValido(String cnpj)
        {

            if (CampoVazio(cnpj))
            {
                return cnpj.Length != 14;
            }
            else
            {
                return false;
            }
        }

        public static int RegistroValido()
        {
            int registroPesquisa;
            do
            {
                Console.Write("Informe o código de registro do funcionário: ");
                registroPesquisa = int.Parse(Console.ReadLine());
            } while (!Verificacoes.CampoValores(registroPesquisa));
            return registroPesquisa;
        }


    }

}
