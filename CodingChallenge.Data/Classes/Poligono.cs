using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{

    public class Poligono : FormaGeometrica<Poligono>, IFormaGeometrica
    {
        public decimal CalcularArea()
        {
            throw new NotImplementedException();
        }

        public decimal CalcularPerimetro()
        {
            throw new NotImplementedException();
        }

        public string ObtenerLinea(int cantidad, decimal area, decimal perimetro)
        {
            throw new NotImplementedException();
        }
    }
}
