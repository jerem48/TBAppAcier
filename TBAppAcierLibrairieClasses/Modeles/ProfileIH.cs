using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using TBAppAcierLibrairieClasses.Maths;
using TBAppAcierLibrairieClasses.Modeles.CoefficientsCTICM;

namespace TBAppAcierLibrairieClasses.Modeles
{
    /// <summary>
    /// Profilé I ou H héritant de la classe Element 1D
    /// </summary>
    public class ProfileIH : Element1D
    {



        /// <summary>
        /// Clé étrangère de la géométrie de profilé I ou H
        /// </summary>
        public int? GeometrieIHSelectionneeIdGeometrieIH { get; set; }



        /// <summary>
        /// Caractéristiques géométriques du profilé
        /// </summary>
        [ForeignKey("GeometrieIHSelectionneeIdGeometrieIH")]
        public GeometrieIH GeometrieIHSelectionnee { get; set; }



        /// <summary>
        /// Nom entier de l'élément
        /// </summary>
        public override string NomEntier
        {
            get
            {

                return $"{NomElement} : {NomPersonnalise}";

            }

            protected set { }
        }



        #region Constructeur

        /// <summary>
        /// Nom du type de profilé
        /// </summary>


        public ProfileIH()
        {
            NomElement = "Profilé I ou H";
        }



       



        public ProfileIH(
            string nompersonnalise,
            string positionnementcharge,
            string coefficientflambageY,
            string coefficientflambageZ,
            string sectionnette,
            bool omegaY1,
            bool omegaZ1,
            NuanceAcier resistanceAcier,
            DiagrammesEffortsInternes diagrammes,
            GeometrieIH geometrieIH
            )
        {


            #region Informations générales


            NomPersonnalise = nompersonnalise;
            NomElement = "Profilé I ou H";


            #endregion



            #region Informations techniques



            double positionnementchargeValue = 0;
            double.TryParse(positionnementcharge, out positionnementchargeValue);
            PositionnementCharge = positionnementchargeValue;

            #endregion



            #region Inputs Effort normal



            double coefficientflambageYValue = 0;
            double.TryParse(coefficientflambageY, out coefficientflambageYValue);
            CoefficientFlambageAxeY = coefficientflambageYValue;


            double coefficientflambageZValue = 0;
            double.TryParse(coefficientflambageZ, out coefficientflambageZValue);
            CoefficientFlambageAxeZ = coefficientflambageZValue;

            double sectionNetteValue = 0;
            double.TryParse(sectionnette, out sectionNetteValue);
            SectionNette = sectionNetteValue;





            #endregion



            #region Stabilité


            OmegaY1 = omegaY1;

            OmegaZ1 = omegaZ1;


            #endregion



            #region Autres classes


            NuanceAcierSelectionnee = resistanceAcier;


            DiagrammesEffortsInternesCalcule = diagrammes;
            Longueur = DiagrammesEffortsInternesCalcule.CombinaisonCharges1DSelectionnee.LongueurElement;


            GeometrieIHSelectionnee = geometrieIH;


            ClasseSectionCalcule = ObtenirClasseSection();
            FlambageCalcule = ObtenirFlambage();
            EffortTranchantCalcule = ObtenirResistanceCisaillement();
            MomentsFlexionnelResistantCalcules = ObtenirResistanceMoments();

            // Moment de déversement selon CTICM
            if ( diagrammes.CombinaisonCharges1DSelectionnee.EffortNormalNed == 0)
            {
                // Charge répartie uniformément
                if (diagrammes.CombinaisonCharges1DSelectionnee.ChargeRepartieUniformeqAxeZ != 0 && diagrammes.CombinaisonCharges1DSelectionnee.ChargeConcentreMilieuTraveeQAxeZ == 0)
                {
                    MomentDeversementCTICMCalcule = ObtientMDRdCTICMAnalytiques(false);
                }

                //Charge concentrée
                // if (diagrammes.CombinaisonCharges1DSelectionnee.ChargeRepartieUniformeqAxeZ == 0 && diagrammes.CombinaisonCharges1DSelectionnee.ChargeConcentreMilieuTraveeQAxeZ != 0)
                // {
                //     MomentDeversementCTICMCalcule = deversementCTICMRealConc;
                // }

                MomentDeversementCTICMCalculeMin = ObtientMDRdCTICMAnalytiques(true);

            }

            // Moment de déversement selon SIA 263
            if (diagrammes.CombinaisonCharges1DSelectionnee.EffortNormalNed!=0 && diagrammes.CombinaisonCharges1DSelectionnee.ChargeRepartieUniformeqAxeZ == 0 && diagrammes.CombinaisonCharges1DSelectionnee.ChargeConcentreMilieuTraveeQAxeZ == 0)
            {
                MomentDeversementSIACalcule = ObtenirMomentDeversementSIA(false);
                MomentDeversementSIACalculeMin = ObtenirMomentDeversementSIA(true);
            }


            if (diagrammes.CombinaisonCharges1DSelectionnee.ChargeConcentreMilieuTraveeQAxeZ == 0)
            {
                StabiliteCalcule = ObtenirResultatEquationStabilite();
            }


            ResistanceSectionCalculee = ObtientResultatEquationResistanceSectionMin();



            #endregion

        }




        public void UpdateProfileIH(
                string nompersonnalise,
                string positionnementcharge,
                string coefficientflambageY,
                string coefficientflambageZ,
                string sectionnette,
                bool omegaY1,
                bool omegaZ1,
                NuanceAcier resistanceAcier,
                DiagrammesEffortsInternes diagrammes,
                GeometrieIH geometrieIH
                )
        {


            #region Informations générales


            NomPersonnalise = nompersonnalise;
            NomElement = "Profilé I ou H";


            #endregion



            #region Informations techniques




            double positionnementchargeValue = 0;
            double.TryParse(positionnementcharge, out positionnementchargeValue);
            PositionnementCharge = positionnementchargeValue;

            #endregion



            #region Effort normal



            double coefficientflambageYValue = 0;
            double.TryParse(coefficientflambageY, out coefficientflambageYValue);
            CoefficientFlambageAxeY = coefficientflambageYValue;


            double coefficientflambageZValue = 0;
            double.TryParse(coefficientflambageZ, out coefficientflambageZValue);
            CoefficientFlambageAxeZ = coefficientflambageZValue;


            double sectionNetteValue = 0;
            double.TryParse(sectionnette, out sectionNetteValue);
            SectionNette = sectionNetteValue;

            #endregion



            #region Stabilité


            OmegaY1 = omegaY1;

            OmegaZ1 = omegaZ1;


            #endregion



            #region Autres classes


            NuanceAcierSelectionnee = resistanceAcier;


            DiagrammesEffortsInternesCalcule = diagrammes;
            Longueur = DiagrammesEffortsInternesCalcule.CombinaisonCharges1DSelectionnee.LongueurElement;


            GeometrieIHSelectionnee = geometrieIH;



            #region Calculs


            ClasseSectionCalcule = ObtenirClasseSection();
            FlambageCalcule = ObtenirFlambage();
            EffortTranchantCalcule = ObtenirResistanceCisaillement();
            MomentsFlexionnelResistantCalcules = ObtenirResistanceMoments();


            if (diagrammes.CombinaisonCharges1DSelectionnee.ChargeRepartieUniformeqAxeZ != 0 && diagrammes.CombinaisonCharges1DSelectionnee.EffortNormalNed == 0 && diagrammes.CombinaisonCharges1DSelectionnee.ChargeConcentreMilieuTraveeQAxeZ == 0)
            {
                MomentDeversementCTICMCalcule = ObtientMDRdCTICMAnalytiques(false);
                MomentDeversementCTICMCalculeMin = ObtientMDRdCTICMAnalytiques(true);
            }



            if (diagrammes.CombinaisonCharges1DSelectionnee.EffortNormalNed != 0 && diagrammes.CombinaisonCharges1DSelectionnee.ChargeRepartieUniformeqAxeZ == 0 && diagrammes.CombinaisonCharges1DSelectionnee.ChargeConcentreMilieuTraveeQAxeZ == 0)
            {
                MomentDeversementSIACalcule = ObtenirMomentDeversementSIA(false);
                MomentDeversementSIACalculeMin = ObtenirMomentDeversementSIA(true);
            }



            StabiliteCalcule = ObtenirResultatEquationStabilite();
            ResistanceSectionCalculee = ObtientResultatEquationResistanceSectionMin();


            #endregion


            #endregion

        }


        #endregion



        #region Methodes 


        #region Epaisseur aile


        private NuanceAcier ObtientNuanceReduite()
        {


            NuanceAcier nuance = NuanceAcierSelectionnee;

            double tf = GeometrieIHSelectionnee.EpaisseurAile;


            if (tf > 40)
            { 
            
                if(nuance.NomNuance == "S235")
                {

                    nuance.LimiteElastique = 215;
                    nuance.LimiteElastiqueCisaillement = 124;
                    nuance.ResistanceTraction = 340;


                }
                else if (nuance.NomNuance == "S275")
                {

                    nuance.LimiteElastique = 255;
                    nuance.LimiteElastiqueCisaillement = 147;
                    nuance.ResistanceTraction = 410;


                }
                else if (nuance.NomNuance == "S355")
                {

                    nuance.LimiteElastique = 335;
                    nuance.LimiteElastiqueCisaillement = 193;
                    nuance.ResistanceTraction = 490;


                }
                else if (nuance.NomNuance == "S460")
                {

                    nuance.LimiteElastique = 430;
                    nuance.LimiteElastiqueCisaillement = 248;
                    nuance.ResistanceTraction = 530;


                }



            }



            return nuance;


        }


        #endregion



        #region Classes de sections


        #region Fonction principale


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ClasseSection ObtenirClasseSection()
        {



            ClasseSection classesection = new ClasseSection();

            classesection = ObtenirClasseSection2();

            if (classesection.ClasseSectionCalculee == 2)
            {


                return classesection;


            }
            else
            {

                return ObtenirClasseSection3();
            
            
            }






        }




        /// <summary>
        /// Classe de section 2 calulée
        /// </summary>
        /// <returns></returns>
        public override ClasseSection ObtenirClasseSection2()
        {

            #region Variables


            double γm1 = NuanceAcier.FacteurPartielGammaM1;
            double fy = ObtientNuanceReduite().LimiteElastique;

            double tw = GeometrieIHSelectionnee.EpaisseurAme;
            double tf = GeometrieIHSelectionnee.EpaisseurAile;
            double r = GeometrieIHSelectionnee.RayonConge;
            double h1 = GeometrieIHSelectionnee.HauteurPortionDroiteAme;
            double b = GeometrieIHSelectionnee.Largeur;
            double A = GeometrieIHSelectionnee.AireTotal;


            ClasseSection classe = new ClasseSection();

            EffortsInternesDistanceX effortsmax = DiagrammesEffortsInternesCalcule.ObtientEffortsInternesMax();

            //Effort normal considéré positif pour la compression
            double Ned = Math.Abs(effortsmax.EffortNormalNed) * 1000;
            double Mz = effortsmax.MomentMAxeZDistanceX * Math.Pow(10, 6);
            double My = effortsmax.MomentMAxeYDistanceX * Math.Pow(10, 6);
            #endregion



            #region Elancement Ame


            #region Elancement limite

            //Calcul de la part de compression dans l'âme

            double hNed = γm1 * Ned / (tw * fy);
            if (effortsmax.EffortNormalNed>0)
            {
                hNed = 0;


            }




            
            double hComprimee = (h1 + hNed) / 2;
            double αAme = 1;
            classe.HauteurComprimeeAme = hComprimee;



            if (hComprimee / h1 >= 1)
            {
                αAme = 1;
            }
            else if (My == 0)
            {
                αAme = hComprimee / h1;
            }
            else
            {
                αAme = hComprimee / h1;
            }
            


            classe.PartEffortPlastiqueAme = αAme;


            if (αAme >= 0.5)
            {

                classe.ElancementLimiteAme = ObtienEpsilon() / (13 * αAme - 1) * 456;


            }
            else
            {

                classe.ElancementLimiteAme = ObtienEpsilon() / αAme * 41.5;


            }

            #endregion



            #region Elancement effectif Ame


            classe.ElancementEffectifAme = h1 / tw;


            #endregion


            #endregion



            #region Elancement Aile


            #region Elancement limite

            //Calcul de la part de compression dans l'aile


            double bmz = MathsAcier.Bissection(b / 2, 100, ObtientLargeurMzAile);

            classe.LargeurComprimeeAile = bmz;

            double AireTractionlimite = A - tf * (b - tw - r * 2) * 2;
            double AireTractionEffective = 0;
            if (effortsmax.EffortNormalNed <= 0)
            {

                AireTractionEffective = Ned / (fy / γm1) * (-1);

            }

            double αAile = bmz / (b - tw - r * 2) * 2;

            classe.PartEffortPlastiqueAile = αAile;




            if (AireTractionEffective > AireTractionlimite)
            {

                classe.ElancementLimiteAile = ObtienEpsilon() / αAile * 10;

            }
            else
            {

                classe.ElancementLimiteAile = ObtienEpsilon() * 10;          

            
            }




            #endregion



            #region Elancement effectif


            classe.ElancementEffectifAile = (b - tw - r * 2) / 2 / tf;


            #endregion



            #endregion



            #region Calcul Classe

            if (classe.ElancementEffectifAme > classe.ElancementLimiteAme || classe.ElancementEffectifAile > classe.ElancementLimiteAile)
            {


                classe.ClasseSectionCalculee = 3;



            }
            else
            {

               
                classe.ClasseSectionCalculee = 2;               



            }


            return classe;

            #endregion


        }



