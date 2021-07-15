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
using TBAppAcierLibrairieClasses.Modeles.CoefficientsCTICM;

namespace TBAppAcier.Interface_Utilisateur__UI_
{
    /// <summary>
    /// Logique d'interaction pour ChoixProfileEtResistance.xaml
    /// </summary>
    public partial class ChoixProfileEtResistance : Window
    {




        public ChoixProfileEtResistance()
        {
            InitializeComponent();

            WireUpLists();

            ProfileIH iH = new ProfileIH();

            comboBox_TypeProfile.Items.Add(iH);
            comboBox_TypeProfile.DisplayMemberPath = "NomElement";


        }



        #region Wire up et validation de la fenêtre



        private void WireUpLists()
        {


           
            ObtientDiagrammes();

            ObtientResistance();

            ObtientProfile();

        }




        #endregion



        #region Buttons


        private void CreateProfileButton_Click(object sender, RoutedEventArgs e)
        {
            object typeprofilé = comboBox_TypeProfile.SelectedItem;

            var afficheProfilé = new Dictionary<object, Action>()
                    {

                        { typeof(ProfileIH), ()=> CreerProfileIH()}


                    };
            if (ValidateWindow() == "")
            {
                if (afficheProfilé.TryGetValue(typeprofilé.GetType(), out Action act))
                    act();
            }
            else
            {

                MessageBox.Show(ValidateWindow());

            }

            WireUpLists();
        }



        private void DeleteProfileButton_Click(object sender, RoutedEventArgs e)
        {

            if (ProfileListBox.SelectedItem != null)
            {

                object profilé = ProfileListBox.SelectedItem;

                var afficheProfilé = new Dictionary<object, Action>()
                    {

                        { typeof(ProfileIH), ()=> SupprimerProfileIH()}


                    };

                if (afficheProfilé.TryGetValue(profilé.GetType(), out Action act))
                    act();



            }

            WireUpLists();
        }



        private void ModifyProfileButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (ProfileListBox.SelectedItem != null && ValidateWindow() == "")
            {

                object profilé = ProfileListBox.SelectedItem;

                var afficheProfilé = new Dictionary<object, Action>()
                    {

                        { typeof(ProfileIH), ()=> ModifierProfileIH()}


                    };

                if (afficheProfilé.TryGetValue(profilé.GetType(), out Action act))
                    act();



            }
            else
            {

                MessageBox.Show(ValidateWindow());
            
            }


            WireUpLists();
        }



        private void ShutDowmThis_Click(object sender, RoutedEventArgs e)
        {


            this.Close();


        }

        #endregion



        #region ListBox events


