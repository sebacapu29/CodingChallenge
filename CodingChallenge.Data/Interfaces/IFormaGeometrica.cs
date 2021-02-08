using CodingChallenge.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Interfaces
{
    public interface IFormaGeometrica
    {
        decimal CalcularArea();
        decimal CalcularPerimetro();
        string ObtenerLinea(int cantidad, decimal area, decimal perimetro);
    }
}
