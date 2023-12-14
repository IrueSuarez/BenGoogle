using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ben : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("esta_en_suelo", false);
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
            Invoke("Perder");
        }
    }
}
