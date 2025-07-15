using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUERTA : MonoBehaviour
{
    public Animator puertaIzquierda;
    public Animator puertaDerecha;
    public GameObject cartelInteraccion;

    private bool jugadorCerca = false;
    private bool puertaYaSeAbrio = false;

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E) && !puertaYaSeAbrio)
        {
            puertaIzquierda.SetTrigger("Abrir");
            puertaDerecha.SetTrigger("Abrir");
            puertaYaSeAbrio = true;
            cartelInteraccion.SetActive(false); // Oculta cartel al abrir
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !puertaYaSeAbrio)
        {
            jugadorCerca = true;
            cartelInteraccion.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            cartelInteraccion.SetActive(false);
        }
    }
}