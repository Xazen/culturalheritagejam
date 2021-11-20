using DefaultNamespace.Interactable;
using UnityEngine;

public class DialogInteractable : Interactable
{
    [SerializeField]
    private DialogComponent dialogComponent;

    public override void Interact()
    {
        if (dialogComponent.Condition.IsValid())
        {
            dialogComponent.DialogText.OnComplete(() => dialogComponent.Change.Execute());
            dialogComponent.DialogText.Execute();
        }
    }
}