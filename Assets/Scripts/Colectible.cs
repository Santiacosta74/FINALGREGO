using UnityEngine;

public class Colectible : MonoBehaviour
{
    public int cantidadLuces = 1; // Cantidad de luces que este objeto proporciona

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RecolectarLuz();
        }
    }

    void RecolectarLuz()
    {
        // Llama al método para incrementar el contador de luces en ScriptPrincipal
        ScriptPrincipal scriptPrincipal = FindObjectOfType<ScriptPrincipal>();
        if (scriptPrincipal != null)
        {
            scriptPrincipal.IncrementarLuces(cantidadLuces);
        }

        gameObject.SetActive(false); // Desactiva el objeto recolectable
    }
}
