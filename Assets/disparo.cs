using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour
{
    public GameObject proyectilNormal;
    public Transform puntoDisparo;
    public float velocidadProyectil = 20f;
    public AudioSource audioDisparo;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DispararSimple();

            if (audioDisparo != null)
                audioDisparo.Play();
        }
    }

    void DispararSimple()
    {
        GameObject bala = Instantiate(proyectilNormal, puntoDisparo.position, puntoDisparo.rotation);
        Rigidbody rb = bala.GetComponent<Rigidbody>();
        rb.velocity = puntoDisparo.forward * velocidadProyectil;
        Destroy(bala, 3f);
    }
}
