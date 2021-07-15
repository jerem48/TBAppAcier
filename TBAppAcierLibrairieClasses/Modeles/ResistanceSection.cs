using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TBAppAcierLibrairieClasses.Modeles
{
    public class ResistanceSection
    {



        /// <summary>
        /// Clé de la classe "Stabilite"
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdResistanceSection { get; set; }




        /// <summary>
        /// Donne le résultat de l'équation de stabilité chiffré
        /// Unit = [-]
        /// </summary>
        public double ResultatResistanceSection { get; set; }




        /// <summary>
        /// Donne le nom de l'équation utilisée pour la vérification à la stabilité
        /// </summary>
        public string EquationUtiliseeResistanceSection { get; set; }



        /// <summary>
        /// Clé étrangère de la classe "Efforts determinants pour la resistance en section" 
        /// </summary>
        public int? EffortsDeterminantsResistanceSectionId { get; set; }



        /// <summary>
        /// Efforts internes déterminants pour le calcul de la résistance en section
        /// Unit = [-]
        /// </summary>
        [ForeignKey("EffortsDeterminantsResistanceSectionId")]
        public EffortsInternesDistanceX EffortsDeterminantsResistanceSection { get; set; }


        /// <summary>
        /// Clé étrangère de la classe "Contraintes determinantes pour la resistance en section" 
        /// </summary>
        public int? ContraintesDeterminantesId { get; set; }



        /// <summary>
        /// Contraintes pour le calcul de la résistance en section
        /// </summary>
        [ForeignKey("ContraintesDeterminantesId")]
        public ContraintesElastiques1PointYZ ContraintesDeterminantes { get; set; }




        /// <summary>
        /// Résultat équation sous forme de text
        /// </summary>
        public string Resultat { get; set; }


    }
}
