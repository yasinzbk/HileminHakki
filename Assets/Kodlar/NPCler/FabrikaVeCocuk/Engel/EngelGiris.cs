using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngelGiris : MonoBehaviour
{
    public Animator engelAnim;
    private bool engelCalisabilirMi = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (engelCalisabilirMi)
        {
          engelAnim.SetBool("girildiMi", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        engelAnim.SetBool("girildiMi", false);

    }

    public void EngelKapat()
    {
        engelAnim.SetBool("girildiMi", false);
        engelCalisabilirMi = false;



    }


}
