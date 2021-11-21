using System;
using UnityEngine.Events;

[Serializable]
internal class DialogComponent
{
    public ItemCondition[] Conditions;
    public TextDialog DialogText;
    public ItemChange[] Changes;
    public UnityEvent UnityEvent;
}