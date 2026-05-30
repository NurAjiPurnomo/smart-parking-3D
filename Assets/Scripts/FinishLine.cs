using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SensorFinish : MonoBehaviour
{
    [Header("UI")]
    public GameObject berhasilPanel;

    [Header("Setting")]
    public float delayBeforeNextLevel = 3f;

    private bool finished = false;

    private Rigidbody carRb;

    private void OnTriggerEnter(Collider other)
    {
        // Mobil masuk area parkir
        if (other.CompareTag("Player") && !finished)
        {
            carRb = other.GetComponent<Rigidbody>();

            // Cek apakah mobil benar-benar berhenti
            if (carRb != null)
            {
                StartCoroutine(CheckParking(other));
            }
        }
    }

    IEnumerator CheckParking(Collider player)
    {
        while (!finished)
        {
            // Pastikan mobil masih di area parkir
            if (player.bounds.Intersects(GetComponent<Collider>().bounds))
            {
                // Cek apakah mobil berhenti
                if (carRb.linearVelocity.magnitude < 0.2f)
                {
                    finished = true;

                    Debug.Log("PARKIR BERHASIL!");

                    // Tampilkan tulisan BERHASIL
                    if (berhasilPanel != null)
                    {
                        berhasilPanel.SetActive(true);
                    }

                    // Tunggu beberapa detik
                    yield return new WaitForSeconds(delayBeforeNextLevel);

                    // Kembali ke pilih level
                    SceneManager.LoadScene("LevelSelect");
                }
            }

            yield return null;
        }
    }
}