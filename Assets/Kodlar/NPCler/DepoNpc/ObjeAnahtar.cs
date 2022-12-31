using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjeAnahtar : MonoBehaviour
{
    public GameObject canvas;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag=="karakter")
        canvas.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "karakter")
        {
           canvas.SetActive(true);

        }
    }
}
