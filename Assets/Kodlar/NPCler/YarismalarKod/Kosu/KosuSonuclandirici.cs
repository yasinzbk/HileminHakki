using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KosuSonuclandirici : MonoBehaviour
{

    public GameObject gorevliEng;
    public GameObject gorevliTurk;


    private bool biriKazandiMi = false;

    public bool reklamYuklendiMi = false;

    public GameObject kosucu1;
    public GameObject kosucu2;

    public GameObject Resim;

    public Text ekranBilgiText;

    public GameObject panelBilgi;

    private string kazananAdi;

    public bool dilTurkceMi;

    public string lvl;

    private void Start()
    {
        dilTurkceMi = FindObjectOfType<EnvanterSlotu>().dilTurkceMi;

        if (dilTurkceMi)
        {
            gorevliTurk.SetActive(true);
        }
        else
        {
            gorevliEng.SetActive(true);
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        kazananAdi = collision.gameObject.name;

        StartCoroutine(YarismacilariDurdur());

        
    


        if (collision.gameObject.name == "Karakter" && !biriKazandiMi)
        {

            FindObjectOfType<SesYoneticisi>().Oynat("Kazanma");

            FindObjectOfType<KosuYarismasiDenetleyici>().KupaKazandi();

            ekranBilgiText.color = Color.green;
            panelBilgi.SetActive(true);
            ekranBilgiText.text = " Sen Kazandın ";
            if (!dilTurkceMi)
            {
                ekranBilgiText.text = " YOU WON ";
            }


            biriKazandiMi = true;
        }
        else if (!biriKazandiMi)
        {
            FindObjectOfType<SesYoneticisi>().Oynat("Kaybetme");
            FindObjectOfType<KosuYarismasiDenetleyici>().Yenildi();

            Resim.GetComponent<Image>().sprite = collision.GetComponent<SpriteRenderer>().sprite;

                ekranBilgiText.color = Color.red;
                panelBilgi.SetActive(true);
                ekranBilgiText.text = kazananAdi + " Kazandı";

            if (!dilTurkceMi)
            {
                ekranBilgiText.text = kazananAdi + " WON";
            }

            biriKazandiMi = true;
        }

       
        //gameObject.SetActive(false);
    }

    public void PanelKapat()
    {
        panelBilgi.SetActive(false);
    }

    IEnumerator YarismacilariDurdur()
    {
        
        yield return new WaitForSeconds(2f);
        GameObject.FindObjectOfType<KosuBaslatici>().GetComponent<KosuBaslatici>().KosuculariDurdur();

        kosucu1.GetComponent<BoxCollider2D>().isTrigger = true;

        kosucu2.GetComponent<BoxCollider2D>().isTrigger = true;


    }

    public void ReklamsizEkranYukle()
    {
        if (!reklamYuklendiMi)
        {
            SceneManager.LoadScene(lvl);
        }
    }

    public void ReklamYuklendi()
    {
        reklamYuklendiMi = true;
    }

    public void EkranYukle1()
    {
        SceneManager.LoadScene(lvl);
    }

}
