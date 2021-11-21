using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class LookUpSetup : MonoBehaviour
{
    [FormerlySerializedAs("dialogSystem")] [SerializeField] private DialogController dialogController;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private Transform abuelaSpawnPoint;
    [SerializeField] private GameObject player;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private DialogOptions dialogOptions;
    
    private void Start()
    {
        LookUp.PlayerInput = playerInput;
        LookUp.DialogController = dialogController;
        LookUp.EventSystem = eventSystem;
        LookUp.AbuelaSpawnPoint = abuelaSpawnPoint;
        LookUp.Player = player;
        LookUp.PauseScreen = pauseScreen;
        LookUp.DialogOptions = dialogOptions;
        LookUp.CharacterController = characterController;
        LookUp.MessageHub = new MessageHub();
        LookUp.InventorySystem = new InventorySystem();
        
        LookUp.InventorySystem.AddItem(ItemTag.Flowers, Priority.MustHave);
        LookUp.InventorySystem.AddItem(ItemTag.Photo, Priority.MustHave);
        LookUp.InventorySystem.AddItem(ItemTag.SugarSkull, Priority.MustHave);
        LookUp.InventorySystem.AddItem(ItemTag.Bread, Priority.MustHave);
        
        LookUp.InventorySystem.AddItem(ItemTag.Candle, Priority.NiceToHave);
        LookUp.InventorySystem.AddItem(ItemTag.Garlands, Priority.NiceToHave);
        LookUp.InventorySystem.AddItem(ItemTag.Salt, Priority.NiceToHave);
        LookUp.InventorySystem.AddItem(ItemTag.Cross, Priority.NiceToHave);
        LookUp.InventorySystem.AddItem(ItemTag.Fragrance, Priority.NiceToHave);
    }
}