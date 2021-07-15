using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TBAppAcierLibrairieClasses.Modeles
{
    /// <summary>
    /// Element Adjacents utilisé pour le calcul de la longueur de flambage
    /// </summary>
    public class ElementAdjacent
    {

        #region Informations générales


        /// <summary>
        /// Id de l'élément adjacent
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdElementAdjacent { get; set; }


        #endregion


        #region Caractéristiques techniques


        /// <summary>
        /// Moment d'inertie d'axe concerné
        /// Unit =[mm4]
        /// </summary>
        public double MomentInertie { get; set; }



        /// <summary>
        /// Module d'élasticité 
        /// Unit =[N/mm2]
        /// </summary>
        public double ModuleElasticite { get; set; }



        /// <summary>
        /// Longueur 
        /// Unit =[m]
        /// </summary>
        public double Longueur { get; set; }



        #endregion

    }
}
