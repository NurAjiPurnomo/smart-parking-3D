using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("Timer")]
    public float timeLeft = 60f;

    [Header("UI")]
    public TMP_Text timerText;
    public GameObject gameOverPanel;

    private bool gameEnded = false;

    void Update()
    {
        // Jika game sudah selesai
        if (gameEnded)
            return;

        // Kurangi waktu
        timeLeft -= Time.deltaTime;

        // Tampilkan waktu ke UI
        timerText.text = Mathf.Ceil(timeLeft).ToString();

        // Jika waktu habis
        if (timeLeft <= 0)
        {
            timeLeft = 0;
            GameOver();
        }
    }

    // Dipanggil saat parkir berhasil
    public void WinGame()
    {
        gameEnded = true;
    }

    // GAME OVER
    void GameOver()
    {
        gameEnded = true;

        Debug.Log("GAME OVER");

        // Tampilkan tulisan GAME OVER
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // Kembali ke pilih level
        StartCoroutine(ReturnToLevelSelect());
    }

    IEnumerator ReturnToLevelSelect()
    {
        // Tunggu 3 detik
        yield return new WaitForSeconds(3f);

        // Pindah ke Level Select
        SceneManager.LoadScene("LevelSelect");
    }
}