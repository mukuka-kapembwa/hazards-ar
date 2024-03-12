using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CandyCoded.HapticFeedback;

public class VibrationHapticsManager : MonoBehaviour
{
     public void DisableVibrationHaptics()
     {
          GetUserSettings.GetUserOptions.IsVibrationHaptic = false;
     }

     public void EnableVibrationHaptics()
     {
          GetUserSettings.GetUserOptions.IsVibrationHaptic = true;
     }

     public void HeavyVibration()
     {
          if(GetUserSettings.GetUserOptions.IsVibrationHaptic == true)
          {
               HapticFeedback.HeavyFeedback();
          }
     }

     public void LongVibration()
     {
          if(GetUserSettings.GetUserOptions.IsVibrationHaptic == true)
          {
               Handheld.Vibrate();
          }
     }
}
