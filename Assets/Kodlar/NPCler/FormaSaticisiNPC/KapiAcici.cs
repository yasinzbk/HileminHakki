using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KapiAcici : MonoBehaviour
{
    public Animator kapiAnimator;
    // public bool acilabilirMi = false;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<SesYoneticisi>().Oynat("Parmaklik");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //acilabilirMi = true;
        kapiAnimator.SetBool("kapiAcilabilir", true);

      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //acilabilirMi = false;
        kapiAnimator.SetBool("kapiAcilabilir", false);

        FindObjectOfType<SesYoneticisi>().Oynat("Parmaklik");
    }
}
