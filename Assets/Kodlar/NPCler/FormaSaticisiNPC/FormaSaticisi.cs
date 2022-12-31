using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormaSaticisi : MonoBehaviour
{
    public GameObject oyunDenetleyiciObj;
    public Animator kapiAnimator;
    public Animator KarakterAnimator;

    public int formaParasi;

    OyunDenetleyici OyunDenetleyici;

    void Start()
    {
        OyunDenetleyici = oyunDenetleyiciObj.GetComponent<OyunDenetleyici>();
        KarakterAnimator = GameObject.Find("Karakter").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (OyunDenetleyici.ParaSayisiniVer() >= formaParasi)
        {
            FindObjectOfType<SesYoneticisi>().Oynat("EsyaAlma");

            OyunDenetleyici.paraSayisi -= formaParasi;
            OyunDenetleyici.paraText.text = OyunDenetleyici.paraSayisi.ToString();
            kapiAnimator.SetBool("kapiAcilabilir", true);

            FindObjectOfType<SesYoneticisi>().Oynat("Kapi");
            KarakterAnimator.SetBool("FormaliMi", true);
        }
    }


}
