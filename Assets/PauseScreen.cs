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
}
