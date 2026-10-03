namespace L4_5.Develop.Gameplay.Utilities.Conditions
{
    public interface ICompositeCondition : ICondition
    {
        ICompositeCondition Add(ICondition condition);
        
        ICompositeCondition Remove(ICondition condition);
    }

    public class LogicOperations
    {
        public static bool And(bool a, bool b) => a && b;
        
        public static bool Or(bool a, bool b) => a || b;
    }
}