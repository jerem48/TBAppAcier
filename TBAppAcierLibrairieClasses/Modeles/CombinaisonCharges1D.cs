using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TBAppAcierLibrairieClasses.Modeles
{
    /// <summary>
    /// Combinaison de charges pour un élément 1D
    /// </summary>
    public class CombinaisonCharges1D
    {


        #region Informations générales


        /// <summary>
        /// Id de la combinaison de charges
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int IdCombinaisonCharges { get; set; }



        /// <summary>
        /// Longueur de l'élément
        /// </summary>
        public double LongueurElement { get; set; }

        #endregion



        #region Effort Normal


        /// <summary>
        /// Efforts normal constant le long de l'élément 1D
        /// Unit = [kN]
        /// </summary>
        public double EffortNormalNed { get; set; }

        #endregion



        #region Charges ponctuelles et réparties


        /// <summary>
        /// Charge répartie uniforme q le long de l'élément 1D dans la direction Y
        /// Unit = [kN/m2]
        /// </summary>
        public double ChargeRepartieUniformeqAxeY { get; set; }




        /// <summary>
        /// Charge répartie uniforme q le long de l'élément 1D dans la direction Z
        /// Unit = [kN/m2]
        /// </summary>
        public double ChargeRepartieUniformeqAxeZ { get; set; }




        /// <summary>
        /// Charge concentrée en milieu de travée Q dans la direction y
        /// Unit = [kN/m2]
        /// </summary>
        public double ChargeConcentreMilieuTraveeQAxeY { get; set; }




        /// <summary>
        /// Charge concentrée en milieu de travée Q dans la direction z
        /// Unit = [kN/m2]
        /// </summary>
        public double ChargeConcentreMilieuTraveeQAxeZ { get; set; }


        #endregion



        #region Moments aux extrémités


        /// <summary>
        /// Moment autour de l'axe Y à l'extrémité O (gauche)
        /// Unit = [kNm]
        /// </summary>
        public double MomentMAxeYExtremiteO { get; set; }




        /// <summary>
        /// Moment autour de l'axe Y à l'extrémité E (droite)
        /// Unit = [kNm]
        /// </summary>
        public double MomentMAxeYExtremiteE { get; set; }




        /// <summary>
        /// Moment autour de l'axe Z à l'extrémité O (gauche)
        /// Unit = [kNm]
        /// </summary>
        public double MomentMAxeZExtremiteO { get; set; }




        /// <summary>
        /// Moment autour de l'axe Z à l'extrémité E (droite)
        /// Unit = [kNm]
        /// </summary>
        public double MomentMAxeZExtremiteE { get; set; }


        #endregion

        public CombinaisonCharges1D()
        {

        }



        public CombinaisonCharges1D(
            string longueur,
            string chargeqy,
            string chargeqz,
            string chargeQy,
            string chargeQz
            )
        {


            #region Longeur et effort normal


            double longueurValue = 0;
            double.TryParse(longueur, out longueurValue);
            LongueurElement = longueurValue;


            
            #endregion



            #region Charges


            double chargeqyValue = 0;
            double.TryParse(chargeqy, out chargeqyValue);
            ChargeRepartieUniformeqAxeY = chargeqyValue;


            double chargeqzValue = 0;
            double.TryParse(chargeqz, out chargeqzValue);
            ChargeRepartieUniformeqAxeZ = chargeqzValue;


            double chargeQyValue = 0;
            double.TryParse(chargeQy, out chargeQyValue);
            ChargeConcentreMilieuTraveeQAxeY = chargeQyValue;


            double chargeQzValue = 0;
            double.TryParse(chargeQz, out chargeQzValue);
            ChargeConcentreMilieuTraveeQAxeZ = chargeQzValue;


            #endregion





        }




        public CombinaisonCharges1D(
            string longueur,
            string effortnormal,
            string chargeqy,
            string chargeqz,
            string chargeQy,
            string chargeQz,
            string momentMyo,
            string momentMzo,
            string momentMye,
            string momentMze
            )
        {


            #region Longeur et effort normal


            double longueurValue = 0;
            double.TryParse(longueur, out longueurValue);
            LongueurElement = longueurValue;


            double effortnormalValue = 0;
            double.TryParse(effortnormal, out effortnormalValue);
            EffortNormalNed = effortnormalValue;

            #endregion



            #region Charges


            double chargeqyValue = 0;
            double.TryParse(chargeqy, out chargeqyValue);
            ChargeRepartieUniformeqAxeY = chargeqyValue;


            double chargeqzValue = 0;
            double.TryParse(chargeqz, out chargeqzValue);
            ChargeRepartieUniformeqAxeZ = chargeqzValue;


            double chargeQyValue = 0;
            double.TryParse(chargeQy, out chargeQyValue);
            ChargeConcentreMilieuTraveeQAxeY = chargeQyValue;


            double chargeQzValue = 0;
            double.TryParse(chargeQz, out chargeQzValue);
            ChargeConcentreMilieuTraveeQAxeZ = chargeQzValue;


            #endregion



            #region Moments aux extrémités


            double momentMyoValue = 0;
            double.TryParse(momentMyo, out momentMyoValue);
            MomentMAxeYExtremiteO = momentMyoValue;


            double momentMzoValue = 0;
            double.TryParse(momentMzo, out momentMzoValue);
            MomentMAxeZExtremiteO = momentMzoValue;


            double momentMyeValue = 0;
            double.TryParse(momentMye, out momentMyeValue);
            MomentMAxeYExtremiteE = momentMyeValue;


            double momentMzeValue = 0;
            double.TryParse(momentMze, out momentMzeValue);
            MomentMAxeZExtremiteE = momentMzeValue;



            #endregion


        }



        public void UpdateCombinaisonCharges1D(
           string longueur,
           string effortnormal,
           string chargeqy,
           string chargeqz,
           string chargeQy,
           string chargeQz,
           string momentMyo,
           string momentMzo,
           string momentMye,
           string momentMze
           )
        {


            #region Longeur et effort normal


            double longueurValue = 0;
            double.TryParse(longueur, out longueurValue);
            LongueurElement = longueurValue;


            double effortnormalValue = 0;
            double.TryParse(effortnormal, out effortnormalValue);
            EffortNormalNed = effortnormalValue;

            #endregion



            #region Charges


            double chargeqyValue = 0;
            double.TryParse(chargeqy, out chargeqyValue);
            ChargeRepartieUniformeqAxeY = chargeqyValue;


            double chargeqzValue = 0;
            double.TryParse(chargeqz, out chargeqzValue);
            ChargeRepartieUniformeqAxeZ = chargeqzValue;


            double chargeQyValue = 0;
            double.TryParse(chargeQy, out chargeQyValue);
            ChargeConcentreMilieuTraveeQAxeY = chargeQyValue;


            double chargeQzValue = 0;
            double.TryParse(chargeQz, out chargeQzValue);
            ChargeConcentreMilieuTraveeQAxeZ = chargeQzValue;


            #endregion



            #region Moments aux extrémités


            double momentMyoValue = 0;
            double.TryParse(momentMyo, out momentMyoValue);
            MomentMAxeYExtremiteO = momentMyoValue;


            double momentMzoValue = 0;
            double.TryParse(momentMzo, out momentMzoValue);
            MomentMAxeZExtremiteO = momentMzoValue;


            double momentMyeValue = 0;
            double.TryParse(momentMye, out momentMyeValue);
            MomentMAxeYExtremiteE = momentMyeValue;


            double momentMzeValue = 0;
            double.TryParse(momentMze, out momentMzeValue);
            MomentMAxeZExtremiteE = momentMzeValue;



            #endregion


        }
    }
}
