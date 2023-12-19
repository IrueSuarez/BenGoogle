using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprobarSuelo : MonoBehaviour
{
    public static bool estaEnSuelo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        estaEnSuelo = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        estaEnSuelo = false;
    }
}
