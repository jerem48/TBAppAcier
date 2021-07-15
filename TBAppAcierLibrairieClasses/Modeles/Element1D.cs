using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TBAppAcierLibrairieClasses.Modeles.CoefficientsCTICM;

namespace TBAppAcierLibrairieClasses.Modeles
{
    /// <summary>
    /// Classe représentant un élément 1D tel qu'un pilier ou une poutre
    /// </summary>
    public abstract class Element1D : Element
    {


        /// <summary>
        /// Longueur de l'élément 1D
        /// Unit = [m]
        /// </summary>
        public double Longueur { get; set; }


        #region Variables Flambage





        /// <summary>
        /// Coefficient de flambage selon les types d'appuis Lk,y
        /// Unit = [-]
        /// </summary>
        public double CoefficientFlambageAxeY { get; set; }






        /// <summary>
        /// Coefficient de flambage selon les types d'appuis Lk,z
        /// Unit = [-]
        /// </summary>
        public double CoefficientFlambageAxeZ { get; set; }



        /// <summary>
        /// Section nette d'un élément tendu Anet
        /// Unit = [mm2]
        /// </summary>
        public double SectionNette { get; set; }



        #endregion


        #region Déversement






        /// <summary>
        /// Positionnement de la charge par rapport au centre de gravité zg
        /// Unit = [mm]
        /// </summary>
        public double PositionnementCharge { get; set; }


        #endregion



        #region Stabilité


        /// <summary>
        /// Si vrai, force ωy  = 1.0 pour la stabilié 
        /// </summary>
        public bool OmegaY1 { get; set; }




        /// <summary>
        /// Si vrai, force ωz  = 1.0 pour la stabilié 
        /// </summary>
        public bool OmegaZ1 { get; set; }


        #endregion




        #region EffortsInternes



        /// <summary>
        /// Clé étrangère du diagramme des efforts internes pour les profilés I ou H
        /// </summary>
        public int? DiagrammesEffortsInternesCalculeIdDiagrammeEffortsInternes { get; set; }



        /// <summary>
        /// Diagramme des efforts calculé
        /// </summary>
        [ForeignKey("DiagrammesEffortsInternesCalculeIdDiagrammeEffortsInternes")]
        public DiagrammesEffortsInternes DiagrammesEffortsInternesCalcule { get; set; }



        #endregion



        #region Classe de section


        /// <summary>
        /// Clé étrangère de la classe de section 
        /// </summary>
        public int? ClasseSectionCalculeIdClasseSection { get; set; }



        /// <summary>
        /// Classe de section calculée
        /// </summary>
        [ForeignKey("ClasseSectionCalculeIdClasseSection")]
        public virtual ClasseSection ClasseSectionCalcule { get; set; }


        #endregion



        #region Flambage



        /// <summary>
        /// Clé étrangère de la classe "Flambage" 
        /// </summary>
        public int? FlambageCalculeIdFlambage { get; set; }



        /// <summary>
        /// Flambage calculé
        /// </summary>
        [ForeignKey("FlambageCalculeIdFlambage")]
        public virtual Flambage FlambageCalcule { get; set; }


        #endregion



        #region Resistances

        /// <summary>
        /// Clé étrangère de la classe "Effort tranchant" 
        /// </summary>
        public int? EffortTranchantCalculeIdEffortTranchant { get; set; }



        /// <summary>
        /// Effort Tranchant calculé
        /// </summary>
        [ForeignKey("EffortTranchantCalculeIdEffortTranchant")]
        public virtual EffortTranchant EffortTranchantCalcule { get; set; }




        /// <summary>
        /// Clé étrangère de la classe "Moments flexionnels calcules" 
        /// </summary>
        public int? MomentsFlexionnelResistantCalculesIdMomentsFlexionnelResistant { get; set; }



        /// <summary>
        /// Moments flexionnels calculés
        /// </summary>
        [ForeignKey("MomentsFlexionnelResistantCalculesIdMomentsFlexionnelResistant")]
        public virtual MomentsFlexionnelResistant MomentsFlexionnelResistantCalcules { get; set; }



        #endregion



        #region Moment de déversement



