using System;
using DefaultNamespace;

[Serializable]
public class ItemCondition
{
    public ItemTag itemTag;
    public ItemState itemState;

    public bool IsValid()
    {
        return itemTag == ItemTag.Fallback || 
               LookUp.InventorySystem.IsItemState(itemTag, itemState);
    }
}