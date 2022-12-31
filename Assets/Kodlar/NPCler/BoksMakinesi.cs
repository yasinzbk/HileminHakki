using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoksMakinesi : MonoBehaviour
{
    static bool gucIsaretiAcildiMi = false;

    private bool boksMakinesiKullandiMi = false;

    private bool boksAlanindaMi = false;

    public float boksAnimSuresi;

    public float gucIsaretiCikisAnimSuresi;

    public GameObject boksAnimObje;

    

    public GameObject gucIsaretiAnimObje;

  

    public GameObject gucIsaretiObje;


    private void Start()
    {
        if (gucIsaretiAcildiMi)
        {
            gucIsaretiObje.SetActive(true);
        }
    }

    private void Update()
    {
        BoksMakinesiKontrol();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        boksAlanindaMi = true;

        FindObjectOfType<ButonKlavye>().GetComponent<Button>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        boksAlanindaMi = false;

        FindObjectOfType<ButonKlavye>().GetComponent<Button>().enabled = false;

        FindObjectOfType<ButonKlavye>().butonaBasildiMi = false;
    }

    void BoksMakinesiKontrol()
    {
        if (boksAlanindaMi && (Input.GetKeyDown(KeyCode.E) || FindObjectOfType<ButonKlavye>().butonaBasildiMi) && !gucIsaretiAcildiMi)
        {
            BoksMakinesiCalistir();

            FindObjectOfType<ButonKlavye>().butonaBasildiMi = false;
        }
    }

    void BoksMakinesiCalistir()
    {
        if (!boksMakinesiKullandiMi)
        {
            
            StartCoroutine(BoksAnimasyonunuOynat());

            boksMakinesiKullandiMi = true;
        }
    }

    IEnumerator BoksAnimasyonunuOynat()
    {
        boksAnimObje.SetActive(true);
       
        yield return new WaitForSeconds(boksAnimSuresi);
       
        boksAnimObje.SetActive(false);
       

        StartCoroutine(GucIsaretiCikisAnimOynat());

    }

    IEnumerator GucIsaretiCikisAnimOynat()
    {
        gucIsaretiAnimObje.SetActive(true);
        
        yield return new WaitForSeconds(gucIsaretiCikisAnimSuresi);
        gucIsaretiAcildiMi = true;

        gucIsaretiAnimObje.SetActive(false);
        gucIsaretiObje.SetActive(true);
    }
}
