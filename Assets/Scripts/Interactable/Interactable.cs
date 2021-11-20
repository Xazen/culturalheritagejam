using UnityEngine;

namespace DefaultNamespace.Interactable
{
    public abstract class Interactable : MonoBehaviour, IInteractable
    {
        public abstract void Interact();
    }
}