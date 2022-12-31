using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToplanabilirPara : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("karakter"))
        {
        FindObjectOfType<OyunDenetleyici>().ParaSayisiniArttir();

            FindObjectOfType<SesYoneticisi>().Oynat("BozuklukAlma");

        Destroy(gameObject);

        }
    }

}
