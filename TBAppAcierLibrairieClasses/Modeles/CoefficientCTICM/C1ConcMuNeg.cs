using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TBAppAcierLibrairieClasses.Modeles.CoefficientsCTICM
{
    /// <summary>
    /// Tableau regroupant les valeurs du coefficients C1 selon μ négatif pour une charge concentrée
    /// 
    /// </summary>
    public class C1ConcMuNeg
    {


        #region Informations générales


        /// <summary>
        /// clé de la classe
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdC1ConcMuNeg { get; set; }



        /// <summary>
        /// Valeur de μ négatif
        /// Unit = [-]
        /// </summary>
        public double MuNeg { get; set; }



        #endregion



        #region Colonne Psi


        #region négatif


        /// <summary>
        /// Valeur de ψ = -1.0
        /// Unit = [-]
        /// </summary>
        public double Psi00 { get; set; }



        /// <summary>
        /// Valeur de ψ = -0.9
        /// Unit = [-]
        /// </summary>
        public double Psi01 { get; set; }



        /// <summary>
        /// Valeur de ψ = -0.8
        /// Unit = [-]
        /// </summary>
        public double Psi02 { get; set; }



        /// <summary>
        /// Valeur de ψ = -0.7
        /// Unit = [-]
        /// </summary>
        public double Psi03 { get; set; }



        /// <summary>
        /// Valeur de ψ = -0.6
        /// Unit = [-]
        /// </summary>
        public double Psi04 { get; set; }



        /// <summary>
        /// Valeur de ψ = -0.5
        /// Unit = [-]
        /// </summary>
        public double Psi05 { get; set; }



        /// <summary>
        /// Valeur de ψ = -0.4
        /// Unit = [-]
        /// </summary>
        public double Psi06 { get; set; }



        /// <summary>
        /// Valeur de ψ = -0.3
        /// Unit = [-]
        /// </summary>
        public double Psi07 { get; set; }



        /// <summary>
        /// Valeur de ψ = -0.2
        /// Unit = [-]
        /// </summary>
        public double Psi08 { get; set; }



        /// <summary>
        /// Valeur de ψ = -0.1
        /// Unit = [-]
        /// </summary>
        public double Psi09 { get; set; }



        /// <summary>
        /// Valeur de ψ = 0.0
        /// Unit = [-]
        /// </summary>
        public double Psi10 { get; set; }

        #endregion



        #region Positif


        /// <summary>
        /// Valeur de ψ = 0.1
        /// Unit = [-]
        /// </summary>
        public double Psi11 { get; set; }



        /// <summary>
        /// Valeur de ψ = 0.2
        /// Unit = [-]
        /// </summary>
        public double Psi12 { get; set; }



        /// <summary>
        /// Valeur de ψ = 0.3
        /// Unit = [-]
        /// </summary>
        public double Psi13 { get; set; }



        /// <summary>
        /// Valeur de ψ = 0.4
        /// Unit = [-]
        /// </summary>
        public double Psi14 { get; set; }



        /// <summary>
        /// Valeur de ψ = 0.5
        /// Unit = [-]
        /// </summary>
        public double Psi15 { get; set; }



        /// <summary>
        /// Valeur de ψ = 0.6
        /// Unit = [-]
        /// </summary>
        public double Psi16 { get; set; }



        /// <summary>
        /// Valeur de ψ = 0.7
        /// Unit = [-]
        /// </summary>
        public double Psi17 { get; set; }



        /// <summary>
        /// Valeur de ψ = 0.8
        /// Unit = [-]
        /// </summary>
        public double Psi18 { get; set; }



        /// <summary>
        /// Valeur de ψ = 0.9
        /// Unit = [-]
        /// </summary>
        public double Psi19 { get; set; }



        /// <summary>
        /// Valeur de ψ = 1.0
        /// Unit = [-]
        /// </summary>
        public double Psi20 { get; set; }

        #endregion


        #endregion



    }
}
