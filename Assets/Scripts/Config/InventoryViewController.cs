using System;
using System.Collections.Generic;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

namespace DefaultNamespace
{
    public class InventoryViewController : MonoBehaviour
    {
        [Serializable]
        public class TagSpriteDictionary : SerializableDictionaryBase<ItemTag, Sprite> {}

        [SerializeField] private TagSpriteDictionary spriteByItemTag;
        [SerializeField] private GameObject itemContainer;
        [SerializeField] private ItemSlot itemSlotPrefab;

        private readonly Dictionary<ItemTag, ItemSlot> itemSlotByTag = new();

        private void Start()
        {
            InitSlot(ItemTag.Bread);
            InitSlot(ItemTag.Candle);
            InitSlot(ItemTag.Cross);
            InitSlot(ItemTag.Cross);
            InitSlot(ItemTag.Flowers);
            InitSlot(ItemTag.Fragrance);
            InitSlot(ItemTag.Garlands);
            InitSlot(ItemTag.Photo);
            InitSlot(ItemTag.Salt);
            InitSlot(ItemTag.SugarSkull);

            LookUp.MessageHub.OnItemUpdated += OnItemUpdate;
            LookUp.MessageHub.OnItemUpdated += OnItemUpdate;
        }

        private void OnDestroy()
        {
            LookUp.MessageHub.OnItemUpdated -= OnItemUpdate;
        }

        private void OnItemUpdate(ItemTag itemTag, ItemState state)
        {
            itemSlotByTag[itemTag].SetState(state);
        }

        private void InitSlot(ItemTag itemTag)
        {
            var itemSlot = Instantiate(itemSlotPrefab, itemContainer.transform, false);
            itemSlot.SetSprite(spriteByItemTag[itemTag]);
            itemSlot.SetState(ItemState.Unknown);
            itemSlotByTag[itemTag] = itemSlot;
        }
    }
}