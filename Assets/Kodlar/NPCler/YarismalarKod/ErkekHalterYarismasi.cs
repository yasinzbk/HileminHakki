using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ErkekHalterYarismasi : MonoBehaviour
{
    bool kostumluMu = true;

    public Text ekranBilgiText;
    public GameObject panelBilgi;

    private bool yarismaAlanindaMi = false;

    public GameObject eHalterAnimObje;

    public float AnimSuresi = 4f;

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

            
            //Debug.Log(" Halter madalyasi kazanamadiniz ");
            ekranBilgiText.color = Color.red;
            panelBilgi.SetActive(true);


            if (TurkceMi)
            {
                if (kostumluMu)
                {
                    StartCoroutine(HalterAnimOynat());
                    ekranBilgiText.text = " Erkek Halter Yarışmasını KAZANAMADINIZ. ";

                }
                else
                {
                    ekranBilgiText.text = " Erkek Halter Yarışmasını KATILAMADINIZ. ";
                }
            }
            else
            {
                if (kostumluMu)
                {
                    StartCoroutine(HalterAnimOynat());
                    ekranBilgiText.text = " YOU COULD NOT WIN the men's weightlifting competition. ";

                }
                else
                {
                    ekranBilgiText.text = " You could not participate in the men's weightlifting competition. ";
                }
            }


            FindObjectOfType<ButonKlavye>().butonaBasildiMi = false;

        }
    }


    IEnumerator HalterAnimOynat()
    {
        eHalterAnimObje.SetActive(true);
        yield return new WaitForSeconds(AnimSuresi);
        eHalterAnimObje.SetActive(false);

        FindObjectOfType<SesYoneticisi>().Oynat("Kaybetme");
    }


    public void PanelKapat()
    {
        panelBilgi.SetActive(false);
    }

    public void KostumKullanKullanma()
    {
        kostumluMu = !kostumluMu;
    }

}
