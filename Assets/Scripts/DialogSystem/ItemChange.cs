using System;
using DefaultNamespace;
using UnityEngine;

[Serializable]
internal class ItemChange
{
    public ItemTag itemTag;
    public ItemState itemState;

    public void Execute()
    {
        if (itemTag != ItemTag.Fallback)
        {
            LookUp.InventorySystem.UpdateState(itemTag, itemState);
            if (itemState == ItemState.Collected)
            {
                LookUp.AudioCollection.PlayItemGet();
            }
            Debug.Log($"Will update {itemTag} to {itemState}");
        }
    }
}