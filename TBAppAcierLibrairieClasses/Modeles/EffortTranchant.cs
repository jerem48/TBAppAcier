using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TBAppAcierLibrairieClasses.Modeles
{

    /// <summary>
    /// Classe regroupant les informations concernant la résistance à l'effort tranchant et au voilement
    /// Seul l'axe z est considéré!
    /// Des warning sont à mettre pour ne pas prendre en compte Vy
    /// </summary>
    public class EffortTranchant
    {


        #region Informations générales


        /// <summary>
        /// Clé de la classe effort tranchant
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEffortTranchant { get; set; }


        #endregion



        #region Résistance au cisaillement


        /// <summary>
        /// Résistance au cisaillement, axe z VRd
        /// Unit = [kN]
        /// </summary>
        public double RésistanceCisaillementZ { get; set; }


        #endregion



        #region Voilement par effort tranchant


        /// <summary>
        /// Coefficient de voilement, axe z kt
        /// Unit = [-]
        /// </summary>
        public double CoefficientVoilementCisaillementZ { get; set; }



        /// <summary>
        /// Contrainte critique de cisaillement, axe z τcr
        /// Unit = [N/mm2]
        /// </summary>
        public double ContrainteCritiqueCisaillementZ { get; set; }



        /// <summary>
        /// Résistance au Voilement, axe z VRd
        /// Unit = [N/mm2]
        /// </summary>
        public double RésistanceVoilementCisaillementZ { get; set; }



        /// <summary>
        /// Résistance minimum, axe z VRd min
        /// Unit = [kN]
        /// </summary>
        public double RésistanceCisaillementMinZ { get; set; }



        #endregion



    }
}
