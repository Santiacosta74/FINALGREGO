using UnityEngine;
using UnityEngine.UI;

public class EquipamientoPersonaje : MonoBehaviour
{
    public Transform manoDelJugador;
    private ParticleSystem efectoDisparo;
    public GameObject prefabBala;
    public float tiempoVidaBala = 5f;
    public Transform spawnBala;

    private bool tieneArmaEquipada = false;
    private int balasRestantes = 15;
    private bool necesitaRecarga = false;

    public Text mensajeRecargaTexto;
    public Text contadorBalasTexto;

    private AudioSource audioSource; // Referencia al componente de audio

    void Start()
    {
        efectoDisparo = GetComponentInChildren<ParticleSystem>();
        audioSource = GetComponent<AudioSource>(); // Obtener el componente de audio
        ActualizarInterfaz();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && tieneArmaEquipada && balasRestantes > 0)
        {
            Disparar(spawnBala);
        }

        if (necesitaRecarga)
        {
            mensajeRecargaTexto.text = "Presiona R para recargar";
            if (Input.GetKeyDown(KeyCode.R))
            {
                Recargar();
            }
        }
        else
        {
            mensajeRecargaTexto.text = "";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RecogerArma();
        }
    }

    void RecogerArma()
    {
        GameObject armaRecogida = GameObject.FindGameObjectWithTag("ArmaRecogible");
        if (armaRecogida != null)
        {
            Light pointLight = armaRecogida.GetComponentInChildren<Light>();
            if (pointLight != null) pointLight.enabled = false;

            armaRecogida.transform.SetParent(manoDelJugador);
            armaRecogida.transform.localPosition = Vector3.zero;
            armaRecogida.transform.localRotation = Quaternion.identity;

            tieneArmaEquipada = true;
            balasRestantes = 15;
            necesitaRecarga = false;
            ActualizarInterfaz();

            // Reproducir el sonido al recoger el arma
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }

    void Disparar(Transform origen)
    {
        if (balasRestantes > 0)
        {
            if (efectoDisparo != null) efectoDisparo.Play();

            if (prefabBala != null)
            {
                Instantiate(prefabBala, origen.position, origen.rotation);
                balasRestantes--;
                necesitaRecarga = (balasRestantes <= 0);
                ActualizarInterfaz();
            }
        }
    }

    void Recargar()
    {
        balasRestantes = 15;
        necesitaRecarga = false;
        ActualizarInterfaz();
    }

    void ActualizarInterfaz()
    {
        contadorBalasTexto.gameObject.SetActive(tieneArmaEquipada);
        if (tieneArmaEquipada)
        {
            contadorBalasTexto.text = balasRestantes + "/15";
        }
    }
}
