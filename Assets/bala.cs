using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float velocidad = 10f;
    public int da�o = 1;
    public float tiempoVida = 3f;

    void Start()
    {
        Destroy(gameObject, tiempoVida);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            Debug.Log("La bala golpe� al enemigo");
            enemy enemigo = other.GetComponent<enemy>();

            if (enemigo != null)
            {
                enemigo.RecibirDa�o(da�o);
            }

            Destroy(gameObject);
        }
    }
}
