using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TBAppAcierLibrairieClasses.Modeles
{

    /// <summary>
    /// Classe regroupant les valeurs des moments flexionnels
    /// </summary>
    public class MomentsFlexionnelResistant
    {


        #region Informations générales

        /// <summary>
        /// Clé de la classe "Moments flexionnels"
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMomentsFlexionnelResistant { get; set; }


        #endregion


        #region Effort normal


        /// <summary>
        /// Effort normal résistant NRd
        /// Unit = [kN]
        /// </summary>
        public double EffortNormalResistant { get; set; }



        #endregion



        #region Résistance moment flexionnel


        /// <summary>
        /// Part d'effort tranchant Vzed/VzRd 
        /// Unit = [-]
        /// </summary>
        public double PartEffortTranchantZ { get; set; }



        /// <summary>
        /// Moment flexionnel résitant My,Rd
        /// Il dépend de la classe dans laquelle se trouve le profilé.
        /// Il ne prend pas compte la part d'effort tranchant Vz.
        /// Unit = [kNm]
        /// </summary>
        public double MomentFlexionResistantY { get; set; }



        /// <summary>
        /// Moment flexionnel résitant Mvy,Rd
        /// Il dépend de la classe dans laquelle se trouve le profilé.
        /// Il prend compte la part d'effort tranchant Vz.
        /// Unit = [kN]
        /// </summary>
        // public double MomentFlexionEtEffortTranchantY { get; set; }



        /// <summary>
        /// Moment flexionnel résitant Mz,Rd
        /// Celui-ci ne prend pas en compte l'effort tranchant Vy mais la classe est prise en compte
        /// Unit = [kNm]
        /// </summary>
        public double MomentFlexionResistantZ { get; set; }



        #endregion

    }
}
