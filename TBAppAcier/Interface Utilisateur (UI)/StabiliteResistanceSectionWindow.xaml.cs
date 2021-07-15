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
    /// Logique d'interaction pour StabiliteResistanceSectionWindow.xaml
    /// </summary>
    public partial class StabiliteResistanceSectionWindow : Window
    {
        public StabiliteResistanceSectionWindow()
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


        private void AfficheResistancesAndStabilite_Click(object sender, RoutedEventArgs e)
        {

            if (ListBox_Profile.SelectedItem != null)
            {

                object profilé = ListBox_Profile.SelectedItem;

                var afficheProfilé = new Dictionary<object, Action>()
                    {

                        { typeof(ProfileIH), ()=> AfficheResistanceAndStabilite()}


                    };

                if (afficheProfilé.TryGetValue(profilé.GetType(), out Action act))
                    act();

                MessageBox.Show("Attention. Les valeurs affichées dans cette fenêtre représentent une partie des résultats.");


            }
            else
            {

                MessageBox.Show("Erreur. Veuillez sélectionner un profilé.");

            }


        }






        private void AfficheResistanceAndStabilite()
        {

            ProfileIH profile = ListBox_Profile.SelectedItem as ProfileIH;
            ResistanceSection resistance = profile.ResistanceSectionCalculee;

            EffortsInternesDistanceX effortsDeter = resistance.EffortsDeterminantsResistanceSection;

            CombinaisonCharges1D combi = profile.DiagrammesEffortsInternesCalcule.CombinaisonCharges1DSelectionnee;

            if (profile.ClasseSectionCalcule.ClasseSectionCalculee == 4)
            {

                MessageBox.Show("Erreur. La classe de section 4 n'est pas calculée dans ce programme.");

            }
            else
            {
                if (effortsDeter.EffortTranchanVAxeYDistanceX != 0)
                {

                    MessageBox.Show("Attention. L'effort tranchant Vyed n'étant pas pris en compte dans l'application et qu'il est non-nul, une approximation est faite.");

                }



                #region Stabilité


                Stabilite stabilite = profile.StabiliteCalcule;

                textBox_OmegaY.Text = Math.Round(stabilite.OmegaY, Element.ArrondiCoefficients).ToString();
                textBox_OmegaZ.Text = Math.Round(stabilite.OmegaZ, Element.ArrondiCoefficients).ToString();


                textBox_EquationutiliseeStabilite.Text = stabilite.EquationUtiliseeStabilite;
                textBox_ResultatChiffreStabilite.Text = Math.Round(stabilite.ResultatStabilite, Element.ArrondiResultats).ToString();

                textBox_ResultatStabilite.Text = stabilite.Resultat;

                #endregion



                





                #region Warning Moments déversement


                if (combi.EffortNormalNed != 0 && combi.ChargeRepartieUniformeqAxeZ != 0)
                {

                    MessageBox.Show("Attention. Le moment de déversement ne peut être calculé. Un effort normal et une charge transversale sont présents. Une approximation est faite pour le résultats de l'équation de la stabilité.");

                }




                if (combi.EffortNormalNed != 0 && combi.ChargeConcentreMilieuTraveeQAxeZ != 0)
                {

                    MessageBox.Show("Attention. Le moment de déversement ne peut être calculé. Un effort normal et une charge transversale sont présents. Une approximation est faite pour le résultats de l'équation de la stabilité.");

                }


                if (combi.ChargeRepartieUniformeqAxeZ != 0 && combi.ChargeConcentreMilieuTraveeQAxeZ != 0)
                {

                    MessageBox.Show("Attention. Le moment de déversement ne peut être calculé. Deux types de charge transversale sont présents. Une approximation est faite pour le résultats de l'équation de la stabilité.");

                }

                #endregion











            }




        }



        private void ShutDowmThis_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        #endregion



        #region Charger Données & WireUpLists


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
                    .Include(x => x.EffortTranchantCalcule)
                    .Include(x => x.MomentsFlexionnelResistantCalcules)
                    .Include(x => x.MomentDeversementCTICMCalcule)
                    .Include(x => x.MomentDeversementCTICMCalculeMin)
                    .Include(x => x.StabiliteCalcule)
                    .Include(x => x.ResistanceSectionCalculee)
                    .Include(x => x.ResistanceSectionCalculee.EffortsDeterminantsResistanceSection)
                    .Include(x => x.ResistanceSectionCalculee.ContraintesDeterminantes)
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




            EffortsInternesDistanceX effortsmax = profile.DiagrammesEffortsInternesCalcule.ObtientEffortsInternesMax();

            textBox_EffortNormalMax.Text = Math.Round(effortsmax.EffortNormalNed, Element.ArrondiForce).ToString();
            textBox_MomentFlexionnelYMax.Text = Math.Round(effortsmax.MomentMAxeYDistanceX, Element.ArrondiMoments).ToString();
            textBox_MomentFlexionnelZMax.Text = Math.Round(effortsmax.MomentMAxeZDistanceX, Element.ArrondiMoments).ToString();
            textBox_EffortTranchantZMax.Text = Math.Round(effortsmax.EffortTranchanVAxeZDistanceX, Element.ArrondiForce).ToString();


        }






        #endregion


    }
}
