using UnityEngine;
using UnityEngine.Serialization;

namespace L1_3.Scripts.Game.Gameplay.Subsequence.Config
{
    [CreateAssetMenu(fileName = "SubsequenceConfigs", menuName = "Config/Gameplay/SubsequenceConfigs")]
    public class SubsequenceConfigs : ScriptableObject
    {
        [field: SerializeField] public int Length { get; private set; }
        [field: SerializeField] public int WinGold { get; private set; }
        [field: SerializeField] public int LoseGold { get; private set; }
        
        [field: SerializeField] public SubsequenceConfig Numbers { get; private set; }
        
        [field: SerializeField] public SubsequenceConfig Chars { get; private set; }
    }
}