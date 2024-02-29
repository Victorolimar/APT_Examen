using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float suavizado = 5f;
    [SerializeField] private Transform target;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }

    private void FixedUpdate() {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, suavizado * Time.deltaTime);
    }
}
