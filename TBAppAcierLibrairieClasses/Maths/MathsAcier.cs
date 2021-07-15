using System;
using System.Collections.Generic;
using System.Text;

namespace TBAppAcierLibrairieClasses.Maths
{
    /// <summary>
    /// Permet d'effctuer des calculs mathématiques
    /// </summary>
    public class MathsAcier
    {

        public delegate double FonctionAIterer(double x);


        /// <summary>
        /// Solver permettant de calculer la valeur x répondant à fct(x) == 0
        /// </summary>
        /// <param name="val_b">Borne supérieur</param>
        /// <param name="tmax">Nombre d'itérations max</param>
        /// <param name="fonctionaiterer">Fonction dont on doit calculer le x</param>
        /// <returns></returns>
        public static double Bissection (double val_b, double tmax, FonctionAIterer fonctionaiterer)
        {
            double middle = 0;
            int i = 0;
            double val_a = 0;



            while (Math.Abs(val_b - val_a) > tmax)
            {
                middle = (val_a + val_b) / 2;



                if (fonctionaiterer(middle) > 0)
                {
                    val_b = middle;
                    i++;


                }
                else
                {
                    val_a = middle;
                    i++;

                }
                





            }
           
            
           
            return middle;
        }



    }
}
