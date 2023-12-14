using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia;
    [SerializeField] public int puntuacionActual, puntuacionMaxima;
    [SerializeField] float tiempo;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(this);
        }
    }
    void Start()
    {
        puntuacionMaxima = PlayerPrefs.GetInt("puntuacionMaxima");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Perder()
    {
        
    }

    private void ReiniciarJuego()
    {
        
    }

    public void ActualizarPuntuacion()
    {
        puntuacionActual+= 1;
        if (puntuacionActual >= puntuacionMaxima)
        {
            puntuacionMaxima = puntuacionActual;
            PlayerPrefs.SetInt("puntuacionMaxima", puntuacionMaxima);
        }
    }
}