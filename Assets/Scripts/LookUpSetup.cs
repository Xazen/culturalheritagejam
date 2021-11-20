using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookUpSetup : MonoBehaviour
{
    private void Start()
    {
        LookUp.PlayerInput = GameObject.FindWithTag("Player").GetComponent<PlayerInput>();
    }
}
