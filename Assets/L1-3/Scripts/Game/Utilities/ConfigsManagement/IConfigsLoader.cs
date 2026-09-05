using System;
using System.Collections;
using System.Collections.Generic;

namespace L1_3.Scripts.Game.Utilities.ConfigsManagement
{
    public interface IConfigsLoader
    {
        IEnumerator LoadAsync(Action<Dictionary<Type, object>> onConfigsLoaded);
    }
}