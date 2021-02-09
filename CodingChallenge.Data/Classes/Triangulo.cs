using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Triangulo : FormaGeometrica<Triangulo> , IFormaGeometrica
    {
        //[0] base , [1] lado , [2] lado

        #region Atributos privados
        private TipoTriangulo _tipo;
        #endregion

        #region Propiedades Publicas
        public TipoTriangulo Tipo { get { return this._tipo; } }
        #endregion

        #region Constructor
        public Triangulo(TipoTriangulo tipo, decimal lado) : base(lado)
        {
            this._tipo = tipo;
        }
        public Triangulo(TipoTriangulo tipo)
        {
            this._tipo = tipo;
        }
        /// <summary>
        /// Especifica los 3 lados en caso de ser Triangulo Escaleno
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="lados"></param>
        public Triangulo(TipoTriangulo tipo, decimal[] lados) : base(lados)
        {
            this._tipo = tipo;
        }
        #endregion
      
        #region Metodos privados para Calculo de Area
        /// <summary>
        /// Calcula la formula del triangulo Equilatero, verificando si existe la altura, en caso que sea 0 la calcula y luego utiliza la formlula tradicional base x altura / 2
        /// </summary>
        /// <returns></returns>
        private decimal CalcularAreaEquilatero() 
        {
            if (this.Altura == 0)
            {
                var b = this.Lado;
                var h = ((decimal)Math.Sqrt(3) * b) / 2;
                return (b * h)/2;
            }
            return this.CalcularAreaBaseAltura();
        }
        /// <summary>
        /// En caso de no conocer el Area (h) se calcula con su lado base (b) y el lado (a) - Formula : h = razi(b^2 - a^2/4)
        /// Luego el area se calcula con la formula : (b x h) / 2
        /// </summary>
        /// <returns></returns>
        private decimal CalcularAreaIsoceles()
        {
            if (this.Altura == 0)
            {
                var b = this.Lados[0];
                var a = this.Lados[1];
                var h = Math.Round((decimal)Math.Sqrt( (Math.Pow(Convert.ToDouble(b),2)) - Math.Pow(Convert.ToDouble(a), 2)/4));
                
                return ((decimal) (b * h) /2);
            }
            return (decimal)this.Lados[0] * this.Altura / 2;
        }

        /// <summary>
        /// Obtiene el calculo del Area de un triangulo Escaleno, Se debe conocer los 3 lados para calcular el area del triangulo
        /// Notacion semiperimetro (sp), y (a,b,c) son lados
        /// </summary>
        /// <returns></returns>
        private decimal CalcularAreaEscaleno()
        {
            var sp = this.Lados.Sum() / 2;
            var a = this.Lados[0];
            var b = this.Lados[1];
            var c = this.Lados[2];

            return ((decimal)Math.Sqrt((double)(sp * (sp - a) * (sp - b) * (sp - c))));
        }
        /// <summary>
        /// Calcula el Area con la formula de base (b) * altura (h) / 2 conociendo ambos valores
        /// </summary>
        /// <returns></returns>
        private decimal CalcularAreaBaseAltura()
        {
            var b = this.Lado;
            return (b * this.Altura) / 2;
        }
        #endregion

        #region Metodos Públicos
        /// <summary>
        /// Calcula el Area de un Triangulo, en caso de necesitar algun dato previo, lo calcula y luego lo usa en la formula final
        /// </summary>
        /// <returns></returns>
        public decimal CalcularArea()
        {
            switch (this._tipo)
            {
                case TipoTriangulo.Equilatero:
                    return this.CalcularAreaEquilatero();
                case TipoTriangulo.Isoceles:
                    return this.CalcularAreaIsoceles();
                case TipoTriangulo.Escaleno:
                    return this.CalcularAreaEscaleno();
                case TipoTriangulo.Rectangulo:
                    return this.CalcularAreaBaseAltura();
                default:
                    return this.CalcularAreaBaseAltura();
            }
        }
        public decimal CalcularPerimetro()
        {
            if (this.Tipo == TipoTriangulo.Equilatero)
            {
                return this.Lado * 3;
            }
            else
            {
                return this.Lados.Sum();
            }
        }

        public string ObtenerLinea(int cantidad, decimal area, decimal perimetro)
        {
            string palabraSoP = cantidad > 1 ? Resources.Idioma.Triangulos : Resources.Idioma.Triangulo;
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
    public enum TipoTriangulo
    {
        Equilatero=0,
        Isoceles=1,
        Escaleno=2,
        Rectangulo=3
    }
}
