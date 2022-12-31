using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTetikleyici : MonoBehaviour
{
    public GameObject cocukAnimObj;

    public Text ekranBilgiText;
    public GameObject panelBilgi;

    private static bool portalVerilebilir = true;

    private bool cocukBulunduMu = false;

    private static bool dedeIleKonusulduMu = false;

    private bool alandaMi = false;

    private bool TurkceMi;

    public GameObject cocukDedeFotoPanelObj;

    public Dialog[] dialog;

    public GameObject portalPref;

    public UzunYaziDenetleyici yasliAmcaUzunYazi;


    public float odakSuresi;


    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E) || FindObjectOfType<ButonKlavye>().butonaBasildiMi) && dedeIleKonusulduMu && alandaMi && !cocukBulunduMu)
        {
            ekranBilgiText.color = Color.black;
            panelBilgi.SetActive(true);

            if (TurkceMi)
            {
                ekranBilgiText.text = "Çocuğu Bul";
            }
            else
            {
                ekranBilgiText.text = "Find The Kid";
            }

            DialogTetikle(dialog[2]);

            cocukDedeFotoPanelObj.SetActive(true);

            cocukAnimObj.GetComponentInChildren<CocukBulunmasi>().CocukBulmaGoreviniAktifEt();

            FindObjectOfType<ButonKlavye>().butonaBasildiMi = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "karakter")
        {
            DialogKontrol();

            TurkceMi = FindObjectOfType<DilYoneticisi>().turkceMi;

            alandaMi = true;

            FindObjectOfType<ButonKlavye>().GetComponent<Button>().enabled = true;

        }

        if (collision.tag == "cocuk")
        {
            CocukBul();
            if (portalVerilebilir)
            {
                FindObjectOfType<KameraKontrol>().TakipEdilenKisiyiDegistir(gameObject, odakSuresi);
                DialogTetikle(dialog[1]);
                Instantiate(portalPref, new Vector3(transform.position.x + 1f, transform.position.y - 2f, transform.position.z), Quaternion.identity);

                GameObject.Find("Karakter").GetComponent<KarakterHareket>().CocuguVer();



                portalVerilebilir = false;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        alandaMi = false;

        FindObjectOfType<ButonKlavye>().GetComponent<Button>().enabled = false;
    }

    public void DialogKontrol()
    {
        if (!dedeIleKonusulduMu)                      // if (!cocukBulunduMu && portalVerilebilir && !dedeIleKonusulduMu)
        {
            dedeIleKonusulduMu = true;
            

            FindObjectOfType<KameraKontrol>().TakipEdilenKisiyiDegistir(gameObject, odakSuresi);
            
            DialogTetikle(dialog[0]);


        }
    }





    public void CocukBul()
    {


        cocukBulunduMu = true;
    }


    public void DialogTetikle(Dialog dialog)
	{
		yasliAmcaUzunYazi.StartDialogue(dialog);
	}



    public void FotoyuKapat()          // Bu Fonksiyon sadece Cocuk ve dedenin fotografini kapatmak icin yazdim kod dosyasiyla alakasi yoktur.
    {
        cocukDedeFotoPanelObj.SetActive(false);
    }

    public void CocukAlindiBilgisiVer()
    {
        TurkceMi = FindObjectOfType<DilYoneticisi>().turkceMi;

        ekranBilgiText.color = Color.black;
        panelBilgi.SetActive(true);
        ekranBilgiText.text = " Çocuk seni takip ediyor. ";

        if (!TurkceMi)
        {
            ekranBilgiText.text = " the kid is now following you ";
        }
    }

}
