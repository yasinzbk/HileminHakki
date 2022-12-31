using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SarjMakinesi : MonoBehaviour
{

    private static bool telefonuAldiMi = false;

    private static bool aydinlandiMi = false;

    private bool sarjDaMi = false;

    private bool icerdeMi = false;

    public float pilSarjMiktari=0,pilSarjTavan;

    public float pilSarjHizi,sarjEtmesiIcinGerekenSure;

    private float sarjZamani = Mathf.NegativeInfinity;

    public Image pilYesilResim;

    public GameObject karanlik;

    public GameObject panelPil;

    public GameObject pilAnimResmi, karanlikEngel;


    public Animator pilAnim;

    public float pilAnimSuresi;

    private void Start()
    {
        pilSarjMiktari = pilYesilResim.GetComponent<RectTransform>().sizeDelta.y;

        if (!telefonuAldiMi)
        {
            panelPil.SetActive(false);
            
        }

        if (!aydinlandiMi)
        {
         
            karanlikEngel.SetActive(true);
            karanlik.SetActive(true);
        }
        if (aydinlandiMi)
        {
            //FindObjectOfType<DepoNpcDialogTetikleyici>().Sustur();  //Burda bi hata çıktı sonra bak
            pilYesilResim.GetComponent<RectTransform>().sizeDelta = new Vector2(pilYesilResim.GetComponent<RectTransform>().sizeDelta.x, pilSarjTavan);
        }

    }
    private void Update()
    {
        SarjdaMiKontrol();
        if (sarjDaMi && !aydinlandiMi)
        {
            SarjDoldur();
        }
    }
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        icerdeMi = true;
        FindObjectOfType<ButonKlavye>().GetComponent<Button>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        icerdeMi = false;
        sarjDaMi = false;
        Debug.Log("!!!!!!!!sarj etmiyor");

        FindObjectOfType<ButonKlavye>().GetComponent<Button>().enabled = false;

        FindObjectOfType<ButonKlavye>().butonaBasildiMi = false;
    }

    private void SarjdaMiKontrol()
    {
        if (telefonuAldiMi && !sarjDaMi && icerdeMi)
        {
            if ((Input.GetKeyDown(KeyCode.E) || FindObjectOfType<ButonKlavye>().butonaBasildiMi))
            {
              Debug.Log("sarj ediyor");
              sarjDaMi = true;
              sarjZamani = Time.time;

                FindObjectOfType<ButonKlavye>().butonaBasildiMi = false;

            }
        }
    }


    private void SarjDoldur()
    {
        if(Time.time>= sarjZamani + sarjEtmesiIcinGerekenSure)
        {
            pilYesilResim.GetComponent<RectTransform>().sizeDelta = new Vector2(pilYesilResim.GetComponent<RectTransform>().sizeDelta.x, pilYesilResim.GetComponent<RectTransform>().sizeDelta.y + pilSarjHizi);
            pilSarjMiktari = pilYesilResim.GetComponent<RectTransform>().sizeDelta.y;
            sarjZamani = Time.time;
        }
        if (pilSarjMiktari >= pilSarjTavan)
        {
            karanlikEngel.SetActive(false);
            pilYesilResim.GetComponent<RectTransform>().sizeDelta = new Vector2(pilYesilResim.GetComponent<RectTransform>().sizeDelta.x,pilSarjTavan);
            karanlik.SetActive(false);
            aydinlandiMi = true;

            FindObjectOfType<DepoNpcDialogTetikleyici>().Sustur();
            //telefonuAldiMi = false;
        }
    }

    public void TelefonuVer()
    {
        telefonuAldiMi = true;
        StartCoroutine(pilAnimasyonunuOynat(true));
     
    }


    IEnumerator pilAnimasyonunuOynat(bool a)
    {
        pilAnimResmi.SetActive(true);
        pilAnim.SetTrigger("TelefonAl");

        yield return new WaitForSeconds(pilAnimSuresi);

        panelPil.SetActive(a);
        pilAnimResmi.SetActive(false);
    }
}
