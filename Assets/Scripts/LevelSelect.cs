using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button level2Button;

    void Start()
    {
        // cek apakah Lv1 sudah selesai
        if (PlayerPrefs.GetInt("Lv1Selesai", 0) == 1)
        {
            level2Button.interactable = true;
        }
        else
        {
            level2Button.interactable = false;
        }
    }


    public void LoadLevel1()
    {
        SceneManager.LoadScene("Lv1");
    }


    public void LoadLevel2()
    {
        // cek lagi sebelum masuk
        if (PlayerPrefs.GetInt("Lv1Selesai", 0) == 1)
        {
            SceneManager.LoadScene("Lv2");
        }
        else
        {
            Debug.Log("Selesaikan Level 1 dulu!");
        }
    }


    public void BackMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}