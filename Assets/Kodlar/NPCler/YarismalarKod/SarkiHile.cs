using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SarkiHile : MonoBehaviour
{
    private bool kupaKazandiMi = false;

    private bool gerekenEsya1VarMi = false, gerekenEsya2VArmi = false;

    public Esya gerekenEsya1, gerekenEsya2;

    private bool yarismaAlanindaMi = false;

    public Transform esyalarEbeveyn;

    public Transform envanterTransform;

    EnvanterSlotu[] envanterSlotlar;

    public GameObject dsa;

    public GameObject sahneYeniObjeler;

    Envanter envanter;
    private void Start()
    {
        envanter = Envanter.ornek;
        dsa = GameObject.Find("CanvasEnvanter");
        envanterTransform = dsa.transform.Find("Envanter");
        esyalarEbeveyn = envanterTransform.transform.Find("EsyalarEbevyn");

        envanterSlotlar = esyalarEbeveyn.GetComponentsInChildren<EnvanterSlotu>();


    }

    private void Update()
    {
        KazanmaKontrol();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        yarismaAlanindaMi = true;

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
            if (kupaKazandiMi)
            {
                Debug.Log("Zaten Esyalari Koydunuz.");
            }
            else
            {
                for (int i = 0; i < envanterSlotlar.Length; i++)
                {
                    if (envanterSlotlar[i].esya == gerekenEsya1)
                    {
                        gerekenEsya1VarMi = true;

                    }
                    else if (envanterSlotlar[i].esya == gerekenEsya2)
                    {
                        gerekenEsya2VArmi = true;
                    }

                }
            }

            if (gerekenEsya1VarMi && gerekenEsya2VArmi)
            {
                if (FindObjectOfType<SarkiYarismasi>() == null)
                {
                    Debug.Log("sarki yarismasi bulunamadi");

                }
                else
                {

                    FindObjectOfType<SarkiYarismasi>().PlaybackKullan();
                }
                envanter.Kaldir(gerekenEsya1);
                envanter.Kaldir(gerekenEsya2);

                for (int i = 0; i < envanterSlotlar.Length; i++)
                {
                    if (envanterSlotlar[i].esya == null && envanterSlotlar[i].iptalTusu.interactable==true)
                    {
                        envanterSlotlar[i].IptalTusuAktifEtme();


                    }


                }

                sahneYeniObjeler.SetActive(true);

                kupaKazandiMi = true;
            }
            else
            {
                Debug.Log("gerekenEsyalarEksik");
            }

            FindObjectOfType<ButonKlavye>().butonaBasildiMi = false;

        }
    }
}
