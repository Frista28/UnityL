using System;
using Random = UnityEngine.Random;

namespace L1_3.Scripts.Game.Gameplay.Subsequence
{
    public class SubsequenceGenerator
    {
        public string Generate(SubsequenceType subsequenceType, int length)
        {
            string items = subsequenceType switch
            {
                SubsequenceType.Number => "123",
                SubsequenceType.Chars => "qwerty",
                _ => throw new ArgumentException("Invalid SubsequenceType")
            };
            
            char[] generatedChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                generatedChars[i] = items[Random.Range(0, items.Length)];
            }

            return new string(generatedChars);
        }
    }
}