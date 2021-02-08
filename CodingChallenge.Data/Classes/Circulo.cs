using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Circulo : FormaGeometrica<Circulo>, IFormaGeometrica 
    {
     
        //Lado = diametro

        public Circulo(decimal diametro):base(diametro)
        {

        }
        public decimal CalcularArea()
        {
            return (decimal)(Math.PI * Math.Pow((double)(this.Lado / 2),2));
        }

        public decimal CalcularPerimetro()
        {
            return (2 * (decimal)Math.PI * (this.Lado/2));
        }

        public string ObtenerLinea(int cantidad, decimal area, decimal perimetro)
        {
            string palabraSoP = cantidad > 1 ? Resources.Idioma.Circulos : Resources.Idioma.Circulo;
            return $"{cantidad} {palabraSoP} | {Resources.Idioma.Area} {area:#.##} | {Resources.Idioma.Perimetro} {perimetro:#.##} <br/>";
        }
    }
}
