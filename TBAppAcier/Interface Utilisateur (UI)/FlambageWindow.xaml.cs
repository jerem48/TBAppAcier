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
    /// Logique d'interaction pour Flambage.xaml
    /// </summary>
    public partial class FlambageWindow : Window
    {
        public FlambageWindow()
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


        private void AfficheFlambageButton_Click(object sender, RoutedEventArgs e)
        {



            ProfileIH profile = ListBox_Profile.SelectedItem as ProfileIH;
            if (profile != null)
            {

                if (profile.ClasseSectionCalcule.ClasseSectionCalculee != 4)
                {

                    profile.FlambageCalcule = profile.ObtenirFlambage();


                    Flambage flambage = profile.FlambageCalcule;


                    #region général


                    textBox_ElancementLimiteElastique.Text = Math.Round(flambage.ElancementLimiteelastique, Element.ArrondiElancement).ToString();



                    #endregion



                    #region Axe y

                    textBox_CoefficientLongueurFlambageY.Text = Math.Round(profile.CoefficientFlambageAxeY * profile.Longueur, Element.ArrondiDimensionsm).ToString();
                    textBox_ContrainteCritiqueY.Text = Math.Round(flambage.ContrainteCritiqueAxeY, Element.ArrondiContrainte).ToString();
                    textBox_EffortNormalCritiqueY.Text = Math.Round(flambage.EffortNormalCritiqueAxeY, Element.ArrondiForce).ToString();
                    textBox_CoeffcientelastiqueY.Text = Math.Round(flambage.CoefficientElancementY, 2).ToString();
                    textBox_FacteurReductionY.Text = Math.Round(flambage.FacteurReductionFlambageChikAxeY, Element.ArrondiCoefficients).ToString();
                    textBox_ResistanceFlambageY.Text = Math.Round(flambage.RésistanceFlambageAxeY, Element.ArrondiForce).ToString();

                    #endregion



                    #region Axe z

                    textBox_CoefficientLongueurFlambageZ.Text = Math.Round(profile.CoefficientFlambageAxeZ * profile.Longueur, Element.ArrondiDimensionsm).ToString();
                    textBox_ContrainteCritiqueZ.Text = Math.Round(flambage.ContrainteCritiqueAxeZ, Element.ArrondiContrainte).ToString();
                    textBox_EffortNormalCritiqueZ.Text = Math.Round(flambage.EffortNormalCritiqueAxeZ, Element.ArrondiForce).ToString();
                    textBox_CoeffcientelastiqueZ.Text = Math.Round(flambage.CoefficientElancementZ, 2).ToString();
                    textBox_FacteurReductionZ.Text = Math.Round(flambage.FacteurReductionFlambageChikAxeZ, Element.ArrondiCoefficients).ToString();
                    textBox_ResistanceFlambageZ.Text = Math.Round(flambage.RésistanceFlambageAxeZ, Element.ArrondiForce).ToString();

                    #endregion


                }
                else
                {
                                  

                    MessageBox.Show("Erreur. La classe de section 4 n'est pas calculée dans ce programme.");


                }

                MessageBox.Show("Attention. Les valeurs affichées dans cette fenêtre sont des résultats intermédiaires.");

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



        #region WireUp et chargement des données


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


            textBox_EffortNormal.Text = Math.Round(effortsmax.EffortNormalNed, Element.ArrondiForce).ToString();


        }









        #endregion



    }
}
