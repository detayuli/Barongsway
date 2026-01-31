namespace Barongslay.Core.Health
{
    using UnityEngine;
    
    [CreateAssetMenu(fileName = "WholeHealthSO", menuName = "WholeHealthSO", order = 0)]
    public class WholeHealthSO : ScriptableObject {
        public int Health{ get; set; }
        [SerializeField] private int maxHealth = 1;
    }
}