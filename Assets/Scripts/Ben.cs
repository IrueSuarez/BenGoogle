using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ben : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] float alturaSalto;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(ComprobarSuelo.estaEnSuelo) //Script ComprobarSuelo
            {
                rb.AddForce(Vector2.up * alturaSalto);
            }
        }

        if(rb.velocity.y > 0.1f || rb.velocity.y < -0.1f) //personaje o esta subiendo o esta bajando
        {
             animator.SetBool("esta_en_suelo", false);
        }
        else
        {
             animator.SetBool("esta_en_suelo", true);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Suelo")
        {
            animator.SetBool("esta_en_suelo", true);
        }
        if (collision.transform.tag == "Enemigo")
        {
            Invoke("Perder",0.2f);
        }
    }
    void Perder()
    {
        GameManager.Instancia.Perder();
    }
}
