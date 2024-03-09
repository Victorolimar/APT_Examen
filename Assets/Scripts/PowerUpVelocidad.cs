using System.Collections;
using UnityEngine;

public class PowerUpVelocidad : MonoBehaviour
{
    public float aumentoVelocidad = 3f;
    public float duracionPowerUp = 2f;

    private Player player;
    private Collider collider;

    private void Start()
    {
        collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<Player>(); // Obtener una referencia al script Player del jugador que entra en contacto con el objeto de velocidad
            collider.enabled = false; // Desactivar el collider para que el jugador no pueda recoger el power-up repetidamente
            StartCoroutine(AplicarPowerUp()); // Comenzar la corrutina para aplicar el power-up
        }
    }

    private IEnumerator AplicarPowerUp()
    {
        if (player != null) // Verificar si se obtuvo correctamente una referencia al script Player
        {
            player.AumentarVelocidad(aumentoVelocidad); // Aumentar la velocidad del jugador
        }

        yield return new WaitForSeconds(duracionPowerUp); // Esperar el tiempo de duración del power-up

        if (player != null) // Verificar si se obtuvo correctamente una referencia al script Player
        {
            player.RestaurarVelocidad(); // Restaurar la velocidad del jugador después de que termine el power-up
        }

        collider.enabled = true; // Reactivar el collider para que el jugador pueda recoger el power-up nuevamente
        gameObject.SetActive(false); // Desactivar el objeto de velocidad
        yield return new WaitForSeconds(2f); // Esperar un breve tiempo antes de activar el objeto de velocidad nuevamente
        gameObject.SetActive(true); // Reactivar el objeto de velocidad
    }
}
