using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogOptions : MonoBehaviour
{
    public void SwitchToMainMenu()
    {
        SceneManager.LoadScene(SceneConst.MainMenu);
    }
    
    public void OpenPause()
    {
        LookUp.PauseScreen.SetActive(true);
    }
    
    public void GoToAbuela()
    {
        var target = LookUp.AbuelaSpawnPoint.transform;
        LookUp.Player.transform.position = target.position;
        LookUp.Player.transform.rotation = target.rotation;
    }
}
