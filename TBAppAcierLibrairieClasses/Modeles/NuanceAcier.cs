using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TBAppAcierLibrairieClasses.Modeles
{
    /// <summary>
    /// Classe de la résistance en acier
    /// </summary>
    public class NuanceAcier
    {

        /// <summary>
        /// Id de la résistance en acier
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNuance { get; set; }



        /// <summary>
        /// Nom de la résistance
        /// </summary>
        public string NomNuance { get; set; }



        /// <summary>
        /// Limite élastique fy 
        /// Unit = [N/mm2]
        /// </summary>
        public double LimiteElastique { get; set; }



        /// <summary>
        /// Limite élastique cisaillement τy 
        /// Unit = [N/mm2]
        /// </summary>
        public double LimiteElastiqueCisaillement { get; set; }



        /// <summary>
        /// Résistance à la traction fu
        /// Unit = [N/mm2]
        /// </summary>
        public double ResistanceTraction { get; set; }



        /// <summary>
        /// Facteur partiel pour les profilés en général
        /// Unit = [-]
        /// </summary>
        public const double FacteurPartielGammaM1 = 1.05;



        /// <summary>
        /// Facteur partiel pour les assemblages et certains cas pour la résistance en section
        /// Unit = [-]
        /// </summary>
        public const double FacteurPartielGammaM2 = 1.25;


        /// <summary>
        /// Module d'élasticité de l'acier
        /// Unit = [N/mm2]
        /// </summary>
        public const double ModuleElasticite = 210000;



        /// <summary>
        /// Module de glissement de l'acier
        /// Unit = [N/mm2]
        /// </summary>
        public const double ModuleGlissement = 80769;



        /// <summary>
        /// Coefficient de Poisson
        /// Unit = [-]
        /// </summary>
        public const double CoefficientPoisson = 0.3;



    }
}
