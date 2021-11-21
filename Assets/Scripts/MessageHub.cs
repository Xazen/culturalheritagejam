public class MessageHub
{
    public delegate void ItemUpdated(ItemTag tag, ItemState state);
    public event ItemUpdated OnItemUpdated;
    
    
    public delegate void EnterHome();
    public event EnterHome OnEnterHome;

    public void InvokeItemUpdated(ItemTag itemTag, ItemState state)
    {
        OnItemUpdated?.Invoke(itemTag, state);
    }

    public void InvokeOnOnEnterHome()
    {
        OnEnterHome?.Invoke();
    }
}