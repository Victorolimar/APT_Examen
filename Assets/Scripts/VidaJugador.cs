using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidaJugador : MonoBehaviour
{

    public int vidaInicial = 100;
    public int vidaActual;
    public Slider vidaSlider;
    public GameObject gameOver;

    private bool isDead;
    private bool damaged;

    private Player player;
    private Shoot shoot;

    private void Awake() {
        vidaActual = vidaInicial;
        vidaSlider.maxValue = vidaInicial;
        vidaSlider.value = vidaInicial;
        player = GetComponent<Player>();
        shoot = GetComponent<Shoot>();
    }

    public void TakeDamage(int amount)
    {
        damaged = true;
        vidaActual -= amount;
        vidaSlider.value = vidaActual;
        if(vidaActual <= 0 && !isDead)
        {
            Death();
        }
    }

    public void Death()
    {
        isDead = true;
        gameOver.SetActive(true);
        player.enabled = false;
        shoot.enabled = false;
        StartCoroutine(RestartLevel());
    }
    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("SampleScene");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