        /// <summary>
        /// Classe de section 3 calulée
        /// </summary>
        /// <returns></returns>
        public override ClasseSection ObtenirClasseSection3()
        {

            #region Variables


            double fy = ObtientNuanceReduite().LimiteElastique;

            double tw = GeometrieIHSelectionnee.EpaisseurAme;
            double tf = GeometrieIHSelectionnee.EpaisseurAile;
            double r = GeometrieIHSelectionnee.RayonConge;
            double h1 = GeometrieIHSelectionnee.HauteurPortionDroiteAme;
            double b = GeometrieIHSelectionnee.Largeur;
            double A = GeometrieIHSelectionnee.AireTotal;


            ClasseSection classe = new ClasseSection();

            EffortsInternesDistanceX effortsmax = DiagrammesEffortsInternesCalcule.ObtientEffortsInternesMax();
            //Effort normal considéré positif pour la compression

            double Ned = effortsmax.EffortNormalNed * 1000;
            double Mz = effortsmax.MomentMAxeZDistanceX * Math.Pow(10, 6);

            #endregion

            

            #region Elancement Ame


            #region Elancement limite

            //Calcul de la part de compression dans l'âme en contrainte élastique

            List<ContraintesElastiques1PointYZ> pointYZs = ObtenirContrainteselastiquesPourClasseSection();
            classe.ContraintesElastiquesMax = new List<ContraintesElastiques1PointYZ>();
            classe.ContraintesElastiquesMax.Add(pointYZs[4]);
            classe.ContraintesElastiquesMax.Add(pointYZs[5]);


            double ψAme = Math.Min(Math.Abs(pointYZs[4].ContrainteNormalSigmaX), Math.Abs(pointYZs[5].ContrainteNormalSigmaX)) / (Math.Max(Math.Abs(pointYZs[4].ContrainteNormalSigmaX), Math.Abs(pointYZs[5].ContrainteNormalSigmaX)))
                * Math.Sign(pointYZs[4].ContrainteNormalSigmaX * pointYZs[5].ContrainteNormalSigmaX);
            
            classe.RapportContraintePsiAme = ψAme;


            if (ψAme >=  -1)
            {

                classe.ElancementLimiteAme = ObtienEpsilon() / (0.67 + 0.33 * ψAme) * 42;

            }
            else
            {

                classe.ElancementLimiteAme = ObtienEpsilon() / (1- ψAme) * 62 * Math.Sqrt(- ψAme);

            }

            #endregion



            #region Elancement effectif Ame


            classe.ElancementEffectifAme = h1 / tw;


            #endregion


            #endregion



            #region Elancement Aile


            #region Elancement limite


            // Calcul de la part de compression dans l'aile en contrainte élastique
            List<double> elancementToutesclassesAiles = new List<double>();
            List<ClasseSection> toutesclassesAiles = new List<ClasseSection>();

            ClasseSection AileSupGauche = ObtientElancementLimiteChaqueAile(pointYZs[0].ContrainteNormalSigmaX, pointYZs[1].ContrainteNormalSigmaX);
            elancementToutesclassesAiles.Add(AileSupGauche.ElancementLimiteAile);
            toutesclassesAiles.Add(AileSupGauche);

            ClasseSection AileSupDroite = ObtientElancementLimiteChaqueAile(pointYZs[3].ContrainteNormalSigmaX, pointYZs[2].ContrainteNormalSigmaX);
            elancementToutesclassesAiles.Add(AileSupDroite.ElancementLimiteAile);
            toutesclassesAiles.Add(AileSupDroite);

            ClasseSection AileInfGauche = ObtientElancementLimiteChaqueAile(pointYZs[6].ContrainteNormalSigmaX, pointYZs[7].ContrainteNormalSigmaX);
            elancementToutesclassesAiles.Add(AileInfGauche.ElancementLimiteAile);
            toutesclassesAiles.Add(AileInfGauche);

            ClasseSection AileInfDroite = ObtientElancementLimiteChaqueAile(pointYZs[9].ContrainteNormalSigmaX, pointYZs[8].ContrainteNormalSigmaX);
            elancementToutesclassesAiles.Add(AileInfDroite.ElancementLimiteAile);
            toutesclassesAiles.Add(AileInfDroite);





            ClasseSection classeDeter = toutesclassesAiles.Find(x => x.ElancementLimiteAile.Equals(elancementToutesclassesAiles.Min()));
            
            classe.RapportContraintePsiAile = classeDeter.RapportContraintePsiAile;
            classe.Valeurintermediairek1 = classeDeter.Valeurintermediairek1;
            classe.ElancementLimiteAile = classeDeter.ElancementLimiteAile;
            foreach (ContraintesElastiques1PointYZ contraintes in classeDeter.ContraintesElastiquesMax)
            {
                classe.ContraintesElastiquesMax.Add(contraintes);
            }



            #endregion



            #region Elancement effectif


            classe.ElancementEffectifAile = (b - tw - r * 2) / 2 / tf;


            #endregion



            #endregion



            #region Calcul Classe

            if (classe.ElancementEffectifAme > classe.ElancementLimiteAme || classe.ElancementEffectifAile > classe.ElancementLimiteAile)
            {


                classe.ClasseSectionCalculee = 4;



            }
            else
            {


                classe.ClasseSectionCalculee = 3;



            }


            return classe;

            #endregion


        }


        #endregion



        #region Valeur intermédiaires et sous-méthodes


        /// <summary>
        /// Obtient la valeur ε correspondant à la résistance élastique
        /// </summary>
        /// <returns></returns>
        private double ObtienEpsilon()
        {

            double fy = ObtientNuanceReduite().LimiteElastique;


            double ε;
            ε = Math.Sqrt(235 / fy);


            return ε;
        }




        /// <summary>
        /// Fonction quadratique pour la largeur bmz
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private double ObtientLargeurMzAile(double x)
        {

            double tf = GeometrieIHSelectionnee.EpaisseurAile;
            double γm1 = NuanceAcier.FacteurPartielGammaM1;
            double fy = ObtientNuanceReduite().LimiteElastique;
            double b = GeometrieIHSelectionnee.Largeur;
           
            EffortsInternesDistanceX effortsmax = DiagrammesEffortsInternesCalcule.ObtientEffortsInternesMax();
            double Mz = effortsmax.MomentMAxeZDistanceX;

            double y;

            // Equation à équilibrer
            y = x * tf * fy / γm1 * (b - x) * 2 - Mz * Math.Pow(10, 6);


            return y;


        }



        private ClasseSection ObtientElancementLimiteChaqueAile(double σxAileExterieure, double σxAileInterieure)
        {

            ClasseSection classe = new ClasseSection();
            classe.ContraintesElastiquesMax = new List<ContraintesElastiques1PointYZ>();
            ContraintesElastiques1PointYZ pointYZExt = new ContraintesElastiques1PointYZ();

            pointYZExt.ContrainteNormalSigmaX = σxAileExterieure;
            classe.ContraintesElastiquesMax.Add(pointYZExt);


            ContraintesElastiques1PointYZ pointYZInt = new ContraintesElastiques1PointYZ();
            pointYZInt.ContrainteNormalSigmaX = σxAileInterieure;
            classe.ContraintesElastiquesMax.Add(pointYZInt);


            // Aile complétement comprimée
            if (σxAileInterieure <= 0 && σxAileExterieure <= 0)
            {
                classe.RapportContraintePsiAile = 1;
                classe.Valeurintermediairek1 = 0;
                classe.ElancementLimiteAile = ObtienEpsilon() * 14;

            }
            // Aile complétement en traction
            else if (σxAileInterieure >= 0 && σxAileExterieure >= 0)
            {

                classe.RapportContraintePsiAile = 0;
                classe.Valeurintermediairek1 = 0;
                classe.ElancementLimiteAile = 10000000;



            }

            // Bout de l'aile comprimé
            else if (σxAileInterieure >= 0 && σxAileExterieure <= 0)
            {
                //Contrainte de traction sur celle de compression
                double ψAile = σxAileExterieure / σxAileInterieure;

                double k2 = 0;

                if (ψAile <= 1 && ψAile >= 0)
                {
                    k2 = 0.578 / (0.34 + ψAile);
                }
                else if (ψAile < 0 && ψAile >= -1)
                {
                
                    k2 = 1.7 - ψAile * 5 + Math.Pow(ψAile, 2) * 17.1;
                
                
                }
                
                classe.RapportContraintePsiAile = ψAile;
                classe.Valeurintermediairek1 = k2;
                classe.ElancementLimiteAile = ObtienEpsilon() * Math.Sqrt(k2) * 21;

            }


            // Bout de l'aile en traction
            else if (σxAileInterieure <= 0 && σxAileExterieure >= 0)
            {
                //Contrainte de traction sur celle de compression
                double ψAile = σxAileInterieure / σxAileExterieure;
                double k1 = 0.57 - ψAile * 0.21 + Math.Pow(ψAile, 2) * 0.07;
                classe.RapportContraintePsiAile = ψAile;
                classe.Valeurintermediairek1 = k1;
                classe.ElancementLimiteAile = ObtienEpsilon() * Math.Sqrt(k1) * 21;


            }


            return classe;

        }


        #endregion



        #endregion



        #region Flambage

        /// <summary>
        /// Permet de calculer le flambage
        /// </summary>
        /// <returns></returns>
        public override Flambage ObtenirFlambage()
        {

            #region Variables


            Flambage flambage = new Flambage();

            double E = NuanceAcier.ModuleElasticite;
            double A = GeometrieIHSelectionnee.AireTotal;
            double h = GeometrieIHSelectionnee.Hauteur;
            double b = GeometrieIHSelectionnee.Largeur;
            double tf = GeometrieIHSelectionnee.EpaisseurAile;
            double γm1 = NuanceAcier.FacteurPartielGammaM1;
            double fy = ObtientNuanceReduite().LimiteElastique;


            double Lky = CoefficientFlambageAxeY * Longueur;
            double Iy = GeometrieIHSelectionnee.MomentInertieAxeY;

            double Lkz = CoefficientFlambageAxeZ * Longueur;
            

            double Iz = GeometrieIHSelectionnee.MomentInertieAxeZ;


            double λE = Math.PI * Math.Sqrt(E / fy);
            flambage.ElancementLimiteelastique = λE;

            #endregion



            #region Facteur d'imperfection


            double αky = 0;

            if (tf <= 100)
            {

                if (tf <= 40 && (h - tf) / b > 1.2)
                {

                    αky = 0.21;


                }
                else
                {

                    αky = 0.34;

                }

            }
            else
            {

                αky = 0.76;

            }


            double αkz = 0;

            if (tf <= 100)
            {

                if (tf <= 40 && (h - tf) / b > 1.2)
                {

                    αkz = 0.34;


                }
                else
                {

                    αkz = 0.49;

                }

            }
            else
            {

                αkz = 0.76;

            }


            #endregion



            #region Axe y


            double σcry = Math.Pow(Math.PI, 2) * E * Iy / Math.Pow(Lky, 2) / A;
            flambage.ContrainteCritiqueAxeY = σcry;

            double Ncry = σcry * A / 1000;
            flambage.EffortNormalCritiqueAxeY = Ncry;

            double λkymoy = Math.Sqrt(fy / σcry);
            flambage.CoefficientElancementY = λkymoy;

            double Φky = (1 + (λkymoy - 0.2) * αky + Math.Pow(λkymoy, 2)) * 0.5;
            double χky
                = 1 / (
                Φky
                + Math.Sqrt(
                    Math.Pow(Φky, 2) - Math.Pow(λkymoy, 2)
                    )
                );

            if (χky >= 1)
            {

                χky = 1;

            }

            flambage.FacteurReductionFlambageChikAxeY = χky;


            double NkyRd = χky * fy * A / γm1 / 1000;
            flambage.RésistanceFlambageAxeY = NkyRd;


            #endregion



            #region Axe z


            double σcrz = Math.Pow(Math.PI, 2) * E * Iz / Math.Pow(Lkz, 2) / A;
            flambage.ContrainteCritiqueAxeZ = σcrz;

            double Ncrz = σcrz * A / 1000;
            flambage.EffortNormalCritiqueAxeZ = Ncrz;

            double λkzmoy = Math.Sqrt(fy / σcrz);
            flambage.CoefficientElancementZ = λkzmoy;

            double Φkz = (1 + (λkzmoy - 0.2) * αkz + Math.Pow(λkzmoy, 2)) * 0.5;
            double χkz
                = 1 / (
                Φkz
                + Math.Sqrt(
                    Math.Pow(Φkz, 2) - Math.Pow(λkzmoy, 2)
                    )
                );
            if (χkz >= 1)
            {

                χkz = 1;

            }

            flambage.FacteurReductionFlambageChikAxeZ = χkz;


            double NkzRd = χkz * fy * A / γm1 / 1000;
            flambage.RésistanceFlambageAxeZ = NkzRd;


            #endregion



            return flambage;

        }



