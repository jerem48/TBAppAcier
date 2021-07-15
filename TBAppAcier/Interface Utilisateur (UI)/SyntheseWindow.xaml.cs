using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TBAppAcier.AccesDonnees;
using TBAppAcierLibrairieClasses.Modeles;

namespace TBAppAcier.Interface_Utilisateur__UI_
{
    /// <summary>
    /// Logique d'interaction pour SyntheseWindow.xaml
    /// </summary>
    public partial class SyntheseWindow : Window
    {
        public SyntheseWindow()
        {


            InitializeComponent();


            WireUpLists();


        }



        #region ListBox


        private void ListBox_Profile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (ListBox_Profile.SelectedItem != null)
            {

                object profilé = ListBox_Profile.SelectedItem;

                var afficheProfilé = new Dictionary<object, Action>()
                    {

                        { typeof(ProfileIH), ()=> ObtienProfileIHListBox()}


                    };

                if (afficheProfilé.TryGetValue(profilé.GetType(), out Action act))
                    act();



            }


        }


        #endregion



        #region Buttons


        private void AfficheSynthèse_Click(object sender, RoutedEventArgs e)
        {
            ProfileIH profile = ListBox_Profile.SelectedItem as ProfileIH;

            if (profile != null)
            {

                // TODO - Classe section 4 à éviter
                object profilé = ListBox_Profile.SelectedItem;

                var afficheProfilé = new Dictionary<object, Action>()
                    {

                        { typeof(ProfileIH), ()=> AfficheResultatProfileIH()}


                    };

                if (afficheProfilé.TryGetValue(profilé.GetType(), out Action act))
                    act();

                MessageBox.Show("Attention. Les valeurs affichées dans cette fenêtre représentent une synthèse des résultats.");

            }
            else
            {

                MessageBox.Show("Erreur. Veuillez sélectionner un profilé.");

            }



        }



