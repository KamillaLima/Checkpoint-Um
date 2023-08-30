using Checkpoint.Excecao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint.Model
{
    internal class Pj : Funcionario, ICustoPj
    {
        public double ValorHora { get; set; }
        public int QuantidadeHoras { get; set; }
        public String Cnpj { get; set; }

        public int HorasExtras { get; set; }

        public static List<Pj> listaPj = new();

        public Pj(int codigo, string nome, Genero genero, double valorHora, int quantidadeHoras, string cnpj) : base(codigo, nome, genero)
        {
            ValorHora = valorHora;
            QuantidadeHoras = quantidadeHoras;
            Cnpj = cnpj;
        }
        public override string ToString()
        {
            return $"\nCódigo do funcionário: {Codigo}\n" +
               $"Nome do funcionário: {Nome}\n" +
               $"Gênero do funcionário: {Genero}\n" +
               $"valor por hora do funcionário: {ValorHora}\n" +
               $"Quantidade de horas trabalhadas pelo funcionário: {QuantidadeHoras}\n" +
               $"CNPJ do funcionário: {Cnpj}\n" +
               $"Salário mensal do funcionário: R${CustoMensal(QuantidadeHoras, ValorHora).ToString("N2")}\n";
        }

        public double CustoMensal(int horas, double valorPorHora)
        {
            double salarioMensal = horas * valorPorHora;
            return salarioMensal;
        }

        public double CustoMensallHorasExtras(int horasExtras, int horasNormais, double valorPorHora)
        {
            double valorTotal = CustoMensal(horasNormais, valorPorHora);
            double extra = horasExtras * valorPorHora;
            return extra + valorTotal;
        }

        public static void AumentoValorHora(Funcionario func, int registro, int aumento)
        {
            if (func is Pj pj && registro == pj.Codigo)
            {
                if (aumento < 0)
                {
                    throw new HoraExtraNegativaException(aumento);
                }
                else
                {
                    double novoSalario = pj.ValorHora + aumento;
                    pj.ValorHora = novoSalario;
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
