using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SensorFinish : MonoBehaviour
{
    public GameObject berhasilPanel;

    public float delayBeforeNextLevel = 3f;

    private bool finished = false;

    private Rigidbody carRb;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !finished)
        {
            carRb = other.GetComponent<Rigidbody>();

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
            if (player.bounds.Intersects(GetComponent<Collider>().bounds))
            {
                if (carRb.linearVelocity.magnitude < 0.2f)
                {
                    finished = true;

                    Debug.Log("PARKIR BERHASIL!");

                    // buka Level 2
                    PlayerPrefs.SetInt("Lv1Selesai", 1);
                    PlayerPrefs.Save();


                    if (berhasilPanel != null)
                    {
                        berhasilPanel.SetActive(true);
                    }


                    yield return new WaitForSeconds(delayBeforeNextLevel);


                    SceneManager.LoadScene("LevelSelect");
                }
            }

            yield return null;
        }
    }
}