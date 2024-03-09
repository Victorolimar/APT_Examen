using UnityEngine;

public class PowerUpReducirSpawnTime : MonoBehaviour
{
    public float multiplicadorSpawnTime = 2f; // Multiplicar el tiempo de spawn por dos
    public float duracionPowerUp = 5f; // Duración del power-up

    private float[] spawnTimesOriginales; // Almacenar los valores originales de spawnTime
    private EnemigoManager[] enemigoManagers;
    private Collider collider;

    private void Start()
    {
        enemigoManagers = FindObjectsOfType<EnemigoManager>(); // Obtener todas las instancias de EnemigoManager
        collider = GetComponent<Collider>();

        // Guardar los valores originales de spawnTime
        spawnTimesOriginales = new float[enemigoManagers.Length];
        for (int i = 0; i < enemigoManagers.Length; i++)
        {
            spawnTimesOriginales[i] = enemigoManagers[i].spawnTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collider.enabled = false; // Desactivar el collider para que el jugador no pueda recoger el power-up repetidamente
            AplicarPowerUp(); // Aplicar el power-up
        }
    }

    private void AplicarPowerUp()
    {
        foreach (EnemigoManager enemigoManager in enemigoManagers)
        {
            enemigoManager.ModificarSpawnTime(multiplicadorSpawnTime); // Multiplicar el tiempo de spawn de cada EnemigoManager
        }

        // Desactivar el objeto de power-up
        gameObject.SetActive(false);

        // Destruir el objeto después de la duración del power-up
        Destroy(gameObject, duracionPowerUp);

        // Restaurar el tiempo de spawn después de la duración del power-up
        Invoke(nameof(RestaurarSpawnTime), duracionPowerUp);
    }

    private void RestaurarSpawnTime()
    {
        for (int i = 0; i < enemigoManagers.Length; i++)
        {
            enemigoManagers[i].spawnTime = spawnTimesOriginales[i] / 2f; // Dividir el tiempo de spawn original por dos
        }
    }
}
