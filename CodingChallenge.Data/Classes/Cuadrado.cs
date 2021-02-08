using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Cuadrado :  FormaGeometrica<Cuadrado>, IFormaGeometrica 
    {
        #region Constructor
        public Cuadrado(decimal lado) : base(lado)
        {

        }
        #endregion

        public decimal CalcularArea()
        {
            return this.Lado * this.Lado;
        }

        public decimal CalcularAreaTotal(List<IFormaGeometrica> formas)
        {
            if (formas != null)
            {
                return formas.Sum((figura) => figura.CalcularArea());
            }
            return 0m;
        }

        public decimal CalcularPerimetro()
        {
            return this.Lado * 4; 
        }

        public string ObtenerLinea(int cantidad, decimal area, decimal perimetro)
        {
            string palabra = cantidad > 1 ? Resources.Idioma.Cuadrados : Resources.Idioma.Cuadrado;
            return $"{cantidad} {palabra} | {Resources.Idioma.Area} {area:#.##} | {Resources.Idioma.Perimetro} {perimetro:#.##} <br/>";
        }
    }
}