        private void ShutDowmThis_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }



        #endregion



        #region Afficher résultats


        private void AfficheResultatProfileIH()
        {

            ProfileIH profile = ListBox_Profile.SelectedItem as ProfileIH;



            #region Efforts internes max

            EffortsInternesDistanceX effortmax = profile.DiagrammesEffortsInternesCalcule.ObtientEffortsInternesMax();

            textBox_EffortNormal.Text = Math.Round(effortmax.EffortNormalNed, Element.ArrondiForce).ToString();
            textBox_MomentFlexionnelAxeY.Text = Math.Round(effortmax.MomentMAxeYDistanceX, Element.ArrondiMoments).ToString();
            textBox_MomentFlexionnelAxeZ.Text = Math.Round(effortmax.MomentMAxeZDistanceX, Element.ArrondiMoments).ToString();
            textBox_EffortTranchantAxeZ.Text = Math.Round(effortmax.EffortTranchanVAxeZDistanceX, Element.ArrondiForce).ToString();
            textBox_EffortTranchantAxeY.Text = Math.Round(effortmax.EffortTranchanVAxeYDistanceX, Element.ArrondiForce).ToString();




            #endregion



            #region Classe Section


            ClasseSection classe = profile.ClasseSectionCalcule;

            textBox_ClasseSection.Text = $"Classe de section {classe.ClasseSectionCalculee}";

            if (classe.ClasseSectionCalculee == 2)
            {
                textBox_ClasseSection.Text = $"Classe de section 1/{classe.ClasseSectionCalculee}";

            }


            #endregion



            #region Flambage


            Flambage flambage = profile.FlambageCalcule;

            textBox_EffortNormalCritiqueY.Text = Math.Round(flambage.EffortNormalCritiqueAxeY, Element.ArrondiForce).ToString();
            textBox_EffortNormalCritiqueZ.Text = Math.Round(flambage.EffortNormalCritiqueAxeZ, Element.ArrondiForce).ToString();
            textBox_ResistanceFlambageY.Text = Math.Round(flambage.RésistanceFlambageAxeY, Element.ArrondiForce).ToString();
            textBox_ResistanceFlambageZ.Text = Math.Round(flambage.RésistanceFlambageAxeZ, Element.ArrondiForce).ToString();


            #endregion



            #region Effort tranchant et moments flexionnels


            EffortTranchant tranchant = profile.EffortTranchantCalcule;

            textBox_ResistanceTranchant.Text = Math.Round(tranchant.RésistanceCisaillementZ, Element.ArrondiForce).ToString();
            textBox_ResistanceVoilementCisaillement.Text = Math.Round(tranchant.RésistanceVoilementCisaillementZ, Element.ArrondiForce).ToString();



            MomentsFlexionnelResistant flexionnelResistant = profile.MomentsFlexionnelResistantCalcules;

            textBox_ResistanceMomentflexionnelY.Text = Math.Round(flexionnelResistant.MomentFlexionResistantY, Element.ArrondiMoments).ToString();
            textBox_ResistanceMomentflexionnelZ.Text = Math.Round(flexionnelResistant.MomentFlexionResistantZ, Element.ArrondiMoments).ToString();


            #endregion


            #region Moment de déversement


            CombinaisonCharges1D combinaison = profile.DiagrammesEffortsInternesCalcule.CombinaisonCharges1DSelectionnee;



            if (combinaison.EffortNormalNed == 0)
            {
                if (combinaison.ChargeRepartieUniformeqAxeZ == 0 || combinaison.ChargeConcentreMilieuTraveeQAxeZ == 0)
                {

                    MomentDeversementCTICM momentDeversementCTICM = profile.MomentDeversementCTICMCalcule;

                    MomentDeversementCTICM momentDeversementCTICMMin = profile.MomentDeversementCTICMCalculeMin;


                    textBox_LongueurDeversement.Text = Math.Round(momentDeversementCTICM.LongueurCritiqueDeversement, Element.ArrondiDimensionsm).ToString();
                    textBox_MomentDeversment.Text = Math.Round(momentDeversementCTICM.MomentResistantReduit, Element.ArrondiMoments).ToString();

                    textBox_LongueurDeversementMin.Text = Math.Round(momentDeversementCTICMMin.LongueurCritiqueDeversement, Element.ArrondiDimensionsm).ToString();
                    textBox_MomentDeversmentMin.Text = Math.Round(momentDeversementCTICMMin.MomentResistantReduit, Element.ArrondiMoments).ToString();





                }

            }
            else
            {

                if(combinaison.ChargeRepartieUniformeqAxeZ == 0 && combinaison.ChargeConcentreMilieuTraveeQAxeZ == 0)

                {

                    MomentDeversementSIA momentDeversementSIA = profile.MomentDeversementSIACalcule;

                    MomentDeversementSIA momentDeversementSIAMin = profile.MomentDeversementSIACalculeMin;


                    textBox_LongueurDeversement.Text = Math.Round(momentDeversementSIA.LongueurDeversementCritique, Element.ArrondiDimensionsm).ToString();
                    textBox_MomentDeversment.Text = Math.Round(momentDeversementSIA.MomentResistantReduit, Element.ArrondiMoments).ToString();

                    textBox_LongueurDeversementMin.Text = Math.Round(momentDeversementSIAMin.LongueurDeversementCritique, Element.ArrondiDimensionsm).ToString();
                    textBox_MomentDeversmentMin.Text = Math.Round(momentDeversementSIAMin.MomentResistantReduit, Element.ArrondiMoments).ToString();
                 




                }

            }


            #endregion



            #region Stabilité

            Stabilite stabilite = profile.StabiliteCalcule;

            textBox_Equationutilisee.Text = stabilite.EquationUtiliseeStabilite;
            textBox_ResultatChiffre.Text = Math.Round(stabilite.ResultatStabilite, Element.ArrondiResultats).ToString();
            textBox_Resultat.Text = stabilite.Resultat;



            #endregion


            #region Stabilité

            ResistanceSection resistance = profile.ResistanceSectionCalculee;

            textBox_EquationutiliseeResistanceSection.Text = resistance.EquationUtiliseeResistanceSection;
            textBox_ResultatChiffreResistanceSection.Text = Math.Round(resistance.ResultatResistanceSection, Element.ArrondiResultats).ToString();
            textBox_ResultatResistanceSection.Text = resistance.Resultat;



            #endregion


            #region Warning Moments déversement


            if (combinaison.EffortNormalNed != 0 && combinaison.ChargeRepartieUniformeqAxeZ != 0)
            {

                MessageBox.Show("Attention. Le moment de déversement ne peut être calculé. Un effort normal et une charge transversale sont présents. Une approximation est faite pour le résultats de l'équation de la stabilité.");

            }




            if (combinaison.EffortNormalNed != 0 && combinaison.ChargeConcentreMilieuTraveeQAxeZ != 0)
            {

                MessageBox.Show("Attention. Le moment de déversement ne peut être calculé. Un effort normal et une charge transversale sont présents. Une approximation est faite pour le résultats de l'équation de la stabilité.");

            }


            if (combinaison.ChargeRepartieUniformeqAxeZ != 0 && combinaison.ChargeConcentreMilieuTraveeQAxeZ != 0)
            {

                MessageBox.Show("Attention. Le moment de déversement ne peut être calculé. Deux types de charge transversale sont présents. Une approximation est faite pour le résultats de l'équation de la stabilité.");

            }

            if (profile.DiagrammesEffortsInternesCalcule.ObtientEffortsInternes().Any(x=> x.EffortTranchanVAxeYDistanceX!= 0))
            {

                MessageBox.Show("Attention. L'effort tranchant Vyed n'étant pas pris en compte dans l'application et qu'il est non-nul, une approximation est faite.");

            }

            #endregion

        }


        #endregion



        #region WireUpList et chargement de données

        /// <summary>
        /// Met à jour les listes de données sur la page
        /// </summary>
        private void WireUpLists()
        {


            ObientProfiles();




        }





        /// <summary>
        /// Obtient la liste des profilés
        /// </summary>
        private void ObientProfiles()
        {


            using (var db = new AcierDbContext())
            {
                ListBox_Profile.ItemsSource = null;

                var profile = db.ProfileIHs
                    .Include(x => x.NuanceAcierSelectionnee)
                    .Include(x => x.DiagrammesEffortsInternesCalcule)
                    .Include(x => x.DiagrammesEffortsInternesCalcule.CombinaisonCharges1DSelectionnee)
                    .Include(x => x.GeometrieIHSelectionnee)
                    .Include(x => x.ClasseSectionCalcule)
                    .Include(x => x.FlambageCalcule)
                    .Include(x => x.EffortTranchantCalcule)
                    .Include(x => x.MomentsFlexionnelResistantCalcules)
                    .Include(x => x.MomentDeversementCTICMCalcule)
                    .Include(x => x.MomentDeversementCTICMCalculeMin)
                    .Include(x => x.MomentDeversementSIACalcule)
                    .Include(x => x.MomentDeversementSIACalculeMin)
                    .Include(x => x.StabiliteCalcule)
                    .Include(x => x.ResistanceSectionCalculee)
                    .ToList();






                ListBox_Profile.ItemsSource = profile;
                ListBox_Profile.DisplayMemberPath = "NomEntier";
                db.SaveChanges();

            }





        }



        /// <summary>
        /// Permet de récupérer le profilé selectionné si c'est un I ou H
        /// </summary>
        private void ObtienProfileIHListBox()
        {




            ProfileIH profile = ListBox_Profile.SelectedItem as ProfileIH;


            textBox_Resistance.Text = profile.NuanceAcierSelectionnee.NomNuance;
            textBox_TypeProfile.Text = profile.GeometrieIHSelectionnee.NomGeometrieIH;
            textBox_Longueur.Text = profile.Longueur.ToString();



            CombinaisonCharges1D combi = profile.DiagrammesEffortsInternesCalcule.CombinaisonCharges1DSelectionnee;


            textBox_ChargeRpartieZ.Text = Math.Round(combi.ChargeRepartieUniformeqAxeZ, Element.ArrondiForce).ToString();
            textBox_ChargeConcentreeZ.Text = Math.Round(combi.ChargeConcentreMilieuTraveeQAxeZ, Element.ArrondiForce).ToString();
            textBox_ChargeRpartieY.Text = Math.Round(combi.ChargeRepartieUniformeqAxeY, Element.ArrondiForce).ToString();
            textBox_ChargeConcentreeY.Text = Math.Round(combi.ChargeConcentreMilieuTraveeQAxeY, Element.ArrondiForce).ToString();


        }








        #endregion



    }
}
