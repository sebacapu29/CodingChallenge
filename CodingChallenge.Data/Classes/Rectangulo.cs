using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Rectangulo : FormaGeometrica<Rectangulo>, IFormaGeometrica
    {
        public Rectangulo(decimal ladoBase ,decimal ladoAltura):base(new decimal[] { ladoBase,ladoAltura})
        {

        }
        public decimal CalcularArea()
        {
            return this.Lados[0] * this.Lados[1]; //Base * Altura
        }

        public decimal CalcularPerimetro()
        {
            return this.Lados.Sum();
        }

        public string ObtenerLinea(int cantidad, decimal area, decimal perimetro)
        {
            string palabraSoP = cantidad > 1 ? Resources.Idioma.Rectangulo+"s" : Resources.Idioma.Rectangulo;
            return $"{cantidad} {palabraSoP} | {Resources.Idioma.Area} {area:#.##} | {Resources.Idioma.Perimetro} {perimetro:#.##} <br/>";
        }
    }
}
