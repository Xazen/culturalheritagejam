using System.Linq;
using DefaultNamespace.DialogSystem;
using UnityEngine;

namespace DefaultNamespace.Interactable
{
    public class MultipleChoiceInteractable : Interactable
    {
        [SerializeField]
        private MultipleChoiceComponent[] multipleChoiceComponent; 
        
        public override void Interact()
        {
            foreach (var dialogComponent in multipleChoiceComponent)
            {
                if (dialogComponent.Conditions.Any(dialogComponentCondition => !dialogComponentCondition.IsValid()))
                {
                    return;
                }

                dialogComponent.DialogText.Execute();
                return;
            }
        }

        public override bool IsAnyInteractable()
        {
            foreach (var dialogComponent in multipleChoiceComponent)
            {
                if (dialogComponent.Conditions.Any(condition => !condition.IsValid()))
                {
                    continue;
                }

                return true;
            }

            return false;
        }
    }
}