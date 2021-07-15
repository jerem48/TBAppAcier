using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TBAppAcierLibrairieClasses.Modeles
{

    /// <summary>
    /// Element, classe abstraite servant de base au autres classes comme Element1D
    /// </summary>
    public abstract class Element
    {

        /// <summary>
        /// Id de l'élément
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdElement { get; set; }



        /// <summary>
        /// Nom général de l'élément
        /// </summary>
        public string NomElement { get; set; }



        /// <summary>
        /// Nom personnalisé de l'élément
        /// </summary>
        public string NomPersonnalise { get; set; }


        /// <summary>
        /// Nom entier de l'élément
        /// </summary>
        public virtual string NomEntier
        {
            get
            {

                return $"{NomElement} : {NomPersonnalise}";

            }

            protected set { }
        }



        /// <summary>
        /// Clé étrangère de la résistance en Acier
        /// </summary>
        public int? NuanceAcierSelectionneeIdNuance { get; set; }



        /// <summary>
        /// Resistance d'acier séléctionnée de l'élément
        /// </summary>
        [ForeignKey("NuanceAcierSelectionneeIdNuance")]
        public virtual NuanceAcier NuanceAcierSelectionnee { get; set; }



        #region Constantes arrondi


        /// <summary>
        /// Arrondi des contraintes [N/mm2]
        /// </summary>
        public const int ArrondiContrainte = 0;




        /// <summary>
        /// Arrondi des forces [kN]
        /// </summary>
        public const int ArrondiForce = 1;




        /// <summary>
        /// Arrondi des moments [kNm]
        /// </summary>
        public const int ArrondiMoments = 1;




        /// <summary>
        /// Arrondi des coefficients [-]
        /// </summary>
        public const int ArrondiCoefficients = 3;


        /// <summary>
        /// Arrondi des résultats [-]
        /// </summary>
        public const int ArrondiResultats = 2;



        /// <summary>
        /// Arrondi des dimensions [mm]
        /// </summary>
        public const int ArrondiDimensionsmm = 0;




        /// <summary>
        /// Arrondi des dimensions [m]
        /// </summary>
        public const int ArrondiDimensionsm = 1;



        /// <summary>
        /// Arrondi des élancements [m]
        /// </summary>
        public const int ArrondiElancement = 1;

        #endregion



    }
}
