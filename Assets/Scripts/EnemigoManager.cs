using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoManager : MonoBehaviour
{
    public GameObject enemigo;
    public float spawnTime;
    public Transform spawnPoint;
    private VidaJugador _vidaJugador;
    private void Awake() {
        _vidaJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<VidaJugador>();
    }
    void Start()
    {
        if(_vidaJugador.vidaActual <= 0)
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
}
