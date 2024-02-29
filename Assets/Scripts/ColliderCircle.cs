using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCircle : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")) {
            // Destroy(gameObject);
        }
    }

    private void OnCollisionExit(Collision other) {
        if(other.gameObject.CompareTag("Player")) {
            // Instantiate(other.gameObject, new Vector3(0, 10, 0), Quaternion.identity);
        }
    }

   private void OnCollisionStay(Collision other) {
         if(other.gameObject.CompareTag("Player"))
        {
           //Debug.Log("Me estoy quemando");
        }
   }
}
