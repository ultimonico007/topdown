using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public int vida = 3;
    public NavMeshAgent agente;
    public Transform jugador;
    public AudioSource audiomuerte;

    void Start()
    {
        if (jugador == null)
            jugador = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (agente == null)
            agente = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (jugador != null && agente != null)
        {
            agente.SetDestination(jugador.position);
        }
    }

    public void RecibirDa�o(int da�o)
    {
        vida -= da�o;

        if (vida <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        if (audiomuerte != null && audiomuerte.clip != null)
        {
            AudioSource.PlayClipAtPoint(audiomuerte.clip, transform.position);
        }

        Destroy(gameObject);
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("El enemigo toc� al jugador");

           
            Destroy(collision.gameObject);
        }
    }
}