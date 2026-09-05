using UnityEngine;

namespace L1_3.Scripts.Game.Gameplay.Subsequence.Config
{
    [CreateAssetMenu(fileName = "SubsequenceConfig", menuName = "Config/Gameplay/SubsequenceConfig")]
    public class SubsequenceConfig : ScriptableObject
    {
        [field: SerializeField] public string Subsequence { get; private set; }
    }
}