        #region CTICM


        /// <summary>
        /// Clé étrangère de la classe "Moments de déversement selon CTICM" 
        /// </summary>
        public int? MomentDeversementCTICMCalculeIdMomentDeversementCTICM { get; set; }



        /// <summary>
        /// Moment de déversement calculé selon le CTICM
        /// </summary>
        [ForeignKey("MomentDeversementCTICMCalculeIdMomentDeversementCTICM")]
        public virtual MomentDeversementCTICM MomentDeversementCTICMCalcule { get; set; }


        /// <summary>
        /// Clé étrangère de la classe "Moments de déversement selon CTICM" 
        /// </summary>
        public int? MomentDeversementCTICMCalculeMinIdMomentDeversementCTICM { get; set; }



        /// <summary>
        /// Moment de déversement calculé selon le CTICM
        /// </summary>
        [ForeignKey("MomentDeversementCTICMCalculeMinIdMomentDeversementCTICM")]
        public virtual MomentDeversementCTICM MomentDeversementCTICMCalculeMin { get; set; }

        #region Coefficient pour charge concentrée


        /// <summary>
        /// Clé étrangère de la classe "Coeffcient C1 de charge concentrée, μ positif" 
        /// </summary>
        public int? C1ConcMuPosesIdC1ConcMuPos { get; set; }



        /// <summary>
        /// Coeffcient C1 de charge concentrée, μ positif
        /// </summary>
        [ForeignKey("C1ConcMuPosesIdC1ConcMuPos")]
        public virtual C1ConcMuPos C1ConcMuPoses { get; set; }



        /// <summary>
        /// Clé étrangère de la classe "Coeffcient C1 de charge concentrée, μ négatif" 
        /// </summary>
        public int? C2ConcMuNegsIdC2ConcMuNeg { get; set; }



        /// <summary>
        /// Coeffcient C1 de charge concentrée, μ négatif
        /// </summary>
        [ForeignKey("C2ConcMuNegsIdC2ConcMuNeg")]
        public virtual C2ConcMuNeg C2ConcMuNegs { get; set; }



        /// <summary>
        /// Clé étrangère de la classe "Coeffcient C1 de charge concentrée, μ positif" 
        /// </summary>
        public int? C2ConcMuPosesIdC2ConcMuPos { get; set; }



        /// <summary>
        /// Coeffcient C1 de charge concentrée, μ positif
        /// </summary>
        [ForeignKey("C2ConcMuPosesIdC2ConcMuPos")]
        public virtual C2ConcMuPos C2ConcMuPoses { get; set; }



        /// <summary>
        /// Clé étrangère de la classe "Coeffcient C1 de charge concentrée, μ négatif" 
        /// </summary>
        public int? C1ConcMuNegsIdC1ConcMuNeg { get; set; }



        /// <summary>
        /// Coeffcient C1 de charge concentrée, μ négatif
        /// </summary>
        [ForeignKey("C1ConcMuNegsIdC1ConcMuNeg")]
        public virtual C1ConcMuNeg C1ConcMuNegs { get; set; }



        #endregion


        #endregion



        #region SIA

        /// <summary>
        /// Clé étrangère de la classe "Moments de déversement selon CTICM" 
        /// </summary>
        public int? MomentDeversementSIACalculeIdMomentDeversementSIA { get; set; }



        /// <summary>
        /// Moment de déversement calculé selon le CTICM
        /// </summary>
        [ForeignKey("MomentDeversementSIACalculeIdMomentDeversementSIA")]
        public virtual MomentDeversementSIA MomentDeversementSIACalcule { get; set; }





        /// <summary>
        /// Clé étrangère de la classe "Moments de déversement selon CTICM" 
        /// </summary>
        public int? MomentDeversementSIACalculeMinIdMomentDeversementSIA { get; set; }



        /// <summary>
        /// Moment de déversement calculé selon le CTICM
        /// </summary>
        [ForeignKey("MomentDeversementSIACalculeMinIdMomentDeversementSIA")]
        public virtual MomentDeversementSIA MomentDeversementSIACalculeMin { get; set; }






        #endregion



        #endregion



        #region Stabilité


