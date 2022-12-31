using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SarkiYarismasi : MonoBehaviour
{

   static bool playbackMi = false;
   static bool madalayaKazandiMi = false;

    private bool yarismaAlanindaMi = false;

    public Text ekranBilgiText;

    public GameObject panelBilgi;

    public GameObject sarkiAnimObje;

    public float sarkiAnimSuresi = 4f;

    public Animator sarkiAnimator;

    private bool TurkceMi;

    private void Update()
    {
        KazanmaKontrol();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        yarismaAlanindaMi = true;

        TurkceMi = FindObjectOfType<DilYoneticisi>().turkceMi;

        FindObjectOfType<ButonKlavye>().GetComponent<Button>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        yarismaAlanindaMi = false;

        FindObjectOfType<ButonKlavye>().GetComponent<Button>().enabled = false;
    }

    public void KazanmaKontrol()
    {
        if ((Input.GetKeyDown(KeyCode.E) || FindObjectOfType<ButonKlavye>().butonaBasildiMi) && yarismaAlanindaMi)
        {

            if (TurkceMi)
            {
                if (playbackMi && !madalayaKazandiMi)
                {
                    StartCoroutine(SarkiKazanmaAnimasyonunuOynat());
                    
                    madalayaKazandiMi = true;
                    KupayiEkle();
                    ekranBilgiText.color = Color.green;
                    panelBilgi.SetActive(true);
                    ekranBilgiText.text = " Şarkı Yarışmasını KAZANDINIZ :) ";

                }
                else if (!madalayaKazandiMi)
                {
                    StartCoroutine(SarkiKaybetmeAnimasyonunuOynat());
                    ekranBilgiText.color = Color.red;
                    panelBilgi.SetActive(true);
                    ekranBilgiText.text = " Şarkı Yarışmasını KAZANAMADINIZ ";

                }
                else if (madalayaKazandiMi)
                {
                    ekranBilgiText.color = Color.green;
                    panelBilgi.SetActive(true);
                    ekranBilgiText.text = " Şarkı Yarışmasını zaten kazandınız. ";
                }
            }
            else
            {
                if (playbackMi && !madalayaKazandiMi)
                {
                    StartCoroutine(SarkiKazanmaAnimasyonunuOynat());
                    
                    madalayaKazandiMi = true;
                    KupayiEkle();
                    ekranBilgiText.color = Color.green;
                    panelBilgi.SetActive(true);
                    ekranBilgiText.text = " You won the song contest :) ";

                }
                else if (!madalayaKazandiMi)
                {
                    StartCoroutine(SarkiKaybetmeAnimasyonunuOynat());
                    ekranBilgiText.color = Color.red;
                    panelBilgi.SetActive(true);
                    ekranBilgiText.text = " YOU COULD NOT WIN the song contest ";

                }
                else if (madalayaKazandiMi)
                {
                    ekranBilgiText.color = Color.green;
                    panelBilgi.SetActive(true);
                    ekranBilgiText.text = " You've already won the song contest ";
                }
            }

            FindObjectOfType<ButonKlavye>().butonaBasildiMi = false;

        }
    }


    void KupayiEkle()
    {
        if (madalayaKazandiMi)
        {
            FindObjectOfType<OyunDenetleyici>().KupaSayisiniArttir();
        }
    }

    public void PlaybackKullan()
    {
        playbackMi = true;
    }


    IEnumerator SarkiKazanmaAnimasyonunuOynat()
    {
        sarkiAnimObje.SetActive(true);
        sarkiAnimator.SetBool("kazandiMi", true);

        FindObjectOfType<SesYoneticisi>().Oynat("SarkiKazanma");

        yield return new WaitForSeconds(sarkiAnimSuresi);
        
        sarkiAnimObje.SetActive(false);



    }



    IEnumerator SarkiKaybetmeAnimasyonunuOynat()
    {
        sarkiAnimObje.SetActive(true);
        sarkiAnimator.SetBool("kazandiMi", false);


        yield return new WaitForSeconds(sarkiAnimSuresi);

        sarkiAnimObje.SetActive(false);
        FindObjectOfType<SesYoneticisi>().Oynat("Kaybetme");


    }
}
