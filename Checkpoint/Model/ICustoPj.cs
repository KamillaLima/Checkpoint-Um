using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint.Model
{
    internal interface ICustoPj
    {
        double CustoMensal(int horas, double valorPorHora);

        double CustoMensallHorasExtras(int HorasExtras, int horasNormais, double valorPorHora);
    }
}