        #endregion



        #region Contraintes élastiques


        /// <summary>
        /// Calcule les contraintes à un point y, z
        /// </summary>
        /// <param name="coordonneeY"></param>
        /// <param name="coordonneeZ"></param>
        /// <returns></returns>
        protected override ContraintesElastiques1PointYZ ObtenirContraintesElastiques(double coordonneeY, double coordonneeZ)
        {


            #region Variables

            ContraintesElastiques1PointYZ contraintes = new ContraintesElastiques1PointYZ();


            contraintes.CoordonnéeY = coordonneeY;
            contraintes.CoordonnéeZ = coordonneeZ;

          
            // Pas de changement d'unité, sauf pour l'effort normal
            double A = GeometrieIHSelectionnee.AireTotal;
            double Iy = GeometrieIHSelectionnee.MomentInertieAxeY * Math.Pow(10, 6);
            double Iz = GeometrieIHSelectionnee.MomentInertieAxeZ * Math.Pow(10, 6);

            EffortsInternesDistanceX effortsmax = DiagrammesEffortsInternesCalcule.ObtientEffortsInternesMax();

            double Ned =  effortsmax.EffortNormalNed * 1000;
            double My = effortsmax.MomentMAxeYDistanceX * Math.Pow(10,6);
            double Mz = effortsmax.MomentMAxeZDistanceX * Math.Pow(10, 6);



            #endregion



            #region Contraintes

            //TODO- Vérifier Valeur de ce calcul, signe de ned pas clair
            double σx =  Ned / A + My * coordonneeZ / Iy - Mz * coordonneeY / Iz;



            contraintes.ContrainteNormalSigmaX = σx;

            //TODO - Contrainte de cisaillement à calculer
            double τxz = 0;


            contraintes.ContrainteTangentielleTauZX = τxz;


            #endregion


            return contraintes;
        }


        /// <summary>
        /// Calcule les contraintes à un point y, z
        /// </summary>
        /// <param name="coordonneeY"></param>
        /// <param name="coordonneeZ"></param>
        /// <returns></returns>
        protected override ContraintesElastiques1PointYZ ObtenirContraintesElastiques(double Ned, double Myed, double Mzed, double Vzed, double coordonneeY, double coordonneeZ)
        {


            #region Variables

            ContraintesElastiques1PointYZ contraintes = new ContraintesElastiques1PointYZ();


            contraintes.CoordonnéeY = coordonneeY;
            contraintes.CoordonnéeZ = coordonneeZ;


            // Pas de changement d'unité, sauf pour l'effort normal
            double A = GeometrieIHSelectionnee.AireTotal;
            double Iy = GeometrieIHSelectionnee.MomentInertieAxeY;
            double Iz = GeometrieIHSelectionnee.MomentInertieAxeZ;

            EffortsInternesDistanceX effortsmax = DiagrammesEffortsInternesCalcule.ObtientEffortsInternesMax();

            // Géométrie supplémentaires

            double b = GeometrieIHSelectionnee.Largeur;
            double h = GeometrieIHSelectionnee.Hauteur;
            double h1 = GeometrieIHSelectionnee.HauteurPortionDroiteAme;

            double tf = GeometrieIHSelectionnee.EpaisseurAile;
            double tw = GeometrieIHSelectionnee.EpaisseurAme;
            double r = GeometrieIHSelectionnee.RayonConge;


            #endregion



            #region Contraintes


            #region Contrainte normal


            //TODO- Vérifier Valeur de ce calcul, signe de ned pas clair
            double σx = Ned / A + Myed * coordonneeZ / Iy - Mzed * coordonneeY / Iz;



            contraintes.ContrainteNormalSigmaX = σx;


            #endregion


            #region Contrainte tangentielle τzx


            double SyAPrime = 0;
            double τxz = 0;
            if (coordonneeZ == -h / 2)
            {


                SyAPrime = 0;
                τxz = 0;

            }
            else if ( coordonneeZ == -h1 / 2)
            {



                SyAPrime =
                    (
                    -b * tf * (h - tf)
                    + ((r * 2 + tw) * r * -(r + h1) / 2 - (Math.Pow(r, 2) / 2) * -(0.424 * r + h1 / 2))
                    );
                τxz = -Vzed * (SyAPrime) / (tw * Iy);




            }
            else if(coordonneeZ == 0)
            {

                SyAPrime =
                   (
                   b * tf * -(h - tf)
                   + ((r * 2 + tw) * r * -(r + h1) / 2 - (Math.Pow(r, 2) / 2) * -(0.424 * r + h1 / 2))
                   + (tw*h1/2))*-(h1/4);
                τxz = -Vzed * (SyAPrime) / (tw * Iy);


            }
            else if (coordonneeZ == h1/2)
            {

                SyAPrime =
                   (
                   b * tf * -(h - tf)
                   + ((r * 2 + tw) * r * -(r + h1) / 2 - (Math.Pow(r, 2) / 2) * -(0.424 * r + h1 / 2))
                   );
                τxz = -Vzed * (SyAPrime) / (tw * Iy);

            }
            else if (coordonneeZ == h / 2)
            {
                SyAPrime = 0;
                τxz = 0;
            }






            //TODO - Contrainte de cisaillement à calculer
            
            

            contraintes.ContrainteTangentielleTauZX = τxz;

            #endregion


            #endregion


            return contraintes;
        }

        /// <summary>
        /// Calcule les contraintes nécessaire pour le calcul de section
        /// </summary>
        /// <returns></returns>
        protected override List<ContraintesElastiques1PointYZ> ObtenirContrainteselastiquesPourClasseSection()
        {


            #region Variables



            double tw = GeometrieIHSelectionnee.EpaisseurAme;
            double tf = GeometrieIHSelectionnee.EpaisseurAile;
            double r = GeometrieIHSelectionnee.RayonConge;
            double h1 = GeometrieIHSelectionnee.HauteurPortionDroiteAme;
            double h = GeometrieIHSelectionnee.Hauteur;
            double b = GeometrieIHSelectionnee.Largeur;

            

            List<ContraintesElastiques1PointYZ> contraintes = new List<ContraintesElastiques1PointYZ>();


            #endregion



            #region Contraintes


            #region Aile supérieure gauche


            ContraintesElastiques1PointYZ contrainteAileSupGaucheGauche = new ContraintesElastiques1PointYZ();

            contrainteAileSupGaucheGauche = ObtenirContraintesElastiques(-b / 2, -(h - tf) / 2);
            contraintes.Add(contrainteAileSupGaucheGauche);


            ContraintesElastiques1PointYZ contrainteAileSupGaucheDroite = new ContraintesElastiques1PointYZ();

            contrainteAileSupGaucheDroite = ObtenirContraintesElastiques(-(b - tw - 2 * r) / 2, -(h - tf) / 2);
            contraintes.Add(contrainteAileSupGaucheDroite);

            #endregion



            #region Aile supérieure droite


            ContraintesElastiques1PointYZ contrainteAileSupDroiteGauche = new ContraintesElastiques1PointYZ();

            contrainteAileSupDroiteGauche = ObtenirContraintesElastiques((b - tw - 2 * r) / 2, -(h - tf) / 2);
            contraintes.Add(contrainteAileSupDroiteGauche);

            ContraintesElastiques1PointYZ contrainteAileSupDroiteDroite = new ContraintesElastiques1PointYZ();

            contrainteAileSupDroiteDroite = ObtenirContraintesElastiques(b / 2, -(h - tf) / 2);
            contraintes.Add(contrainteAileSupDroiteDroite);

            #endregion



            #region Ame

            ContraintesElastiques1PointYZ contrainteAmeHaut= new ContraintesElastiques1PointYZ();

            contrainteAmeHaut = ObtenirContraintesElastiques(0, -h1/2);
            contraintes.Add(contrainteAmeHaut);

            ContraintesElastiques1PointYZ contrainteAmeBas = new ContraintesElastiques1PointYZ();

            contrainteAmeBas = ObtenirContraintesElastiques(0 , h1/2);
            contraintes.Add(contrainteAmeBas);


            #endregion



            #region Aile inférieure gauche


            ContraintesElastiques1PointYZ contrainteAileSInfGaucheGauche = new ContraintesElastiques1PointYZ();

            contrainteAileSInfGaucheGauche = ObtenirContraintesElastiques(-b / 2, (h - tf) / 2);
            contraintes.Add(contrainteAileSInfGaucheGauche);


            ContraintesElastiques1PointYZ contrainteAileInfGaucheDroite = new ContraintesElastiques1PointYZ();

            contrainteAileInfGaucheDroite = ObtenirContraintesElastiques(-(b - tw - 2 * r) / 2, (h - tf) / 2);
            contraintes.Add(contrainteAileInfGaucheDroite);

            #endregion



            #region Aile inférieure droite


            ContraintesElastiques1PointYZ contrainteAileInfDroiteGauche = new ContraintesElastiques1PointYZ();

            contrainteAileInfDroiteGauche = ObtenirContraintesElastiques((b - tw - 2 * r) / 2, (h - tf) / 2);
            contraintes.Add(contrainteAileInfDroiteGauche);

            ContraintesElastiques1PointYZ contrainteAileInfDroiteDroite = new ContraintesElastiques1PointYZ();

            contrainteAileInfDroiteDroite = ObtenirContraintesElastiques(b / 2, (h - tf) / 2);
            contraintes.Add(contrainteAileInfDroiteDroite);

            #endregion


            #endregion



            return contraintes;


        }


