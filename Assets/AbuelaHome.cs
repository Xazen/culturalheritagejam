using System;
using System.Linq;
using DefaultNamespace;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

public class AbuelaHome : MonoBehaviour
{
    [Serializable]
    public class TagGameObjectDict : SerializableDictionaryBase<ItemTag, string> {}

    [SerializeField] private TagGameObjectDict unityTagByItem;
    [SerializeField] private GameObject omaObject;

    private void Start()
    {
        LookUp.MessageHub.OnEnterHome += OnEnterHome;
    }

    private void OnDestroy()
    {
        LookUp.MessageHub.OnEnterHome -= OnEnterHome;
    }

    private void OnEnterHome()
    {
        foreach (var entry in unityTagByItem)
        {
            var isCollected = LookUp.InventorySystem.IsItemState(entry.Key, ItemState.Collected);
            var objects = GameObject.FindGameObjectsWithTag(entry.Value);
            foreach (var o in objects)
            {
                o.SetActive(isCollected);
            }
        }

        omaObject.SetActive(
            unityTagByItem.Keys.All(itemTag => LookUp.InventorySystem.IsItemState(itemTag, ItemState.Collected))
        );
    }
}
