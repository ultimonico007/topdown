using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public int daño = 1;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            enemy enemigo = collision.gameObject.GetComponent<enemy>();
            if (enemigo != null)
            {
                enemigo.RecibirDaño(daño);
            }
        }

        Destroy(gameObject); 
    }
}
