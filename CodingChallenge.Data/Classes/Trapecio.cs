using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Trapecio : FormaGeometrica<Trapecio>, IFormaGeometrica
    {
        #region Constructor
        public Trapecio(decimal baseMayor, decimal baseMenor, decimal ladoA, decimal ladoB):base(new decimal[] { baseMayor,baseMenor,ladoA,ladoB})
        {
        }
        #endregion

        #region Metodos Públicos
        public decimal CalcularArea()
        {
            return ((this.Lados[0] + this.Lados[1] ) * this.Altura) / 2;
        }

        public decimal CalcularPerimetro()
        {
            return this.Lados.Sum();
        }
        public decimal CalcularAltura()
        {
            //Por pitagoras
            var baseT = this.Lados[0] - this.Lados[1];
            return (decimal)(Math.Sqrt((double)this.Lados[2]) - Math.Sqrt((double)baseT)); 
        }
        public string ObtenerLinea(int cantidad, decimal area, decimal perimetro)
        {
            string palabraSoP = cantidad > 1 ? Resources.Idioma.Trapecios + "s" : Resources.Idioma.Trapecio;
            return $"{cantidad} {palabraSoP} | {Resources.Idioma.Area} {area:#.##} | {Resources.Idioma.Perimetro} {perimetro:#.##} <br/>";
        }
        #endregion

        #region Métodos Protegidos
        public override string ObtenerNombre()
        {
            return Resources.Idioma.FormaGeometrica + " " + this.GetType().Name;
        }
        #endregion
    }
}
