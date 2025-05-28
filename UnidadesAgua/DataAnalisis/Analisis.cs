using System.Text;
using UnidadesAgua.DataAccess;
using UnidadesAgua.Models;

namespace UnidadesAgua.DataAnalisis
{
    public class Analisis
    {
        public int AnalizaTerreno(AlturaTerreno terreno)
        {
            DATerreno dA = new DATerreno();

            //Inicializamos las variables
            int unidadesAgua = 0;
            int posMuroIzquierdo = 0;
            int muroIzquierdo = 0;

            int posMuroDerecho = 0;
            int muroDerecho = 0;
            int muroActual = terreno.Altura;

            //Obtenemos los valores de los muros izquierdo y derecho
            posMuroIzquierdo = (terreno.Posicion - 1) <= 0 ? 0 : terreno.Posicion - 1;
            posMuroDerecho = (terreno.Posicion + 1);// >= posiciones ? 0 : i + 1;

            if(posMuroIzquierdo == 0)
            {
                return unidadesAgua;
            }

            muroIzquierdo = dA.ConsultaTerreno(posMuroIzquierdo).Altura;
            muroDerecho = dA.ConsultaTerreno(posMuroDerecho).Altura;


            if (muroActual < muroDerecho && muroActual < muroIzquierdo)
            {
                if (muroDerecho >= muroIzquierdo)
                {
                    unidadesAgua= (muroIzquierdo - muroActual);
                    
                }
                else
                {
                    unidadesAgua = (muroDerecho - muroActual);
                    
                }
            }
            
            return unidadesAgua;

        }

        public void EjecutaAnalisis()
        { 
            StringBuilder str = new StringBuilder();
            int[] altura = [0,1,0,2,1,0,1,3,2,1,2,1];
            int posMuroIzquierdo = 0;
            int muroIzquierdo = 0;
            
            int posMuroDerecho = 0;
            int muroDerecho = 0;
            int muroActual = 0;

            int posiciones = altura.Length;

            for (int i = 0; i < posiciones; i++)
            {
                //posMuroIzquierdo = i - 1;
                //if (posMuroIzquierdo <= 0)
                //{ posMuroIzquierdo = 0; } 
                posMuroIzquierdo = (i - 1) <= 0 ? 0: i - 1;
                posMuroDerecho = (i + 1) >= posiciones ? 0 :i+1;

                if (posMuroIzquierdo == 0)
                    {
                        str.AppendLine($"Posicion {i} - Agua acumulada 0");
                        continue;
                    }
                if (posMuroDerecho== posiciones)
                {
                    str.AppendLine($"Posicion {i} - Agua acumulada 0");
                    continue;
                }
                muroDerecho = int.Parse(altura[posMuroDerecho].ToString());
                muroIzquierdo = int.Parse(altura[posMuroIzquierdo].ToString());
                muroActual= int.Parse(altura[i].ToString());
                if (muroActual < muroDerecho && muroActual < muroIzquierdo)
                {
                    if (muroDerecho >= muroIzquierdo)
                    {
                        str.AppendLine($"Posicion {i} - Agua acumulada {muroIzquierdo - muroActual}");
                        continue;
                    }
                    else
                    {
                        str.AppendLine($"Posicion {i} - Agua acumulada {muroDerecho - muroActual}");
                        continue;
                    }
                }
                else
                {
                     str.AppendLine($"Posicion {i} - Agua acumulada 0");
                }

                //if (altura[i] > muroizquierdo)
                //{
                //    muroizquierdo = altura[i];
                //    posMuroIzquierdo = i;
                //}
                //if (altura[posiciones - 1 - i] > MuroDerecho)
                //{
                //    MuroDerecho = altura[posiciones - 1 - i];
                //    posMuroDerecho = posiciones - 1 - i;
                //}
            }

        }
    }
}
