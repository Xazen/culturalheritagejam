using System;

namespace DefaultNamespace.DialogSystem
{
    [Serializable]
    public class MultipleChoiceComponent
    {
        public ItemCondition[] Conditions;
        public MultipleChoiceDialog DialogText;
    }
}