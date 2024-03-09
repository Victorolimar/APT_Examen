using System.Collections;
using UnityEngine;

public class PocionVida : MonoBehaviour
{
    public int vidaRecuperada = 20;
    public float tiempoDesaparicion = 10f;

    private bool playerInRange;
    private VidaJugador vidaJugador;
    private Collider collider;

    private void Start()
    {
        vidaJugador = FindObjectOfType<VidaJugador>();
        collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            StartCoroutine(RecogerPocion());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private IEnumerator RecogerPocion()
    {
        yield return new WaitForSeconds(0.5f); // Pequeño retraso para evitar múltiples recogidas instantáneas
        if (playerInRange)
        {
            vidaJugador.AumentarVida(vidaRecuperada);
            collider.enabled = false; // Desactivar el collider para que el jugador no pueda recoger la poción repetidamente
            gameObject.SetActive(false);
            yield return new WaitForSeconds(tiempoDesaparicion);
            gameObject.SetActive(true);
            collider.enabled = true; // Reactivar el collider para que el jugador pueda recoger la poción nuevamente
        }
    }
}