        /// <summary>
        /// Clé étrangère de la classe "Stabilite" 
        /// </summary>
        public int? StabiliteCalculeIdStabilite { get; set; }



        /// <summary>
        /// Stabilite calculée selon la méthode SIA
        /// </summary>
        [ForeignKey("StabiliteCalculeIdStabilite")]
        public virtual Stabilite StabiliteCalcule { get; set; }



        #endregion



        #region Résistance en section


        /// <summary>
        /// Clé étrangère de la classe "Stabilite" 
        /// </summary>
        public int? ResistanceSectionCalculeeIdResistanceSection { get; set; }



        /// <summary>
        /// Stabilite calculée selon la méthode SIA
        /// </summary>
        [ForeignKey("ResistanceSectionCalculeeIdResistanceSection")]
        public virtual ResistanceSection ResistanceSectionCalculee { get; set; }



        #endregion







        #region Methodes virtuelles


        #region Classe de section


        public virtual ClasseSection ObtenirClasseSection()
        {

            ClasseSection classe = new ClasseSection();

            return classe;


        }



        public virtual ClasseSection ObtenirClasseSection2()
        {

            ClasseSection classe = new ClasseSection();

            return classe;


        }



        public virtual ClasseSection ObtenirClasseSection3()
        {

            ClasseSection classe = new ClasseSection();

            return classe;


        }




        #endregion



        #region Contraintes


        protected virtual ContraintesElastiques1PointYZ ObtenirContraintesElastiques(double coordonneeY, double coordonneeZ)
        {

            ContraintesElastiques1PointYZ contraintes = new ContraintesElastiques1PointYZ();

            return contraintes;


        }

        protected virtual ContraintesElastiques1PointYZ ObtenirContraintesElastiques(double Ned, double Myed, double Mzed, double Vzed, double coordonneeY, double coordonneeZ)
        {

            ContraintesElastiques1PointYZ contraintes = new ContraintesElastiques1PointYZ();

            return contraintes;


        }


        protected virtual List<ContraintesElastiques1PointYZ> ObtenirContrainteselastiquesPourClasseSection()
        {

            List<ContraintesElastiques1PointYZ> contraintes = new List<ContraintesElastiques1PointYZ>();

            return contraintes;


        }



        protected virtual ContraintesElastiques1PointYZ ObtenirContrainteelastiqueMaxResistanceSection(double Ned, double Myed, double Mzed, double Vzed)
        {

            ContraintesElastiques1PointYZ contraintes = new ContraintesElastiques1PointYZ();

            return contraintes;


        }


        /// <summary>
        /// Obtient la contrainte de comparaison de Von Mises
        /// </summary>
        /// <param name="σx">Contrainte normale</param>
        /// <param name="τzx">Contrainte tangentielle</param>
        /// <returns></returns>
        protected virtual double ObtientContrainteComparaison(double σx, double τzx)
        {

            double σcomp = 0;



            σcomp = Math.Sqrt(Math.Pow(σx, 2) + Math.Pow(τzx, 2) * 3);


            return σcomp;




        }

        #endregion



        #region Flambage


        public virtual Flambage ObtenirFlambage()
        {

            Flambage flambage = new Flambage();

            return flambage;


        }


        #endregion



        #region Résistances


        #region Effort tranchant


        public virtual EffortTranchant ObtenirResistanceCisaillement()
        {

            EffortTranchant effortTranchant = new EffortTranchant();

            return effortTranchant;


        }


        public virtual double ObtenirResistanceCisaillementClasse2()
        {

            double VRd = 0;

            return VRd;


        }


        public virtual double ObtenirResistanceCisaillementClasse3()
        {

            double VRd = 0;

            return VRd;


        }


        #endregion



        #region Moments flexionnels


        public virtual MomentsFlexionnelResistant ObtenirResistanceMoments()
        {

            MomentsFlexionnelResistant moments = new MomentsFlexionnelResistant();


            return moments;


        }


        #endregion


        #endregion



        #region Moment de déversement


        #region CTICM





        public virtual MomentDeversementCTICM ObtenirMomentDeversementCTICM()
        {

            MomentDeversementCTICM momentDeversementCTICM = new MomentDeversementCTICM();

            return momentDeversementCTICM;


        }


