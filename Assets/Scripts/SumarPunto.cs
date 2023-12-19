using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumarPunto : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Invoke("ActualizarPuntuacion",0.2f);
    }
    void ActualizarPuntuacion()
    {
        GameManager.Instancia.ActualizarPuntuacion();
    }
}
