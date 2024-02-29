using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public int damage = 20;
    public float fireRate = 0.15f;
    public float weaponRange = 100f;
    private float tiempo;
    private Ray disparoRay;
    private RaycastHit disparoHit;
    private int disparableMask;
    private LineRenderer disparoLinea;
    private Player _player;
    // Start is called before the first frame update
    private void Awake() {
        disparableMask = LayerMask.GetMask("disparable");
        disparoLinea = GetComponent<LineRenderer>();
        _player = GetComponentInParent<Player>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        if (Input.GetButton("Fire1") && tiempo >= fireRate)
        {
            StartCoroutine(Disparo());
        }
        
        if (tiempo >= fireRate * 0.2f)
        {
            disparoLinea.enabled = false;
        }
    }

    IEnumerator Disparo()
    {
        tiempo = 0;
        yield return new WaitForSeconds(0.2f);

        disparoLinea.enabled = true;
        disparoLinea.SetPosition(0, new Vector3(transform.position.x, transform.position.y, transform.position.z));
        disparoRay.origin = transform.position;
        disparoRay.direction = transform.forward;

        if (Physics.Raycast(disparoRay, out disparoHit, weaponRange, disparableMask))
        {
            VidaEnemigo vidaEnemigo = disparoHit.collider.GetComponent<VidaEnemigo>();
            
            if (vidaEnemigo != null){
                vidaEnemigo.DamageRecibido(damage, disparoHit.point);
            }
            disparoLinea.SetPosition(1, disparoHit.point);
        }
        else
        {
            disparoLinea.SetPosition(1, disparoRay.origin + disparoRay.direction * weaponRange);
        }
    }
}
