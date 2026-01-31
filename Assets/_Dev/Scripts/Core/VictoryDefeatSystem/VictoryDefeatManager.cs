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
            Debug.Log("[VictoryDefeatManager] Run Victory");
        }

        public void RunDefeat()
        {
            AllowKeyboardInput = false;
            OnDefeat?.Invoke();
            Debug.Log("[VictoryDefeatManager] Run Defeat");
        }
    }
}