        /// <summary>
        /// Contraintes de comparaison selon Von Mises
        /// </summary>
        /// <param name="Ned"></param>
        /// <param name="Myed"></param>
        /// <param name="Mzed"></param>
        /// <param name="Vzed"></param>
        /// <returns></returns>
        protected override ContraintesElastiques1PointYZ ObtenirContrainteelastiqueMaxResistanceSection(double Ned, double Myed, double Mzed, double Vzed)
        {

            List<ContraintesElastiques1PointYZ> contraintesComparaison = new List<ContraintesElastiques1PointYZ>();

            ContraintesElastiques1PointYZ contraintesMax = new ContraintesElastiques1PointYZ();


            #region Variables


            double b = GeometrieIHSelectionnee.Largeur;
            double h = GeometrieIHSelectionnee.Hauteur;
            double h1 = GeometrieIHSelectionnee.HauteurPortionDroiteAme;

            double tf = GeometrieIHSelectionnee.EpaisseurAile;
            double tw = GeometrieIHSelectionnee.EpaisseurAme;
            double r = GeometrieIHSelectionnee.RayonConge;


            #endregion



            #region Aile Sup


            #region Point à gauche


            ContraintesElastiques1PointYZ contrainteAileSupGauche = ObtenirContraintesElastiques(Ned, Myed, Mzed, Vzed ,- b / 2, -h / 2);
            double σcompAileSupGauche = ObtientContrainteComparaison(contrainteAileSupGauche.ContrainteNormalSigmaX, contrainteAileSupGauche.ContrainteTangentielleTauZX);

            contrainteAileSupGauche.ContrainteComparaisonVonMises = σcompAileSupGauche;

            contraintesComparaison.Add(contrainteAileSupGauche);


            #endregion



            #region Point au milieu


            ContraintesElastiques1PointYZ contrainteAileSupMilieu = ObtenirContraintesElastiques(Ned, Myed, Mzed, Vzed, 0, -h / 2);
            double σcompAileSupMilieu = ObtientContrainteComparaison(contrainteAileSupMilieu.ContrainteNormalSigmaX, contrainteAileSupMilieu.ContrainteTangentielleTauZX);

            contrainteAileSupMilieu.ContrainteComparaisonVonMises = σcompAileSupMilieu;

            contraintesComparaison.Add(contrainteAileSupMilieu);


            #endregion



            #region Point à droite


            ContraintesElastiques1PointYZ contrainteAileSupDroite = ObtenirContraintesElastiques(Ned, Myed, Mzed, Vzed, b /2, -h / 2);
            double σcompAileSupDroite = ObtientContrainteComparaison(contrainteAileSupDroite.ContrainteNormalSigmaX, contrainteAileSupDroite.ContrainteTangentielleTauZX);

            contrainteAileSupDroite.ContrainteComparaisonVonMises = σcompAileSupDroite;

            contraintesComparaison.Add(contrainteAileSupDroite);


            #endregion


            #endregion



            #region Ame


            #region Point en haut, niveau bas du congé


            ContraintesElastiques1PointYZ contrainteAmeHaut = ObtenirContraintesElastiques(Ned, Myed, Mzed, Vzed, 0, -h1 / 2);
            double σcompAmeHaut = ObtientContrainteComparaison(contrainteAmeHaut.ContrainteNormalSigmaX, contrainteAmeHaut.ContrainteTangentielleTauZX);

            contrainteAmeHaut.ContrainteComparaisonVonMises = σcompAmeHaut;

            contraintesComparaison.Add(contrainteAmeHaut);


            #endregion



            #region Point au milieu


            ContraintesElastiques1PointYZ contrainteAmeMilieu = ObtenirContraintesElastiques(Ned, Myed, Mzed, Vzed, 0, 0);
            double σcompAmeMilieu = ObtientContrainteComparaison(contrainteAmeMilieu.ContrainteNormalSigmaX, contrainteAmeMilieu.ContrainteTangentielleTauZX);

            contrainteAmeMilieu.ContrainteComparaisonVonMises = σcompAmeMilieu;

            contraintesComparaison.Add(contrainteAmeMilieu);


            #endregion



            #region Point en bas, niveau bas du congé


            ContraintesElastiques1PointYZ contrainteAmeBas = ObtenirContraintesElastiques(Ned, Myed, Mzed, Vzed, 0, h1/2);
            double σcompAmeBas = ObtientContrainteComparaison(contrainteAmeBas.ContrainteNormalSigmaX, contrainteAmeBas.ContrainteTangentielleTauZX);

            contrainteAmeBas.ContrainteComparaisonVonMises = σcompAmeBas;

            contraintesComparaison.Add(contrainteAmeBas);


            #endregion


            #endregion



            #region Aile Inf


            #region Point à gauche


            ContraintesElastiques1PointYZ contrainteAileInfGauche = ObtenirContraintesElastiques(Ned, Myed, Mzed, Vzed, -b / 2, h / 2);
            double σcompAileInfGauche = ObtientContrainteComparaison(contrainteAileInfGauche.ContrainteNormalSigmaX, contrainteAileInfGauche.ContrainteTangentielleTauZX);

            contrainteAileInfGauche.ContrainteComparaisonVonMises = σcompAileInfGauche;

            contraintesComparaison.Add(contrainteAileInfGauche);


            #endregion



            #region Point au milieu


            ContraintesElastiques1PointYZ contrainteAileInfMilieu = ObtenirContraintesElastiques(Ned, Myed, Mzed, Vzed, 0, h / 2);
            double σcompAileInfMilieu = ObtientContrainteComparaison(contrainteAileInfMilieu.ContrainteNormalSigmaX, contrainteAileInfMilieu.ContrainteTangentielleTauZX);

            contrainteAileInfMilieu.ContrainteComparaisonVonMises = σcompAileInfMilieu;

            contraintesComparaison.Add(contrainteAileInfMilieu);


            #endregion



            #region Point à droite


            ContraintesElastiques1PointYZ contrainteAileInfDroite = ObtenirContraintesElastiques(Ned, Myed, Mzed, Vzed, b / 2, h / 2);
            double σcompAileInfDroite = ObtientContrainteComparaison(contrainteAileInfDroite.ContrainteNormalSigmaX, contrainteAileInfDroite.ContrainteTangentielleTauZX);

            contrainteAileInfDroite.ContrainteComparaisonVonMises = σcompAileInfDroite;

            contraintesComparaison.Add(contrainteAileInfDroite);


            #endregion


            #endregion



            #region Contrainte de comparaison max


            int indexContrainteMax = contraintesComparaison.FindIndex(x=> x.ContrainteComparaisonVonMises.Equals(contraintesComparaison.Max()));

            contraintesMax = contraintesComparaison[indexContrainteMax];

            #endregion




            return contraintesMax;


        }

        #endregion



        #region Résistance




        /// <summary>
        /// Résistance au cisaillement pour les classes 1 et 2
        /// </summary>
        /// <returns></returns>
        public override double ObtenirResistanceCisaillementClasse2()
        {
            double VRd = 0;


            double τy = ObtientNuanceReduite().LimiteElastiqueCisaillement;
            double γm1 = NuanceAcier.FacteurPartielGammaM1;

            double Av = GeometrieIHSelectionnee.AireAmeAvecConge;


            VRd = τy * Av / γm1 / 1000;


            return VRd;
        }



        /// <summary>
        /// Résistance au cisaillement pour la classe 3
        /// </summary>
        /// <returns></returns>
        public override double ObtenirResistanceCisaillementClasse3()
        {
            double VRd = 0;


            double τy = ObtientNuanceReduite().LimiteElastiqueCisaillement;
            double γm1 = NuanceAcier.FacteurPartielGammaM1;

            double Aw = GeometrieIHSelectionnee.AireAmeSansConge;


            VRd = τy * Aw / γm1 / 1000;


            return VRd;
        }



        /// <summary>
        /// Résistance au cisaillement
        /// </summary>
        /// <returns></returns>
        public override EffortTranchant ObtenirResistanceCisaillement()
        {

            EffortTranchant tranchant = new EffortTranchant();

            ClasseSection classe = ClasseSectionCalcule;


            #region Resistance Effort tranchant

            double VRdz = 0;


            if (classe.ClasseSectionCalculee == 2)
            {
                VRdz = ObtenirResistanceCisaillementClasse2();
                tranchant.RésistanceCisaillementZ = VRdz;

            }
            else if (classe.ClasseSectionCalculee == 3)
            {
                VRdz = ObtenirResistanceCisaillementClasse3();

                tranchant.RésistanceCisaillementZ = VRdz;

            }
            else
            {

                tranchant.RésistanceCisaillementZ = 0;


            }


            #endregion



            #region Voilement cisaillement


            #region Axe z


            double E = NuanceAcier.ModuleElasticite;
            double ν = NuanceAcier.CoefficientPoisson;
            double τ = ObtientNuanceReduite().LimiteElastiqueCisaillement;
            double fy = ObtientNuanceReduite().LimiteElastique;

            double γm1 = NuanceAcier.FacteurPartielGammaM1;




            double L = Longueur;
            double h = GeometrieIHSelectionnee.Hauteur;
            double tw = GeometrieIHSelectionnee.EpaisseurAme;
            double tf = GeometrieIHSelectionnee.EpaisseurAile;

            //TODO - h-tf
            double αy = L / (h - tf) * 1000;
            double kt = 0;


            if (αy > 1)
            {

                kt = 5.34 + 4.0 / Math.Pow(αy, 2);

            }
            else
            {

                kt = 4 + 5.34 / Math.Pow(αy, 2);

            }


            tranchant.CoefficientVoilementCisaillementZ = kt;



            double τcry = kt
                * (
                Math.Pow(Math.PI, 2)
                * E)
                /
                (
                (1 - Math.Pow(ν, 2))
                * 12
                )
                * Math.Pow(tw / (h - tf), 2);


            tranchant.ContrainteCritiqueCisaillementZ = τcry;


            double VRdVoilementZ = Math.Sqrt(τcry * τ) * (h - tf) * tw / γm1 * 0.9 / 1000;

            double VRdVoilementZLim = τ * (h - tf) * tw / γm1 / 1000;


            if (VRdVoilementZ > VRdVoilementZLim)
            {

                VRdVoilementZ = VRdVoilementZLim;

            }
            tranchant.RésistanceVoilementCisaillementZ = VRdVoilementZ;


            double VRdMinz = Math.Min(VRdVoilementZ, VRdz);

            tranchant.RésistanceCisaillementMinZ = VRdMinz;
            //Critère 5.1.4.2 SIA 263 seulement valable pour classe de section 1/2
            if (ClasseSectionCalcule.ClasseSectionCalculee == 2 && (h - tf) / tw <= Math.Sqrt(E / fy * 4))
            {

                tranchant.RésistanceCisaillementMinZ = VRdz;



            }
                
                
            


            #endregion



            

            #endregion



            return tranchant;
        }


        /// <summary>
        /// Résistances au moments flexionnels MyRd et MzRd
        /// MyRd prend en compte Vz
        /// </summary>
        /// <returns></returns>
        public override MomentsFlexionnelResistant ObtenirResistanceMoments()
        {


            MomentsFlexionnelResistant moments = new MomentsFlexionnelResistant();


            #region Variables

            double fy = ObtientNuanceReduite().LimiteElastique;
            double γm1 = NuanceAcier.FacteurPartielGammaM1;



            EffortsInternesDistanceX efforts = DiagrammesEffortsInternesCalcule.ObtientEffortsInternesMax();

            double Ned = efforts.EffortNormalNed;
            double Vzed = efforts.EffortTranchanVAxeZDistanceX;
            double VzRd = EffortTranchantCalcule.RésistanceCisaillementMinZ;
            double rapportVz = Vzed / VzRd;
            moments.PartEffortTranchantZ = rapportVz;


            double Wply = GeometrieIHSelectionnee.ModuleFlexionPlastiqueAxeY;
            double Wely = GeometrieIHSelectionnee.ModuleFlexionElastiqueAxeY;

            double Wplz = GeometrieIHSelectionnee.ModuleFlexionPlastiqueAxeZ;
            double Welz = GeometrieIHSelectionnee.ModuleFlexionElastiqueAxeZ;



            double tw = GeometrieIHSelectionnee.EpaisseurAme;
            double tf = GeometrieIHSelectionnee.EpaisseurAile;
            double h = GeometrieIHSelectionnee.Hauteur;
            double h2 = GeometrieIHSelectionnee.DistanceAilesProfile;
            double b = GeometrieIHSelectionnee.Largeur;

            double fu = ObtientNuanceReduite().ResistanceTraction;
            double Anet = SectionNette;
            double γm2 = NuanceAcier.FacteurPartielGammaM2;
            double A = GeometrieIHSelectionnee.AireTotal;


            #endregion



            #region Effort normal

            double NRd;
            // Equation 38

            if (Ned <= 0)
            {
                NRd = fy * A / γm1;
            }

            /// Equation 39
            else
            {

                NRd = Math.Min(fy * A / γm1, fu * Anet / γm2 * 0.9);

            }

            moments.EffortNormalResistant = NRd /1000;

            #endregion



            #region Moment flexionnel y

            double MyRd = 0;

            if (ClasseSectionCalcule.ClasseSectionCalculee == 2)
            {

                if (rapportVz <= 0.5)
                {

                    // Unité : transforme de Nmm à kNm avec W x 10^3
                    MyRd = fy * Wply / γm1 / Math.Pow(10, 3);

                }
                else
                {

                    // Unité : transforme de Nmm à kNm avec W x 10^3
                    MyRd = (b * tf * fy * (h - tf) / γm1 + Math.Pow(h2, 2) * tw * fy / (4 * γm1) * (1 - Math.Pow(Vzed / VzRd, 2))) / Math.Pow(10,6);



                }

            }
            else if (ClasseSectionCalcule.ClasseSectionCalculee == 3)
            {

                if (rapportVz <= 0.5)
                {

                    // Unité : transforme de Nmm à kNm avec W x 10^3
                    MyRd = fy * Wely / γm1 / Math.Pow(10, 3);

                }
                else
                {


                    // Unité : transforme de Nmm à kNm 
                    MyRd = (b * tf * fy * (h - tf) / γm1 + Math.Pow(h2, 2) * tw * fy / (6 * γm1) * (1 - Math.Pow(Vzed / VzRd, 2))) / Math.Pow(10, 6);



                }

            }
            else
            {

                MyRd = 0;
            
            }

            moments.MomentFlexionResistantY = MyRd;

            #endregion



            #region Moment flexionnel z

            double MzRd = 0;

            if (ClasseSectionCalcule.ClasseSectionCalculee == 2)
            {

                // Unité : transforme de Nmm à kNm avec W x 10^3
                MzRd = fy * Wplz / γm1 / Math.Pow(10, 3);

            }
            else if (ClasseSectionCalcule.ClasseSectionCalculee == 3)
            {

                // Unité : transforme de Nmm à kNm avec W x 10^3
                MzRd = fy * Welz / γm1 / Math.Pow(10, 3);

            }
            else
            {

                MzRd = 0;

            }

            moments.MomentFlexionResistantZ = MzRd;

            #endregion



            return moments;


        }


        #endregion



        #region Moment de déversement





        #region SIA



