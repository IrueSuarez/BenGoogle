using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverEnemigo : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] float velocidad;
    [SerializeField] public Vector2 posicionInicial, posicionMinima;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        posicionMinima = camera.ViewportToWorldPoint(new Vector2(0, 0));
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * velocidad * Time.deltaTime); 

        if(transform.position.x < posicionMinima.x -1)
        {
            transform.position = posicionInicial;
            velocidad++;  
        }
    }

    public void IniciarEnemigo()
    {
        transform.position = posicionInicial;
        velocidad = 7;
    }
}

