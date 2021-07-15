using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TBAppAcierLibrairieClasses.Modeles
{
    /// <summary>
    /// Classe regroupant les informations liées au flambage
    /// </summary>
    public class Flambage
    {


        #region Informations générales


        /// <summary>
        /// Id de la classe "Flambage"
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFlambage { get; set; }



        /// <summary>
        /// Elancement limite élastique, valable pour les deux axe λE
        /// Unit = [-]
        /// </summary>
        public double ElancementLimiteelastique { get; set; }


        #endregion



        #region Flambage Axe Y



             
        
        /// <summary>
        /// Contrainte critique de l'axe y σcr,y
        /// Unit = [N/mm2]
        /// </summary>
        public double ContrainteCritiqueAxeY { get; set; }



        /// <summary>
        /// Effort normal critique critique de l'axe y Ncr,y
        /// Unit = [kN]
        /// </summary>
        public double EffortNormalCritiqueAxeY { get; set; }



        /// <summary>
        /// Coefficient d'élancement y  λkymoy
        /// Unit = [-]
        /// </summary>
        public double CoefficientElancementY { get; set; }



        /// <summary>
        /// Facteur de réduction pour le flambage χ
        /// Unit = [-]
        /// </summary>
        public double FacteurReductionFlambageChikAxeY { get; set; }



        /// <summary>
        /// Résistance au flambage Nk,z,Rd
        /// Unit = [kN]
        /// </summary>
        public double RésistanceFlambageAxeY { get; set; }


        #endregion



        #region Axe Z





        /// <summary>
        /// Contrainte critique de l'axe Z σcr,z
        /// Unit = [N/mm2]
        /// </summary>
        public double ContrainteCritiqueAxeZ { get; set; }



        /// <summary>
        /// Effort normal critique critique de l'axe z Ncr,z
        /// Unit = [kN]
        /// </summary>
        public double EffortNormalCritiqueAxeZ { get; set; }



        /// <summary>
        /// Coefficient d'élancement z  λkzmoy
        /// Unit = [-]
        /// </summary>
        public double CoefficientElancementZ { get; set; }



        /// <summary>
        /// Facteur de réduction pour le flambage χ
        /// Unit = [-]
        /// </summary>
        public double FacteurReductionFlambageChikAxeZ { get; set; }



        /// <summary>
        /// Résistance au flambage Nk,z,Rd
        /// Unit = [kN]
        /// </summary>
        public double RésistanceFlambageAxeZ { get; set; }


        #endregion


    }
}
