using UnityEngine;
using System.Collections;

public class ParkingStep1 : MonoBehaviour
{
    public GameObject petunjukText;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;

            Debug.Log("LANJUT KE PARKIRAN 2");

            // Tampilkan petunjuk
            if (petunjukText != null)
            {
                StartCoroutine(ShowPetunjuk());
            }

            // Nonaktifkan trigger saja
            GetComponent<Collider>().enabled = false;
        }
    }

    IEnumerator ShowPetunjuk()
    {
        // Munculkan text
        petunjukText.SetActive(true);

        // Tunggu 5 detik
        yield return new WaitForSeconds(5f);

        // Hilangkan text
        petunjukText.SetActive(false);
    }
}