﻿public class MessageHub
{
    public delegate void ItemUpdated(ItemTag tag, ItemState state);
    public event ItemUpdated OnItemUpdated;

    public void InvokeItemUpdated(ItemTag itemTag, ItemState state)
    {
        OnItemUpdated?.Invoke(itemTag, state);
    }
}