using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private Image textDone;
    [SerializeField] private InputAction textAction;
    
    private int textIndex;
    private TweenerCore<string, string, StringOptions> textTweener;
    private string[] texts;
    private Action completeCallback;

    private void Start()
    {
        dialogPanel.SetActive(false);
        dialogText.text = "";
    }

    public void ShowText(string[] texts, Action completeCallback)
    {
        textAction.Enable();
        this.completeCallback = completeCallback;
        dialogPanel.SetActive(true);
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
                    dialogPanel.SetActive(false);
                    textAction.Disable();
                    completeCallback();
                }
            }
            else
            {
                // Skip text
                textTweener.Complete(true);
            }
        }
    }
}