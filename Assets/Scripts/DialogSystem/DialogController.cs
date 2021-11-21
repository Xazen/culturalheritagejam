using System;
using DefaultNamespace;
using DefaultNamespace.DialogSystem;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private Image textDone;
    [SerializeField] private InputAction textAction;
    [SerializeField] private Button choice1Btn;
    [SerializeField] private TextMeshProUGUI choice1Text;
    [SerializeField] private Button choice2Btn;
    [SerializeField] private TextMeshProUGUI choice2Text;
    
    private int textIndex;
    private TweenerCore<string, string, StringOptions> textTweener;
    private string[] texts;
    private UnityAction completeCallback;
    private Choice choice1;
    private Choice choice2;

    private void Start()
    {
        dialogPanel.SetActive(false);
        choice1Btn.gameObject.SetActive(false);
        choice2Btn.gameObject.SetActive(false);
        dialogText.text = "";
    }

    public void ShowText(string[] texts, UnityAction completeCallback)
    {
        textAction.Enable();
        this.completeCallback = completeCallback;
        dialogPanel.SetActive(true);
        LookUp.EventSystem.SetSelectedGameObject(dialogPanel);
        this.texts = texts;
        textIndex = 0;
        ShowText(texts[textIndex]);
    }

    private void ShowText(string text)
    {
        textDone.gameObject.SetActive(false);
        textTweener = dialogText.DOText(text, text.Length * 0.03f)
            .OnUpdate(() => textDone.gameObject.SetActive(false))
            .OnComplete(() =>
            {
                textDone.gameObject.SetActive(true);
                textIndex++;
            });
    }

    private void Update()
    {
        if (textAction.WasPerformedThisFrame())
        {
            if (textTweener == null) return;
            
            if (textTweener.IsComplete())
            {
                if (textIndex < texts.Length)
                {
                    // Show next text
                    dialogText.text = "";
                    ShowText(texts[textIndex]);
                }
                else
                {
                    // Last text shown
                    if (completeCallback != null)
                    {
                        dialogPanel.SetActive(false);
                        textAction.Disable();
                        var tempCallback = completeCallback;
                        completeCallback = null;
                        tempCallback();
                        return;
                    }

                    if (choice1 != null && choice2 != null)
                    {
                        SetupButton(choice1Btn, choice1Text, choice1);
                        SetupButton(choice2Btn, choice2Text, choice2);
                        LookUp.EventSystem.SetSelectedGameObject(choice1Btn.gameObject);
                        return;
                    }
                    
                    dialogPanel.SetActive(false);
                    textAction.Disable();
                }
            }
            else
            {
                // Skip text
                textTweener.Complete(true);
            }
        }
    }

    private void SetupButton(Button button, TextMeshProUGUI text, Choice choice)
    {
        choice1Btn.gameObject.SetActive(true);
        choice2Btn.gameObject.SetActive(true);
        button.onClick.RemoveAllListeners();
        text.text = choice.ButtonText;
        button.onClick.AddListener(() =>
        {
            choice1Btn.gameObject.SetActive(false);
            choice2Btn.gameObject.SetActive(false);
            dialogText.text = "";
            ShowText(choice.Texts, () =>
            {
                var tempChoice = choice;
                choice1 = null;
                choice2 = null;
                LookUp.PlayerInput.enabled = true;
                tempChoice.Action?.Invoke();
            });
        });
    }

    public void ShowText(string[] texts, Choice choice1, Choice choice2)
    {
        this.choice2 = choice2;
        this.choice1 = choice1;
        
        textAction.Enable();
        dialogPanel.SetActive(true);
        this.texts = texts;
        textIndex = 0;
        ShowText(texts[textIndex]);
    }
}