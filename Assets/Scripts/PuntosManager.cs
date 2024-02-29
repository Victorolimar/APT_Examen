using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntosManager : MonoBehaviour
{
    public TextMeshProUGUI textPuntos;
    public static int puntos;

    private void Awake() {
        puntos = 0;
    }

    void Update()
    {
        textPuntos.text = "Score: " + puntos;
    }
}
