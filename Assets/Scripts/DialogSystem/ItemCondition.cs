using System;

[Serializable]
internal class ItemCondition
{
    public ItemTag itemTag;
    public ItemState itemState;

    public bool IsValid()
    {
        return itemTag == ItemTag.None && true;
    }
}