        public override MomentDeversementSIA ObtenirMomentDeversementSIA(bool MDRdmin)
        {

            MomentDeversementSIA momentDeversementSIA = new MomentDeversementSIA();





            double MyO = ObtenirMomentExtremiteGaucheO();
            momentDeversementSIA.MomentExtremiteO = MyO;
            double MyE = ObtenirMomentExtremiteDroiteE();
            momentDeversementSIA.MomentExtremiteE = MyE;


            double ψ = ObtenirRapportMomentsExtremitePsi();
            double μ = 0;
            double η = 0;



            if (MDRdmin != true)
            {
                if (ψ == 1 && μ == 0)
                {

                   
                    μ = 0;
                    η = 1;

                }
                else
                {
                    η = ObtientCoefficientC1CTICMAnalytiquement(ψ, μ)[0];
                }
            }
            else
            {

                ψ = 1;
                η = 1;


            }



            momentDeversementSIA.LongueurDeversementCritique = ObtenirLongueurCritiqueDéversement(ψ);

            momentDeversementSIA.CoefficientMomentEta = η;
            momentDeversementSIA.RapportMomentsExtremitePsi = ψ;




            momentDeversementSIA = ObtenirMomentCritiqueDeversementSIA(momentDeversementSIA);
            double Mcr = momentDeversementSIA.MomentCritiqueDeversement;

            #region Moment réduit
            double λDmoy = ObtientMomentDeversement(Mcr)[0];
            momentDeversementSIA.ElancementReduitDeversement = λDmoy;

            double χD = ObtientMomentDeversement(Mcr)[1];
            momentDeversementSIA.FacteurReductionDeversementChi = χD;

            double MDRd = ObtientMomentDeversement(Mcr)[2];
            momentDeversementSIA.MomentResistantReduit = MDRd;
            #endregion



            return momentDeversementSIA;


        }



        public override MomentDeversementSIA ObtenirMomentCritiqueDeversementSIA(MomentDeversementSIA SIA)
        {
            double MO = SIA.MomentExtremiteO;
            double ME = SIA.MomentExtremiteE;

            double Mmax = Math.Max(Math.Abs(MO), Math.Abs(ME));

            //Géométrie
            double A = GeometrieIHSelectionnee.AireTotal;
            double b = GeometrieIHSelectionnee.Largeur;
            double h = GeometrieIHSelectionnee.Hauteur;
            double h2 = GeometrieIHSelectionnee.DistanceAilesProfile;

            double tf = GeometrieIHSelectionnee.EpaisseurAile;
            double tw = GeometrieIHSelectionnee.EpaisseurAme;

            double LD = Longueur * 1000;
            double Wely = GeometrieIHSelectionnee.ModuleFlexionElastiqueAxeY *1000;
            double E = NuanceAcier.ModuleElasticite;
            double G = NuanceAcier.ModuleGlissement;
            double K = GeometrieIHSelectionnee.MomentInertieAxeX * Math.Pow(10, 6);
            double Iz = GeometrieIHSelectionnee.MomentInertieAxeZ * Math.Pow(10, 6);
            double Iy = GeometrieIHSelectionnee.MomentInertieAxeY * Math.Pow(10, 6);

            // Effort normal
            double Ned = DiagrammesEffortsInternesCalcule.CombinaisonCharges1DSelectionnee.EffortNormalNed * 1000;

            double iD = 1;
            // Calcul de iD avec réduction selon Ned
            if (Ned < 0)
            {
                double ZaN = -Ned * Iy / (A * Mmax * Math.Pow(10, 6));
                if (ZaN > (h2 + tf) / 2)
                {
                    ZaN = (h2 + tf) / 2;
                }

                double hc = (h2 + tf) / 2 + ZaN;
                double Zc = hc / 3;
                double ham = (h2 + tf) / 2 - Zc;

                double Izc = Iz / 2 - ham * Math.Pow(tw, 3) / 12;
                double Ac = A / 2 - ham * tw;
                iD = Math.Sqrt(Izc / Ac);
            }
            else
            {
                iD =
                    Math.Sqrt(
                        (
                        Math.Pow(b, 3) * tf
                        ) / (
                        (b * tf + (h - tf) / 6 * tw) * 12
                        )
                        );
            }

            SIA.RayonGirationMembrureComprimée = iD;

            double η = SIA.CoefficientMomentEta;

            double σDv = η * Math.PI / (LD * Wely) * Math.Sqrt(G*K*E*Iz);
            SIA.ContrainteTorsionUniforme = σDv;

            double σDw = η * Math.Pow(iD, 2) * Math.Pow(Math.PI, 2) * E / Math.Pow(LD, 2);
            SIA.ContrainteTorsionNonUniforme = σDw;

            double σcrD = Math.Sqrt(Math.Pow(σDv, 2) + Math.Pow(σDw, 2));
            SIA.ContrainteCritiqueDeversement = σcrD;



            double Mcr = σcrD * Wely;

            SIA.MomentCritiqueDeversement = Mcr;

            return SIA;


        }



        #endregion



        #region Calculs intermédiaires et indicatifs

        /// <summary>
        /// Obtient le moment à l'extrêmité gauche Mo
        /// </summary>
        /// <returns></returns>
        public override double ObtenirMomentExtremiteGaucheO()
        {
            // double LongueurBarre = 0;
            // if (NombreAppuisFourches == 0)
            // {
            // 
            //     LongueurBarre = Longueur;
            // 
            // }
            // else 
            // {
            //     LongueurBarre = Longueur / NombreAppuisFourches;
            // }
          
            List<EffortsInternesDistanceX> efforts = DiagrammesEffortsInternesCalcule.ObtientEffortsInternes();


            //double xStartReal = NumeroBarre * LongueurBarre;
            //double xStartUnder = Math.Floor(xStartReal);
            //double xStartOver = Math.Ceiling(xStartReal);
            //
            //
            //double MomentYStartUnder = efforts[(int)xStartUnder].MomentMAxeYDistanceX;
            //double MomentYStartOver = efforts[(int)xStartOver].MomentMAxeYDistanceX;
            //
            //double MomentYStartReal = MomentYStartUnder + (MomentYStartOver - MomentYStartUnder) * (xStartReal - xStartUnder);
            
            double MomentYStartReal = efforts[0].MomentMAxeYDistanceX;
            return MomentYStartReal;


        }


        /// <summary>
        /// Obtient le moment à l'extrêmité gauche Me
        /// </summary>
        /// <returns></returns>
        public override double ObtenirMomentExtremiteDroiteE()
        {
                      

            List<EffortsInternesDistanceX> efforts = DiagrammesEffortsInternesCalcule.ObtientEffortsInternes();

            int Nbefforts = efforts.Count();


            double MomentYEndReal = efforts[Nbefforts - 1].MomentMAxeYDistanceX;


          



            return MomentYEndReal;


        }





        /// <summary>
        /// Calcul le rapport des moments aux extrêmités signé ψ
        /// Unit = [-]
        /// </summary>
        /// <returns></returns>
        public override double ObtenirRapportMomentsExtremitePsi()
        {


            double ψ = 0;

            double MomentYStartReal = ObtenirMomentExtremiteGaucheO();
            double MomentYEndReal = ObtenirMomentExtremiteDroiteE();


            #region Psi

            if (MomentYStartReal == 0 && MomentYEndReal == 0)
            {

                ψ = 1;

            }
            else
            {

                ψ = Math.Min(Math.Abs(MomentYStartReal), Math.Abs(MomentYEndReal)) / Math.Max(Math.Abs(MomentYStartReal), Math.Abs(MomentYEndReal)) * (Math.Sign(MomentYStartReal * MomentYEndReal));

            }
            #endregion


            return ψ;



        }



        /// <summary>
        /// Longueur critique de déversement indicative selon la SIA 263 Lcr
        /// Unit = [m]
        /// </summary>
        /// <returns></returns>
        public override double ObtenirLongueurCritiqueDéversement(double ψ)
        {

            double Lcr = 0;
            double iz = GeometrieIHSelectionnee.RayonGirationAxeZ;
            double fy = ObtientNuanceReduite().LimiteElastique;
            double E = NuanceAcier.ModuleElasticite;
            Lcr = iz * (1 - 0.5 * ψ) * Math.Sqrt(E / fy) * 2.7 / 1000;


            return Lcr;

        }



        /// <summary>
        /// Calcul le rapport entre le moment isostatique crée par les charges et le moment max
        /// </summary>
        /// <returns></returns>
        public override double ObtenirRapportMomentIsoMomentExtremiteMu()
        {
            #region Variables


            CombinaisonCharges1D combinaison = DiagrammesEffortsInternesCalcule.CombinaisonCharges1DSelectionnee;

            double μ = 0;
            double L = Longueur;



            #endregion


            #region μ


            List<double> MExtremite = new List<double>();

            double MomentOAbs = Math.Abs(ObtenirMomentExtremiteGaucheO());
            MExtremite.Add(ObtenirMomentExtremiteGaucheO());

            double MomentEAbs = Math.Abs(ObtenirMomentExtremiteDroiteE());
            MExtremite.Add(ObtenirMomentExtremiteDroiteE());


            double Mmax = Math.Max(MomentOAbs, MomentEAbs);
            int indexMmax = MExtremite.FindIndex(x => Math.Abs(x) == Mmax);
            double MmaxSigne = Mmax * Math.Sign(MExtremite[indexMmax]);

            if (combinaison.ChargeConcentreMilieuTraveeQAxeZ == 0)
            {

                double q = combinaison.ChargeRepartieUniformeqAxeZ;
                μ = q * Math.Pow(L, 2) / MmaxSigne / 8;


            }
            else if (combinaison.ChargeRepartieUniformeqAxeZ == 0)
            {


                double Q = combinaison.ChargeConcentreMilieuTraveeQAxeZ;
                μ = Q * L / MmaxSigne / 4;



            }
           

            

            #endregion

            return μ;

        }










        /// <summary>
        /// Obtient le moment critique selon CTICM avec C1 et C2
        /// </summary>
        /// <param name="C1"></param>
        /// <param name="C2"></param>
        /// <returns></returns>
        public override double ObtientMomentCritiqueAvecC1C2(double C1, double C2)
        {

            double E = NuanceAcier.ModuleElasticite;
            double Iz = GeometrieIHSelectionnee.MomentInertieAxeZ * Math.Pow(10, 6);
            double G = NuanceAcier.ModuleGlissement;
            double It = GeometrieIHSelectionnee.MomentInertieAxeX * Math.Pow(10, 6);
            double zg = PositionnementCharge;

            double Lmm = Longueur * 1000;
            double tf = GeometrieIHSelectionnee.EpaisseurAile;
            double h = GeometrieIHSelectionnee.Hauteur;
            double largeur = GeometrieIHSelectionnee.Largeur;

            double Iω = tf * Math.Pow(h - tf, 2) * Math.Pow(largeur / 2, 3) / 3;





            double Mcr
                = C1 * Math.Pow(Math.PI, 2) * E * Iz / Math.Pow(Lmm, 2) *
                (
                Math.Sqrt(
                    Iω / Iz + Math.Pow(Lmm, 2) * G * It / (Math.Pow(Math.PI, 2) * E * Iz)
                    + Math.Pow(C2 * zg, 2)
                    ) - C2 * zg
                );


            
            return Mcr;
        }



        //Calcul moment de déversement MDRd à partir du moment critique Mcr
        public override List<double> ObtientMomentDeversement(double Mcr)
        {

            List<double> petole = new List<double>();

            double fy = ObtientNuanceReduite().LimiteElastique;
            double Wply = GeometrieIHSelectionnee.ModuleFlexionPlastiqueAxeY * 1000;
            double Wely = GeometrieIHSelectionnee.ModuleFlexionElastiqueAxeY * 1000;

            double λDmoy = 0;

            if (ClasseSectionCalcule.ClasseSectionCalculee == 2)
            {

                λDmoy = Math.Sqrt((Wply * fy) / Mcr);

                if (λDmoy < 0.4)
                {

                    λDmoy = 0.4;

                }


            }
            else if (ClasseSectionCalcule.ClasseSectionCalculee == 3)
            {

                λDmoy = Math.Sqrt((Wely * fy) / Mcr);

                if (λDmoy < 0.4)
                {

                    λDmoy = 0.4;

                }


            }

            petole.Add(λDmoy);


            //Profilés laminés
            double ΦD = (1 + (λDmoy - 0.4) * 0.21 + Math.Pow(λDmoy, 2)) * 0.5;

            double χD = 1 / (ΦD + Math.Sqrt(Math.Pow(ΦD, 2) - Math.Pow(λDmoy, 2)));
            if (χD > 1)
            {
                χD = 1;
            }

            petole.Add(χD);

            double MyRd = MomentsFlexionnelResistantCalcules.MomentFlexionResistantY;

            double MDRd = MyRd * χD;

            petole.Add(MDRd);

            return petole;


        }







        


        #region Partie pour charge répartie (Annexe de la norme française)


