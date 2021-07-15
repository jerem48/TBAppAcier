using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TBAppAcierLibrairieClasses.Modeles
{
    /// <summary>
    /// Géométrie des profilés I et H
    /// </summary>
    public class GeometrieIH
    {


        #region Informations Générales

        /// <summary>
        /// Id de la géométrie I ou H
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdGeometrieIH { get; set; }



        /// <summary>
        /// Nom de la géométrie I ou H
        /// </summary>
        public string NomGeometrieIH { get; set; }




        #endregion


        #region Géométrie


        #region Aires


        /// <summary>
        /// Aire total A
        /// Unit = [mm2]
        /// </summary>
        public double AireTotal { get; set; }



        /// <summary>
        /// Aire de l'âme avec les congés Av
        /// Unit = [mm2]
        /// </summary>
        public double AireAmeAvecConge { get; set; }



        /// <summary>
        /// Aire de l'âme sans les congés Aw
        /// Unit = [mm2]
        /// </summary>
        public double AireAmeSansConge { get; set; }


        #endregion



        #region Axe y


        /// <summary>
        /// Moment d'inertie Iy 
        /// A multiplier par 10^6
        /// Unit = [mm4]
        /// </summary>
        public double MomentInertieAxeY { get; set; }



        /// <summary>
        /// Moment de flexion élastique Wely
        /// A multiplier par 10^3
        /// Unit = [mm3]
        /// </summary>
        public double ModuleFlexionElastiqueAxeY { get; set; }



        /// <summary>
        /// Moment de flexion moyen Wy moy
        /// A multiplier par 10^3
        /// Unit = [mm3]
        /// </summary>
        public double ModuleFlexionMoyenAxe { get; set; }



        /// <summary>
        /// Moment de flexion palstique Wply
        /// A multiplier par 10^3
        /// Unit = [mm3]
        /// </summary>
        public double ModuleFlexionPlastiqueAxeY { get; set; }



        /// <summary>
        /// Rayon de giration iy
        /// Unit = [mm]
        /// </summary>
        public double RayonGirationAxeY { get; set; }

        #endregion



        #region Axe z


        /// <summary>
        /// Moment d'inertie Iz 
        /// A multiplier par 10^6
        /// Unit = [mm4]
        /// </summary>
        public double MomentInertieAxeZ { get; set; }



        /// <summary>
        /// Moment de flexion élastique Welz
        /// A multiplier par 10^3
        /// Unit = [mm3]
        /// </summary>
        public double ModuleFlexionElastiqueAxeZ { get; set; }







        /// <summary>
        /// Moment de flexion palstique Wplz
        /// A multiplier par 10^3
        /// Unit = [mm3]
        /// </summary>
        public double ModuleFlexionPlastiqueAxeZ { get; set; }



        /// <summary>
        /// Rayon de giration iz
        /// Unit = [mm]
        /// </summary>
        public double RayonGirationAxeZ{ get; set; }

        #endregion



        #region Axe x


        /// <summary>
        /// Moment d'inertie Ix ou K 
        /// A multiplier par 10^6
        /// Unit = [mm4]
        /// </summary>
        public double MomentInertieAxeX { get; set; }



        #endregion



        #region Dimensions de la section


        /// <summary>
        /// Hauteur h
        /// Unit = [mm]
        /// </summary>
        public double Hauteur { get; set; }



        /// <summary>
        /// Largeur b
        /// Unit = [mm]
        /// </summary>
        public double Largeur { get; set; }



        /// <summary>
        /// Epaisseur de l'âme tw
        /// Unit = [mm]
        /// </summary>
        public double EpaisseurAme { get; set; }



        /// <summary>
        /// Epaisseur de l'aile tf
        /// Unit = [mm]
        /// </summary>
        public double EpaisseurAile { get; set; }



        /// <summary>
        /// Rayon de congé r
        /// Unit = [mm]
        /// </summary>
        public double RayonConge { get; set; }


        #endregion



        #region Dimensions constructives

        /// <summary>
        /// Hauteur de la portion droite de l'âme h1
        /// Unit = [mm]
        /// </summary>
        public double HauteurPortionDroiteAme { get; set; }


        /// <summary>
        /// Distance libre entre les ailes d'un profilé h2
        /// Unit = [mm]
        /// </summary>
        public double DistanceAilesProfile { get; set; }

        #endregion



        #endregion

    }
}
