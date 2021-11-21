using DefaultNamespace;
using UnityEngine;

public class Intro : MonoBehaviour
{
    [SerializeField] private TextDialog _textDialog;
    
    private void Start()
    {
        LookUp.PlayerInput.enabled = false;
        LookUp.DialogController.ShowText(_textDialog.Texts, () => LookUp.PlayerInput.enabled = true);
    }
}
