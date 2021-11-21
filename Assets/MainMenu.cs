using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject firstInteractable;
    [SerializeField] private EventSystem eventSystem;

    private void Start()
    {
        eventSystem.SetSelectedGameObject(firstInteractable);
    }
}
