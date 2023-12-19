using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Textos : MonoBehaviour
{
    [SerializeField] TMP_Text actual, maxima, tiempo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        actual.text = GameManager.Instancia.puntuacionActual.ToString();
        maxima.text = GameManager.Instancia.puntuacionMaxima.ToString();
        tiempo.text = GameManager.Instancia.cronometro.ToString();
    }
}
