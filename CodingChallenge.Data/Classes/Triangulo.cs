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
        
        private TipoTriangulo _tipo;

        public TipoTriangulo Tipo { get { return this._tipo; } }
       
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
        /// <summary>
        /// Calcula el Area de un Triangulo, en caso de necesitar algun dato previo, lo calcula y luego lo usa en la formula final
        /// </summary>
        /// <returns></returns>
        public decimal CalcularArea()
        {
            switch (this._tipo)
            {
                case TipoTriangulo.Equilatero:
                    if (this.Altura == 0)
                    {
                        this.Altura = Math.Round(((decimal)Math.Sqrt(3) * this.Lado / 2),2);
                        return ((decimal)Math.Sqrt(3) / 4) * (this.Altura * this.Altura);
                    }
                    return ((decimal)Math.Sqrt(3) / 4) * (this.Altura * this.Altura);
                case TipoTriangulo.Isoceles:
                    return ((decimal)Math.Sqrt((double)((this.Altura * this.Altura) - (this.Altura * this.Altura / 4))) / 2);
                case TipoTriangulo.Escaleno:
                    var semiperimetro = this.Lados.Sum();
                    return ((decimal)Math.Sqrt((double)(semiperimetro * (semiperimetro - this.Altura) * (semiperimetro - this.Lado) * (semiperimetro - this.Lados[2]))));
                case TipoTriangulo.Rectangulo:
                    return (this.Lado * this.Altura) / 2;
                default:
                    return (this.Lado * this.Altura) / 2;
            }
        }

        public decimal CalcularPerimetro()
        {
            if(this.Tipo == TipoTriangulo.Equilatero)
            {
                if (this.Altura > 0)
                {
                    return this.Altura * 3;
                }
                else
                {
                    return this.Lado * 3;
                }
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

    }
    public enum TipoTriangulo
    {
        Equilatero=0,
        Isoceles=1,
        Escaleno=2,
        Rectangulo=3
    }
}
