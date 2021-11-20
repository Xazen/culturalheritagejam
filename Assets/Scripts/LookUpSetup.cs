using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookUpSetup : MonoBehaviour
{
    [SerializeField] private DialogSystem dialogSystem;
    [SerializeField] private PlayerInput playerInput;
    
    private void Start()
    {
        LookUp.PlayerInput = playerInput;
        LookUp.DialogSystem = dialogSystem;
    }
}