using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ItemSlot : MonoBehaviour
    {
        [SerializeField] private Image image;

        public void SetSprite(Sprite icon)
        {
            image.sprite = icon;
        }

        public void SetState(ItemState state)
        {
            switch (state)
            {
                case ItemState.None:
                case ItemState.Unknown:
                    gameObject.SetActive(false);
                    break;
                case ItemState.Known:
                    gameObject.SetActive(true);
                    var knownColor = image.color;
                    knownColor.a = 0.5f;
                    image.color = knownColor;
                    break;
                case ItemState.Collected:
                    gameObject.SetActive(true);
                    var collectedAlpha = image.color;
                    collectedAlpha.a = 1f;
                    image.color = collectedAlpha;
                    break;
            }
        }
    }
}