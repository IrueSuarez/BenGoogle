using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia;
    [SerializeField] public int puntuacionActual, puntuacionMaxima;
    [SerializeField] float tiempo;
    [SerializeField] GameObject gameOver, boton, jugador, enemigo, enemigoVolador;
    [SerializeField] MoverEnemigo moverEnemigoVolador;
    [SerializeField] public bool cronometro;
    [SerializeField] TMP_Text texto;
    [SerializeField] MoverEnemigo moverEnemigo;
    [SerializeField] float velocidad;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClip;

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

        gameOver.SetActive(false);
        boton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(cronometro == true)
        {
            tiempo += Time.deltaTime;
            int minutos = (int)tiempo / 60;
            int segundos = (int)tiempo % 60;
            Debug.Log(minutos + ":" + segundos);
            string textoTiempo = $"{minutos:D2}:{segundos:D2}";
            texto.text = textoTiempo;
        }
    }

    public void Perder()
    {
        jugador.SetActive(false);
        enemigo.SetActive(false);
        enemigoVolador.SetActive(false);

        gameOver.SetActive(true);
        boton.SetActive(true);

        cronometro = false;
    }

    public void ReiniciarJuego()
    {
        puntuacionActual = 0;

        jugador.SetActive(true);
        enemigo.SetActive(true);
        enemigoVolador.SetActive(true);

        gameOver.SetActive(false);
        boton.SetActive(false);

        tiempo = 0;

        cronometro = true;

        IniciarEnemigo();
    }

    public void ActualizarPuntuacion()
    {
        puntuacionActual+= 1;
        audioSource.clip= audioClip[0];
        audioSource.Play();
        if (puntuacionActual >= puntuacionMaxima)
        {
            puntuacionMaxima = puntuacionActual;
            PlayerPrefs.SetInt("puntuacionMaxima", puntuacionMaxima);
        }
    }
    
    public void IniciarEnemigo()
    {
        moverEnemigo.IniciarEnemigo();
        moverEnemigoVolador.IniciarEnemigo();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Enemigo")
        {
           ActualizarPuntuacion();
        }
    }
}