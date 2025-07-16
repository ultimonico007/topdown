using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    public float duracion = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            disparo d = other.GetComponent<disparo>();
            if (d != null)
            {
                d.ActivarDisparoTriple(duracion);
            }

            Destroy(gameObject);
        }
    }
}
