using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoManager : MonoBehaviour
{
    public GameObject enemigo;
    public float spawnTime; // Cambiar a public para que sea accesible desde fuera de la clase
    public Transform spawnPoint;
    private VidaJugador _vidaJugador;

    private void Awake()
    {
        _vidaJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<VidaJugador>();
    }

    void Start()
    {
        if (_vidaJugador.vidaActual <= 0)
        {
            return;
        }
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Update()
    {

    }

    public void Spawn()
    {
        Instantiate(enemigo, spawnPoint.position, spawnPoint.rotation);
    }

    // Método para modificar el tiempo de spawn
    public void ModificarSpawnTime(float multiplicador)
    {
        spawnTime *= multiplicador;
    }
}
