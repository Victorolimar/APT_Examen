using UnityEngine;

public class AumentoSalto : MonoBehaviour
{
    public float aumentoFactor = 1.5f; // Factor de aumento de la fuerza de salto
    public float duracionPowerUp = 10f; // Duración del power-up

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>(); // Obtener el script Player del jugador
            if (player != null)
            {
                player.AumentarSalto(aumentoFactor); // Aumentar la fuerza de salto del jugador
            }

            Destroy(gameObject); // Destruir el objeto de power-up

            // Restaurar la fuerza de salto después de la duración del power-up
            Invoke(nameof(RestaurarSalto), duracionPowerUp);
        }
    }

    private void RestaurarSalto()
    {
        // No se necesita hacer nada aquí, ya que la fuerza de salto se restaura automáticamente en el script Player
    }
}
