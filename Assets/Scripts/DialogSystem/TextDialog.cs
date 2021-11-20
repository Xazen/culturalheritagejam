using System;
using UnityEngine;

[Serializable]
internal class TextDialog
{
    public string[] Texts;
    private Action onCompleteAction;

    public void Execute()
    {
        foreach (var text in Texts)
        {
            Debug.Log(text);
        }
        onCompleteAction.Invoke();
    }

    public void OnComplete(Action action)
    {
        onCompleteAction = action;
    }
}