        private void ProfileListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if (ProfileListBox.SelectedItem != null)
            {

                object profilé = ProfileListBox.SelectedItem;

                var afficheProfilé = new Dictionary<object, Action>()
                    {

                        { typeof(ProfileIH), ()=> ObtienProfileIHListBox()}


                    };

                if (afficheProfilé.TryGetValue(profilé.GetType(), out Action act))
                    act();



            }

        }


        private void DiagrammesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        #endregion



        #region ComboBox



        private void comboBox_TypeProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



            object typeprofilé = comboBox_TypeProfile.SelectedItem;

            var afficheProfilé = new Dictionary<object, Action>()
                    {

                        { typeof(ProfileIH), ()=> ObtientSerieIH()}


                    };
            if (afficheProfilé.TryGetValue(typeprofilé.GetType(), out Action act))
                act();

        }




        private void comboBox_SerieProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object typeprofilé = comboBox_TypeProfile.SelectedItem;

            string serie = comboBox_SerieProfile.SelectedItem as string;

            var afficheProfilé = new Dictionary<object, Action>()
                    {

                        { typeof(ProfileIH), ()=> ObtientProfiléIH(serie)}


                    };
            if (afficheProfilé.TryGetValue(typeprofilé.GetType(), out Action act))
                act();
        }


        private void comboBox_ListProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GeometrieIH geo = comboBox_ListProfile.SelectedItem as GeometrieIH;

            if (geo != null)
            {
                textbox_SectionNette.Text = geo.AireTotal.ToString();
            }

        }

        #endregion



        #region Validate


        public string ValidateWindow()
        {


            string output = "";


            if (textBox_NomPersonnalise.Text.Length == 0)
            {

                output = "Erreur. le nom personnalisé de l'élément est entré incorrectement.";

            }




            object typeResistance = null;
            typeResistance = comboBox_Nuance.SelectedItem;
            if (typeResistance == null)
            {

                output = "Erreur. Veuillez sélectionner une résistance.";

            }



            object diagramme = null;
            diagramme = DiagrammesListBox.SelectedItem;
            if (diagramme == null)
            {

                output = @"Erreur. Veuillez sélectionner un diagramme des efforts internes. Si aucun diagramme n'est présent, veuillez en créer un dans l'onglet 'Diagramme'";

            }


            object typeprofile = null;
            typeprofile = comboBox_ListProfile.SelectedItem;
            GeometrieIH geometrieIH = typeprofile as GeometrieIH;
            if (typeprofile == null)
            {

                output = "Erreur. Veuillez sélectionner un profilé I ou H.";

            }







            #region Effort normal

            double coefficientflambageY = 0;

            bool coefficientflambageYValid = double.TryParse(textbox_CoefficientFlambageAxeY.Text, out coefficientflambageY);

            if (!coefficientflambageYValid)
            {

                output = "Erreur. Le rapport entre la longueur de flambage Lky et L selon l'axe y est entré incorrectement. Celui-ci devrait se composer de chiffres.";

            }
            if (coefficientflambageY <= 0)
            {

                output = "Erreur. Le rapport entre la longueur de flambage Lky et L selon l'axe y est entré incorrectement. Celui-ci ne peut être négatif ni valoir 0.";

            }


            double coefficientflambageZ = 0;

            bool coefficientflambageZValid = double.TryParse(textbox_CoefficientFlambageAxeZ.Text, out coefficientflambageZ);

            if (!coefficientflambageZValid)
            {

                output = "Erreur. Le rapport entre la longueur de flambage Lkz et L selon l'axe z est entré incorrectement. Celui-ci devrait se composer de chiffres.";

            }
            if (coefficientflambageZ <= 0)
            {

                output = "Erreur. Le rapport entre la longueur de flambage Lkz et L selon l'axe z est entré incorrectement. Celui-ci ne peut être négatif ni valoir 0.";

            }



            double sectionnette = 0;

            bool sectionnetteValid = double.TryParse(textbox_SectionNette.Text, out sectionnette);

            if (!sectionnetteValid)
            {

                output = "Erreur. La section nette Anet est entrée incorrectement. Celle-ci devrait se composer de chiffres.";

            }
            if (sectionnette <= 0)
            {

                output = "Erreur. La section nette Anet est entrée incorrectement. Celle-ci ne peut être négative ni valoir 0.";

            }
            if (geometrieIH != null)
            {

                if (sectionnette > geometrieIH.AireTotal)
                {

                    output = "Erreur. La section nette Anet est supérieure à l'aire total du profilé.";


                }

            }
            #endregion



            #region Déversement





            double PositionnementCharge = 0;

            bool PositionnementChargeValid = double.TryParse(textbox_PositionnementChargeZg.Text, out PositionnementCharge);

            if (!PositionnementChargeValid)
            {

                output = "Erreur. Le positionnement de la charge est entré incorrectement. Cellui-ci devrait se composer de chiffres.";

            }
            if (geometrieIH != null)
            {

                if (PositionnementCharge > geometrieIH.Hauteur / 2)
                {

                    output = "Erreur. Le positionnement de la charge est supérieur à la moitié de la hauteur du profilé. Veuillez consulter le mode d'emploi pour plus d'informations.";


                }

            }



            #endregion



            return output;


        }


        #endregion



        #region Charger données


        /// <summary>
        /// Permet de récupérer les diagrammes dans la base de données
        /// </summary>
        private void ObtientDiagrammes()
        {


            using (var db = new AcierDbContext())
            {
                DiagrammesListBox.ItemsSource = null;

                var diagrammes = db.DiagrammesEffortsInternes
                    .Include(x => x.CombinaisonCharges1DSelectionnee)
                    .Include(x => x.EffortsInternesDistanceXes).ToList();



                DiagrammesListBox.ItemsSource = diagrammes;
                DiagrammesListBox.DisplayMemberPath = "FullName";
                db.SaveChanges();

            }



        }




        /// <summary>
        /// Permet de récupéere les résistance dans la base de données
        /// </summary>
        private void ObtientResistance()
        {


            using (var db = new AcierDbContext())
            {
                comboBox_Nuance.ItemsSource = null;

                var resistances = db.NuanceAciers.ToList();



                comboBox_Nuance.ItemsSource = resistances;
                comboBox_Nuance.DisplayMemberPath = "NomNuance";
                db.SaveChanges();

            }



        }



        /// <summary>
        /// Obtient les séries disponibles pour un type de profilés
        /// </summary>
        private void ObtientSerieIH()
        {


            comboBox_SerieProfile.Items.Add("IPE");
            comboBox_SerieProfile.Items.Add("INP");
            comboBox_SerieProfile.Items.Add("HEA");
            comboBox_SerieProfile.Items.Add("HEB");
            comboBox_SerieProfile.Items.Add("HEM");
            comboBox_SerieProfile.Items.Add("HHD");
            comboBox_SerieProfile.Items.Add("HL");



        }



        /// <summary>
        /// Permet de récupérer les profilés I et H dans la base de données
        /// </summary>
        private void ObtientProfiléIH(string serie)
        {


            using (var db = new AcierDbContext())
            {
                comboBox_ListProfile.ItemsSource = null;

                var profilésIH = db.GeometrieIHs.ToList();

                List<GeometrieIH> profileIHs = new List<GeometrieIH>();
                foreach (var profile in profilésIH)
                {

                    GeometrieIH p = profile as GeometrieIH;

                    if (p.NomGeometrieIH.Contains(serie))
                    {
                        profileIHs.Add(p);
                    }
                
                }

                

                comboBox_ListProfile.ItemsSource = profileIHs;
                comboBox_ListProfile.DisplayMemberPath = "NomGeometrieIH";
                db.SaveChanges();

            }



        }




        /// <summary>
        /// Permet de récupérer les profilés dans la base de données
        /// </summary>
        private void ObtientProfile()
        {


            using (var db = new AcierDbContext())
            {
                ProfileListBox.ItemsSource = null;

                var profile = db.ProfileIHs
                    .Include(x => x.NuanceAcierSelectionnee)
                    .Include(x => x.DiagrammesEffortsInternesCalcule)
                    .Include(x => x.GeometrieIHSelectionnee).ToList();






                ProfileListBox.ItemsSource = profile;
                ProfileListBox.DisplayMemberPath = "NomEntier";
                db.SaveChanges();

            }



        }


        /// <summary>
        /// Permet d'obtenir le profilé selectionné dans la list box I ou H
        /// </summary>
        private void ObtienProfileIHListBox()
        {

            DiagrammesListBox.SelectedItem = null;
            comboBox_Nuance.SelectedItem = null;
            comboBox_ListProfile.SelectedItem = null;



            ProfileIH profile = (ProfileListBox.SelectedItem as ProfileIH);

            DiagrammesEffortsInternes diagramm = profile.DiagrammesEffortsInternesCalcule;
            NuanceAcier resistance = profile.NuanceAcierSelectionnee;
            GeometrieIH geometrie = profile.GeometrieIHSelectionnee;

            
            DiagrammesListBox.SelectedItem = diagramm;
            comboBox_Nuance.SelectedIndex = resistance.IdNuance - 1;
            textBox_Profileselectionne.Text = $"{geometrie.NomGeometrieIH} {resistance.NomNuance}";
            

            // comboBox_TypeProfile.SelectedItem = new ProfileIH();
            // 
            // ObtientSerieIH();
            // 
            // List<string> itemserie = new List<string>();
            // 
            // foreach (string o in comboBox_SerieProfile.Items)
            // {
            // 
            //     itemserie.Add(o);
            // 
            // 
            // }
            // 
            // string itemserieselected = itemserie.Find(x => geometrie.NomGeometrieIH.Contains(x));
            // comboBox_SerieProfile.SelectedItem = itemserieselected;

            

            textBox_NomPersonnalise.Text = profile.NomPersonnalise;
            textbox_CoefficientFlambageAxeY.Text = profile.CoefficientFlambageAxeY.ToString(); 
            textbox_CoefficientFlambageAxeZ.Text = profile.CoefficientFlambageAxeZ.ToString();
            textbox_PositionnementChargeZg.Text = profile.PositionnementCharge.ToString();
            textbox_SectionNette.Text = profile.SectionNette.ToString();

            if (profile.OmegaY1)
            {

                checkBox_OmegaY1.IsChecked = true;
            
            }
            if (profile.OmegaZ1)
            {

                checkBox_OmegaZ1.IsChecked = true;

            }
        }




        /// <summary>
        /// Affiche les résultats du moment de déversement pour les profilés I ou H avec lecture tableau
        /// </summary>
        private List<double> ObtientC1C2TableauCTICM(ProfileIH profile)
        {




            double ψ = profile.ObtenirRapportMomentsExtremitePsi();
            double μ = profile.ObtenirRapportMomentIsoMomentExtremiteMu();

            #region données


            List<C1ConcMuNeg> c1ConcMuNegs = new List<C1ConcMuNeg>();
            List<C1ConcMuPos> c1ConcMuPos = new List<C1ConcMuPos>();
            List<C2ConcMuNeg> c2ConcMuNegs = new List<C2ConcMuNeg>();
            List<C2ConcMuPos> c2ConcMuPos = new List<C2ConcMuPos>();



            using (var db = new AcierDbContext())
            {

                var _c1ConcMuNegs = db.C1ConcMuNegs.ToList();
               
                foreach (object c1 in _c1ConcMuNegs)
                {
               
                    C1ConcMuNeg c1Conc = c1 as C1ConcMuNeg;
                    c1ConcMuNegs.Add(c1Conc);
               
               
                }


                var _c1ConcMuPos = db.C1ConcMuPos.ToList();

                foreach (object c1 in _c1ConcMuPos)
                {

                    C1ConcMuPos c1Conc = c1 as C1ConcMuPos;
                    c1ConcMuPos.Add(c1Conc);


                }



                var _c2ConcMuNegs = db.C2ConcMuNegs.ToList();

                foreach (object c2 in _c2ConcMuNegs)
                {

                    C2ConcMuNeg c2Conc = c2 as C2ConcMuNeg;
                    c2ConcMuNegs.Add(c2Conc);


                }


                var _c2ConcMuPos = db.C2ConcMuPos.ToList();

                foreach (object c2 in _c2ConcMuPos)
                {

                    C2ConcMuPos c2Conc = c2 as C2ConcMuPos;
                    c2ConcMuPos.Add(c2Conc);


                }



                db.SaveChanges();

            }


            #endregion



            List<double> C1C2 = profile.ObtientCoefficientC1CTICMTableau(ψ, μ, c1ConcMuNegs, c1ConcMuPos, c2ConcMuNegs, c2ConcMuPos);



            profile.MomentDeversementCTICMCalcule.CoefficientChargeC1 = C1C2[0];
            profile.MomentDeversementCTICMCalcule.CoefficientPositionChargeC2 = C1C2[1];





            return C1C2;

        }

        #endregion



        #region Création de Profilé


        /// <summary>
        /// Methode permettant de créer un profilé I ou H et de l'ajouter à la base de données
        /// </summary>
        public void CreerProfileIH()
        {

            NuanceAcier resistance = comboBox_Nuance.SelectedItem as NuanceAcier;

            DiagrammesEffortsInternes diagrammesSource = DiagrammesListBox.SelectedItem as DiagrammesEffortsInternes;

            GeometrieIH geometrieIH = comboBox_ListProfile.SelectedItem as GeometrieIH;


            #region Forcer ω = 1.0

            bool omegaYEstForce = false;
            if (checkBox_OmegaY1.IsChecked == true)
            {
                omegaYEstForce = true;
            }

            bool omegaZEstForce = false;
            if (checkBox_OmegaZ1.IsChecked == true)
            {
                omegaZEstForce = true;
            }


            #endregion

            

           

            ProfileIH profile = new ProfileIH(

                textBox_NomPersonnalise.Text,
                textbox_PositionnementChargeZg.Text,
                textbox_CoefficientFlambageAxeY.Text,
                textbox_CoefficientFlambageAxeZ.Text,
                textbox_SectionNette.Text,
                omegaYEstForce,
                omegaZEstForce,
                resistance,
                diagrammesSource,
                geometrieIH

                );


            if (diagrammesSource.CombinaisonCharges1DSelectionnee.ChargeRepartieUniformeqAxeZ == 0 && diagrammesSource.CombinaisonCharges1DSelectionnee.EffortNormalNed == 0)
            {

                profile.MomentDeversementCTICMCalcule = new MomentDeversementCTICM();
                List<double> C1C2 = ObtientC1C2TableauCTICM(profile);
                profile.MomentDeversementCTICMCalcule = profile.ObtientMDRdCTICMTableau(C1C2[0], C1C2[1]);
                profile.StabiliteCalcule = profile.ObtenirResultatEquationStabilite();

            }



            using (var db = new AcierDbContext())
            {



                db.ProfileIHs.Update(profile);



                db.SaveChanges();

            }



            textBox_NomPersonnalise.Text = "";
            textbox_PositionnementChargeZg.Text = "";
            textbox_CoefficientFlambageAxeY.Text = "";
            textbox_CoefficientFlambageAxeZ.Text = "";
            comboBox_Nuance.SelectedItem = null;
            DiagrammesListBox.SelectedItem = null;
            comboBox_ListProfile.SelectedItem = null;

        }



        #endregion



        #region Supprimer Profile


        /// <summary>
        /// Supprime le profilé sélectioné 
        /// </summary>
        private void SupprimerProfileIH()
        {

            ProfileIH d = (ProfileListBox.SelectedItem as ProfileIH);




            if (d != null)
            {


                if (MessageBox.Show($"Supprimer lr profilé I ou H {d.NomEntier}", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {

                }
                else
                {
                    using (var db = new AcierDbContext())
                    {


                        db.ProfileIHs.Remove(d);


                        db.SaveChanges();
                    }
                }


            }

            textBox_NomPersonnalise.Text = "";
            textbox_PositionnementChargeZg.Text = "";
            textbox_CoefficientFlambageAxeY.Text = "";
            textbox_CoefficientFlambageAxeZ.Text = "";
            textbox_SectionNette.Text = "";
            comboBox_Nuance.SelectedItem = null;
            DiagrammesListBox.SelectedItem = null;
            comboBox_ListProfile.SelectedItem = null;



        }


        #endregion



        #region Modifier Profilé

        /// <summary>
        /// Supprime le profilé sélectioné 
        /// </summary>
        private void ModifierProfileIH()
        {

            //Diagramme à modifier
            ProfileIH profileSource = ProfileListBox.SelectedItem as ProfileIH;

            NuanceAcier resistance = comboBox_Nuance.SelectedItem as NuanceAcier;

            DiagrammesEffortsInternes diagrammes = DiagrammesListBox.SelectedItem as DiagrammesEffortsInternes;

            GeometrieIH geo = comboBox_ListProfile.SelectedItem as GeometrieIH;

            profileSource.NuanceAcierSelectionnee = resistance;
            profileSource.GeometrieIHSelectionneeIdGeometrieIH = geo.IdGeometrieIH;
            profileSource.DiagrammesEffortsInternesCalculeIdDiagrammeEffortsInternes = diagrammes.IdDiagrammeEffortsInternes;

            #region Forcer ω = 1.0

            bool omegaYEstForce = false;
            if (checkBox_OmegaY1.IsChecked == true)
            {
                omegaYEstForce = true;
            }

            bool omegaZEstForce = false;
            if (checkBox_OmegaZ1.IsChecked == true)
            {
                omegaZEstForce = true;
            }


            #endregion



            #region Appel du constructeur


            profileSource.UpdateProfileIH(
                textBox_NomPersonnalise.Text,
                textbox_PositionnementChargeZg.Text,
                textbox_CoefficientFlambageAxeY.Text,
                textbox_CoefficientFlambageAxeZ.Text,
                textbox_SectionNette.Text,
                omegaYEstForce,
                omegaZEstForce,
                resistance,
                diagrammes,
                geo
                );


            #endregion



            #region CTICM charge concentrée


            if (diagrammes.CombinaisonCharges1DSelectionnee.ChargeRepartieUniformeqAxeZ == 0 && diagrammes.CombinaisonCharges1DSelectionnee.EffortNormalNed == 0)
            {


                List<double> C1C2 = ObtientC1C2TableauCTICM(profileSource);
                profileSource.MomentDeversementCTICMCalcule = profileSource.ObtientMDRdCTICMTableau(C1C2[0], C1C2[1]);


            }


            #endregion



            using (var db = new AcierDbContext())
            {


                #region Données

                ProfileIH profileToUpdate = db.ProfileIHs
                         .Where(p => p.IdElement == profileSource.IdElement).FirstOrDefault();

                profileToUpdate.NuanceAcierSelectionnee = db.NuanceAciers
                         .Where(r => r.IdNuance == profileToUpdate.NuanceAcierSelectionneeIdNuance).FirstOrDefault();

                profileToUpdate.GeometrieIHSelectionnee = db.GeometrieIHs
                         .Where(g => g.IdGeometrieIH == profileToUpdate.GeometrieIHSelectionneeIdGeometrieIH).FirstOrDefault();

                profileToUpdate.DiagrammesEffortsInternesCalcule = db.DiagrammesEffortsInternes
                         .Where(d => d.IdDiagrammeEffortsInternes == profileToUpdate.DiagrammesEffortsInternesCalculeIdDiagrammeEffortsInternes).FirstOrDefault();

                #region Calculs



                profileToUpdate.ClasseSectionCalcule = db.ClasseSections
                    .Where(c => c.IdClasseSection == profileToUpdate.ClasseSectionCalculeIdClasseSection).FirstOrDefault();

                profileToUpdate.FlambageCalcule = db.Flambages
                    .Where(f => f.IdFlambage == profileToUpdate.FlambageCalculeIdFlambage).FirstOrDefault();

                profileToUpdate.EffortTranchantCalcule = db.EffortTranchants
                    .Where(et => et.IdEffortTranchant == profileToUpdate.EffortTranchantCalculeIdEffortTranchant).FirstOrDefault();

                profileToUpdate.MomentsFlexionnelResistantCalcules = db.MomentsFlexionnelResistants
                    .Where(m => m.IdMomentsFlexionnelResistant == profileToUpdate.MomentsFlexionnelResistantCalculesIdMomentsFlexionnelResistant).FirstOrDefault();



                profileToUpdate.MomentDeversementCTICMCalcule = db.MomentDeversementCTICMs
                    .Where(m => m.IdMomentDeversementCTICM == profileToUpdate.MomentDeversementCTICMCalculeIdMomentDeversementCTICM).FirstOrDefault();

                profileToUpdate.MomentDeversementCTICMCalculeMin = db.MomentDeversementCTICMs
                    .Where(m => m.IdMomentDeversementCTICM == profileToUpdate.MomentDeversementCTICMCalculeMinIdMomentDeversementCTICM).FirstOrDefault();



                profileToUpdate.MomentDeversementSIACalcule = db.MomentDeversementSIAs
                      .Where(m => m.IdMomentDeversementSIA == profileToUpdate.MomentDeversementSIACalculeIdMomentDeversementSIA).FirstOrDefault();

                profileToUpdate.MomentDeversementSIACalculeMin = db.MomentDeversementSIAs
                    .Where(m => m.IdMomentDeversementSIA == profileToUpdate.MomentDeversementSIACalculeMinIdMomentDeversementSIA).FirstOrDefault();



                profileToUpdate.StabiliteCalcule = db.Stabilites
                    .Where(m => m.IdStabilite == profileToUpdate.StabiliteCalculeIdStabilite).FirstOrDefault();

                profileToUpdate.ResistanceSectionCalculee = db.ResistanceSections
                    .Where(m => m.IdResistanceSection == profileToUpdate.ResistanceSectionCalculeeIdResistanceSection).FirstOrDefault();



                #endregion


                #endregion



                #region Calculs





                #endregion




                if (profileToUpdate != null)
                {
                    db.Entry(profileToUpdate).CurrentValues.SetValues(profileSource);
                }

                db.SaveChanges();



            }



            textBox_NomPersonnalise.Text = "";
            textbox_PositionnementChargeZg.Text = "";
            textbox_CoefficientFlambageAxeY.Text = "";
            textbox_CoefficientFlambageAxeZ.Text = "";
            comboBox_Nuance.SelectedItem = null;
            DiagrammesListBox.SelectedItem = null;
            comboBox_ListProfile.SelectedItem = null;

            WireUpLists();


        }

        #endregion



        #region Loaded

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            textBox_NomPersonnalise.Text = "test";
            textbox_CoefficientFlambageAxeY.Text = "1";
            textbox_CoefficientFlambageAxeZ.Text = "1";

            textbox_PositionnementChargeZg.Text = "0";

        }


        #endregion

        private void checkBox_OmegaY1_Checked(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
