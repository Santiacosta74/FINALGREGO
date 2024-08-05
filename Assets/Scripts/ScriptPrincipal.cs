using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptPrincipal : MonoBehaviour
{
    public Text vidaTexto;
    public Text balasTexto;
    public Text killsTexto;
    public Text contadorLucesTexto;

    public GameObject panelMuerte;
    public GameObject panelVictoria;
    public GameObject finalObject;

    private int vida = 100;
    private int balas = 15;
    private int kills = 0;
    private int lucesRecolectadas = 0;
    private const int totalLuces = 12;

    void Start()
    {
        vidaTexto = GameObject.Find("Vida").GetComponent<Text>();
        balasTexto = GameObject.Find("Balas").GetComponent<Text>();
        killsTexto = GameObject.Find("Kills").GetComponent<Text>();
        contadorLucesTexto = GameObject.Find("ContadorLuces").GetComponent<Text>();

        ActualizarInterfaz();
        Time.timeScale = 1;
    }

    void ActualizarInterfaz()
    {
        vidaTexto.text = "" + vida;
        balasTexto.text = balas + "/15";
        killsTexto.text = "Kills: " + kills;
        contadorLucesTexto.text = "Luces: " + lucesRecolectadas + "/" + totalLuces;
    }

    public void RecibirDanio(int cantidadDanio)
    {
        vida -= cantidadDanio;
        vida = Mathf.Max(0, vida);

        ActualizarInterfaz();

        if (vida == 0)
        {
            ActivarPantallaMuerte();
        }
    }

    void ActivarPantallaMuerte()
    {
        if (panelMuerte != null)
        {
            panelMuerte.SetActive(true);
            PausarJuego();
        }
        else
        {
            Debug.LogError("¡Error! Panel de muerte no asignado.");
        }
    }

    void ActivarPantallaVictoria()
    {
        if (panelVictoria != null)
        {
            panelVictoria.SetActive(true);
            PausarJuego();
        }
        else
        {
            Debug.LogError("¡Error! Panel de victoria no asignado.");
        }
    }

    public void IncrementarBalas(int cantidadBalas)
    {
        balas += cantidadBalas;
        ActualizarInterfaz();
    }

    public void IncrementarKills()
    {
        kills++;
        ActualizarInterfaz();
    }

    public void IncrementarLuces(int cantidadLuces)
    {
        lucesRecolectadas += cantidadLuces;
        ActualizarInterfaz();

        if (lucesRecolectadas >= totalLuces && finalObject != null)
        {
            finalObject.SetActive(true);
        }
    }

    void PausarJuego()
    {
        Time.timeScale = 0;
    }

    public void ReanudarJuego()
    {
        Time.timeScale = 1;
    }

    public void VolverAJugar()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            RecibirDanio(15);
        }
    }
}
