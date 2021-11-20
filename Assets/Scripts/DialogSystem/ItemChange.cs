using System;
using UnityEngine;

[Serializable]
internal class ItemChange
{
    public ItemTag itemTag;
    public ItemState itemState;

    public void Execute()
    {
        if (itemTag != ItemTag.None)
        {
            Debug.Log($"Will update {itemTag} to {itemState}");
        }
    }
}