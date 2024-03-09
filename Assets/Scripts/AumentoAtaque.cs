using System.Collections;
using UnityEngine;

public class AumentoAtaque : MonoBehaviour
{
    public int aumentoDamage = 5; // Cantidad de aumento de daño
    public float duracionPowerUp = 5f; // Duración del aumento de daño

    private Shoot shootScript;
    private Collider collider;

    private void Start()
    {
        shootScript = FindObjectOfType<Shoot>(); // Obtener una referencia al script Shoot en el jugador
        collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collider.enabled = false; // Desactivar el collider para que el jugador no pueda recoger el power-up repetidamente
            StartCoroutine(AplicarPowerUp()); // Comenzar la corrutina para aplicar el power-up
        }
    }

    private IEnumerator AplicarPowerUp()
    {
        if (shootScript != null) // Verificar si se obtuvo correctamente una referencia al script Shoot
        {
            shootScript.AumentarDamage(aumentoDamage); // Aumentar el daño del jugador
        }

        gameObject.SetActive(false); // Desactivar el objeto de aumento de daño

        yield return new WaitForSeconds(duracionPowerUp); // Esperar el tiempo de duración del power-up

        if (shootScript != null) // Verificar si se obtuvo correctamente una referencia al script Shoot
        {
            shootScript.RestaurarDamage(); // Restaurar el daño del jugador después de que termine el power-up
        }

        Destroy(gameObject); // Destruir el objeto de aumento de daño después de su duración
    }
}