        /// <summary>
        /// Calcule le coefficient C1 analytiquement selon l'annexe de la norme française
        /// </summary>
        /// <returns></returns>
        public override List<double> ObtientCoefficientC1CTICMAnalytiquement(double ψ, double μ)
        {

            List<double> C1C2 = new List<double>();

            #region Facteur type de charge C1

            double β = ψ + μ * 4 - 1;
            double γ = Math.Pow(β, 2) - μ * 8;


            double a = (1 + β) * 0.5 + γ * 0.1413364 - β * μ * 0.6960364 + Math.Pow(μ, 2) * 0.9126223;
            double b = (1 + β) * 0.5 + γ * 0.1603341 - β * μ * 0.9240091 + Math.Pow(μ, 2) * 1.4281556;
            double c = -β * 0.1801266 - γ * 0.0900633 + β * μ * 0.5940757 - Math.Pow(μ, 2) * 0.9352904;

            double A = a * b - Math.Pow(c, 2);
            double B = a * 2 + b / 2;





            double d1 = Math.Abs(μ + (1 + ψ) * 0.52);
            double e1 = 0.3;

            double r1 = 0;

            if (d1 > e1)
            {

                r1 = 1;

            }
            else
            {

                double f1 = 0.88 - ψ * 0.04;
                r1 = f1 + ((1 - f1) * d1 / e1);

            }




            double zheta = 0.5 - (1 - ψ) / (μ * 8);

            if (zheta > 1)
            {
                zheta = 1;
            }
            else if (zheta < 0)
            {
                zheta = 0;
            }

            double m = Math.Abs(1 - (1 - ψ) * zheta + (1 - zheta) * μ * zheta * 4);
            if (m < 1)
            {

                m = 1;

            }






            double C10
                = Math.Sqrt(
                    (
                    B - Math.Sqrt(
                        Math.Pow(B, 2) - A * 4
                        )
                    ) / (A * 2)
                    );


            double C1 = C10 * m;

            if (Math.Abs(μ) > 100)
            {

                C1 = 1.127;

            }

            C1C2.Add(C1);

            #endregion



            #region Facteur de positionement de la charge C2


            double d2 = Math.Abs(0.425 + μ + ψ * 0.675);
            double e2 = 0.65 - ψ * 0.35;



            double r2 = 0;

            if (d2 > e2)
            {

                r2 = 1;

            }
            else
            {

                double f2 = 0.81 + ψ * 0.05;
                r2 = f2 + ((1 - f2) * d2 / e2);

            }



            double C2 = r2 * Math.Abs(μ) * C10 * 0.398;


            if (Math.Abs(μ) > 100)
            {

                C2 = 0.454;

            }

            C1C2.Add(C2);



            #endregion

            return C1C2;
        }




        /// <summary>
        /// Obtient les coefficients C1 et C2 analytiquement à partir de l'annexe MCR - moment critique de déversement élastique de la norme française.
        /// </summary>
        /// <param name="NumeroBarre"></param>
        /// <returns></returns>
        public override MomentDeversementCTICM ObtientMDRdCTICMAnalytiques(bool MDRdMin)
        {

            MomentDeversementCTICM deversementCTICM = new MomentDeversementCTICM();


            #region Informations générales ( Moments, géométrie, ψ)



            double L = Longueur;


            double MomentOAbs = Math.Abs(ObtenirMomentExtremiteGaucheO());
            deversementCTICM.MomentExtremiteO = MomentOAbs;
            double MomentEAbs = Math.Abs(ObtenirMomentExtremiteDroiteE());
            deversementCTICM.MomentExtremiteE = MomentEAbs;


            double ψ = 0;
            double μ = 0;
            double C1 = 0;
            double C2 = 0;

            if (MDRdMin != true)
            {
                if (ψ == 1 && μ == 0)
                {

                    ψ = 1;
                    μ = 0;
                    C1 = 1;
                    C2 = 0;

                }
                else
                {
                    ψ = ObtenirRapportMomentsExtremitePsi();
                    μ = ObtenirRapportMomentIsoMomentExtremiteMu();
                    C1 = ObtientCoefficientC1CTICMAnalytiquement(ψ, μ)[0];
                    C2 = ObtientCoefficientC1CTICMAnalytiquement(ψ, μ)[1];
                }

            }
            else
            {
                ψ = 1;
                μ = 0;
                C1 = 1;
                C2 = 0;
            }


            deversementCTICM.RapportMomentsExtremitePsi = ψ;
            deversementCTICM.RapportMomentIsoMomentExtremiteMu = μ;
            deversementCTICM.LongueurCritiqueDeversement = ObtenirLongueurCritiqueDéversement(ψ);


            CombinaisonCharges1D combinaison = DiagrammesEffortsInternesCalcule.CombinaisonCharges1DSelectionnee;



            #endregion

            #region Valeurs intermédiaires

            deversementCTICM.CoefficientChargeC1 = C1;
            deversementCTICM.CoefficientPositionChargeC2 = C2;


            #region Moment critique Mcr

            double Mcr = ObtientMomentCritiqueAvecC1C2(C1, C2);
            deversementCTICM.MomentCritiqueDeversement = Mcr;

            #endregion



            #region Moment réduit
            double λDmoy = ObtientMomentDeversement(Mcr)[0];
            deversementCTICM.ElancementReduitDeversement = λDmoy;

            double χD = ObtientMomentDeversement(Mcr)[1];
            deversementCTICM.FacteurReductionDeversementChi = χD;

            double MDRd = ObtientMomentDeversement(Mcr)[2];
            deversementCTICM.MomentResistantReduit = MDRd;
            #endregion



            #endregion



            return deversementCTICM;




        }


        #endregion



        #region Partie pour charge concentrée


        /// <summary>
        /// Obtient les coefficients C1 et C2 à partir des Abaques fournis dans le cahier du CTICM
        /// </summary>
        /// <param name="NumeroBarre"></param>
        /// <returns></returns>
        public override List<int> ObtientPsisChargeConcentree(double ψ)
        {

            List<int> ψes = new List<int>();


            #region Informations générales ( Moments, géométrie, ψ)
            // coefficient μ utilisé avant pour le choix du tableau


            double L = Longueur;


            CombinaisonCharges1D combinaison = DiagrammesEffortsInternesCalcule.CombinaisonCharges1DSelectionnee;


            #endregion






            #region Coefficients C1 et C2
            List<decimal> ψBornes = new List<decimal>();

            for (int i = 0; i <= 20; i++)
            {


                decimal ψi = i * 0.1m - 1m;

                ψBornes.Add(ψi);


            }


            decimal ψBorneSup = 0;
            decimal ψBorneInf = 0;

            int ψBorneSupInt = 0;
            int ψBorneInfInt = 20;


            if (combinaison.ChargeConcentreMilieuTraveeQAxeZ == 0)
            {





            }
            else if (combinaison.ChargeRepartieUniformeqAxeZ == 0)
            {



                #region Borne ψ


                ψBorneSup = -1.0m;
                while ((decimal)ψ > ψBorneSup)
                {

                    ψBorneSup += 0.1m;
                    ψBorneSupInt++;


                }




                ψBorneInf = 1.0m;
                while ((decimal)ψ < ψBorneInf)
                {

                    ψBorneInf -= 0.1m;
                    ψBorneInfInt--;

                }



                #endregion




            }

            ψes.Add(ψBorneInfInt);
            ψes.Add(ψBorneSupInt);
            #endregion



            return ψes;
        }





