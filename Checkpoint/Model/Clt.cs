using Checkpoint.Excecao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint.Model
{
        internal class Clt : Funcionario
        {
            public double Salario { get; set; }
            public Boolean CargoConfianca { get; set; }

            public static List<Clt> listaClt = new();

            public Clt(int codigo, string nome, Genero genero, double salario, bool cargoConfianca) : base(codigo, nome, genero)
            {
                Salario = salario;
                CargoConfianca = cargoConfianca;
            }



        public override string ToString()
        {
            return $"\nCódigo do funcionário: {Codigo}\n" +
                $"Nome do funcionário: {Nome}\n" +
                $"Gênero do funcionário: {Genero}\n" +
                $"Salário do funcionário: R${Salario.ToString("N2")}\n" +
                $"Cargo de Confiança do funcionário: {CargoConfianca}\n";
        }

            public double CustoMensal(double salario)
            {
                double custoMensal = 0;
                double ferias = salario * 11.11 / 100;
                double decimo_terceiro = salario * 8.33 / 100;
                double fgts = salario * 8 / 100;
                double multa = salario * 4 / 100;
                double previdencia = salario * 7.93 / 100;

                custoMensal += salario + ferias + decimo_terceiro + fgts + multa + previdencia;
                return custoMensal;
            }

            public static void AumentoSalario(Funcionario func, double porcentagem)
            {
                if (func is Clt clt)
                {
                    if (porcentagem < 0)
                    {
                        throw new AumentoSalarioException(porcentagem);
                    }
                    else
                    {
                        double novoSalario = clt.Salario * (1 + porcentagem / 100);
                        clt.Salario = novoSalario;
                        clt.CustoMensal(novoSalario);
                        Console.WriteLine("Aumento realizado com sucesso!");
                    }
                }
                else
                {
                    throw new TipoFuncionarioException();
                }


            }


        }

    }
