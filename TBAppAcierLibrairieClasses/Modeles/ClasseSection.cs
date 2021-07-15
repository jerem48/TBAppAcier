using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TBAppAcierLibrairieClasses.Modeles
{
    /// <summary>
    /// Regroupe les informations concernant le calcul de la classe de section
    /// </summary>
    public class ClasseSection
    {


        #region Informations générales


        /// <summary>
        /// Id de la classe de section
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdClasseSection { get; set; }


        #endregion



        #region Classes de section


        /// <summary>
        /// Classe de section 
        /// </summary>
        public int ClasseSectionCalculee { get; set; }



        



        #endregion



        #region Résultats intermédiaires

        /// <summary>
        /// Clé étrangère de la classe de section pour les profilés I ou H
        /// </summary>
        public int ContraintesElastiquesMaxIdContraintesElastiques { get; set; }

        


        /// <summary>
        /// Classe de section calculée
        /// </summary>
        [ForeignKey("ClasseSectionCalculeIdClasseSection")]

        /// <summary>
        /// Contraintes élastiques obtenues avec les efforts maximaux
        /// </summary>
        public List<ContraintesElastiques1PointYZ> ContraintesElastiquesMax { get; set; }





        /// <summary>
        /// Rapport ψ des contraintes σx de l'âme
        /// Unit = [-]
        /// </summary>
        public double RapportContraintePsiAme { get; set; }



        /// <summary>
        /// Rapport ψ des contraintes σx de l'aile
        /// Unit = [-]
        /// </summary>
        public double RapportContraintePsiAile { get; set; }



        /// <summary>
        /// Valeur intermédiaire k1 pour l'aile
        /// Unit = [-]
        /// </summary>
        public double Valeurintermediairek1 { get; set; }



        /// <summary>
        /// Hauteur comprimée de l'âme
        /// Unit = [mm]
        /// </summary>
        public double HauteurComprimeeAme { get; set; }



        /// <summary>
        /// Part des effort plastique α de l'âme
        /// Unit = [-]
        /// </summary>
        public double PartEffortPlastiqueAme { get; set; }



        /// <summary>
        /// Largeur comprimée de l'aile
        /// Unit = [mm]
        /// </summary>
        public double LargeurComprimeeAile { get; set; }




        /// <summary>
        /// Part des effort plastique α de l'aile
        /// Unit = [-]
        /// </summary>
        public double PartEffortPlastiqueAile { get; set; }



        /// <summary>
        /// Elancement effectif de l'âme
        /// Unit = [-]
        /// </summary>
        public double ElancementEffectifAme { get; set; }



        /// <summary>
        /// Elancement effectif de l'aile
        /// Unit = [-]
        /// </summary>
        public double ElancementEffectifAile { get; set; }



        /// <summary>
        /// Elancement Limite de l'âme
        /// Unit = [-]
        /// </summary>
        public double ElancementLimiteAme { get; set; }



        /// <summary>
        /// Elancement Limite de l'aile
        /// Unit = [-]
        /// </summary>
        public double ElancementLimiteAile { get; set; }


        #endregion



    }


}
