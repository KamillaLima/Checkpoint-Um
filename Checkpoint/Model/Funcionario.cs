using Checkpoint.Excecao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint.Model
{
    internal abstract class Funcionario
    {
        public int Codigo { get; }
        public String Nome { get; set; }
        public Genero Genero { get; set; }

        public static List<Funcionario> listaFuncionarios = new();
        public Funcionario(int codigo, string nome, Genero genero)
        {
            Codigo = codigo;
            Nome = nome;
            Genero = genero;
        }

        public static void PesquisarFuncCodigo(int registro)
        {
            Funcionario func = PesquisarCodigo(registro);
            if (func is Clt clt)
            {
                Console.WriteLine(clt);

            }
            else if (func is Pj pj)
            {
                Console.WriteLine(pj);
            }


        }

        public static void PesquisarCustoMensal(int registro)
        {
            Funcionario func = PesquisarCodigo(registro);
            if (func is Clt clt)
            {
                Console.WriteLine($"O custo mensal do(a) funcionário(a) {clt.Nome}" +
                    $" é de R$ " + clt.CustoMensal(clt.Salario).ToString("N2"));

            }
            else if (func is Pj pj)
            {
                Console.WriteLine($"O custo mensal do(a) funcionário(a) {pj.Nome}" +
                    $" é de R$ " + pj.CustoMensal(pj.QuantidadeHoras, pj.ValorHora).ToString("N2"));
            }
            else
            {
                throw new FuncionarioNaoExisteException();
            }
        }

        public static Funcionario PesquisarCodigo(int registro)
        {
            foreach (var funcionario in listaFuncionarios)
            {
                if (funcionario.Codigo == registro)
                {
                    if (funcionario is Clt clt)
                    {
                        return clt;
                    }
                    else if (funcionario is Pj pj)
                    {
                        return pj;
                    }
                }
            }

            Console.WriteLine("Funcionário não encontrado!");
            return null;
        }

        public static void GastoTotalEmpresa()
        {
            double total = 0;
            foreach (var item in listaFuncionarios)
            {
                if (item is Clt clt)
                {

                    total += clt.CustoMensal(clt.Salario);

                }
                else if (item is Pj pj && pj.HorasExtras == 0)
                {
                    total += pj.CustoMensal(pj.QuantidadeHoras, pj.ValorHora);
                }
            }

            Console.WriteLine($"O total mensal gasto em funcionários é de R$ " + total.ToString("N2"));
        }

    }
}