using System;
using AriverseStudio.Singletons;
using UnityEngine;
namespace Barongslay.Core.VictoryDefeat
{
    public class VictoryDefeatManager : Singleton<VictoryDefeatManager>
    {

        public bool AllowKeyboardInput { get; set; } = true;    
        public Action OnVictory;
        public Action OnDefeat;
        public void RunVictory()
        {
            AllowKeyboardInput = false;
            OnVictory?.Invoke();
            audiomanager.Instance.PlaySFX(audiomanager.Instance.WinSound);
            Debug.Log("[VictoryDefeatManager] Run Victory");
        }

        public void RunDefeat()
        {
            AllowKeyboardInput = false;
            OnDefeat?.Invoke();
            audiomanager.Instance.PlaySFX(audiomanager.Instance.LoseSound);
            Debug.Log("[VictoryDefeatManager] Run Defeat");
        }
    }
}