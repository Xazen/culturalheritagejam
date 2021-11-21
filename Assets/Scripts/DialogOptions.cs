using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogOptions : MonoBehaviour
{
    public void SwitchToMainMenu()
    {
        SceneManager.LoadScene(SceneConst.MainMenu);
    }
    
    public void SwitchToGame()
    {
        SceneManager.LoadScene(SceneConst.Game);
    }
    
    public void ExitApplication()
    {
        Application.Quit();
    }
    
    public void OpenPause()
    {
        LookUp.PauseScreen.SetActive(true);
    }
    
    public void GoToAbuela()
    {
        var characterController = LookUp.CharacterController;
        characterController.enabled = false;
        var target = LookUp.AbuelaSpawnPoint.transform;
        LookUp.Player.transform.position = target.position;
        LookUp.Player.transform.rotation = target.rotation;
        characterController.enabled = true;
        LookUp.MessageHub.InvokeOnOnEnterHome();
    }

    private void Update()
    {
        if (LookUp.PlayerInput != null && LookUp.PlayerInput.actions[InputActions.Pause].WasPerformedThisFrame())
        {
            OpenPause();
        }
    }
}
