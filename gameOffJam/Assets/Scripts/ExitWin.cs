using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ExitWin : MonoBehaviour
{
    public Image button;
    public Sprite image;
    
    public void OnExitWin()
    {
        button.sprite = image;
        SceneManager.LoadScene(0);
    }
}
