using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TBAppAcierLibrairieClasses.Modeles
{
    /// <summary>
    /// Classe regroupant les diagrammes des efforts internes sur des points distant d'une distance x
    /// </summary>
    public class DiagrammesEffortsInternes
    {



        /// <summary>
        /// Id du diagramme des efforts internes
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDiagrammeEffortsInternes { get; set; }



        /// <summary>
        /// Nom du diagramme
        /// </summary>
        public string FullName
        {

            get
            {

                return $"Combinaison : {IdDiagrammeEffortsInternes}";

            }


        }




        /// <summary>
        /// Clé étrangère pour la combinaison d'efforts
        /// </summary>
        public int CombinaisonCharges1DSelectionneeIdCombinaisonCharges { get; set; }

        /// <summary>
        /// Combinaison de charges 1D prédéfinies par l'utilisateur
        /// </summary>
        [ForeignKey("CombinaisonCharges1DSelectionneeIdCombinaisonCharges")]
        public CombinaisonCharges1D CombinaisonCharges1DSelectionnee { get; set; }



        /// <summary>
        /// Listes des efforts internes du diagrammes par distance X
        /// </summary>
        
        public ICollection<EffortsInternesDistanceX> EffortsInternesDistanceXes { get; set; }


        public DiagrammesEffortsInternes()
        {

        }



        public DiagrammesEffortsInternes(
            CombinaisonCharges1D combinaisonCharges1D)
        {


            CombinaisonCharges1DSelectionnee = combinaisonCharges1D;


        }



        /// <summary>
        /// Permet d'obtenir une liste d'efforts internes pour créer les diagrammes de ceux-ci
        /// </summary>
        /// <returns></returns>
        public List<EffortsInternesDistanceX> ObtientEffortsInternes()
        {

            List<EffortsInternesDistanceX> effortsInternes = new List<EffortsInternesDistanceX>();


            #region Variables


            double L = CombinaisonCharges1DSelectionnee.LongueurElement;
            double Ned = CombinaisonCharges1DSelectionnee.EffortNormalNed;
            double qy = CombinaisonCharges1DSelectionnee.ChargeRepartieUniformeqAxeY;
            double qz = CombinaisonCharges1DSelectionnee.ChargeRepartieUniformeqAxeZ;
            double Qy = CombinaisonCharges1DSelectionnee.ChargeConcentreMilieuTraveeQAxeY;
            double Qz = CombinaisonCharges1DSelectionnee.ChargeConcentreMilieuTraveeQAxeZ;
            double Myo = - CombinaisonCharges1DSelectionnee.MomentMAxeYExtremiteO;
            double Mzo = - CombinaisonCharges1DSelectionnee.MomentMAxeZExtremiteO;
            double Mye = - CombinaisonCharges1DSelectionnee.MomentMAxeYExtremiteE;
            double Mze = - CombinaisonCharges1DSelectionnee.MomentMAxeZExtremiteE;


            #endregion



            #region Réactions d'appuis

            //Calcul des réactions d'appuis

            double ReactionAppuiAxeZExtremiteO = qz * L / 2 + Qz / 2 + (Myo - Mye) / L;
            double ReactionAppuiAxeYExtremiteO = qy * L / 2 + Qy / 2 + (Mzo - Mze) / L;

            #endregion



            // Fixe le nombre de points calculés
            int NombrePoints = 1000;

            for (int i = 0; i <= NombrePoints; i++)
            {

                EffortsInternesDistanceX efforts = new EffortsInternesDistanceX();

                double x = i * CombinaisonCharges1DSelectionnee.LongueurElement / NombrePoints;

                efforts.DistanceX = x;

                double PartQyM;
                double PartQzM;
                double PartQyV;
                double PartQzV;


                //Efforts dus aux charges ponctuelles en fonction de la distance
                if (x <= L / 2)
                {

                    PartQyM = 0;
                    PartQyV = 0;
                    PartQzM = 0;
                    PartQzV = 0;

                }
                else
                {

                    PartQyV = Qy;
                    PartQyM = Qy * (x - L / 2);

                    PartQzV = Qz;
                    PartQzM = Qz * (x - L / 2);

                }



                double Myi = ReactionAppuiAxeZExtremiteO * x - qz * Math.Pow(x, 2.0) / 2 - PartQzM - Myo;
                efforts.MomentMAxeYDistanceX = Myi;

                double Mzi = ReactionAppuiAxeYExtremiteO * x - qy * Math.Pow(x, 2.0) / 2 - PartQyM - Mzo;
                efforts.MomentMAxeZDistanceX = Mzi;

                double Vzi = ReactionAppuiAxeZExtremiteO - qz * x - PartQzV;
                efforts.EffortTranchanVAxeZDistanceX = Vzi;

                double Vyi = ReactionAppuiAxeYExtremiteO - qy * x - PartQyV;
                efforts.EffortTranchanVAxeYDistanceX = Vyi;

                //Efforts normal constant
                efforts.EffortNormalNed = Ned;

                effortsInternes.Add(efforts);

            }


            return effortsInternes;



        }



        /// <summary>
        /// Calcul les moments d'encastrement parfaits selon l'axe y et z
        /// </summary>
        /// <returns></returns>
        public List<double> ObtientMomentEncastrement()

        {


            List<double> moments = new List<double>();

            #region Variables


            double L = CombinaisonCharges1DSelectionnee.LongueurElement;
            double qy = CombinaisonCharges1DSelectionnee.ChargeRepartieUniformeqAxeY;
            double qz = CombinaisonCharges1DSelectionnee.ChargeRepartieUniformeqAxeZ;
            double Qy = CombinaisonCharges1DSelectionnee.ChargeConcentreMilieuTraveeQAxeY;
            double Qz = CombinaisonCharges1DSelectionnee.ChargeConcentreMilieuTraveeQAxeZ;


            #endregion


            #region Calcul des moments

            double MyAppuyeEncastre = - (Math.Round( qz * Math.Pow(L, 2.0)/8 +  Qz * L* 3 / 16, Element.ArrondiMoments));
            double MyEncastreEncastre = -( Math.Round(qz * Math.Pow(L, 2.0) / 12 + Qz * L / 8, Element.ArrondiMoments));
            double MzAppuyeEncastre = - (Math.Round(qy * Math.Pow(L, 2.0) / 8 + Qy * L * 3 / 16, Element.ArrondiMoments));
            double MzEncastreEncastre = - (Math.Round(qy * Math.Pow(L, 2.0) / 12 + Qy * L / 8, Element.ArrondiMoments));

            moments.Add(MyAppuyeEncastre);
            moments.Add(MyEncastreEncastre);
            moments.Add(MzAppuyeEncastre);
            moments.Add(MzEncastreEncastre);

            #endregion

            return moments;
        
        
        
        }




        /// <summary>
        /// Permet de calculer les efforts internes maximaux le long d'un élément
        /// </summary>
        /// <returns></returns>
        public EffortsInternesDistanceX ObtientEffortsInternesMax()
        {

            EffortsInternesDistanceX effortsmax = new EffortsInternesDistanceX();


            List<EffortsInternesDistanceX> efforts = ObtientEffortsInternes();


            #region  Effort normal constant


            effortsmax.EffortNormalNed = efforts[0].EffortNormalNed;


            #endregion



            #region Moment My max en valeur absolue avec signe

            List<double> mys = new List<double>();

            foreach (EffortsInternesDistanceX effort in efforts)
                mys.Add(Math.Abs(effort.MomentMAxeYDistanceX));

            effortsmax.MomentMAxeYDistanceX = efforts[efforts.FindIndex(x => Math.Abs(x.MomentMAxeYDistanceX) == mys.Max())].MomentMAxeYDistanceX;


            #endregion



            #region Effort tranchant Vz max en valeur absolue avec signe

            List<double> vzs = new List<double>();

            foreach (EffortsInternesDistanceX effort in efforts)
                vzs.Add(Math.Abs(effort.EffortTranchanVAxeZDistanceX));


            int indexVzed = efforts.FindIndex(x => x.EffortTranchanVAxeZDistanceX == vzs.Max());
            int NbVzed = efforts.Count();

            if (indexVzed > NbVzed)
            {
                indexVzed = NbVzed;
            }
            else if (indexVzed < 0)
            {

                indexVzed = 0;

            }

            effortsmax.EffortTranchanVAxeZDistanceX = efforts[indexVzed].EffortTranchanVAxeZDistanceX;


            #endregion



            #region Moment Mz max en valeur absolue avec signe

            List<double> mzs = new List<double>();

            foreach (EffortsInternesDistanceX effort in efforts)
                mzs.Add(Math.Abs(effort.MomentMAxeZDistanceX));

            effortsmax.MomentMAxeZDistanceX = efforts[efforts.FindIndex(x => Math.Abs(x.MomentMAxeZDistanceX) == mzs.Max())].MomentMAxeZDistanceX;


            #endregion


            return effortsmax;



        }


    }
}
