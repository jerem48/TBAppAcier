using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TBAppAcierLibrairieClasses.Modeles
{
    /// <summary>
    /// Contraintes élastiques calculées à une section
    /// </summary>
    public class ContraintesElastiques1PointYZ
    {


        #region Informations Générales


        /// <summary>
        /// Id des contraintes élastiques
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int IdContraintesElastiques { get; set; }

      
        #endregion



        #region Coordonnées


        /// <summary>
        /// Coordonnée Y du point calculé
        /// Unit =[mm]
        /// </summary>
        public double CoordonnéeY { get; set; }



        /// <summary>
        /// Coordonnée Z du point calculé
        /// Unit =[mm]
        /// </summary>
        public double CoordonnéeZ { get; set; }


        #endregion



        #region Contraintes

        /// <summary>
        /// Contrainte normal σx 
        /// Unit = [N/mm2]
        /// </summary>
        public double ContrainteNormalSigmaX { get; set; }



        /// <summary>
        /// Contrainte tangentielle τzx
        /// Unit = [N/mm2]
        /// </summary>
        public double ContrainteTangentielleTauZX { get; set; }



        /// <summary>
        /// Contrainte de comparaison de von Mises
        /// Unit = [N/mm2]
        /// </summary>
        public double ContrainteComparaisonVonMises { get; set; }


        #endregion



    }
}
