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
    /// Logique d'interaction pour ClasseSection.xaml
    /// </summary>
    public partial class ClasseSectionWindow : Window
    {
        public ClasseSectionWindow()
        {
            InitializeComponent();

            WireUpLists();
        }



        #region WireUpList

        /// <summary>
        /// Met à jour les données
        /// </summary>
        private void WireUpLists()
        {


            ObtientProfile();

        }

        #endregion



        #region Buttons


        private void AfficheDiagrammeButton_Click(object sender, RoutedEventArgs e)
        {


            if (ListBox_Profile.SelectedItem != null)
            {


                object profilé = ListBox_Profile.SelectedItem;

                var afficheProfilé = new Dictionary<object, Action>()
                    {

                        { typeof(ProfileIH), ()=> AfficheClasseSectionProfileIH()}


                    };

                if (afficheProfilé.TryGetValue(profilé.GetType(), out Action act))
                    act();

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



        #region Obtenir


        /// <summary>
        /// Permet de récupérer les profilés dans la base de données pour mettre à jour la liste
        /// </summary>
        private void ObtientProfile()
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
                    .Include(x => x.ClasseSectionCalcule.ContraintesElastiquesMax).ToList();






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

           
            StackPanelAileClasse1ou2.Visibility = Visibility.Collapsed;
            StackPanelAmeClasse1ou2.Visibility = Visibility.Collapsed;
            StackPanel_ClasseSection.Visibility = Visibility.Collapsed;
            StackPanel_ContraintesElastiques.Visibility = Visibility.Collapsed;
            StackPanelAileClasse3.Visibility = Visibility.Collapsed;
            StackPanelAmeClasse3.Visibility = Visibility.Collapsed;


            ProfileIH profile = ListBox_Profile.SelectedItem as ProfileIH;


            textBox_Resistance.Text = profile.NuanceAcierSelectionnee.NomNuance;
            textBox_TypeProfile.Text = profile.GeometrieIHSelectionnee.NomGeometrieIH;




            EffortsInternesDistanceX effortsmax = profile.DiagrammesEffortsInternesCalcule.ObtientEffortsInternesMax();


            textBox_EffortNormal.Text = Math.Round(effortsmax.EffortNormalNed, Element.ArrondiForce).ToString();
            textBox_MomentAxeY.Text = Math.Round(effortsmax.MomentMAxeYDistanceX, Element.ArrondiMoments).ToString();
            textBox_MomentAxeZ.Text = Math.Round(effortsmax.MomentMAxeZDistanceX, Element.ArrondiMoments).ToString();


        }



        #endregion



        #region Affichage Classe de section

        public void AfficheClasseSectionProfileIH()
        {

            ProfileIH profile = ListBox_Profile.SelectedItem as ProfileIH;
            


            ClasseSection classe2 = profile.ClasseSectionCalcule;



            if (classe2.ClasseSectionCalculee == 2)
            {



                StackPanelAileClasse1ou2.Visibility = Visibility.Visible;
                StackPanelAmeClasse1ou2.Visibility = Visibility.Visible;
                StackPanel_ClasseSection.Visibility = Visibility.Visible;


                #region Ame


                textBox_HauteurComprimeeAmeClasse12.Text = Math.Round(classe2.HauteurComprimeeAme, Element.ArrondiDimensionsmm).ToString();
                textBox_PartComprimeeAmeClasse12.Text = Math.Round(classe2.PartEffortPlastiqueAme, Element.ArrondiCoefficients).ToString();
                textBox_ElancementLimiteAmeClasse12.Text = Math.Round(classe2.ElancementLimiteAme, Element.ArrondiElancement).ToString();
                textBox_ElancementEffectifAmeClasse12.Text = Math.Round(classe2.ElancementEffectifAme, Element.ArrondiElancement).ToString();


                #endregion



                #region Aile


                textBox_LargeurComprimeeAileClasse12.Text = Math.Round(classe2.LargeurComprimeeAile, Element.ArrondiDimensionsmm).ToString();
                textBox_PartComprimeeAileClasse12.Text = Math.Round(classe2.PartEffortPlastiqueAile, Element.ArrondiCoefficients).ToString();
                textBox_ElancementLimiteAileClasse12.Text = Math.Round(classe2.ElancementLimiteAile, Element.ArrondiElancement).ToString();
                textBox_ElancementEffectifAileClasse12.Text = Math.Round(classe2.ElancementEffectifAile, Element.ArrondiElancement).ToString();


                #endregion



                #region Classe


                

                profile.ClasseSectionCalcule = classe2;

                using (var db = new AcierDbContext())
                {

                    ProfileIH profileToUpdate = db.ProfileIHs
                     .Where(p => p.IdElement == profile.IdElement).FirstOrDefault();

                    profileToUpdate.ClasseSectionCalcule = db.ClasseSections
                    .Where(c => c.IdClasseSection == profileToUpdate.ClasseSectionCalculeIdClasseSection).FirstOrDefault();



                    if (profileToUpdate != null)
                    {
                        db.Entry(profileToUpdate).CurrentValues.SetValues(profile);
                    }



                    db.SaveChanges();

                }


                #endregion


            }
            else if (classe2.ClasseSectionCalculee == 3)
            {


                if (classe2.ClasseSectionCalculee == 3)
                {

                    StackPanelAileClasse3.Visibility = Visibility.Visible;
                    StackPanelAmeClasse3.Visibility = Visibility.Visible;
                    StackPanel_ClasseSection.Visibility = Visibility.Visible;



                    #region Ame

                   

                    textBox_ContrainteSigmaXSupClasse3.Text = Math.Round(classe2.ContraintesElastiquesMax[0].ContrainteNormalSigmaX, Element.ArrondiContrainte).ToString();
                    textBox_ContrainteSigmaXInfClasse3.Text = Math.Round(classe2.ContraintesElastiquesMax[1].ContrainteNormalSigmaX, Element.ArrondiContrainte).ToString();
                    textBox_PsiAmeClasse3.Text = Math.Round(classe2.RapportContraintePsiAme, Element.ArrondiCoefficients).ToString();
                    textBox_ElancementLimiteAmeClasse3.Text = Math.Round(classe2.ElancementLimiteAme, Element.ArrondiElancement).ToString();
                    textBox_ElancementEffectifAmeClasse3.Text = Math.Round(classe2.ElancementEffectifAme, Element.ArrondiElancement).ToString();


                    #endregion



                    #region Aile


                    textBox_ContrainteSigmaXExtClasse3.Text = Math.Round(classe2.ContraintesElastiquesMax[2].ContrainteNormalSigmaX, Element.ArrondiContrainte).ToString();
                    textBox_ContrainteSigmaXIntClasse3.Text = Math.Round(classe2.ContraintesElastiquesMax[3].ContrainteNormalSigmaX, Element.ArrondiContrainte).ToString();
                    if (classe2.Valeurintermediairek1 == 0)
                    {
                        textBox_K1AileClasse3.Text = "-";
                    }
                    else
                    {

                        textBox_K1AileClasse3.Text = Math.Round(classe2.Valeurintermediairek1, Element.ArrondiCoefficients).ToString();

                    }
                    textBox_PsiAileClasse3.Text = Math.Round(classe2.RapportContraintePsiAile, Element.ArrondiCoefficients).ToString();
                    textBox_ElancementLimiteAileClasse3.Text = Math.Round(classe2.ElancementLimiteAile, Element.ArrondiElancement).ToString();
                    textBox_ElancementEffectifAileClasse3.Text = Math.Round(classe2.ElancementEffectifAile, Element.ArrondiElancement).ToString();


                    #endregion



                    #region Classe


                    





                    #endregion



                }
                


            }
            else if (classe2.ClasseSectionCalculee == 4)
            {
                StackPanelAileClasse3.Visibility = Visibility.Visible;
                StackPanelAmeClasse3.Visibility = Visibility.Visible;
                StackPanel_ClasseSection.Visibility = Visibility.Visible;



                #region Ame


                textBox_ContrainteSigmaXSupClasse3.Text = Math.Round(classe2.ContraintesElastiquesMax[0].ContrainteNormalSigmaX, Element.ArrondiContrainte).ToString();
                textBox_ContrainteSigmaXInfClasse3.Text = Math.Round(classe2.ContraintesElastiquesMax[1].ContrainteNormalSigmaX, Element.ArrondiContrainte).ToString();
                textBox_PsiAmeClasse3.Text = Math.Round(classe2.RapportContraintePsiAme, Element.ArrondiCoefficients).ToString();
                textBox_ElancementLimiteAmeClasse3.Text = Math.Round(classe2.ElancementLimiteAme, Element.ArrondiElancement).ToString();
                textBox_ElancementEffectifAmeClasse3.Text = Math.Round(classe2.ElancementEffectifAme, Element.ArrondiElancement).ToString();


                #endregion



                #region Aile


                textBox_ContrainteSigmaXExtClasse3.Text = Math.Round(classe2.ContraintesElastiquesMax[2].ContrainteNormalSigmaX, Element.ArrondiContrainte).ToString();
                textBox_ContrainteSigmaXIntClasse3.Text = Math.Round(classe2.ContraintesElastiquesMax[3].ContrainteNormalSigmaX, Element.ArrondiContrainte).ToString();
                if (classe2.Valeurintermediairek1 == 0)
                {
                    textBox_K1AileClasse3.Text = "-";
                }
                else
                {

                    textBox_K1AileClasse3.Text = Math.Round(classe2.Valeurintermediairek1, Element.ArrondiCoefficients).ToString();

                }
                textBox_PsiAileClasse3.Text = Math.Round(classe2.RapportContraintePsiAile, Element.ArrondiCoefficients).ToString();
                textBox_ElancementLimiteAileClasse3.Text = Math.Round(classe2.ElancementLimiteAile, Element.ArrondiElancement).ToString();
                textBox_ElancementEffectifAileClasse3.Text = Math.Round(classe2.ElancementEffectifAile, Element.ArrondiElancement).ToString();


                #endregion






                

                MessageBox.Show("Attention. Ce profilé n'est pas calculé dans cette application.");




            }

            else
            {

                MessageBox.Show("Erreur. Aucune classe de section calculée.");

            }
            #region Classe Section


            ClasseSection classe = profile.ClasseSectionCalcule;
            textBox_ClasseSectionCalculee.Text = $"Classe de section {classe.ClasseSectionCalculee}";

            if (classe.ClasseSectionCalculee == 2)
            {
                textBox_ClasseSectionCalculee.Text = $"Classe de section 1/{classe.ClasseSectionCalculee}";

            }



            #endregion

            ListBox_Profile.SelectedItem = null;



        }



        #endregion

    }

}
