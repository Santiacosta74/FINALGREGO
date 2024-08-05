using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    public GameObject enemigoPrefab;
    public GameObject enemigoPrefa2;
    public GameObject enemigoPrefab3;
    public Transform[] puntosDeSpawn;
    public float tiempoEntreSpawns = 5f;
    public int maxEnemigos = 12; 
    private int enemigosActuales = 0;
    private bool activarSpawn = false; 

    void Start()
    {
        // Inicialmente no activa el spawn
        activarSpawn = false;
    }

    void Update()
    {
        if (activarSpawn)
        {
            // Llama a la función de spawn continuamente
            if (enemigosActuales < maxEnemigos)
            {
                InvokeRepeating("SpawnearEnemigo", 0f, tiempoEntreSpawns);
            }
        }
    }

    void SpawnearEnemigo()
    {
        if (activarSpawn && enemigosActuales < maxEnemigos)
        {
            Transform puntoDeSpawn = puntosDeSpawn[Random.Range(0, puntosDeSpawn.Length)];
            GameObject enemigo = null;

            int prefabIndex = Random.Range(0, 3);
            switch (prefabIndex)
            {
                case 0:
                    enemigo = enemigoPrefab;
                    break;
                case 1:
                    enemigo = enemigoPrefa2;
                    break;
                case 2:
                    enemigo = enemigoPrefab3;
                    break;
            }

            Instantiate(enemigo, puntoDeSpawn.position, puntoDeSpawn.rotation);
            enemigosActuales++;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activarSpawn = true; // Activa el spawn
        }
    }
}
