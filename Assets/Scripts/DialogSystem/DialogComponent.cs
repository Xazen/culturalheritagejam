using System;

[Serializable]
internal class DialogComponent
{
    public ItemCondition[] Conditions;
    public TextDialog DialogText;
    public ItemChange[] Changes;
}