        #endregion



        #region SIA


        public virtual MomentDeversementSIA ObtenirMomentDeversementSIA(bool MDRdmin)
        {

            MomentDeversementSIA momentDeversementSIA = new MomentDeversementSIA();

            return momentDeversementSIA;


        }

        public virtual MomentDeversementSIA ObtenirMomentCritiqueDeversementSIA(MomentDeversementSIA SIA)
        {


            MomentDeversementSIA momentDeversementSIA = new MomentDeversementSIA();

            return momentDeversementSIA;

        }




        #endregion



        #region Calculs intermédiaires et indicatifs


        public virtual double ObtenirRapportMomentsExtremitePsi()
        {

            double ψ = 0;

            return ψ;


        }



        public virtual double ObtenirMomentExtremiteGaucheO()
        {

            double M = 0;

            return M;


        }



        public virtual double ObtenirMomentExtremiteDroiteE()
        {

            double M = 0;

            return M;


        }



        public virtual double ObtenirLongueurCritiqueDéversement(double ψ)
        {

            double Lcr = 0;

            return Lcr;


        }



        public virtual double ObtenirRapportMomentIsoMomentExtremiteMu()
        {

            double μ = 0;

            return μ;


        }



        public virtual List<double> ObtientCoefficientC1CTICMAnalytiquement(double ψ, double μ)
        {

            List<double> C1 = new List<double>();

            return C1;

        }



        public virtual List<double> ObtientCoefficientC1CTICMTableau(double ψ, double μ, List<C1ConcMuNeg> c1ConcMuNegs, List<C1ConcMuPos> c1ConcMuPos, List<C2ConcMuNeg> c2ConcMuNegs, List<C2ConcMuPos> c2ConcMuPos)
        {

            List<double> C1 = new List<double>();

            return C1;

        }


        public virtual double ObtientMomentCritiqueAvecC1C2(double C1, double C2)
        {

            double Mcr = 0;

            return Mcr;

        }



        public virtual List<double> ObtientMomentDeversement(double Mcr)
        {

            List<double> C1 = new List<double>();

            return C1;

        }


        #region Lecture tableau
        public virtual List<int> ObtientPsisChargeConcentree(double ψ)
        {

            List<int> deversementCTICM = new List<int>();

            return deversementCTICM;

        }



        #endregion

        public virtual MomentDeversementCTICM ObtientMDRdCTICMAnalytiques(bool MDRdMin)
        {

            MomentDeversementCTICM deversementCTICM = new MomentDeversementCTICM();

            return deversementCTICM;

        }



        public virtual MomentDeversementCTICM ObtientMDRdCTICMTableau(double C1, double C2)
        {

            MomentDeversementCTICM deversementCTICM = new MomentDeversementCTICM();



            return deversementCTICM;

        }


        public virtual MomentDeversementCTICM ObtientMomentDeversementCTICMRealMin()
        {


            MomentDeversementCTICM moment = new MomentDeversementCTICM();

            return moment;
        
        
        }
        #endregion






        #endregion



        #region Stabilité



        public virtual double ObtenirOmegai(double q, double Q, double Mmin, double Mmax)
        {

            double ω = 0;

            return ω;


        }



        public virtual Stabilite ObtenirResultatEquationStabilite()
        {

            Stabilite res = new Stabilite();

            return res;


        }



        #endregion



        #region Résistance en section




        public virtual ResistanceSection ObtientResultatEquationResistanceSection(double x, double Ned, double Myed, double Mzed, double Vzed)
        {

            ResistanceSection resultat= new ResistanceSection();

            return resultat;
        
        }


        public virtual ResistanceSection ObtientResultatEquationResistanceSectionMin()
        {

            ResistanceSection resultat = new ResistanceSection();

            return resultat;

        }




        public virtual EffortsInternesDistanceX ObtientEffortsInternesDeterminantsX()
        {


            EffortsInternesDistanceX efforts = new EffortsInternesDistanceX();

            return efforts;

        
        
        }


        #endregion



        #endregion



    }
}
