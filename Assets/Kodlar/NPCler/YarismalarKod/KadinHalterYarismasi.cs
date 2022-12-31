using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class KadinHalterYarismasi : MonoBehaviour
{
    bool kostumluMu = false;
   static bool madalayaKazandiMi = false;
    

    public Text ekranBilgiText;

    public GameObject panelBilgi;

    public KarakterHareket karakter;

    private bool yarismaAlanindaMi = false;


    public GameObject kHalterAnimObje;

    public float AnimSuresi = 9f;

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
            karakter = FindObjectOfType<KarakterHareket>();
            kostumluMu = karakter.kizMi;

            if (TurkceMi)
            {
                if (kostumluMu && !madalayaKazandiMi)
                {
                    StartCoroutine(HalterAnimOynat());
                    
                    madalayaKazandiMi = true;
                    KupayiEkle();
                    ekranBilgiText.color = Color.green;
                    panelBilgi.SetActive(true);
                    ekranBilgiText.text = " Kadın Halter Yarışmasını KAZANDINIZ :) ";

                   

                }
                else if (!madalayaKazandiMi)
                {
                    ekranBilgiText.color = Color.red;
                    panelBilgi.SetActive(true);
                    ekranBilgiText.text = " Kadın Halter Yarışmasına KATILAMADINIZ ";

                }
                else if (madalayaKazandiMi)
                {
                    ekranBilgiText.color = Color.green;
                    panelBilgi.SetActive(true);
                    ekranBilgiText.text = " Kadın Halter Yarışmasını Zaten KAZANDINIZ ";
                }
            }
            else
            {
                if (kostumluMu && !madalayaKazandiMi)
                {
                    StartCoroutine(HalterAnimOynat());
                    
                    madalayaKazandiMi = true;
                    KupayiEkle();
                    ekranBilgiText.color = Color.green;
                    panelBilgi.SetActive(true);
                    ekranBilgiText.text = " YOU WON the women's weightlifting competition :) ";

                    

                }
                else if (!madalayaKazandiMi)
                {
                    ekranBilgiText.color = Color.red;
                    panelBilgi.SetActive(true);
                    ekranBilgiText.text = " You could not participate in the women's weightlifting competition ";

                }
                else if (madalayaKazandiMi)
                {
                    ekranBilgiText.color = Color.green;
                    panelBilgi.SetActive(true);
                    ekranBilgiText.text = " You've already won the women's weightlifting competition ";
                }
            }


            FindObjectOfType<ButonKlavye>().butonaBasildiMi = false;

        }
    }




    IEnumerator HalterAnimOynat()
    {
        kHalterAnimObje.SetActive(true);
        yield return new WaitForSeconds(AnimSuresi);
        kHalterAnimObje.SetActive(false);
        FindObjectOfType<SesYoneticisi>().Oynat("Kazanma");
    }

    void KupayiEkle()
    {
        if (madalayaKazandiMi)
        {
            FindObjectOfType<OyunDenetleyici>().KupaSayisiniArttir();
        }
    }


}
