using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CocukBulunmasi : MonoBehaviour
{
    public Animator CocukAnim;
    public Animator cocukYurumeAnim;

    static bool karakterZatenGirdiMi = true;

    //static bool cocukTeslimEdildiMi = false;

    static bool cocukBulunduMu = false;

    private bool cocukYakinindaMi = false;

    public GameObject cocukAnimObj;
    public GameObject gercekCocukObj;
    public GameObject karakterObj;
    private float karakterHizTutucu;

    public float odakSuresi = 2.02f;
    private void Start()
    {
        karakterObj = GameObject.Find("Karakter");

        if (cocukBulunduMu)
        {
            gameObject.SetActive(false);
        }


        gercekCocukObj = Resources.FindObjectsOfTypeAll<CocukOzellestirici>()[0].gameObject;


    }

    private void Update()
    {
        if (!karakterZatenGirdiMi && cocukYakinindaMi && (Input.GetKeyDown(KeyCode.E) || FindObjectOfType<ButonKlavye>().butonaBasildiMi))
        {
            cocukYakinindaMi = false;
            karakterHizTutucu = karakterObj.GetComponent<KarakterHareket>().hareketHizi;
            karakterObj.GetComponent<KarakterHareket>().hareketHizi = 0;
            StartCoroutine(AnimOynat());

           
            karakterZatenGirdiMi = true;

            FindObjectOfType<ButonKlavye>().butonaBasildiMi = false;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        cocukYakinindaMi = true;

        FindObjectOfType<ButonKlavye>().GetComponent<Button>().enabled = true;

    }


    private void OnTriggerExit2D(Collider2D collision)
    {

        cocukYakinindaMi = false;

        FindObjectOfType<ButonKlavye>().GetComponent<Button>().enabled = false;

    }

    IEnumerator AnimOynat()
    {
        CocukAnim.SetBool("girildiMi", true);
        cocukYurumeAnim.SetBool("yuruyebilirMi", true);
        FindObjectOfType<KameraKontrol>().TakipEdilenKisiyiDegistir(gameObject,odakSuresi);
        yield return new WaitForSeconds(2.02f);
        karakterObj.GetComponent<KarakterHareket>().hareketHizi = karakterHizTutucu;
        gercekCocukObj.SetActive(true);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        cocukBulunduMu = true;
    }


    public void CocukObjeKapat()
    {
        cocukAnimObj.SetActive(false);
    }


    public void CocukBulmaGoreviniAktifEt()
    {
        karakterZatenGirdiMi = false;
    }

    //public void CocuguTeslimEt()
    //{
    //    cocukTeslimEdildiMi = true;
    //}

}
