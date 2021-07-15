using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TBAppAcierLibrairieClasses.Modeles
{
    /// <summary>
    /// Efforts internes selon la distanceX
    /// </summary>
    public class EffortsInternesDistanceX
    {


        #region Informations générales

        /// <summary>
        /// Id de l'efforts internes à une distance x
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int IdEffortsInternes { get; set; }



     


        #endregion



        #region Efforts internes


        /// <summary>
        /// Distance X ou les efforts internes sont calculés
        /// Unit = [m]
        /// </summary>
        public double DistanceX { get; set; }



        /// <summary>
        /// Effort normal Ned
        /// Unit = [kN]
        /// </summary>
        public double EffortNormalNed { get; set; }



        /// <summary>
        /// Moment My à une distance X
        /// Unit = [kNm]
        /// </summary>
        public double MomentMAxeYDistanceX { get; set; }



        /// <summary>
        /// Moment Mz à une distance X
        /// Unit = [kNm]
        /// </summary>
        public double MomentMAxeZDistanceX { get; set; }



        /// <summary>
        /// Effort tranchant Vz à une distance x
        /// Unit = [kN]
        /// </summary>
        public double EffortTranchanVAxeZDistanceX { get; set; }



        /// <summary>
        /// Effort tranchant Vy à une distance x
        /// Unit = [kN]
        /// </summary>
        public double EffortTranchanVAxeYDistanceX { get; set; }




        #endregion



        #region Constructeurs


        public EffortsInternesDistanceX()
        {

        }


        public EffortsInternesDistanceX(
            double distanceX,
            double effortnormal,
            double momentY,
            double momentZ,
            double efforttranchantZ,
            double efforttranchantY)
        {



            DistanceX = distanceX;

            EffortNormalNed = effortnormal;
            MomentMAxeYDistanceX = momentY;
            MomentMAxeZDistanceX = momentZ;
            EffortTranchanVAxeZDistanceX = efforttranchantZ;
            EffortTranchanVAxeYDistanceX = efforttranchantY;




        }


        #endregion



    }
}
