using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public int saludMaxima = 10;
    private int saludActual;

    void Start()
    {
        saludActual = saludMaxima;
    }

    public void RecibirDanio(int cantidadDanio)
    {
        saludActual -= cantidadDanio;
        Debug.Log("Daño recibido: " + cantidadDanio + ". Salud restante: " + saludActual);


        if (saludActual <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        ScriptPrincipal scriptPrincipal = FindObjectOfType<ScriptPrincipal>();

        if (scriptPrincipal != null)
        {
            scriptPrincipal.IncrementarKills();
        }

        gameObject.SetActive(false);
    }
}
