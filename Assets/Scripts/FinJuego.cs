using UnityEngine;

public class FinJuego : MonoBehaviour
{
    public GameObject panelVictoria;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            MostrarPanelVictoria();
        }
    }

    void MostrarPanelVictoria()
    {
        if (panelVictoria != null)
        {
            panelVictoria.SetActive(true);
        }
        else
        {
            Debug.LogError("¡Error! Panel de victoria no asignado.");
        }
    }
}