        /// <summary>
        /// Obtient les coefficients C1 et C2 selon tableau CTICM
        /// </summary>
        /// <param name="ψ"></param>
        /// <param name="μ"></param>
        /// <param name="c1ConcMuNegs"></param>
        /// <param name="c1ConcMuPos"></param>
        /// <param name="c2ConcMuNegs"></param>
        /// <param name="c2ConcMuPos"></param>
        /// <returns></returns>
        public override List<double> ObtientCoefficientC1CTICMTableau(double ψ, double μ, List<C1ConcMuNeg> c1ConcMuNegs, List<C1ConcMuPos> c1ConcMuPos, List<C2ConcMuNeg> c2ConcMuNegs, List<C2ConcMuPos> c2ConcMuPos)
        {

            List<double> C1C2 = new List<double>();



            #region Borne ψes

            List<decimal> ψBornesReal = new List<decimal>();

            for (int i = 0; i <= 20; i++)
            {


                decimal ψi = i * 0.1m - 1m;

                ψBornesReal.Add(ψi);


            }


            List<int> ψesBorne = ObtientPsisChargeConcentree(ψ);

            double ψ1 = (double)ψBornesReal[ψesBorne[0]];
            double ψ2 = (double)ψBornesReal[ψesBorne[1]];



            string nomPropertyPsiInf = "";
            if (ψesBorne[0] < 10)
            {

                nomPropertyPsiInf = "Psi" + "0" + ψesBorne[0].ToString();

            }
            else
            {
                nomPropertyPsiInf = "Psi" + ψesBorne[0].ToString();
            }


            string nomPropertyPsiSup = "";
            if (ψesBorne[1] < 10)
            {

                nomPropertyPsiSup = "Psi" + "0" + ψesBorne[1].ToString();

            }
            else
            {

                nomPropertyPsiSup = "Psi" + ψesBorne[1].ToString();

            }


            #endregion



            #region Borne μes


            CombinaisonCharges1D combi = DiagrammesEffortsInternesCalcule.CombinaisonCharges1DSelectionnee;


            int ligne = 0;


            int nombreligne = c1ConcMuNegs.Count();

            double μ1 = 0;
            double μ2 = 0;



            double C1;
            double C2;




            // Charge concentrée seulement
            if (combi.ChargeRepartieUniformeqAxeZ == 0)
            {


                ligne = 0;

                int ligne1;
                int ligne2;
                // mu positif
                if (μ >= 0)
                {

                    while (μ >= c1ConcMuPos[ligne].MuPos)
                    {

                        ligne++;

                    }


                    ligne1 = Math.Max(ligne - 1, 0);
                    object listeC1ligne1 = c1ConcMuPos[ligne1];
                    C1ConcMuPos c1ConcMuPosInf = listeC1ligne1 as C1ConcMuPos;
                    μ1 = c1ConcMuPosInf.MuPos;

                    ligne2 = Math.Min(ligne, nombreligne);
                    object listeC1ligne2 = c1ConcMuPos[ligne2];

                    C1ConcMuPos c1ConcMuPosSup = listeC1ligne2 as C1ConcMuPos;
                    μ2 = c1ConcMuPosSup.MuPos;




                    ligne1 = Math.Max(ligne - 1, 0);
                    object listeC2ligne1 = c2ConcMuPos[ligne1];
                    C2ConcMuPos c2ConcMuPosInf = listeC2ligne1 as C2ConcMuPos;

                    ligne2 = Math.Min(ligne, nombreligne);
                    object listeC2ligne2 = c2ConcMuPos[ligne2];

                    C2ConcMuPos c2ConcMuPosSup = listeC2ligne2 as C2ConcMuPos;


                    if (nomPropertyPsiInf == nomPropertyPsiSup)
                    {


                        #region C1 Concentrée et mu négatif


                        PropertyInfo C1pInfo1 = c1ConcMuPosInf.GetType().GetProperty(nomPropertyPsiInf);
                        double C1WithMu1Psi = (double)C1pInfo1.GetValue(c1ConcMuPosInf);

                        PropertyInfo C1pInfo2 = c1ConcMuPosSup.GetType().GetProperty(nomPropertyPsiInf);
                        double C1WithMu2Psi = (double)C1pInfo2.GetValue(c1ConcMuPosSup);

                        C1 = (μ - μ1) * (μ2 - μ1) * (C1WithMu2Psi - C1WithMu1Psi) + C1WithMu1Psi;

                        C1C2.Add(C1);

                        #endregion



                        #region C2 Concentrée mu négatif


                        PropertyInfo C2pInfo1 = c2ConcMuPosInf.GetType().GetProperty(nomPropertyPsiInf);
                        double C2WithMu1Psi = (double)C2pInfo1.GetValue(c2ConcMuPosInf);

                        PropertyInfo C2pInfo2 = c2ConcMuPosSup.GetType().GetProperty(nomPropertyPsiInf);
                        double C2WithMu2Psi = (double)C2pInfo2.GetValue(c2ConcMuPosSup);

                        C2 = (μ - μ1) * (μ2 - μ1) * (C2WithMu2Psi - C2WithMu1Psi) + C2WithMu1Psi;

                        C1C2.Add(C2);


                        #endregion


                    }
                    else
                    {

                        #region C1


                        // 1ère ligne, 1ère colonne
                        PropertyInfo pInfo11 = c1ConcMuPosInf.GetType().GetProperty(nomPropertyPsiInf);
                        double C1WithMu1Psi1 = (double)pInfo11.GetValue(c1ConcMuPosInf);


                        //1ère ligne 2ème colonne
                        PropertyInfo pInfo12 = c1ConcMuPosInf.GetType().GetProperty(nomPropertyPsiSup);
                        double C1WithMu1Psi2 = (double)pInfo12.GetValue(c1ConcMuPosInf);


                        // 1ère ligne, 1ère colonne
                        PropertyInfo pInfo21 = c1ConcMuPosSup.GetType().GetProperty(nomPropertyPsiInf);
                        double C1WithMu2Psi1 = (double)pInfo21.GetValue(c1ConcMuPosSup);


                        //1ère ligne 2ème colonne
                        PropertyInfo pInfo22 = c1ConcMuPosSup.GetType().GetProperty(nomPropertyPsiSup);
                        double C1WithMu2Psi2 = (double)pInfo22.GetValue(c1ConcMuPosSup);



                        double C1InterpolationMu1 = (ψ - ψ1) / (ψ2 - ψ1) * (C1WithMu1Psi2 - C1WithMu1Psi1) * C1WithMu1Psi1;

                        double C1InterpolationMu2 = (ψ - ψ1) / (ψ2 - ψ1) * (C1WithMu2Psi2 - C1WithMu2Psi1) * C1WithMu2Psi1;


                        C1 = (μ - μ1) * (μ2 - μ1) * (C1InterpolationMu2 - C1InterpolationMu1) + C1InterpolationMu1;

                        C1C2.Add(C1);


                        #endregion



                        #region C2


                        // 1ère ligne, 1ère colonne
                        PropertyInfo C2pInfo11 = c2ConcMuPosInf.GetType().GetProperty(nomPropertyPsiInf);
                        double C2WithMu1Psi1 = (double)C2pInfo11.GetValue(c2ConcMuPosInf);


                        //1ère ligne 2ème colonne
                        PropertyInfo C2pInfo12 = c2ConcMuPosInf.GetType().GetProperty(nomPropertyPsiSup);
                        double C2WithMu1Psi2 = (double)C2pInfo12.GetValue(c2ConcMuPosInf);


                        // 1ère ligne, 1ère colonne
                        PropertyInfo C2pInfo21 = c2ConcMuPosSup.GetType().GetProperty(nomPropertyPsiInf);
                        double C2WithMu2Psi1 = (double)C2pInfo21.GetValue(c2ConcMuPosSup);


                        //1ère ligne 2ème colonne
                        PropertyInfo C2pInfo22 = c2ConcMuPosSup.GetType().GetProperty(nomPropertyPsiSup);
                        double C2WithMu2Psi2 = (double)C2pInfo22.GetValue(c2ConcMuPosSup);



                        double C2InterpolationMu1 = (ψ - ψ1) / (ψ2 - ψ1) * (C2WithMu1Psi2 - C2WithMu1Psi1) * C2WithMu1Psi1;

                        double C2InterpolationMu2 = (ψ - ψ1) / (ψ2 - ψ1) * (C2WithMu2Psi2 - C2WithMu2Psi1) * C2WithMu2Psi1;


                        C2 = (μ - μ1) * (μ2 - μ1) * (C2InterpolationMu2 - C2InterpolationMu1) + C2InterpolationMu1;

                        C1C2.Add(C2);


                        #endregion
                    }


                }
                // mu négatif
                else
                {

                    while (μ <= c1ConcMuNegs[ligne].MuNeg)
                    {

                        ligne++;

                    }

                    #region C1


                    ligne1 = Math.Max(ligne - 1, 0);
                    object listeC1ligne1 = c1ConcMuNegs[ligne1];
                    C1ConcMuNeg c1ConcMuNegInf = listeC1ligne1 as C1ConcMuNeg;
                    μ1 = c1ConcMuNegInf.MuNeg;

                    ligne2 = Math.Min(ligne, nombreligne);
                    object listeC1ligne2 = c1ConcMuNegs[ligne2];
                    C1ConcMuNeg c1ConcMuNegSup = listeC1ligne2 as C1ConcMuNeg;
                    μ2 = c1ConcMuNegSup.MuNeg;


                    #endregion



                    #region C2

                    ligne1 = Math.Max(ligne - 1, 0);
                    object listeC2ligne1 = c2ConcMuNegs[ligne1];
                    C2ConcMuNeg c2ConcMuNegInf = listeC2ligne1 as C2ConcMuNeg;


                    ligne2 = Math.Min(ligne, nombreligne);
                    object listeC2ligne2 = c2ConcMuNegs[ligne2];
                    C2ConcMuNeg c2ConcMuNegSup = listeC2ligne2 as C2ConcMuNeg;




                    #endregion


                    #region 4 valeurs de C1

                    if (nomPropertyPsiInf == nomPropertyPsiSup)
                    {


                        #region C1 Concentrée et mu négatif


                        PropertyInfo C1pInfo1 = c1ConcMuNegInf.GetType().GetProperty(nomPropertyPsiInf);
                        double C1WithMu1Psi = (double)C1pInfo1.GetValue(c1ConcMuNegInf);

                        PropertyInfo C1pInfo2 = c1ConcMuNegSup.GetType().GetProperty(nomPropertyPsiInf);
                        double C1WithMu2Psi = (double)C1pInfo2.GetValue(c1ConcMuNegSup);

                        C1 = (μ - μ1) * (μ2 - μ1) * (C1WithMu2Psi - C1WithMu1Psi) + C1WithMu1Psi;

                        C1C2.Add(C1);

                        #endregion



                        #region C2 Concentrée mu négatif


                        PropertyInfo C2pInfo1 = c2ConcMuNegInf.GetType().GetProperty(nomPropertyPsiInf);
                        double C2WithMu1Psi = (double)C2pInfo1.GetValue(c2ConcMuNegInf);

                        PropertyInfo C2pInfo2 = c2ConcMuNegSup.GetType().GetProperty(nomPropertyPsiInf);
                        double C2WithMu2Psi = (double)C2pInfo2.GetValue(c2ConcMuNegSup);

                        C2 = (μ - μ1) * (μ2 - μ1) * (C2WithMu2Psi - C2WithMu1Psi) + C2WithMu1Psi;

                        C1C2.Add(C2);


                        #endregion


                    }
                    else
                    {


                        #region C1


                        // 1ère ligne, 1ère colonne
                        PropertyInfo pInfo11 = c1ConcMuNegInf.GetType().GetProperty(nomPropertyPsiInf);
                        double C1WithMu1Psi1 = (double)pInfo11.GetValue(c1ConcMuNegInf);


                        //1ère ligne 2ème colonne
                        PropertyInfo pInfo12 = c1ConcMuNegInf.GetType().GetProperty(nomPropertyPsiSup);
                        double C1WithMu1Psi2 = (double)pInfo12.GetValue(c1ConcMuNegInf);


                        // 1ère ligne, 1ère colonne
                        PropertyInfo pInfo21 = c1ConcMuNegSup.GetType().GetProperty(nomPropertyPsiInf);
                        double C1WithMu2Psi1 = (double)pInfo21.GetValue(c1ConcMuNegSup);


                        //1ère ligne 2ème colonne
                        PropertyInfo pInfo22 = c1ConcMuNegSup.GetType().GetProperty(nomPropertyPsiSup);
                        double C1WithMu2Psi2 = (double)pInfo22.GetValue(c1ConcMuNegSup);



                        double C1InterpolationMu1 = (ψ - ψ1) / (ψ2 - ψ1) * (C1WithMu1Psi2 - C1WithMu1Psi1) * C1WithMu1Psi1;

                        double C1InterpolationMu2 = (ψ - ψ1) / (ψ2 - ψ1) * (C1WithMu2Psi2 - C1WithMu2Psi1) * C1WithMu2Psi1;


                        C1 = (μ - μ1) * (μ2 - μ1) * (C1InterpolationMu2 - C1InterpolationMu1) + C1InterpolationMu1;

                        C1C2.Add(C1);


                        #endregion



                        #region C2


                        // 1ère ligne, 1ère colonne
                        PropertyInfo C2pInfo11 = c2ConcMuNegInf.GetType().GetProperty(nomPropertyPsiInf);
                        double C2WithMu1Psi1 = (double)C2pInfo11.GetValue(c2ConcMuNegInf);


                        //1ère ligne 2ème colonne
                        PropertyInfo C2pInfo12 = c2ConcMuNegInf.GetType().GetProperty(nomPropertyPsiSup);
                        double C2WithMu1Psi2 = (double)C2pInfo12.GetValue(c2ConcMuNegInf);


                        // 1ère ligne, 1ère colonne
                        PropertyInfo C2pInfo21 = c2ConcMuNegSup.GetType().GetProperty(nomPropertyPsiInf);
                        double C2WithMu2Psi1 = (double)C2pInfo21.GetValue(c2ConcMuNegSup);


                        //1ère ligne 2ème colonne
                        PropertyInfo C2pInfo22 = c2ConcMuNegSup.GetType().GetProperty(nomPropertyPsiSup);
                        double C2WithMu2Psi2 = (double)C2pInfo22.GetValue(c2ConcMuNegSup);



                        double C2InterpolationMu1 = (ψ - ψ1) / (ψ2 - ψ1) * (C2WithMu1Psi2 - C2WithMu1Psi1) * C2WithMu1Psi1;

                        double C2InterpolationMu2 = (ψ - ψ1) / (ψ2 - ψ1) * (C2WithMu2Psi2 - C2WithMu2Psi1) * C2WithMu2Psi1;


                        C2 = (μ - μ1) * (μ2 - μ1) * (C2InterpolationMu2 - C2InterpolationMu1) + C2InterpolationMu1;

                        C1C2.Add(C2);


                        #endregion


                    }

                    #endregion


                }












            }






            #endregion




            return C1C2;

        }



        /// <summary>
        /// Obtient la classe moment de déversement selon les tableaux/abaques
        /// </summary>
        /// <param name="C1"></param>
        /// <param name="C2"></param>
        /// <returns></returns>
        public override MomentDeversementCTICM ObtientMDRdCTICMTableau(double C1, double C2)
        {
            MomentDeversementCTICM deversementCTICM = new MomentDeversementCTICM();

            double MomentOAbs = Math.Abs(ObtenirMomentExtremiteGaucheO());
            deversementCTICM.MomentExtremiteO = MomentOAbs;
            double MomentEAbs = Math.Abs(ObtenirMomentExtremiteDroiteE());
            deversementCTICM.MomentExtremiteE = MomentEAbs;

            #region Psi, mu et Lcr

            double ψ = ObtenirRapportMomentsExtremitePsi();



            deversementCTICM.RapportMomentsExtremitePsi = ψ;
            deversementCTICM.LongueurCritiqueDeversement = ObtenirLongueurCritiqueDéversement(ψ);

            deversementCTICM.RapportMomentIsoMomentExtremiteMu = ObtenirRapportMomentIsoMomentExtremiteMu();


            #endregion



            #region C1 et C2


            deversementCTICM.CoefficientChargeC1 = C1;
            deversementCTICM.CoefficientPositionChargeC2 = C2;


            #endregion



            #region Moment critique Mcr

            double Mcr = ObtientMomentCritiqueAvecC1C2(C1, C2);
            deversementCTICM.MomentCritiqueDeversement = Mcr;

            #endregion



            #region Moment réduit
            double λDmoy = ObtientMomentDeversement(Mcr)[0];
            deversementCTICM.ElancementReduitDeversement = λDmoy;

            double χD = ObtientMomentDeversement(Mcr)[1];
            deversementCTICM.FacteurReductionDeversementChi = χD;

            double MDRd = ObtientMomentDeversement(Mcr)[2];
            deversementCTICM.MomentResistantReduit = MDRd;
            #endregion



            return deversementCTICM;
        }


        #endregion


        #endregion


        #endregion



        #region Stabilité


        /// <summary>
        /// Obtient les coefficient ω y et z selon les moments min Mmin et max Mmax
        /// </summary>
        /// <param name="Mmin">Moment min</param>
        /// <param name="Mmax">Moment max</param>
        /// <returns></returns>
        public override double ObtenirOmegai(double q, double Q, double MO, double ME)
        {


            double Mmax = Math.Max(Math.Abs(MO), Math.Abs(ME));
            double Mmin = Math.Min(Math.Abs(MO), Math.Abs(ME));


            double ω = 1;




            if (q == 0 && Q == 0)
            {

                if (Mmin == 0 && Mmax == 0)
                {
                    ω = 1;
                }
                else
                {

                    ω = 0.6 + (Mmin / Mmax)*Math.Sign(MO*ME) * 0.4;

                    if (ω < 0.4)
                    {

                        ω = 0.4;

                    }
                
                }

            }
            else 
            {

                ω = 1;

            }








            return ω;


        }



