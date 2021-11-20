using System.Collections.Generic;

namespace DefaultNamespace
{
    public class InventorySystem
    {
        private readonly Dictionary<ItemTag, Item> inventory = new ();

        public void AddItem(ItemTag tag, Priority priority)
        {
            inventory.Add(tag, new Item
            {
                Priority = priority,
                State = ItemState.Unknown,
                Tag = tag
            });
        }
        
        public void UpdateState(ItemTag tag, ItemState state)
        {
            inventory[tag].State = state;
            LookUp.MessageHub.InvokeItemUpdated(tag, state);
        }

        public bool IsItemState(ItemTag itemTag, ItemState itemState)
        {
            return inventory[itemTag].State == itemState;
        }
    }
}