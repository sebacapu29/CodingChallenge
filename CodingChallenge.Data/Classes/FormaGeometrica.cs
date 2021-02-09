/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public abstract class FormaGeometrica<T>
    {

        #region Atributos Privados
        private decimal[] _lados;
        private decimal _lado;
        private decimal _altura;

        #endregion

        #region Propiedades publicas
        public decimal Lado { get { return this._lado; } }
        public decimal[] Lados { get { return this._lados; } }
        public decimal Altura
        {
            get { return this._altura; }
            set
            {
                if (value.GetType() == typeof(decimal))
                {
                    this._altura = value;
                }
            }
        }
        #endregion

        #region Constructores
        public FormaGeometrica()
        {

        }
        public FormaGeometrica(decimal lado)
        {
            this._lado = lado;
        }
        public FormaGeometrica(decimal[] lados)
        {
            this._lados = lados;
        }
        #endregion

        /// <summary>
        /// Obtiene un string con formato html correspondiente a la informacion de las formas geometricas, altura, area, perimetro y cantidad de formas
        /// </summary>
        /// <param name="formas">Listado de objetos que implementan formas geometricas</param>
        /// <returns></returns>
        public static string Imprimir(List<T> formas)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append("<h1>"+Resources.Idioma.ListaVacia+"!"+ "</h1>");
            }
            else
            {
               sb.Append("<h1>"+Resources.Idioma.TituloReporte + "</h1>");
               
               //Variables auxiliares para el informe, sumatoria del Area total y sumatoria total de todos los Perimetros calculados
               var cantidadTotalFiguras = formas.Count;
               var areaTotal = formas.Sum((f) => { return ((IFormaGeometrica)f).CalcularArea(); });
               var perimetroTotal = formas.Sum((f) => { return ((IFormaGeometrica)f).CalcularPerimetro(); });
                         
               //Agrupo los objetos en la lista para luego distinguir cada unos en las siguientes operaciones
               var groupingQuery =
                      from forma in formas
                      group forma by forma.GetType().Name into newGroup
                      select newGroup;

                int cantidadFigura = 0;
                decimal areaTotalFigura = 0m;
                decimal perimetroTotalFigura = 0m;

                //De la query anterior, recorro el agrupado por entidad para obtener la sumatoria de su respectiva entidad
                //Ejemplo: en la primer iteracion recorrere los Cuadrados, asi obtengo la sumatoria de su Area y Perimetro

                groupingQuery.ToList().ForEach((groupForma) => {
                    foreach (var forma in groupForma)
                    {
                        areaTotalFigura += ((IFormaGeometrica)forma).CalcularArea();
                        perimetroTotalFigura += ((IFormaGeometrica)forma).CalcularPerimetro();
                        cantidadFigura++;
                    }
                    //Obtengo la linea por entidad
                    sb.Append(((IFormaGeometrica)groupForma.FirstOrDefault())?.ObtenerLinea(cantidadFigura, areaTotalFigura,perimetroTotalFigura));
                    
                    areaTotalFigura = 0m;
                    perimetroTotalFigura = 0m;
                    cantidadFigura = 0;
                });               

                // FOOTER
                sb.Append(@"TOTAL:<br/>");

                sb.Append(cantidadTotalFiguras + " " + Resources.Idioma.Figuras + " ");
                sb.Append(Resources.Idioma.Perimetro + " " +(perimetroTotal).ToString("#.##") + " ");
                sb.Append(Resources.Idioma.Area+ " " +(areaTotal).ToString("#.##"));
            }

            return sb.ToString();
        }

    }
}
