using System;

namespace DefaultNamespace.DialogSystem
{
    [Serializable]
    public class MultipleChoiceDialog
    {
        public string[] Texts;
        public Choice Choice1;
        public Choice Choice2;

        public void Execute()
        {
            LookUp.DialogController.ShowText(Texts, Choice1, Choice2);
        }
    }
}