using System;
using UnityEngine.Events;

namespace DefaultNamespace.DialogSystem
{
    [Serializable]
    public class Choice
    {
        public string[] Texts;
        public string ButtonText;
        public UnityEvent Action;
    }
}