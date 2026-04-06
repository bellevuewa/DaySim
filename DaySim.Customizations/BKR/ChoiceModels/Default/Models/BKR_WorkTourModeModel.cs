using DaySim.Framework.ChoiceModels;
using DaySim.Framework.Core;
using DaySim.Framework.DomainModels.Wrappers;

namespace DaySim.ChoiceModels.Default.Models {
  class BKR_WorkTourModeModel : WorkTourModeModel {
    protected override void RegionSpecificCustomizations(ChoiceProbabilityCalculator.Alternative alternative, ITourWrapper tour, int pathType, int mode, IParcelWrapper destinationParcel) {
      //Global.PrintFile.WriteLine("Default PSRC_WorkTourModeModel.RegionSpecificCustomizations called");

      //Global.PrintFile.WriteLine("Default PSRC_WorkTourModeModel.RegionSpecificCustomizations called");
      int homedist = tour.OriginParcel.District;
      int destdist = destinationParcel.District;
      /*
       * 61: Bellevue (DT excluded), 62: Bel DT, 63: Kirkland, 64: Redmond (DT excluded), 65: Other BKR area, 66: Redmond DT
       */
      int originBKR = (homedist == 61 || homedist == 62 || homedist == 63 || homedist == 64 || homedist == 65 || homedist == 66) ? 1 : 0;
      int destBKR = (destdist == 61 || destdist == 62 || destdist == 63 || destdist == 64 || destdist == 65 || destdist == 66) ? 1 : 0;


      if (mode == Global.Settings.Modes.Transit && pathType != Global.Settings.PathTypes.LightRail && pathType != Global.Settings.PathTypes.CommuterRail && pathType != Global.Settings.PathTypes.Ferry) {
        if (homedist < 60) {
          alternative.AddUtilityTerm(200 + tour.OriginParcel.District, 1);//district specific transit calibration constant
          alternative.AddUtilityTerm(400 + destinationParcel.District, 1);//district specific transit calibration constant
        } else {
          alternative.AddUtilityTerm(281, homedist == 60 ? 1 : 0);
          alternative.AddUtilityTerm(282, homedist == 61 ? 1 : 0);
          alternative.AddUtilityTerm(283, homedist == 62 ? 1 : 0);
          alternative.AddUtilityTerm(284, homedist == 63 ? 1 : 0);
          alternative.AddUtilityTerm(285, homedist == 64 ? 1 : 0);
          alternative.AddUtilityTerm(286, homedist == 65 ? 1 : 0);
          alternative.AddUtilityTerm(287, originBKR == 1 ? 1 : 0);
          alternative.AddUtilityTerm(313, homedist == 66 ? 1 : 0);

          alternative.AddUtilityTerm(281, destdist == 60 ? 1 : 0);
          alternative.AddUtilityTerm(282, destdist == 61 ? 1 : 0);
          alternative.AddUtilityTerm(283, destdist == 62 ? 1 : 0);
          alternative.AddUtilityTerm(284, destdist == 63 ? 1 : 0);
          alternative.AddUtilityTerm(285, destdist == 64 ? 1 : 0);
          alternative.AddUtilityTerm(286, destdist == 65 ? 1 : 0);
          alternative.AddUtilityTerm(287, destBKR == 1 ? 1 : 0);
          alternative.AddUtilityTerm(313, destdist == 66 ? 1 : 0);

        }
      } else if (mode == Global.Settings.Modes.Transit && pathType == Global.Settings.PathTypes.LightRail) {
        alternative.AddUtilityTerm(317, homedist == 60 ? 1 : 0);
        alternative.AddUtilityTerm(318, homedist == 61 ? 1 : 0);
        alternative.AddUtilityTerm(319, homedist == 62 ? 1 : 0);
        alternative.AddUtilityTerm(320, homedist == 63 ? 1 : 0);
        alternative.AddUtilityTerm(321, homedist == 64 ? 1 : 0);
        alternative.AddUtilityTerm(322, homedist == 65 ? 1 : 0);
        alternative.AddUtilityTerm(323, originBKR == 1 ? 1 : 0);
        alternative.AddUtilityTerm(324, homedist == 66 ? 1 : 0);

        alternative.AddUtilityTerm(317, destdist == 60 ? 1 : 0);
        alternative.AddUtilityTerm(318, destdist == 61 ? 1 : 0);
        alternative.AddUtilityTerm(319, destdist == 62 ? 1 : 0);
        alternative.AddUtilityTerm(320, destdist == 63 ? 1 : 0);
        alternative.AddUtilityTerm(321, destdist == 64 ? 1 : 0);
        alternative.AddUtilityTerm(322, destdist == 65 ? 1 : 0);
        alternative.AddUtilityTerm(323, destBKR == 1 ? 1 : 0);
        alternative.AddUtilityTerm(324, destdist == 66 ? 1 : 0);

      }

      if (mode == Global.Settings.Modes.ParkAndRide) {
        alternative.AddUtilityTerm(250, pathType == 3 ? 1 : 0);
        alternative.AddUtilityTerm(251, pathType == 4 ? 1 : 0);
        alternative.AddUtilityTerm(252, pathType == 5 ? 1 : 0);
        alternative.AddUtilityTerm(253, pathType == 6 ? 1 : 0);
        alternative.AddUtilityTerm(254, pathType == 7 ? 1 : 0);

        alternative.AddUtilityTerm(309, originBKR == 1 ? 1 : 0);


      } else if (mode == Global.Settings.Modes.Transit) {
        alternative.AddUtilityTerm(255, pathType == 3 ? 1 : 0);
        alternative.AddUtilityTerm(256, pathType == 4 ? 1 : 0);
        alternative.AddUtilityTerm(257, pathType == 5 ? 1 : 0);
        alternative.AddUtilityTerm(258, pathType == 6 ? 1 : 0);
        alternative.AddUtilityTerm(259, pathType == 7 ? 1 : 0);

      } else if (mode == Global.Settings.Modes.Hov3) {
        //BKR specific constant 
        alternative.AddUtilityTerm(274, homedist == 60 ? 1 : 0);
        alternative.AddUtilityTerm(275, homedist == 61 ? 1 : 0);
        alternative.AddUtilityTerm(276, homedist == 62 ? 1 : 0);
        alternative.AddUtilityTerm(277, homedist == 63 ? 1 : 0);
        alternative.AddUtilityTerm(278, homedist == 64 ? 1 : 0);
        alternative.AddUtilityTerm(279, homedist == 65 ? 1 : 0);
        alternative.AddUtilityTerm(280, originBKR == 1 ? 1 : 0);
        alternative.AddUtilityTerm(312, homedist == 66 ? 1 : 0);

        alternative.AddUtilityTerm(274, destdist == 60 ? 1 : 0);
        alternative.AddUtilityTerm(275, destdist == 61 ? 1 : 0);
        alternative.AddUtilityTerm(276, destdist == 62 ? 1 : 0);
        alternative.AddUtilityTerm(277, destdist == 63 ? 1 : 0);
        alternative.AddUtilityTerm(278, destdist == 64 ? 1 : 0);
        alternative.AddUtilityTerm(279, destdist == 65 ? 1 : 0);
        alternative.AddUtilityTerm(280, destBKR == 1 ? 1 : 0);
        alternative.AddUtilityTerm(312, destdist == 66 ? 1 : 0);

      } else if (mode == Global.Settings.Modes.Hov2) {
        //BKR specific constant 
        alternative.AddUtilityTerm(267, homedist == 60 ? 1 : 0);
        alternative.AddUtilityTerm(268, homedist == 61 ? 1 : 0);
        alternative.AddUtilityTerm(269, homedist == 62 ? 1 : 0);
        alternative.AddUtilityTerm(270, homedist == 63 ? 1 : 0);
        alternative.AddUtilityTerm(271, homedist == 64 ? 1 : 0);
        alternative.AddUtilityTerm(272, homedist == 65 ? 1 : 0);
        alternative.AddUtilityTerm(273, originBKR == 1 ? 1 : 0);
        alternative.AddUtilityTerm(311, homedist == 66 ? 1 : 0);

        alternative.AddUtilityTerm(267, destdist == 60 ? 1 : 0);
        alternative.AddUtilityTerm(268, destdist == 61 ? 1 : 0);
        alternative.AddUtilityTerm(269, destdist == 62 ? 1 : 0);
        alternative.AddUtilityTerm(270, destdist == 63 ? 1 : 0);
        alternative.AddUtilityTerm(271, destdist == 64 ? 1 : 0);
        alternative.AddUtilityTerm(272, destdist == 65 ? 1 : 0);
        alternative.AddUtilityTerm(273, destBKR == 1 ? 1 : 0);
        alternative.AddUtilityTerm(311, destdist == 66 ? 1 : 0);

      } else if (mode == Global.Settings.Modes.Sov) {
        //BKR specific constant 
        alternative.AddUtilityTerm(260, homedist == 60 ? 1 : 0);
        alternative.AddUtilityTerm(261, homedist == 61 ? 1 : 0);
        alternative.AddUtilityTerm(262, homedist == 62 ? 1 : 0);
        alternative.AddUtilityTerm(263, homedist == 63 ? 1 : 0);
        alternative.AddUtilityTerm(264, homedist == 64 ? 1 : 0);
        alternative.AddUtilityTerm(265, homedist == 65 ? 1 : 0);
        alternative.AddUtilityTerm(266, originBKR == 1 ? 1 : 0);
        alternative.AddUtilityTerm(310, homedist == 66 ? 1 : 0);

        alternative.AddUtilityTerm(260, destdist == 60 ? 1 : 0);
        alternative.AddUtilityTerm(261, destdist == 61 ? 1 : 0);
        alternative.AddUtilityTerm(262, destdist == 62 ? 1 : 0);
        alternative.AddUtilityTerm(263, destdist == 63 ? 1 : 0);
        alternative.AddUtilityTerm(264, destdist == 64 ? 1 : 0);
        alternative.AddUtilityTerm(265, destdist == 65 ? 1 : 0);
        alternative.AddUtilityTerm(266, destBKR == 1 ? 1 : 0);
        alternative.AddUtilityTerm(310, destdist == 66 ? 1 : 0);

      } else if (mode == Global.Settings.Modes.Bike) {
        //BKR specific constant 
        alternative.AddUtilityTerm(288, homedist == 60 ? 1 : 0);
        alternative.AddUtilityTerm(289, homedist == 61 ? 1 : 0);
        alternative.AddUtilityTerm(290, homedist == 62 ? 1 : 0);
        alternative.AddUtilityTerm(291, homedist == 63 ? 1 : 0);
        alternative.AddUtilityTerm(292, homedist == 64 ? 1 : 0);
        alternative.AddUtilityTerm(293, homedist == 65 ? 1 : 0);
        alternative.AddUtilityTerm(294, originBKR == 1 ? 1 : 0);
        alternative.AddUtilityTerm(314, homedist == 66 ? 1 : 0);

        alternative.AddUtilityTerm(288, destdist == 60 ? 1 : 0);
        alternative.AddUtilityTerm(289, destdist == 61 ? 1 : 0);
        alternative.AddUtilityTerm(290, destdist == 62 ? 1 : 0);
        alternative.AddUtilityTerm(291, destdist == 63 ? 1 : 0);
        alternative.AddUtilityTerm(292, destdist == 64 ? 1 : 0);
        alternative.AddUtilityTerm(293, destdist == 65 ? 1 : 0);
        alternative.AddUtilityTerm(294, destBKR == 1 ? 1 : 0);
        alternative.AddUtilityTerm(314, destdist == 66 ? 1 : 0);

      } else if (mode == Global.Settings.Modes.Walk) {
        //BKR specific constant 
        alternative.AddUtilityTerm(295, homedist == 60 ? 1 : 0);
        alternative.AddUtilityTerm(296, homedist == 61 ? 1 : 0);
        alternative.AddUtilityTerm(297, homedist == 62 ? 1 : 0);
        alternative.AddUtilityTerm(298, homedist == 63 ? 1 : 0);
        alternative.AddUtilityTerm(299, homedist == 64 ? 1 : 0);
        alternative.AddUtilityTerm(300, homedist == 65 ? 1 : 0);
        alternative.AddUtilityTerm(301, originBKR == 1 ? 1 : 0);
        alternative.AddUtilityTerm(315, homedist == 66 ? 1 : 0);

        alternative.AddUtilityTerm(295, destdist == 60 ? 1 : 0);
        alternative.AddUtilityTerm(296, destdist == 61 ? 1 : 0);
        alternative.AddUtilityTerm(297, destdist == 62 ? 1 : 0);
        alternative.AddUtilityTerm(298, destdist == 63 ? 1 : 0);
        alternative.AddUtilityTerm(299, destdist == 64 ? 1 : 0);
        alternative.AddUtilityTerm(300, destdist == 65 ? 1 : 0);
        alternative.AddUtilityTerm(301, destBKR == 1 ? 1 : 0);
        alternative.AddUtilityTerm(315, destdist == 66 ? 1 : 0);

      } else if (mode == Global.Settings.Modes.PaidRideShare) {
        //BKR specific constant 
        alternative.AddUtilityTerm(302, homedist == 60 ? 1 : 0);
        alternative.AddUtilityTerm(303, homedist == 61 ? 1 : 0);
        alternative.AddUtilityTerm(304, homedist == 62 ? 1 : 0);
        alternative.AddUtilityTerm(305, homedist == 63 ? 1 : 0);
        alternative.AddUtilityTerm(306, homedist == 64 ? 1 : 0);
        alternative.AddUtilityTerm(307, homedist == 65 ? 1 : 0);
        alternative.AddUtilityTerm(308, originBKR == 1 ? 1 : 0);
        alternative.AddUtilityTerm(316, homedist == 66 ? 1 : 0);
      }
    }
  }
}
