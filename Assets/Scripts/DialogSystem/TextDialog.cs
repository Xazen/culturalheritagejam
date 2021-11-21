using System;
using DefaultNamespace;
using UnityEngine.Events;

[Serializable]
public class TextDialog
{
    public string[] Texts;
    private UnityAction onCompleteAction;

    public void Execute()
    {
        LookUp.DialogController.ShowText(Texts, onCompleteAction);
    }

    public void OnComplete(UnityAction action)
    {
        onCompleteAction = action;
    }
}