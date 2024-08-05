using UnityEngine;
using UnityEngine.AI;

public class MovimientoEnemigo : MonoBehaviour
{
    public float velocidadEnemigo = 3f;
    private Transform objetivo;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        BuscarJugador();
    }

    void Update()
    {
        if (objetivo != null)
        {
            navMeshAgent.SetDestination(objetivo.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScriptPrincipal scriptPrincipal = FindObjectOfType<ScriptPrincipal>();
            if (scriptPrincipal != null)
            {
                scriptPrincipal.RecibirDanio(15);
            }
        }
    }

    void BuscarJugador()
    {
        objetivo = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (objetivo != null)
        {
            Debug.Log("Objetivo encontrado: " + objetivo.name);
            navMeshAgent.SetDestination(objetivo.position);
        }
        else
        {
            Debug.LogWarning("No se encontró el objetivo con tag 'Player'.");
        }
    }
}
