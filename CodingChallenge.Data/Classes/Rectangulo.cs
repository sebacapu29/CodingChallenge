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
        #region Constructor

        /// <summary>
        /// A partir de los lados A y B se instancia un array con esos valores
        /// </summary>
        /// <param name="ladoBase"></param>
        /// <param name="ladoAltura"></param>
        public Rectangulo(decimal ladoBase ,decimal ladoAltura):base(new decimal[] { ladoBase,ladoAltura})
        {

        }
        #endregion

        #region Metodos Públicos
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
            string palabraSoP = cantidad > 1 ? Resources.Idioma.Rectangulos : Resources.Idioma.Rectangulo;
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
