using System;
using DefaultNamespace;

[Serializable]
internal class ItemCondition
{
    public ItemTag itemTag;
    public ItemState itemState;

    public bool IsValid()
    {
        return itemTag == ItemTag.Fallback || LookUp.InventorySystem.IsItemState(itemTag, itemState);
    }
}