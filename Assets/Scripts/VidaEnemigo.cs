using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public int vidaInicial = 100;
    public int vidaActual = 100;
    public float velDesvanecer = 2.5f;
    public int puntosEnemigo = 10;

    private bool muerto;
    private bool desvanecido;
    // Start is called before the first frame update
    private void Awake() {
        vidaActual = vidaInicial;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(desvanecido){
            transform.Translate(Vector3.up * velDesvanecer * Time.deltaTime);
        }
    }
    public void DamageRecibido(int cantidad, Vector3 hitPoint){
        if(muerto){
            return;
        }
        vidaActual -= cantidad;
        if(vidaActual <= 0){
            Muerto();
        }
    }
    void Muerto(){
        muerto = true;
        desvanecido = true;
        PuntosManager.puntos += puntosEnemigo;
        Destroy(gameObject, 2f);
    }
}
