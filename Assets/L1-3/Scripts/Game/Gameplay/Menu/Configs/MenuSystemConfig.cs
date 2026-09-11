using UnityEngine;

namespace L1_3.Scripts.Game.Gameplay.Menu.Configs
{
    [CreateAssetMenu(fileName = "MenuSystemConfig", menuName = "Configs/Menu/MenuSystemConfig")]
    public class MenuSystemConfig : ScriptableObject
    {
        [field: SerializeField] public int ResetCost { get; private set; }
    }
}