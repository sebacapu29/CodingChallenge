using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Carrito
    {

        #region Atributos Privados
        private static List<IFormaGeometrica> _listaFormasGeometricas;
        #endregion

        #region Propiedades Publicas
        public static List<IFormaGeometrica> ListaFormasGeometricas { get { return Carrito._listaFormasGeometricas; } }

        #endregion

        #region Constructor
      
        public Carrito(List<IFormaGeometrica> formas)
        {
            Carrito._listaFormasGeometricas = formas;
        }
        #endregion
        public static bool operator +(Carrito carrito, object nuevoCuadrado)
        {
            try
            {
                Carrito.ListaFormasGeometricas.Add((IFormaGeometrica)nuevoCuadrado);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
