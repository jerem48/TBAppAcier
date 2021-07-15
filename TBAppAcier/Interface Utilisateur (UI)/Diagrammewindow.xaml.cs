using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TBAppAcierLibrairieClasses.Modeles;
using TBAppAcier.AccesDonnees;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TBAppAcier.Dessins;

namespace TBAppAcier.Interface_Utilisateur__UI_
{
    /// <summary>
    /// Logique d'interaction pour Diagrammewindow.xaml
    /// </summary>
    public partial class Diagrammewindow : Window
    {
        public Diagrammewindow()
        {
            InitializeComponent();

            WireUpLists();

            double gridsWidth = this.Width   * 1/5;

            Grid_EffortsNormal.Width = gridsWidth;

            



        }

        private void DiagrammesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DiagrammesListBox.SelectedItem != null)
            {
                DiagrammesEffortsInternes diagrammesEfforts = (DiagrammesListBox.SelectedItem as DiagrammesEffortsInternes);

                CombinaisonCharges1D combi = diagrammesEfforts.CombinaisonCharges1DSelectionnee;




                textBox_Longueur.Text = combi.LongueurElement.ToString();
                textBox_EffortNormal.Text = combi.EffortNormalNed.ToString();
                textBox_ChargeRepartieUniformeqAxeY.Text = combi.ChargeRepartieUniformeqAxeY.ToString();
                textBox_ChargeRepartieUniformeqAxeZ.Text = combi.ChargeRepartieUniformeqAxeZ.ToString();
                textBox_ChargePonctuelleMilieuTraveeQAxeY.Text = combi.ChargeConcentreMilieuTraveeQAxeY.ToString();
                textBox_ChargePonctuelleMilieuTraveeQAxeZ.Text = combi.ChargeConcentreMilieuTraveeQAxeZ.ToString();
                textBox_MomentMAxeYExtremiteO.Text = combi.MomentMAxeYExtremiteO.ToString();
                textBox_MomentMAxeZExtremiteO.Text = combi.MomentMAxeZExtremiteO.ToString();
                textBox_MomentMAxeYExtremiteE.Text = combi.MomentMAxeYExtremiteE.ToString();
                textBox_MomentMAxeZExtremiteE.Text = combi.MomentMAxeZExtremiteE.ToString();


            }

        }


        #region Interactions Buttons


        #region Données

        private void CreateDiagrammeButton_Click(object sender, RoutedEventArgs e)
        {


            if (ValidateWindow()=="")
            {

                CombinaisonCharges1D combi = new CombinaisonCharges1D(
                    textBox_Longueur.Text,
                    textBox_EffortNormal.Text,
                    textBox_ChargeRepartieUniformeqAxeY.Text,
                    textBox_ChargeRepartieUniformeqAxeZ.Text,
                    textBox_ChargePonctuelleMilieuTraveeQAxeY.Text,
                    textBox_ChargePonctuelleMilieuTraveeQAxeZ.Text,
                    textBox_MomentMAxeYExtremiteO.Text,
                    textBox_MomentMAxeZExtremiteO.Text,
                    textBox_MomentMAxeYExtremiteE.Text, 
                    textBox_MomentMAxeZExtremiteE.Text
                    );


                DiagrammesEffortsInternes diagrammes = new DiagrammesEffortsInternes(
                    combi);

                diagrammes.EffortsInternesDistanceXes = diagrammes.ObtientEffortsInternes();

                using (var db = new AcierDbContext())
                {
                   
                   
                    db.CombinaisonCharges1Ds.Add(combi);
                    db.DiagrammesEffortsInternes.Add(diagrammes);

                    
                    db.SaveChanges();
                }



                textBox_Longueur.Text = "";
                textBox_EffortNormal.Text = "";
                textBox_ChargeRepartieUniformeqAxeY.Text = "";
                textBox_ChargeRepartieUniformeqAxeZ.Text = "";
                textBox_ChargePonctuelleMilieuTraveeQAxeY.Text = "";
                textBox_ChargePonctuelleMilieuTraveeQAxeZ.Text = "";
                textBox_MomentMAxeYExtremiteO.Text = "";
                textBox_MomentMAxeZExtremiteO.Text = "";
                textBox_MomentMAxeYExtremiteE.Text = "";
                textBox_MomentMAxeZExtremiteE.Text = "";


            }
            else
            {

                MessageBox.Show(ValidateWindow());

            }

            WireUpLists();

        }



        private void DeleteDiagrammeButton_Click(object sender, RoutedEventArgs e)
        {

            DiagrammesEffortsInternes d = (DiagrammesListBox.SelectedItem as DiagrammesEffortsInternes);

            List<ProfileIH> profileIH = ObientProfiles();

            ProfileIH profileIHAvecDiagrammeSupprimer = profileIH.Find(x=> x.DiagrammesEffortsInternesCalculeIdDiagrammeEffortsInternes == d.IdDiagrammeEffortsInternes);

            if (DiagrammesListBox.SelectedItem != null)
            {
                if (profileIHAvecDiagrammeSupprimer == null)
                {
                    if (MessageBox.Show($"Supprimer {d.FullName}?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {

                    }
                    else
                    {
                        using (var db = new AcierDbContext())
                        {


                            db.CombinaisonCharges1Ds.Remove(d.CombinaisonCharges1DSelectionnee);
                            db.DiagrammesEffortsInternes.Remove(d);


                            db.SaveChanges();
                        }
                    }
                }
                else
                {

                    MessageBox.Show($"Erreur. Veuillez supprimer {profileIHAvecDiagrammeSupprimer.NomEntier} avant de supprimer {d.FullName}.");

                }



                WireUpLists();
            }
            else
            {

                MessageBox.Show("Erreur. Veuillez sélectionner une combinaison existante à supprimer.");

            }

        }




        private void ModifyDiagrammeButton_Click(object sender, RoutedEventArgs e)
        {

            //Diagramme à modifier
            DiagrammesEffortsInternes diagrammesSource = DiagrammesListBox.SelectedItem as DiagrammesEffortsInternes;

            if (DiagrammesListBox.SelectedItem != null)
            {

                if (ValidateWindow() == "" && DiagrammesListBox.SelectedItem != null)
                {



                    diagrammesSource.CombinaisonCharges1DSelectionnee.UpdateCombinaisonCharges1D(
                        textBox_Longueur.Text,
                        textBox_EffortNormal.Text,
                        textBox_ChargeRepartieUniformeqAxeY.Text,
                        textBox_ChargeRepartieUniformeqAxeZ.Text,
                        textBox_ChargePonctuelleMilieuTraveeQAxeY.Text,
                        textBox_ChargePonctuelleMilieuTraveeQAxeZ.Text,
                        textBox_MomentMAxeYExtremiteO.Text,
                        textBox_MomentMAxeZExtremiteO.Text,
                        textBox_MomentMAxeYExtremiteE.Text,
                        textBox_MomentMAxeZExtremiteE.Text
                        );




                    diagrammesSource.EffortsInternesDistanceXes = diagrammesSource.ObtientEffortsInternes();





                    using (var db = new AcierDbContext())
                    {

                        CombinaisonCharges1D combinaisonToUpdate = db.CombinaisonCharges1Ds
                            .Where(c => c.IdCombinaisonCharges == diagrammesSource.CombinaisonCharges1DSelectionnee.IdCombinaisonCharges).FirstOrDefault();

                        if (combinaisonToUpdate != null)
                        {
                            db.Entry(combinaisonToUpdate).CurrentValues.SetValues(diagrammesSource.CombinaisonCharges1DSelectionnee);
                        }



                        DiagrammesEffortsInternes diagrammToUpdate = db.DiagrammesEffortsInternes
                            .Where(d => d.IdDiagrammeEffortsInternes == diagrammesSource.IdDiagrammeEffortsInternes).FirstOrDefault();

                        if (diagrammToUpdate != null)
                        {
                            db.Entry(diagrammToUpdate).CurrentValues.SetValues(diagrammesSource);
                        }

                        db.SaveChanges();
                    }



                    textBox_Longueur.Text = "";
                    textBox_EffortNormal.Text = "";
                    textBox_ChargeRepartieUniformeqAxeY.Text = "";
                    textBox_ChargeRepartieUniformeqAxeZ.Text = "";
                    textBox_ChargePonctuelleMilieuTraveeQAxeY.Text = "";
                    textBox_ChargePonctuelleMilieuTraveeQAxeZ.Text = "";
                    textBox_MomentMAxeYExtremiteO.Text = "";
                    textBox_MomentMAxeZExtremiteO.Text = "";
                    textBox_MomentMAxeYExtremiteE.Text = "";
                    textBox_MomentMAxeZExtremiteE.Text = "";


                }
                else
                {

                    MessageBox.Show(ValidateWindow());

                }

                WireUpLists();
            }
            else
            {

                MessageBox.Show("Erreur. Veuillez sélectionner une combinaison existante à modifier.");

            }

}

        #endregion



        #region Affichage
      


        /// <summary>
        /// Affiche les différents diagrammes des efforts internes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AfficheDiagrammeButton_Click(object sender, RoutedEventArgs e)
        {

            if (DiagrammesListBox.SelectedItem != null)
            {
                //TODO - Afficher Mz et Vy


                #region Clearing
                Grid_EffortsNormal.Children.Clear();
                Grid_MomentAxeY.Children.Clear();
                Grid_EffortTranchantVz.Children.Clear();


                #endregion

                #region General Info


                double Grid_EffortsInternes_CentreX = Grid_EffortsNormal.ActualWidth / 2;
                Grid_MomentAxeY.Width = Grid_EffortTranchantVz.Width  = Grid_EffortsNormal.ActualWidth;
                double Grid_EffortsInternes_CentreY = StackPanel_My.ActualHeight / 2;

                double Grid_Moments_CentreX = Grid_MomentAxeY.ActualWidth / 2;

                DiagrammesEffortsInternes diagrammes = DiagrammesListBox.SelectedItem as DiagrammesEffortsInternes;
                Dessin dessin = new Dessin();
                List<EffortsInternesDistanceX> efforts = diagrammes.ObtientEffortsInternes();
                int NombreEfforts = efforts.Count();


                #endregion



                #region Drawing scale 


                double Longueur = NombreEfforts* diagrammes.CombinaisonCharges1DSelectionnee.LongueurElement;

                double scaleX = dessin.GetScaleX(Longueur, Grid_EffortsNormal.ActualWidth);
                double scaleY = dessin.GetScaleNormal(Math.Abs(efforts[0].EffortNormalNed), Grid_EffortsNormal.ActualHeight);


                #endregion



                Point startPointElement = new Point(Grid_EffortsInternes_CentreX - Longueur  * scaleX / 2, Grid_EffortsInternes_CentreY);
                Point endPointElement = new Point(Grid_EffortsInternes_CentreX + Longueur * scaleX / 2, Grid_EffortsInternes_CentreY);









                #region Effort Normal

                Point startPointNed = new Point(Grid_EffortsInternes_CentreX - (efforts[NombreEfforts - 1].DistanceX  - efforts[0].DistanceX)* NombreEfforts * scaleX / 2, Grid_EffortsInternes_CentreY + efforts[0].EffortNormalNed * scaleY);
                Point endPointNed = new Point(Grid_EffortsInternes_CentreX + (efforts[NombreEfforts - 1].DistanceX - efforts[0].DistanceX) * NombreEfforts * scaleX / 2 , Grid_EffortsInternes_CentreY + efforts[NombreEfforts - 1].EffortNormalNed * scaleY);



                Grid_EffortsNormal.Children.Add(dessin.GetPathLine(endPointNed, endPointElement, Brushes.Black, 100));
                Grid_EffortsNormal.Children.Add(dessin.GetPathLine(endPointElement, startPointElement, Brushes.Black, 100));
                Grid_EffortsNormal.Children.Add(dessin.GetPathLine(startPointElement, startPointNed, Brushes.Black, 100));
                



                #endregion



                #region Moment My base
                List<double> mys = new List<double>();

                foreach (EffortsInternesDistanceX effort in efforts)
                    mys.Add(Math.Abs(effort.MomentMAxeYDistanceX));

                double scaleMyY = dessin.GetScaleX(mys.Max(), Grid_EffortsInternes_CentreY);

                Point startPointMyedO = new Point(Grid_EffortsInternes_CentreX - (efforts[NombreEfforts - 1].DistanceX - efforts[0].DistanceX) * NombreEfforts * scaleX / 2, Grid_EffortsInternes_CentreY + efforts[0].MomentMAxeYDistanceX * scaleMyY);
                Point endPointMyedE = new Point(Grid_EffortsInternes_CentreX + (efforts[NombreEfforts - 1].DistanceX - efforts[0].DistanceX) * NombreEfforts * scaleX / 2, Grid_EffortsInternes_CentreY + efforts[NombreEfforts - 1].MomentMAxeYDistanceX * scaleMyY);

                Grid_MomentAxeY.Children.Add(dessin.GetPathLine(endPointMyedE, endPointElement, Brushes.Black, 100));
                Grid_MomentAxeY.Children.Add(dessin.GetPathLine(endPointElement, startPointElement, Brushes.Black, 100));
                Grid_MomentAxeY.Children.Add(dessin.GetPathLine(startPointElement, startPointMyedO, Brushes.Black, 100));


                //Efforts max et aux extrêmités

                List<double> mmax = new List<double>();

                foreach (EffortsInternesDistanceX effort in efforts)
                    mmax.Add(effort.MomentMAxeYDistanceX);


                textBox_MomentMaxTravee.Text = Math.Round(mmax.Max(), Element.ArrondiMoments).ToString();

                textBox_MomentAppuiO.Text = Math.Round(efforts[0].MomentMAxeYDistanceX, Element.ArrondiMoments).ToString();
                textBox_MomentAppuiE.Text = Math.Round(efforts[NombreEfforts - 1].MomentMAxeYDistanceX, Element.ArrondiMoments).ToString();


                #endregion



                #region Effort tranchant Vz

                List<double> vzs = new List<double>();

                foreach (EffortsInternesDistanceX effort in efforts)
                    vzs.Add(Math.Abs(effort.EffortTranchanVAxeZDistanceX));

                double scaleVzs= dessin.GetScaleX(vzs.Max(), Grid_EffortsInternes_CentreY);


                Point startPointVzedO = new Point(Grid_EffortsInternes_CentreX - (efforts[NombreEfforts - 1].DistanceX - efforts[0].DistanceX) * NombreEfforts * scaleX / 2, Grid_EffortsInternes_CentreY + efforts[0].EffortTranchanVAxeZDistanceX * scaleVzs);
                Point endPointVzedE = new Point(Grid_EffortsInternes_CentreX + (efforts[NombreEfforts - 1].DistanceX - efforts[0].DistanceX) * NombreEfforts * scaleX / 2, Grid_EffortsInternes_CentreY + efforts[NombreEfforts - 1].EffortTranchanVAxeZDistanceX * scaleVzs);

                Grid_EffortTranchantVz.Children.Add(dessin.GetPathLine(endPointVzedE, endPointElement, Brushes.Black, 100));
                Grid_EffortTranchantVz.Children.Add(dessin.GetPathLine(endPointElement, startPointElement, Brushes.Black, 100));
                Grid_EffortTranchantVz.Children.Add(dessin.GetPathLine(startPointElement, startPointVzedO, Brushes.Black, 100));

                textBox_EffortTranchantE.Text = Math.Round(efforts[0].EffortTranchanVAxeZDistanceX, Element.ArrondiForce).ToString();
                textBox_EffortTranchantO.Text = Math.Round(efforts[NombreEfforts - 1].EffortTranchanVAxeZDistanceX, Element.ArrondiForce).ToString();


                #endregion




                for (int i = 0; i < NombreEfforts - 1; i++) 
                {

                    #region Effort Normal

                    //Lignes d'effort normal
                    Point startPointNedi= new Point(efforts[i].DistanceX * NombreEfforts * scaleX , Grid_EffortsInternes_CentreY + efforts[i].EffortNormalNed * scaleY);
                    Point endPointNedi = new Point(efforts[i + 1].DistanceX * NombreEfforts * scaleX , Grid_EffortsInternes_CentreY + efforts[i + 1].EffortNormalNed * scaleY);
                    Grid_EffortsNormal.Children.Add(dessin.GetPathLine(startPointNedi, endPointNedi, Brushes.Black, 100));
                    #endregion

                    #region Moment My

                    //Lignes des moments My
                    Point startPointMyedi = new Point(efforts[i].DistanceX * NombreEfforts * scaleX, Grid_EffortsInternes_CentreY + efforts[i].MomentMAxeYDistanceX * scaleMyY);
                    Point endPointMyedi = new Point(efforts[i + 1].DistanceX * NombreEfforts * scaleX, Grid_EffortsInternes_CentreY + efforts[i + 1].MomentMAxeYDistanceX * scaleMyY);

                    Grid_MomentAxeY.Children.Add(dessin.GetPathLine(startPointMyedi, endPointMyedi, Brushes.Black, 100));




                    #endregion


                    #region Moment Vz

                    //Ligne des efforts tranchants Vz
                    Point startPointVzedi = new Point(efforts[i].DistanceX * NombreEfforts * scaleX, Grid_EffortsInternes_CentreY + efforts[i].EffortTranchanVAxeZDistanceX * scaleVzs);
                    Point endPointVzedi = new Point(efforts[i + 1].DistanceX * NombreEfforts * scaleX, Grid_EffortsInternes_CentreY + efforts[i + 1].EffortTranchanVAxeZDistanceX * scaleVzs);

                    Grid_EffortTranchantVz.Children.Add(dessin.GetPathLine(startPointVzedi, endPointVzedi, Brushes.Black, 100));


                    #endregion


                }




            }



        }




        /// <summary>
        /// Addiche les moments d'encastrement indicatifs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // private void AfficheMomentsButton_Click(object sender, RoutedEventArgs e)
        // {
        // 
        // 
        //     if (ValidatePourMoments() == "")
        //     {
        //         textBox_MomentMAxeYAppuyeEncastre.Text = "";
        //         textBox_MomentMAxeYEncastreEncastre.Text = "";
        //         textBox_MomentMAxeZAppuyeEncastre.Text = "";
        //         textBox_MomentMAxeZEncastreEncastre.Text = "";
        // 
        // 
        //         if (DiagrammesListBox.SelectedItem == null)
        //         {
        // 
        //             CombinaisonCharges1D combinaisonCharges1D = new CombinaisonCharges1D(
        //                 textBox_Longueur.Text,
        //                 textBox_ChargeRepartieUniformeqAxeY.Text,
        //                 textBox_ChargeRepartieUniformeqAxeZ.Text,
        //                 textBox_ChargePonctuelleMilieuTraveeQAxeY.Text,
        //                 textBox_ChargePonctuelleMilieuTraveeQAxeZ.Text
        //             );
        // 
        // 
        //             DiagrammesEffortsInternes diagrammes = new DiagrammesEffortsInternes(
        //                 combinaisonCharges1D);
        // 
        // 
        //             List<double> momentsencastrement = diagrammes.ObtientMomentEncastrement();
        // 
        // 
        //             textBox_MomentMAxeYAppuyeEncastre.Text = momentsencastrement[0].ToString();
        //             textBox_MomentMAxeYEncastreEncastre.Text = momentsencastrement[1].ToString();
        //             textBox_MomentMAxeZAppuyeEncastre.Text = momentsencastrement[2].ToString();
        //             textBox_MomentMAxeZEncastreEncastre.Text = momentsencastrement[3].ToString();
        // 
        // 
        //         }
        //         else
        //         {
        // 
        // 
        //             DiagrammesEffortsInternes diagrammes = DiagrammesListBox.SelectedItem as DiagrammesEffortsInternes;
        // 
        // 
        //             List<double> momentsencastrement = diagrammes.ObtientMomentEncastrement();
        // 
        // 
        //             textBox_MomentMAxeYAppuyeEncastre.Text = momentsencastrement[0].ToString();
        //             textBox_MomentMAxeYEncastreEncastre.Text = momentsencastrement[1].ToString();
        //             textBox_MomentMAxeZAppuyeEncastre.Text = momentsencastrement[2].ToString();
        //             textBox_MomentMAxeZEncastreEncastre.Text = momentsencastrement[3].ToString();
        // 
        //         }
        // 
        // 
        // 
        // 
        //     }
        //     else
        //     {
        // 
        //         MessageBox.Show(ValidatePourMoments());
        //     
        //     }
        // 
        //            
        // 
        // 
        // 
        // }
        // 
        // 

        #endregion

        private void ShutDowmThis_Click(object sender, RoutedEventArgs e)
        {

            Close();

        }

        #endregion



        #region Wire up et validation de la fenêtre






        /// <summary>
        /// Permet de vérifier si les informations rentrées dans la fenêtre sont correctes
        /// </summary>
        /// <returns></returns>
        private string ValidateWindow()
        {

            string output = "";




            double longueur = 0;

            bool longueurValid = double.TryParse(textBox_Longueur.Text, out longueur);

            if (!longueurValid)
            {

                output = "Erreur. La longueur de l'élément est entrée incorrectement. Celle-ci devrait se composer de chiffres.";

            }
            if (longueur <= 0)
            {

                output = "Erreur. La longueur de l'élément est entrée incorrectement. Celle-ci ne peut être négative ni valoir 0.";

            }

            #region Effort Normal


            double effortNormal = 0;

            bool effortNormalValid = double.TryParse(textBox_EffortNormal.Text, out effortNormal);

            if (!effortNormalValid)
            {

                output = "Erreur. L'effort normal est entré incorrectement. Celui-ci devrait se composer de chiffres.";

            }
            


            #endregion



            #region Charges


            double chargeRepartieUniformeqAxeY = 0;

            bool chargeRepartieUniformeqAxeYValid = double.TryParse(textBox_ChargeRepartieUniformeqAxeY.Text, out chargeRepartieUniformeqAxeY);

            if (!chargeRepartieUniformeqAxeYValid)
            {

                output = "Erreur. La charge répartie uniformément qy est entrée incorrectement. Celle-ci devrait se composer de chiffres.";

            }
            




            double chargeRepartieUniformeqAxeZ = 0;

            bool chargeRepartieUniformeqAxeZValid = double.TryParse(textBox_ChargeRepartieUniformeqAxeZ.Text, out chargeRepartieUniformeqAxeZ);
            
            if (!chargeRepartieUniformeqAxeZValid)
            {

                output = "Erreur. La charge répartie uniformément qz est entrée incorrectement. Celle-ci devrait se composer de chiffres.";

            }
            



            double chargePonctuelleQAxeY = 0;

            bool chargePonctuelleQAxeYValid = double.TryParse(textBox_ChargePonctuelleMilieuTraveeQAxeY.Text, out chargePonctuelleQAxeY);

            if (!chargePonctuelleQAxeYValid)
            {

                output = "Erreur. La charge ponctuelle Qy est entrée incorrectement. Celle-ci devrait se composer de chiffres.";

            }
            


            double chargePonctuelleQAxeZ = 0;

            bool chargePonctuelleQAxeZValid = double.TryParse(textBox_ChargePonctuelleMilieuTraveeQAxeZ.Text, out chargePonctuelleQAxeZ);

            if (!chargePonctuelleQAxeZValid)
            {

                output = "Erreur. La charge ponctuelle Qy est entrée incorrectement. Celle-ci devrait se composer de chiffres.";

            }
            

            #endregion



            #region Moments


            double momentMAxeYExtremiteO = 0;

            bool momentMAxeYExtremiteOValid = double.TryParse(textBox_MomentMAxeYExtremiteO.Text, out momentMAxeYExtremiteO);

            if (!momentMAxeYExtremiteOValid)
            {

                output = "Erreur. Le moment Myo est entré incorrectement. Celui-ci devrait se composer de chiffres.";

            }
            


            double momentMAxeZExtremiteO = 0;

            bool momentMAxeZExtremiteOValid = double.TryParse(textBox_MomentMAxeZExtremiteO.Text, out momentMAxeZExtremiteO);

            if (!momentMAxeZExtremiteOValid)
            {

                output = "Erreur. Le moment Mzo est entré incorrectement. Celui-ci devrait se composer de chiffres.";

            }
            


            double momentMAxeYExtremiteE = 0;

            bool momentMAxeYExtremiteEValid = double.TryParse(textBox_MomentMAxeYExtremiteE.Text, out momentMAxeYExtremiteE);

            if (!momentMAxeYExtremiteEValid)
            {

                output = "Erreur. Le moment Mye est entré incorrectement. Celui-ci devrait se composer de chiffres.";

            }
            


            double momentMAxeZExtremiteE = 0;

            bool momentMAxeZExtremiteEValid = double.TryParse(textBox_MomentMAxeZExtremiteE.Text, out momentMAxeZExtremiteE);

            if (!momentMAxeZExtremiteEValid)
            {

                output = "Erreur. Le moment Mze est entré incorrectement. Celui-ci devrait se composer de chiffres.";

            }
          


            #endregion


            return output;      
        
        
        
        }



        /// <summary>
        /// Permet de vérifier si les informations rentrées dans la fenêtre sont correctes pour les moments d'encastrement (seulement L, qz, qy, Qy, Qz)
        /// </summary>
        /// <returns></returns>
        private string ValidatePourMoments()
        {

            string output = "";




            double longueur = 0;

            bool longueurValid = double.TryParse(textBox_Longueur.Text, out longueur);

            if (!longueurValid)
            {

                output = "Erreur. La longueur de l'élément est entrée incorrectement. Celle-ci devrait se composer de chiffres.";

            }
            if (longueur <= 0)

            {

                output = "Erreur. La longueur de l'élément est entrée incorrectement. Celle-ci ne peut être négative ni valoir 0.";

            }




            #region Charges


            double chargeRepartieUniformeqAxeY = 0;

            bool chargeRepartieUniformeqAxeYValid = double.TryParse(textBox_ChargeRepartieUniformeqAxeY.Text, out chargeRepartieUniformeqAxeY);

            if (!chargeRepartieUniformeqAxeYValid)
            {

                output = "Erreur. La charge répartie uniformément qy est entrée incorrectement. Celle-ci devrait se composer de chiffres.";

            }
           




            double chargeRepartieUniformeqAxeZ = 0;

            bool chargeRepartieUniformeqAxeZValid = double.TryParse(textBox_ChargeRepartieUniformeqAxeZ.Text, out chargeRepartieUniformeqAxeZ);

            if (!chargeRepartieUniformeqAxeZValid)
            {

                output = "Erreur. La charge répartie uniformément qz est entrée incorrectement. Celle-ci devrait se composer de chiffres.";

            }
           



            double chargePonctuelleQAxeY = 0;

            bool chargePonctuelleQAxeYValid = double.TryParse(textBox_ChargePonctuelleMilieuTraveeQAxeY.Text, out chargePonctuelleQAxeY);

            if (!chargePonctuelleQAxeYValid)
            {

                output = "Erreur. La charge ponctuelle Qy est entrée incorrectement. Celle-ci devrait se composer de chiffres.";

            }
            


            double chargePonctuelleQAxeZ = 0;

            bool chargePonctuelleQAxeZValid = double.TryParse(textBox_ChargePonctuelleMilieuTraveeQAxeZ.Text, out chargePonctuelleQAxeZ);

            if (!chargePonctuelleQAxeZValid)
            {

                output = "Erreur. La charge ponctuelle Qy est entrée incorrectement. Celle-ci devrait se composer de chiffres.";

            }
            

            #endregion





            return output;



        }



        /// <summary>
        /// Actualise les listes depuis la base de donnée
        /// </summary>
        private void WireUpLists()
        {


            


            ObtientDiagrammes();





        }

        #endregion



        #region Charger les données
        /// <summary>
        /// Obtient la liste des profilés
        /// </summary>
        private List<ProfileIH> ObientProfiles()
        {

            List<ProfileIH> profileIH = new List<ProfileIH>();

            using (var db = new AcierDbContext())
            {
                

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
                    .ToList();




                profileIH = profile;

                
                db.SaveChanges();

            }



            return profileIH;

        }


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






        #endregion


        #region Loaded


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textBox_Longueur.Text = "5";
            textBox_EffortNormal.Text = "5";
            textBox_ChargeRepartieUniformeqAxeY.Text = "0";
            textBox_ChargeRepartieUniformeqAxeZ.Text = "5";
            textBox_ChargePonctuelleMilieuTraveeQAxeY.Text = "0";
            textBox_ChargePonctuelleMilieuTraveeQAxeZ.Text = "0";
            textBox_MomentMAxeYExtremiteO.Text = "0";
            textBox_MomentMAxeZExtremiteO.Text = "0";
            textBox_MomentMAxeYExtremiteE.Text = "0";
            textBox_MomentMAxeZExtremiteE.Text = "0";
        }


        #endregion

    }
}
