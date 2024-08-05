using UnityEngine;

public class Bala : MonoBehaviour
{
    public int damage = 5;
    public float velocidad = 10f;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * velocidad;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisi�n detectada con: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Colisi�n con un enemigo");

            VidaEnemigo vidaEnemigo = collision.gameObject.GetComponent<VidaEnemigo>();
            if (vidaEnemigo != null)
            {
                Debug.Log("Enemigo tiene el componente VidaEnemigo");

                vidaEnemigo.RecibirDanio(damage);
                Debug.Log("Bala impact� al enemigo. Aplicando " + damage + " de da�o.");
            }
            else
            {
                Debug.Log("El enemigo no tiene el componente VidaEnemigo");
            }
            Destroy(gameObject);
        }
    }
}
