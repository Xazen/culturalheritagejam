using System.Linq;
using DefaultNamespace;
using DefaultNamespace.Interactable;
using UnityEngine;

public class DialogInteractable : Interactable
{
    [SerializeField]
    private DialogComponent[] dialogComponents;

    public override void Interact()
    {
        foreach (var dialogComponent in dialogComponents)
        {
            if (dialogComponent.Conditions.Any(dialogComponentCondition => !dialogComponentCondition.IsValid()))
            {
                return;
            }

            dialogComponent.DialogText.OnComplete(() =>
            {
                foreach (var change in dialogComponent.Changes)
                {
                    change.Execute();
                }

                dialogComponent.UnityEvent?.Invoke();
                
                LookUp.PlayerInput.enabled = true;
            });

            dialogComponent.DialogText.Execute();
            return;
        }
    }

    public override bool IsAnyInteractable()
    {
        foreach (var dialogComponent in dialogComponents)
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