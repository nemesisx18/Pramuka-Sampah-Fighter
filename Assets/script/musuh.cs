using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musuh : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gerak playerGerak = other.GetComponent<gerak>();
            if (playerGerak != null)
            {
                playerGerak.UpdateNyawa(-1); // Kurangi nyawa pemain sebanyak 1
                playerGerak.ulang = true; // Set pemain untuk respawn (reset position)
            }
        }
    }
}
