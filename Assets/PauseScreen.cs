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
        if (LookUp.PlayerInput != null)
        {
            LookUp.EventSystem.SetSelectedGameObject(continueButton.gameObject);
            LookUp.PlayerInput.enabled = false;
        }
    }

    private void OnDisable()
    {
        if (LookUp.PlayerInput != null)
        {
            LookUp.PlayerInput.enabled = true;
        }
    }
}
