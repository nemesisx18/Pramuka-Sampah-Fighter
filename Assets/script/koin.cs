using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class koin : MonoBehaviour
{
    public int koinValue = 1; // Nilai koin yang diberikan ketika diambil

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gerak playerGerak = other.GetComponent<gerak>();
            if (playerGerak != null)
            {
                playerGerak.UpdateKoin(koinValue); // Panggil fungsi UpdateKoin() pada kelas gerak
            }

            Destroy(gameObject);
        }
    }
}
