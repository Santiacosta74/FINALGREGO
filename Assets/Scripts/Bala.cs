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
        Debug.Log("Colisión detectada con: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Colisión con un enemigo");

            VidaEnemigo vidaEnemigo = collision.gameObject.GetComponent<VidaEnemigo>();
            if (vidaEnemigo != null)
            {
                Debug.Log("Enemigo tiene el componente VidaEnemigo");

                vidaEnemigo.RecibirDanio(damage);
                Debug.Log("Bala impactó al enemigo. Aplicando " + damage + " de daño.");
            }
            else
            {
                Debug.Log("El enemigo no tiene el componente VidaEnemigo");
            }
            Destroy(gameObject);
        }
    }
}
