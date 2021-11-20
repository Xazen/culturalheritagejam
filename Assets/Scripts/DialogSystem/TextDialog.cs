﻿using System;
using DefaultNamespace;

[Serializable]
internal class TextDialog
{
    public string[] Texts;
    private Action onCompleteAction;

    public void Execute()
    {
        LookUp.DialogController.ShowText(Texts, onCompleteAction);
    }

    public void OnComplete(Action action)
    {
        onCompleteAction = action;
    }
}