using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{

    private float posY;
    public Material material;
    private MeshRenderer meshRender;

    private void Awake()
    {
        meshRender = GetComponent<MeshRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posY = transform.position.y;
        if (posY < -10)
        {
            transform.position = new Vector3(0, 1, 0);
            meshRender.material = material;
        }
    }
}
