using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TBAppAcier.Interface_Utilisateur__UI_;

namespace TBAppAcier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        #region Button


        #region Données
        private void DiagrammeWindow_Click(object sender, RoutedEventArgs e)
        {

            Diagrammewindow diagrammewindow = new Diagrammewindow();

            diagrammewindow.Show();

        }



        private void Profiles_Click(object sender, RoutedEventArgs e)
        {


            ChoixProfileEtResistance window = new ChoixProfileEtResistance();

            window.Show();


        }



        #endregion



        #region Calculs


        private void menuItem_ClasseSection_Click(object sender, RoutedEventArgs e)
        {
            ClasseSectionWindow window = new ClasseSectionWindow();

            window.Show();
        }




        private void menuItem_Flambage_Click(object sender, RoutedEventArgs e)
        {

            FlambageWindow window = new FlambageWindow();

            window.Show();

        }



        private void menuItem_EffortTranchantMoments_Click(object sender, RoutedEventArgs e)
        {

            ResistanceBaseWindow window = new ResistanceBaseWindow();

            window.Show();

        }


        private void menuItem_MomentsDeversement_Click(object sender, RoutedEventArgs e)
        {


            MomentDeversement window = new MomentDeversement();

            window.Show();


        }


        private void menuItem_StabiliteResistanceSection_Click(object sender, RoutedEventArgs e)
        {
            StabiliteResistanceSectionWindow window = new StabiliteResistanceSectionWindow();

            window.Show();
        }


        private void menuItem_Synthese_Click(object sender, RoutedEventArgs e)
        {

            SyntheseWindow window = new SyntheseWindow();

            window.Show();


        }





        #endregion


        #endregion


    }
}
