using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public Transform puntoDisparo;
    public float velocidadProyectil = 20f;
    public AudioSource audioDisparo;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bala = Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);
            Rigidbody rb = bala.GetComponent<Rigidbody>();
            rb.velocity = puntoDisparo.forward * velocidadProyectil;

            Destroy(bala, 3f); // auto destrucción

            if (audioDisparo != null)
                audioDisparo.Play();
        }
    }
}
