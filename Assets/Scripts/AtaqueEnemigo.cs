using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{
    public float tiempoAtaque;
    public int EnemyDamage;

    private GameObject player;
    private VidaJugador _vidaJugador;
    private VidaEnemigo _vidaEnemigo;
    private bool playerInRange;
    private float timer;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        _vidaJugador = player.GetComponent<VidaJugador>();
        _vidaEnemigo = GetComponent<VidaEnemigo>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject == player){
            playerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject == player){
            playerInRange = false;
        }
    }
    private void Ataque() {
        timer = 0;
        if(_vidaJugador.vidaActual > 0){
            _vidaJugador.TakeDamage(EnemyDamage);
        }
    }

    private void Update() {
        timer += Time.deltaTime;
        if(timer >= tiempoAtaque && playerInRange && _vidaEnemigo.vidaActual > 0){
            Ataque();
        }
    }
}
