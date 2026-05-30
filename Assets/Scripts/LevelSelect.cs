using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Lv1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Lv2");
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}