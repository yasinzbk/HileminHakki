using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KosuYarismasiDenetleyici : MonoBehaviour
{
    private bool kupaKazandiMi=false;

    private bool yenildiMi = false;

    void Update()
    {
        KupayiEkle();
    }


    void KupayiEkle()
    {
        if (kupaKazandiMi)
        {

            if (FindObjectOfType<OyunDenetleyici>() == null)
            {
                Debug.Log("oyun denetleyici bulunamadi");
            }
            else
            {
                FindObjectOfType<OyunDenetleyici>().KupaSayisiniArttir();
                FindObjectOfType<KosuYarismasi>().KupaKazandı();
                kupaKazandiMi = false;
            }
        }
        if (yenildiMi)
        {
            if (FindObjectOfType<OyunDenetleyici>() == null)
            {
                Debug.Log("oyun denetleyici bulunamadi");
            }
            else
            {
                FindObjectOfType<OyunDenetleyici>().KupalariEsitle();

                yenildiMi = false;
            }
        }
    }


    public void KupaKazandi()
    {
        kupaKazandiMi = true;
    }

    public void Yenildi()
    {
        yenildiMi = true;
    }
}
