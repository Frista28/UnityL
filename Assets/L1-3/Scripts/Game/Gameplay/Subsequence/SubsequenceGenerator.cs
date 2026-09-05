using System;
using L1_3.Scripts.Game.DI;
using L1_3.Scripts.Game.Gameplay.Subsequence.Config;
using L1_3.Scripts.Game.Utilities.ConfigsManagement;
using Random = UnityEngine.Random;

namespace L1_3.Scripts.Game.Gameplay.Subsequence
{
    public class SubsequenceGenerator
    {
        private readonly SubsequenceConfigs _subsequenceConfigs;
        
        public SubsequenceGenerator(DIContainer container)
        {
            _subsequenceConfigs = container.Resolve<ConfigsProviderService>().GetConfig<SubsequenceConfigs>();
        }
        
        public string Generate(SubsequenceType subsequenceType)
        {
            string items = subsequenceType switch
            {
                SubsequenceType.Number => _subsequenceConfigs.Numbers.Subsequence,
                SubsequenceType.Chars => _subsequenceConfigs.Chars.Subsequence,
                _ => throw new ArgumentException("Invalid SubsequenceType")
            };
            
            int length = _subsequenceConfigs.Length;
            
            char[] generatedChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                generatedChars[i] = items[Random.Range(0, items.Length)];
            }

            return new string(generatedChars);
        }
    }
}