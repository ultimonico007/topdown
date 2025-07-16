using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour
{
    public GameObject proyectilNormal;
    public GameObject proyectilTriple;
    public Transform puntoDisparo;
    public float velocidadProyectil = 20f;
    public AudioSource audioDisparo;

    private bool usarDisparoTriple = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (usarDisparoTriple)
                DispararTriple();
            else
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

    void DispararTriple()
    {
        DispararEnDireccion(0);     
        DispararEnDireccion(-15);   
        DispararEnDireccion(15);    
    }

    void DispararEnDireccion(float anguloY)
    {
        Quaternion rotacion = Quaternion.Euler(0, anguloY, 0) * puntoDisparo.rotation;
        GameObject bala = Instantiate(proyectilTriple, puntoDisparo.position, rotacion);
        Rigidbody rb = bala.GetComponent<Rigidbody>();
        rb.AddForce(puntoDisparo.forward * velocidadProyectil, ForceMode.VelocityChange);
        Destroy(bala, 3f);
    }

    public void ActivarDisparoTriple(float duracion)
    {
        StopAllCoroutines();
        StartCoroutine(TemporizadorTriple(duracion));
    }

    IEnumerator TemporizadorTriple(float duracion)
    {
        usarDisparoTriple = true;
        yield return new WaitForSeconds(duracion);
        usarDisparoTriple = false;
    }
}
