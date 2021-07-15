using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TBAppAcierLibrairieClasses.Modeles
{
    /// <summary>
    /// Représente les moments de déversement calculé selon la CTICM
    /// </summary>
    public class MomentDeversementCTICM
    {


        #region Information générales


        /// <summary>
        /// Clé de la classe "moment de déversement selon la CTICM"
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMomentDeversementCTICM { get; set; }




        #endregion



        #region caractéristique générales


        /// <summary>
        /// Longueur  critique de déversement Lcr
        /// Unit = [m]
        /// </summary>
        public double LongueurCritiqueDeversement { get; set; }



        /// <summary>
        /// Moment à l'extrêmité gauche de la barrre Mo
        /// Unit = [kNm]
        /// </summary>
        public double MomentExtremiteO { get; set; }


        /// <summary>
        /// Moment à l'extrêmité droite de la barrre Me
        /// Unit = [kNm]
        /// </summary>
        public double MomentExtremiteE { get; set; }


        #endregion



        #region Coefficient C1 et C2


        /// <summary>
        /// Rapport entre les moments des extrêmités de la barre ψ
        /// Unit = [-]
        /// </summary>
        public double RapportMomentsExtremitePsi { get; set; }



        /// <summary>
        /// Rapport entre le moment isostatique dû à la charge et au moment d'extrêmité max μ
        /// Unit = [-]
        /// </summary>
        public double RapportMomentIsoMomentExtremiteMu { get; set; }



        /// <summary>
        /// Coefficient tenant compte de la charge (concentrée ou répartie) C1
        /// Unit = [-]
        /// </summary>
        public double CoefficientChargeC1 { get; set; }



        /// <summary>
        /// Coefficient tenant compte de la position de la charge (concentrée ou répartie) C2
        /// Unit = [-]
        /// </summary>
        public double CoefficientPositionChargeC2 { get; set; }




        #endregion



        #region Calcul moment de déversement


        /// <summary>
        /// Moment critique de déversement Mcr
        /// Unit = [kNm]
        /// </summary>
        public double MomentCritiqueDeversement { get; set; }



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
