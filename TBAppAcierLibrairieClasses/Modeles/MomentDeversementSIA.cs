using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TBAppAcierLibrairieClasses.Modeles
{
    /// <summary>
    ///  Représente le moment de déversement et valeurs intermédiaires calculés selon la SIA 263
    /// </summary>
    public class MomentDeversementSIA
    {



        /// <summary>
        /// Clé de la classe
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMomentDeversementSIA { get; set; }


        #region Valeurs de base


        /// <summary>
        /// Longueur de déversement critique
        /// Unit = [m]
        /// </summary>
        public double LongueurDeversementCritique { get; set; }



        /// <summary>
        /// Moment à l'extrêmité O de la barre
        /// Unit = [kNm]
        /// </summary>
        public double MomentExtremiteO { get; set; }



        /// <summary>
        /// Moment à l'extrêmité E de la barre
        /// Unit = [kNm]
        /// </summary>
        public double MomentExtremiteE { get; set; }




        #endregion



        #region Coefficient C1 ou η

        /// <summary>
        /// Rapport entre les moments des extrêmités de la barre ψ
        /// Unit = [-]
        /// </summary>
        public double RapportMomentsExtremitePsi { get; set; }





        /// <summary>
        /// Coefficient tenant en compte des moments linéaires sur la barre η.
        /// Il est calculé à partir de la CTICM avec μ = 0.
        /// Unit = [-]
        /// </summary>
        public double CoefficientMomentEta { get; set; }


        #endregion



        #region Calcul du Mcr selon SIA


        /// <summary>
        /// Rayon de giration de la membrure comprimée iD
        /// Unit = [mm]
        /// </summary>
        public double RayonGirationMembrureComprimée { get; set; }



        /// <summary>
        /// Contrainte de torsion uniforme σDv
        /// Unit = [N/mm2]
        /// </summary>
        public double ContrainteTorsionUniforme { get; set; }



        /// <summary>
        /// Contrainte de torsion non-uniforme σDw
        /// Unit = [N/mm2]
        /// </summary>
        public double ContrainteTorsionNonUniforme { get; set; }



        /// <summary>
        /// Contrainte critique de déversement σcrD
        /// Unit = [N/mm2]
        /// </summary>
        public double ContrainteCritiqueDeversement { get; set; }



        /// <summary>
        /// Moment critique de déversement Mcr
        /// Unit = [kNm]
        /// </summary>
        public double MomentCritiqueDeversement { get; set; }


        #endregion


        #region Calcul MDRd






        /// <summary>
        /// Elancement réduit λD
        /// Unit = [-]
        /// </summary>
        public double ElancementReduitDeversement { get; set; }



        /// <summary>
        /// Facteur de réduction χD pour le déversement
        /// Unit = [-]
        /// </summary>
        public double FacteurReductionDeversementChi { get; set; }



        /// <summary>
        /// Moment résistant réduit dû au déversement MDRd
        /// Unit = [kNm]
        /// </summary>
        public double MomentResistantReduit { get; set; }




        #endregion


    }
}
