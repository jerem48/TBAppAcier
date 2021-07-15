using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Logique d'interaction pour MomentDeversement.xaml
    /// </summary>
    public partial class MomentDeversement : Window
    {
        public MomentDeversement()
        {
            InitializeComponent();

            WireUpLists();


        }


        #region Buttons



        private void AfficheMomentDeversement_Click(object sender, RoutedEventArgs e)
        {

            ProfileIH profile = ListBox_Profile.SelectedItem as ProfileIH;

            if (profile != null)
            {

                // TODO - Classe section 4 à éviter
                object profilé = ListBox_Profile.SelectedItem;

                var afficheProfilé = new Dictionary<object, Action>()
                    {

                        { typeof(ProfileIH), ()=> AfficheMomentDeversementGeneralProfileIH()}


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
                    .Include(x => x.EffortTranchantCalcule)
                    .Include(x => x.MomentsFlexionnelResistantCalcules)
                    .Include(x => x.MomentDeversementCTICMCalcule)
                    .Include(x => x.MomentDeversementCTICMCalculeMin)
                    .Include(x => x.MomentDeversementSIACalcule)
                    .Include(x => x.MomentDeversementSIACalculeMin)
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


            textBox_MomentFlexionnelY.Text = Math.Round(effortsmax.MomentMAxeYDistanceX, Element.ArrondiMoments).ToString();


        }


        #endregion



        #region Afficher résultats déversement



        private void AfficheMomentDeversementGeneralProfileIH()
        {


            ProfileIH profile = ListBox_Profile.SelectedItem as ProfileIH;


            if (profile.ClasseSectionCalcule.ClasseSectionCalculee == 4)
            {

                MessageBox.Show("Erreur. La classe de section 4 n'est pas calculée dans ce programme.");

            }
            else 
            {

                EffortsInternesDistanceX efforts = profile.DiagrammesEffortsInternesCalcule.ObtientEffortsInternesMax();
                CombinaisonCharges1D combi = profile.DiagrammesEffortsInternesCalcule.CombinaisonCharges1DSelectionnee;

                if (combi.EffortNormalNed == 0)
                {


                    if (combi.ChargeRepartieUniformeqAxeZ != 0 && combi.ChargeConcentreMilieuTraveeQAxeZ != 0)
                    {

                        MessageBox.Show("Erreur. Une charge répartie et une charge concentrée ne peuvent être appliquées en même temps sur l'élément.");

                    }
                    else
                    {

                        AfficheMomentDeversementCTICMProfileIHAnalytique();

                    }


                }
                
                else
                {
                    if (efforts.MomentMAxeYDistanceX !=0 && combi.ChargeRepartieUniformeqAxeZ == 0 && combi.ChargeConcentreMilieuTraveeQAxeZ == 0)
                    {

                        AfficheMomentDeversementSIAProfileIH();
                        MessageBox.Show("Attention. Le positionnement de la charge n'est pas pris en compte dans le calcul du moment critique selon la SIA 263.");



                    }
                    else if (efforts.MomentMAxeYDistanceX == 0 && combi.ChargeRepartieUniformeqAxeZ == 0 && combi.ChargeConcentreMilieuTraveeQAxeZ == 0)
                    {

                        MessageBox.Show("Erreur. Aucun moment Myed est appliqué, seul un effort normal Ned est appliqué. Le moment de déversement n'est pas calculé.");


                    }
                    else
                    {
                     
                        MessageBox.Show("Erreur. Un effort normal important et une charge transversale ne peuvent être appliquées en même temps.");
                    
                    }
                }



            }





        }









        /// <summary>
        /// Affiche les moments de déversment réel et min selon la CTICM
        /// </summary>
        private void AfficheMomentDeversementCTICMProfileIHAnalytique()
        {


            ProfileIH profile = ListBox_Profile.SelectedItem as ProfileIH;

            stackPanel_CTICMMin.Visibility = Visibility.Visible;
            stackPanel_CTICMReal.Visibility = Visibility.Visible;


            #region Moment de déversement réel min


            MomentDeversementCTICM deversementCTICMReel = profile.MomentDeversementCTICMCalcule;


            textBox_LongueurCritiqueDeversement.Text = Math.Round(deversementCTICMReel.LongueurCritiqueDeversement, Element.ArrondiDimensionsm).ToString();
            textBox_MomentExtremiteO.Text = Math.Round(deversementCTICMReel.MomentExtremiteO, Element.ArrondiMoments).ToString();
            textBox_MomentExtremiteE.Text = Math.Round(deversementCTICMReel.MomentExtremiteE, Element.ArrondiMoments).ToString();



            textBox_RapportMomentExtremite.Text = Math.Round(deversementCTICMReel.RapportMomentsExtremitePsi, Element.ArrondiCoefficients).ToString();
            textBox_RapportMomentIsoMomentExtremiteMax.Text = Math.Round(deversementCTICMReel.RapportMomentIsoMomentExtremiteMu, Element.ArrondiCoefficients).ToString();
            textBox_CoefficientTypeChargeC1.Text = Math.Round(deversementCTICMReel.CoefficientChargeC1, Element.ArrondiCoefficients).ToString();
            textBox_CoefficientPositionnementChargeC2.Text = Math.Round(deversementCTICMReel.CoefficientPositionChargeC2, Element.ArrondiCoefficients).ToString();



            textBox_MomentCritiqueDeversement.Text = Math.Round(deversementCTICMReel.MomentCritiqueDeversement / Math.Pow(10, 6), Element.ArrondiMoments).ToString();
            textBox_ElancementReduit.Text = Math.Round(deversementCTICMReel.ElancementReduitDeversement, Element.ArrondiElancement).ToString();
            textBox_FacteurReduction.Text = Math.Round(deversementCTICMReel.FacteurReductionDeversementChi, Element.ArrondiCoefficients).ToString();
            textBox_MomentDeversement.Text = Math.Round(deversementCTICMReel.MomentResistantReduit, Element.ArrondiMoments).ToString();



            #endregion



            #region Moment de déversement réel min


            MomentDeversementCTICM deversementCTICMMin = profile.MomentDeversementCTICMCalculeMin;


            textBox_LongueurCritiqueDeversementMin.Text = Math.Round(deversementCTICMMin.LongueurCritiqueDeversement, Element.ArrondiDimensionsm).ToString();
            textBox_MomentExtremiteOMin.Text = Math.Round(deversementCTICMMin.MomentExtremiteO, Element.ArrondiMoments).ToString();
            textBox_MomentExtremiteEMin.Text = Math.Round(deversementCTICMMin.MomentExtremiteE, Element.ArrondiMoments).ToString();



            textBox_RapportMomentExtremiteMin.Text = Math.Round(deversementCTICMMin.RapportMomentsExtremitePsi, Element.ArrondiCoefficients).ToString();
            textBox_RapportMomentIsoMomentExtremiteMaxMin.Text = Math.Round(deversementCTICMMin.RapportMomentIsoMomentExtremiteMu, Element.ArrondiCoefficients).ToString();
            textBox_CoefficientTypeChargeC1Min.Text = Math.Round(deversementCTICMMin.CoefficientChargeC1, Element.ArrondiCoefficients).ToString();
            textBox_CoefficientPositionnementChargeC2Min.Text = Math.Round(deversementCTICMMin.CoefficientPositionChargeC2, Element.ArrondiCoefficients).ToString();



            textBox_MomentCritiqueDeversementMin.Text = Math.Round(deversementCTICMMin.MomentCritiqueDeversement / Math.Pow(10, 6), Element.ArrondiMoments).ToString();
            textBox_ElancementReduitMin.Text = Math.Round(deversementCTICMMin.ElancementReduitDeversement, Element.ArrondiElancement).ToString();
            textBox_FacteurReductionMin.Text = Math.Round(deversementCTICMMin.FacteurReductionDeversementChi, Element.ArrondiCoefficients).ToString();
            textBox_MomentDeversementMin.Text = Math.Round(deversementCTICMMin.MomentResistantReduit, Element.ArrondiMoments).ToString();



            #endregion




        }




        /// <summary>
        /// Affiche les moments de déversment réel et min selon la CTICM
        /// </summary>
        private void AfficheMomentDeversementSIAProfileIH()
        {


            ProfileIH profile = ListBox_Profile.SelectedItem as ProfileIH;

            stackPanel_SIAMin.Visibility = Visibility.Visible;
            stackPanel_SIAReal.Visibility = Visibility.Visible;


            #region Moment de déversement réel min


            MomentDeversementSIA deversementCTICMReel = profile.MomentDeversementSIACalcule;


            textBox_LongueurCritiqueDeversementSIA.Text = Math.Round(deversementCTICMReel.LongueurDeversementCritique, Element.ArrondiDimensionsm).ToString();
            textBox_MomentExtremiteOSIA.Text = Math.Round(deversementCTICMReel.MomentExtremiteO, Element.ArrondiMoments).ToString();
            textBox_MomentExtremiteESIA.Text = Math.Round(deversementCTICMReel.MomentExtremiteE, Element.ArrondiMoments).ToString();



            textBox_RapportMomentExtremiteSIA.Text = Math.Round(deversementCTICMReel.RapportMomentsExtremitePsi, Element.ArrondiCoefficients).ToString();
            textBox_CoefficientTypeChargeEta.Text = Math.Round(deversementCTICMReel.CoefficientMomentEta, Element.ArrondiCoefficients).ToString();


            textBox_RayonGirationMembrureComprimee.Text = Math.Round(deversementCTICMReel.RayonGirationMembrureComprimée, Element.ArrondiDimensionsmm).ToString();
            textBox_ContrainteTorsionUniforme.Text = Math.Round(deversementCTICMReel.ContrainteTorsionUniforme, Element.ArrondiContrainte).ToString();
            textBox_ContrainteTorsionNonUniforme.Text = Math.Round(deversementCTICMReel.ContrainteTorsionNonUniforme, Element.ArrondiContrainte).ToString();
            textBox_ContrainteCritiqueDeversement.Text = Math.Round(deversementCTICMReel.ContrainteCritiqueDeversement, Element.ArrondiContrainte).ToString();
            textBox_MomentCritiqueDeversementSIA.Text = Math.Round(deversementCTICMReel.MomentCritiqueDeversement / Math.Pow(10, 6), Element.ArrondiMoments).ToString();



            textBox_ElancementReduitΣΙΑ.Text = Math.Round(deversementCTICMReel.ElancementReduitDeversement, Element.ArrondiElancement).ToString();
            textBox_FacteurReductionΣΙΑ.Text = Math.Round(deversementCTICMReel.FacteurReductionDeversementChi, Element.ArrondiCoefficients).ToString();
            textBox_MomentDeversementΣΙΑ.Text = Math.Round(deversementCTICMReel.MomentResistantReduit, Element.ArrondiMoments).ToString();



            #endregion



            #region Moment de déversement min


            MomentDeversementSIA deversementSIAMin = profile.MomentDeversementSIACalculeMin;


            textBox_LongueurCritiqueDeversementSIAMin.Text = Math.Round(deversementSIAMin.LongueurDeversementCritique, Element.ArrondiDimensionsm).ToString();
            textBox_MomentExtremiteOSIAMin.Text = Math.Round(deversementSIAMin.MomentExtremiteO, Element.ArrondiMoments).ToString();
            textBox_MomentExtremiteESIAMin.Text = Math.Round(deversementSIAMin.MomentExtremiteE, Element.ArrondiMoments).ToString();



            textBox_RapportMomentExtremiteSIAMin.Text = Math.Round(deversementSIAMin.RapportMomentsExtremitePsi, Element.ArrondiCoefficients).ToString();
            textBox_CoefficientTypeChargeEtaMin.Text = Math.Round(deversementSIAMin.CoefficientMomentEta, Element.ArrondiCoefficients).ToString();


            textBox_RayonGirationMembrureComprimeeMin.Text = Math.Round(deversementSIAMin.RayonGirationMembrureComprimée, Element.ArrondiDimensionsmm).ToString();
            textBox_ContrainteTorsionUniformeMin.Text = Math.Round(deversementSIAMin.ContrainteTorsionUniforme, Element.ArrondiContrainte).ToString();
            textBox_ContrainteTorsionNonUniformeMin.Text = Math.Round(deversementSIAMin.ContrainteTorsionNonUniforme, Element.ArrondiContrainte).ToString();
            textBox_ContrainteCritiqueDeversementMin.Text = Math.Round(deversementSIAMin.ContrainteCritiqueDeversement, Element.ArrondiContrainte).ToString();
            textBox_MomentCritiqueDeversementSIAMin.Text = Math.Round(deversementSIAMin.MomentCritiqueDeversement / Math.Pow(10, 6), Element.ArrondiMoments).ToString();



            textBox_ElancementReduitΣΙΑMin.Text = Math.Round(deversementSIAMin.ElancementReduitDeversement, Element.ArrondiElancement).ToString();
            textBox_FacteurReductionΣΙΑMin.Text = Math.Round(deversementSIAMin.FacteurReductionDeversementChi, Element.ArrondiCoefficients).ToString();
            textBox_MomentDeversementΣΙΑMin.Text = Math.Round(deversementSIAMin.MomentResistantReduit, Element.ArrondiMoments).ToString();



            #endregion



        }




        #endregion


    }
}