        /// <summary>
        /// Perment d'obtenir les résultats des équations de stabilité
        /// </summary>
        /// <returns></returns>
        public override Stabilite ObtenirResultatEquationStabilite()
        {


            Stabilite resultats = new Stabilite();
            string nomEquation = "";
            double resultatEquation = 0;



            #region Déclaration variables

            EffortsInternesDistanceX efforts = DiagrammesEffortsInternesCalcule.ObtientEffortsInternesMax();
            CombinaisonCharges1D combi = DiagrammesEffortsInternesCalcule.CombinaisonCharges1DSelectionnee;
            double Ned = Math.Abs(efforts.EffortNormalNed);
            double Myed = Math.Abs(efforts.MomentMAxeYDistanceX);
            double Mzed = Math.Abs(efforts.MomentMAxeZDistanceX);
            double LD = Longueur;
            
            // Geométrie
            double A = GeometrieIHSelectionnee.AireTotal;
            double b = GeometrieIHSelectionnee.Largeur;
            double h = GeometrieIHSelectionnee.Hauteur;
            double tf = GeometrieIHSelectionnee.EpaisseurAile;


            double NRd = MomentsFlexionnelResistantCalcules.EffortNormalResistant;
            double NKRdy = FlambageCalcule.RésistanceFlambageAxeY;
            double NKRdz = FlambageCalcule.RésistanceFlambageAxeZ;
            double λkz = FlambageCalcule.CoefficientElancementZ;

            double NKRdmin = Math.Min(NKRdy, NKRdz);

         
            double Ncry = FlambageCalcule.EffortNormalCritiqueAxeY;
            double Ncrz = FlambageCalcule.EffortNormalCritiqueAxeZ;

            double MzRd = MomentsFlexionnelResistantCalcules.MomentFlexionResistantZ;
            double MDRdmin = 0;
            double MDRdReal = 0;
            double MyO = 0;
            double MyE = 0;
            double Lcr = 0;

            if (MomentDeversementCTICMCalculeMin != null)
            {
                MDRdmin = MomentDeversementCTICMCalculeMin.MomentResistantReduit;
                MDRdReal = MomentDeversementCTICMCalcule.MomentResistantReduit;

                MyO = MomentDeversementCTICMCalcule.MomentExtremiteO;
                MyE = MomentDeversementCTICMCalcule.MomentExtremiteE;

                Lcr = MomentDeversementCTICMCalculeMin.LongueurCritiqueDeversement;


            }
            else if (MomentDeversementSIACalcule != null)
            {

                MDRdmin = MomentDeversementSIACalculeMin.MomentResistantReduit;
                MDRdReal = MomentDeversementSIACalcule.MomentResistantReduit;

                MyO = MomentDeversementSIACalcule.MomentExtremiteO;
                MyE = MomentDeversementSIACalcule.MomentExtremiteE;

                Lcr = MomentDeversementSIACalcule.LongueurDeversementCritique;


            }




            List<EffortsInternesDistanceX> effortsTous = DiagrammesEffortsInternesCalcule.ObtientEffortsInternes();

            int Nbefforts = effortsTous.Count();


            double ωy = ObtenirOmegai(combi.ChargeRepartieUniformeqAxeZ, combi.ChargeConcentreMilieuTraveeQAxeZ, MyO, MyE);

            if(OmegaY1)
            {
                ωy = 1;
            }


            resultats.OmegaY = ωy;

            double MzO = effortsTous[0].MomentMAxeZDistanceX;
            double MzE = effortsTous[Nbefforts - 1].MomentMAxeZDistanceX;

            double ωz = ObtenirOmegai(combi.ChargeRepartieUniformeqAxeZ, combi.ChargeConcentreMilieuTraveeQAxeZ, MzO, MzE);

            if (OmegaZ1)
            {
                ωz = 1;
            }

            resultats.OmegaZ = ωz;

            #endregion



            #region Equation de stabilité


            if (ClasseSectionCalcule.ClasseSectionCalculee == 2)
            {

                if (Mzed == 0 && Myed == 0)
                {

                    if (efforts.EffortNormalNed <= 0)
                    {

                        nomEquation = "SIA 263, § 4.5.1";
                        resultatEquation = Ned / NKRdmin;


                    }
                    else if(efforts.EffortNormalNed > 0)
                    {

                        nomEquation = "SIA 263, aucune équation d'instabilité pour Ned > 0";
                        resultatEquation = 0;


                    }



                }
                // Equation 49 axe fort
                else if (Mzed == 0 && Myed != 0)
                {

                    nomEquation = "SIA 263, équation 49, axe fort";
                    double verificationMDRdreal = Myed / MDRdReal;
                    double Equation49 = Ned / NKRdmin + (1 - Ned / Ncry) * ωy * Myed / (MDRdmin);

                    resultatEquation = Math.Max(verificationMDRdreal, Equation49);

                }

                // Equation 49 axe faible
                else if (Myed == 0 && Mzed != 0)
                {

                    nomEquation = "SIA 263, équation 49, axe faible";
                    
                    resultatEquation = Ned / NKRdmin + (1 - Ned / Ncrz) * ωz * Mzed / (MzRd);



                }
                // Equation 51 
                else
                {


                    nomEquation = "SIA 263, équation 51";

                    double β = 0.4 + Ned / NRd + (b / (h - tf));
                    if (β < 1)
                    {

                        β = 1;

                    }

                    double MyredRd = MDRdmin * (1 - Ned / NKRdmin) * (1 - Ned / Ncry);


                    if (MyredRd > ωy * MDRdReal)
                    {

                        MyredRd = ωy * MDRdReal;

                    }


                    if (MyredRd < 0)
                    {

                        MyredRd = 0;


                    }


                    double MzredRd = MzRd * (1 - Ned / NKRdmin) * (1 - Ned / Ncrz);


                    if (MzredRd < 0)
                    {

                        MzredRd = 0;


                    }


                    resultatEquation = Math.Pow(ωy * Myed / MyredRd, β) + Math.Pow(ωz * Mzed / MzredRd, β);

                }

            }
            else if (ClasseSectionCalcule.ClasseSectionCalculee == 3)
            {
                
                nomEquation = "SIA 263, équation 50";

                double verificationMDRdreal = Myed / MDRdReal;
                double Equation50 = Ned / NKRdmin + ωy * Myed / ((1 - Ned / Ncry) * MDRdmin) + ωz * Mzed / ((1 - Ned / Ncrz) * MzRd);
                resultatEquation = Math.Max(verificationMDRdreal,Equation50);

            }



            #endregion



            resultats.EquationUtiliseeStabilite = nomEquation;
            resultats.ResultatStabilite = resultatEquation;

            if (resultats.ResultatStabilite <= 1)
            {

                resultats.Resultat = "OK";


            }
            else
            {

                resultats.Resultat = "KO";

            }


            return resultats;
            

        }






        #endregion



        #region Résistance en section


        /// <summary>
        /// Obtient la resistance en section à un point x avec les efforts à ce point-là
        /// </summary>
        /// <param name="x"></param>
        /// <param name="Ned"></param>
        /// <param name="Myed"></param>
        /// <param name="Mzed"></param>
        /// <param name="Vzed"></param>
        /// <returns></returns>
        public override ResistanceSection ObtientResultatEquationResistanceSection(double x, double Ned, double Myed, double Mzed, double Vzed)
        {
            ResistanceSection resultat =  new ResistanceSection();

            // Efforts

            resultat.EffortsDeterminantsResistanceSection = new EffortsInternesDistanceX(x, Ned, Myed, Mzed, Vzed, 0);



            //Geométrie
            double A = GeometrieIHSelectionnee.AireTotal;
            double b = GeometrieIHSelectionnee.Largeur;
            double h = GeometrieIHSelectionnee.Hauteur;
            double tf = GeometrieIHSelectionnee.EpaisseurAile;

            double fy = ObtientNuanceReduite().LimiteElastique;
            double fu = ObtientNuanceReduite().ResistanceTraction;
            double Anet = SectionNette;

            double NRd = 0;

            NRd = MomentsFlexionnelResistantCalcules.EffortNormalResistant;





            double n = Math.Abs(Ned / NRd);

            double VzRd = EffortTranchantCalcule.RésistanceCisaillementMinZ;
            double MyRd = MomentsFlexionnelResistantCalcules.MomentFlexionResistantY;
            double MzRd = MomentsFlexionnelResistantCalcules.MomentFlexionResistantZ;


            resultat.EquationUtiliseeResistanceSection = "SIA 263, aucune équation adéquate trouvée";
            resultat.ResultatResistanceSection = 0;


            if (ClasseSectionCalcule.ClasseSectionCalculee == 2)
            {




                if (Vzed / VzRd > 0.5 && Mzed ==0)
                {
                    if (Ned == 0)
                    {


                        resultat.EquationUtiliseeResistanceSection = "SIA 263, Equation 43";
                        resultat.ResultatResistanceSection = Myed / MyRd;


                    }
                    else 
                    {

                        resultat.EquationUtiliseeResistanceSection = "SIA 263, Equation 44";
                        resultat.ResultatResistanceSection = Ned / NRd + Myed / MyRd;


                    }




                }

                // Equation 45 - 48 Sia 263
                else if(Vzed <= VzRd * 0.5)
                {
                    #region Valeurs intermédiaires a et zheta

                    double a = (A - b * tf * 2) / A;
                    if (a > 0.5)
                    {

                        a = 0.5;

                    }

                    double zheta = 1 / (1 - a * 0.5);
                    


                    #endregion



                    #region MyNRd

                    double MyNRd = MyRd * (1 - n) * zheta;
                    if (MyNRd > MyRd)
                    {

                        MyNRd = MyRd;

                    }


                    #endregion



                    #region MzNRd


                    double MzNRd = MzRd * (1 - Math.Pow((n - a) / (1 - a), 2));


                    if (n > a)
                    {

                        MzNRd = MzRd * (1 - Math.Pow((n - a) / (1 - a), 2));

                    }
                    else
                    {

                        MzNRd = MzRd;

                    }

                    #endregion

                    if (Ned != 0 && Mzed == 0 && Myed == 0)
                    {

                        resultat.EquationUtiliseeResistanceSection = "SIA 263, équation 38/39";
                        resultat.ResultatResistanceSection = Math.Abs(Ned / NRd);


                    }

                    if (Mzed == 0 && Myed != 0)
                    {
                        resultat.EquationUtiliseeResistanceSection = "SIA 263, équation 40";
                        resultat.ResultatResistanceSection = Math.Abs(Myed / MyRd);

                        if (Ned != 0)
                        {
                            resultat.EquationUtiliseeResistanceSection = "SIA 263, équation 45";
                            resultat.ResultatResistanceSection = Math.Abs(Ned/NRd + Myed / MyNRd);
                        }


                    }
                    if (Myed == 0 && Mzed !=0)
                    {

                        resultat.EquationUtiliseeResistanceSection = "SIA 263, équation 40";
                        resultat.ResultatResistanceSection = Math.Abs(Mzed / MzRd);

                        if (Ned != 0)
                        {
                            resultat.EquationUtiliseeResistanceSection = "SIA 263, équation 46 / 47";
                            resultat.ResultatResistanceSection = Math.Abs(Ned / NRd + Mzed / MzNRd);
                        }
                    }
                    else if (n <= 0.9 && Myed != 0 && Mzed != 0) 
                    {

                        double α = 2;
                        double β = 5 * n;
                        if (β < 1.1)
                        {

                            β = 1.1;

                        }

                        resultat.EquationUtiliseeResistanceSection = "SIA 263, équation 48";
                        resultat.ResultatResistanceSection = Math.Pow(Myed / MyNRd, α) + Math.Pow(Mzed / MzNRd, β);


                    }



                }







            }
            else if (ClasseSectionCalcule.ClasseSectionCalculee == 3)
            {

                if (Vzed / VzRd > 0.5)
                {

                    if (Mzed == 0)
                    {

                        resultat.EquationUtiliseeResistanceSection = "SIA 263, équation 53";
                        resultat.ResultatResistanceSection = Ned / NRd + Myed / MyRd;



                    }

                    // Von Mises
                    else
                    {

                        // resultat.EquationUtiliseeResistanceSection = "SIA 263, Von Mises";
                        // resultat.ContraintesDeterminantes = ObtenirContrainteelastiqueMaxResistanceSection(Ned, Myed, Mzed, Vzed);
                        // double σcomp = resultat.ContraintesDeterminantes.ContrainteComparaisonVonMises;
                        // resultat.ResultatResistanceSection = σcomp / fy * γm1;


                    }

                }
                else
                {

                    resultat.EquationUtiliseeResistanceSection = "SIA 263, équation 54";
                    resultat.ResultatResistanceSection = Ned / NRd + Myed / MyRd + Mzed / MzRd;


                }

            }





            return resultat;
        }



        /// <summary>
        /// Obtient le résultat minimum sur la longueur de l'élément
        /// </summary>
        /// <returns></returns>
        public override ResistanceSection ObtientResultatEquationResistanceSectionMin()
        {

            ResistanceSection resultat = new ResistanceSection();


            List<EffortsInternesDistanceX> efforts = DiagrammesEffortsInternesCalcule.ObtientEffortsInternes();

            List<ResistanceSection> résultatsX = new List<ResistanceSection>();
            List<double> résultatNumerique = new List<double>();

            foreach (EffortsInternesDistanceX effort in efforts)
            {


                ResistanceSection resistanceSection = ObtientResultatEquationResistanceSection(effort.DistanceX, Math.Abs(effort.EffortNormalNed), Math.Abs(effort.MomentMAxeYDistanceX), Math.Abs(effort.MomentMAxeZDistanceX), Math.Abs(effort.EffortTranchanVAxeZDistanceX));

                résultatsX.Add(resistanceSection);
                résultatNumerique.Add(resistanceSection.ResultatResistanceSection);
            
            }


            int indexresultatMax = résultatsX.FindIndex(x=>x.ResultatResistanceSection.Equals(résultatNumerique.Max()));

            resultat = résultatsX[indexresultatMax];
            resultat.EffortsDeterminantsResistanceSection = efforts[indexresultatMax];


            if (resultat.ResultatResistanceSection <= 1)
            {

                resultat.Resultat = "OK";


            }
            else 
            {

                resultat.Resultat = "KO";

            }
            
            return resultat;

        }


        #endregion


        #endregion


    }

}
