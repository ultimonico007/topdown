using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIN : MonoBehaviour
{
    public GameObject cartelVictoria; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (cartelVictoria != null)
                cartelVictoria.SetActive(true); 
            Debug.Log("¡Victoria!");
        }
    }
}
