using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    [SerializeField] private Button exitButton;
    
    void Start()
    {
        gameObject.SetActive(false);
        continueButton.onClick.AddListener(() => gameObject.SetActive(false));
        exitButton.onClick.AddListener(() => LookUp.DialogOptions.SwitchToMainMenu());
    }

    private void OnEnable()
    {
        LookUp.PlayerInput.enabled = false;
    }

    private void OnDisable()
    {
        LookUp.PlayerInput.enabled = true;
    }
}
