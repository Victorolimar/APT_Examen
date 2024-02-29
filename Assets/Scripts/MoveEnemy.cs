using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour
{
    private VidaEnemigo _vidaEnemigo;
    private NavMeshAgent nav;
    private Transform player;
    private VidaJugador _vidaJugador;
    // Start is called before the first frame update
    private void Awake() {
        _vidaEnemigo = GetComponent<VidaEnemigo>();
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _vidaJugador = player.GetComponent<VidaJugador>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_vidaEnemigo.vidaActual <= 0 || _vidaJugador.vidaActual <= 0)
        {
            nav.enabled = false;
        } 
        else 
        {
            nav.SetDestination(player.position);
        }
    }
}
