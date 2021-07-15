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
    /// Logique d'interaction pour ResistanceBaseWindow.xaml
    /// </summary>
    public partial class ResistanceBaseWindow : Window
    {
        public ResistanceBaseWindow()
        {

            InitializeComponent();

            WireUpLists();

        }


        #region Buttons


        private void AfficheResistancesBaseButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileIH profile = ListBox_Profile.SelectedItem as ProfileIH;

            if (profile != null)
            {
                ResistanceSection resistance = profile.ResistanceSectionCalculee;

                EffortsInternesDistanceX effortsDeter = resistance.EffortsDeterminantsResistanceSection;

                CombinaisonCharges1D combi = profile.DiagrammesEffortsInternesCalcule.CombinaisonCharges1DSelectionnee;


                #region Classe Section


                ClasseSection classe = profile.ClasseSectionCalcule;
                textBox_ClasseSection.Text = $"Classe de section {classe.ClasseSectionCalculee}";

                if (classe.ClasseSectionCalculee == 2)
                {
                    textBox_ClasseSection.Text = $"Classe de section 1/{classe.ClasseSectionCalculee}";

                }



                #endregion


                if (profile.ClasseSectionCalcule.ClasseSectionCalculee != 4)
                {



                    EffortTranchant effortTranchant = profile.EffortTranchantCalcule;


                    #region Effort tranchant


                    textBox_ResistanceCisaillemtZ.Text = Math.Round(effortTranchant.RésistanceCisaillementZ, Element.ArrondiForce).ToString();
                    textBox_CoefficientVoilementCisaillementZ.Text = Math.Round(effortTranchant.CoefficientVoilementCisaillementZ, Element.ArrondiCoefficients).ToString();
                    textBox_ContrainteCritiqueCisaillement.Text = Math.Round(effortTranchant.ContrainteCritiqueCisaillementZ, Element.ArrondiContrainte).ToString();
                    textBox_ResistanceVoilementCisaillementZ.Text = Math.Round(effortTranchant.RésistanceVoilementCisaillementZ, Element.ArrondiForce).ToString();
                    textBox_ResistanceMinCisaillementZ.Text = Math.Round(effortTranchant.RésistanceCisaillementMinZ, Element.ArrondiForce).ToString();



                    #endregion

                    MomentsFlexionnelResistant moments = profile.MomentsFlexionnelResistantCalcules;

                    #region Moments flexionnels


                    textBox_PartEffortTranchantZ.Text = Math.Round(moments.PartEffortTranchantZ, Element.ArrondiCoefficients).ToString();
                    textBox_MomentResistantY.Text = Math.Round(moments.MomentFlexionResistantY, Element.ArrondiMoments).ToString();
                    textBox_MomentResistantZ.Text = Math.Round(moments.MomentFlexionResistantZ, Element.ArrondiMoments).ToString();


                    #endregion


                    #region Effort normal


                    textBox_EffortNormalResistant.Text = Math.Round(moments.EffortNormalResistant, Element.ArrondiForce).ToString();


                    #endregion


                    if (effortsDeter.EffortTranchanVAxeYDistanceX != 0)
                    {

                        MessageBox.Show("Attention. L'effort tranchant Vyed n'étant pas pris en compte dans l'application et qu'il est non-nul, une approximation est faite.");

                    }

                    grid_ContraintesElastiques.Visibility = Visibility.Collapsed;
                    textBlock_ContraintesElastiques.Visibility = Visibility.Collapsed;

                    #region Résistance en section



                    #region Efforts internes déterminants





                    textBox_DistanceX.Text = Math.Round(effortsDeter.DistanceX, Element.ArrondiDimensionsm).ToString();
                    textBox_EffortNormalDeterminant.Text = Math.Round(effortsDeter.EffortNormalNed, Element.ArrondiForce).ToString();
                    textBox_MomentAxeYDeterminant.Text = Math.Round(effortsDeter.MomentMAxeYDistanceX, Element.ArrondiMoments).ToString();
                    textBox_MomentAxeZDeterminant.Text = Math.Round(effortsDeter.MomentMAxeZDistanceX, Element.ArrondiMoments).ToString();
                    textBox_EffortTranchantZDeterminant.Text = Math.Round(effortsDeter.EffortTranchanVAxeZDistanceX, Element.ArrondiForce).ToString();


                    #endregion



                    #region Contraintes si besoin


                    ContraintesElastiques1PointYZ contraintesDeter = resistance.ContraintesDeterminantes;


                    if (contraintesDeter != null)
                    {


                        grid_ContraintesElastiques.Visibility = Visibility.Visible;
                        textBlock_ContraintesElastiques.Visibility = Visibility.Visible;


                        textBox_SigmaX.Text = Math.Round(contraintesDeter.ContrainteNormalSigmaX, Element.ArrondiContrainte).ToString();
                        textBox_TauZX.Text = Math.Round(contraintesDeter.ContrainteTangentielleTauZX, Element.ArrondiContrainte).ToString();
                        textBox_SigmaComparaison.Text = Math.Round(contraintesDeter.ContrainteComparaisonVonMises, Element.ArrondiContrainte).ToString();



                    }

                    #endregion






                    #region Résultats


                    textBox_EquationutiliseeResistanceSection.Text = resistance.EquationUtiliseeResistanceSection;
                    textBox_ResultatChiffreResistanceSection.Text = Math.Round(resistance.ResultatResistanceSection, Element.ArrondiResultats).ToString();

                    textBox_ResultatResistanceSection.Text = resistance.Resultat;

                    #endregion


                    #endregion


                }
                else
                { 

                    MessageBox.Show("Erreur. La classe de section 4 n'est pas calculée dans ce programme.");

                }


                MessageBox.Show("Attention. Les valeurs affichées dans cette fenêtre représentent une partie des résultats.");

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



        #region WirUpLists  et chargement des données
       
        
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








        }



        #endregion



    }
}
