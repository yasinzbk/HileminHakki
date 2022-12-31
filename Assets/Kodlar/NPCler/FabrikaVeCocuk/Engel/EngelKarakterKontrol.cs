using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngelKarakterKontrol : MonoBehaviour
{
    public GameObject tekrarKonumu;
    public GameObject karakterObj;
    private float karakterHizTutucu;
    private bool karakterEngeleGirdiMi = false;
    private bool engellerCalisiyorMu = true;
    private void Start()
    {
        karakterObj = GameObject.Find("Karakter");
       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag == "karakter" && engellerCalisiyorMu)
        {

            FindObjectOfType<SesYoneticisi>().Oynat("ÇarpaSesi");

            if (!karakterEngeleGirdiMi)
            {
              karakterHizTutucu = karakterObj.GetComponent<KarakterHareket>().hareketHizi;

            }

            StartCoroutine( KarakterYanmasiGeciktir());

            
           
            IEnumerator KarakterYanmasiGeciktir()
            {
                karakterEngeleGirdiMi = true;
                karakterObj.GetComponent<KarakterHareket>().hareketHizi = 0;
                yield return new WaitForSeconds(0.5f);
                collision.gameObject.transform.position = tekrarKonumu.transform.position;
                karakterObj.GetComponent<KarakterHareket>().hareketHizi = karakterHizTutucu;
                karakterEngeleGirdiMi = false;
            }
        }
    }

    public void EngelKapat()
    {
        engellerCalisiyorMu = false;
    }


}
