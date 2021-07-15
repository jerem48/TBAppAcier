using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TBAppAcierLibrairieClasses.Modeles
{
    /// <summary>
    /// Contient les informations pour la vérifications à la stabilité
    /// Ces valeurs se calculent selon la méthode SIA
    /// </summary>
    public class Stabilite
    {


        /// <summary>
        /// Clé de la classe "Stabilite"
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdStabilite { get; set; }




        /// <summary>
        /// Donne le résultat de l'équation de stabilité
        /// Unit = [-]
        /// </summary>
        public double ResultatStabilite { get; set; }




        /// <summary>
        /// Donne le nom de l'équation utilisée pour la vérification à la stabilité
        /// </summary>
        public string EquationUtiliseeStabilite { get; set; }



        /// <summary>
        /// Valeur intermédiaire ωy
        /// Unit = [-]
        /// </summary>
        public double OmegaY { get; set; }



        /// <summary>
        /// Valeur intermédiaire ωz
        /// Unit = [-]
        /// </summary>
        public double OmegaZ { get; set; }



        /// <summary>
        /// Résultat équation sous forme de text
        /// </summary>
        public string Resultat { get; set; }


    }
}
