using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KosuYarismasi : MonoBehaviour
{
    bool dopingliMi = false;
    bool kupaKazandiMi = false;
    bool yarismayaKatilabilirMi = true;

    public Text ekranBilgiText;

    public GameObject panelBilgi;

    public string lvl2;

    public Transform esyalarEbeveyn;

    public Transform envanter;

    public Esya yasakEsya;

    EnvanterSlotu[] envanterSlotlar;

    public GameObject dsa;

    private bool yarismaAlanindaMi = false;

    private bool TurkceMi;

    private void Start()
    {

        dsa = GameObject.Find("CanvasEnvanter");
        envanter = dsa.transform.Find("Envanter");
        esyalarEbeveyn = envanter.transform.Find("EsyalarEbevyn");

        envanterSlotlar = esyalarEbeveyn.GetComponentsInChildren<EnvanterSlotu>();

        dopingliMi = FindObjectOfType<KarakterHareket>().dopingliMi;
    }


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

            if (TurkceMi)
            {
                if (kupaKazandiMi)
                {
                    ekranBilgiText.color = Color.green;
                    panelBilgi.SetActive(true);
                    ekranBilgiText.text = " Koşu Yarışını zaten kazandınız ";

                }
                else if (dopingliMi)
                {
                    ekranBilgiText.color = Color.red;
                    panelBilgi.SetActive(true);
                    ekranBilgiText.text = "!!! Yarışmadan Atıldın Doping Tespit Edildi. ";

                }
                else
                {
                    for (int i = 0; i < envanterSlotlar.Length; i++)
                    {
                        if (envanterSlotlar[i].esya == yasakEsya)
                        {
                            
                            ekranBilgiText.color = Color.red;
                            panelBilgi.SetActive(true);
                            ekranBilgiText.text = "!!! Yasak Eşya Bulundu | Yarışa katılamazsınız. ";
                            yarismayaKatilabilirMi = false;
                        }


                    }
                    if (yarismayaKatilabilirMi)
                    {
                        SceneManager.LoadScene(lvl2);
                    }

                }
            }
            else
            {
                if (kupaKazandiMi)
                {
                    ekranBilgiText.color = Color.green;
                    panelBilgi.SetActive(true);
                    ekranBilgiText.text = " You have already won the running race ";

                }
                else if (dopingliMi)
                {
                    ekranBilgiText.color = Color.red;
                    panelBilgi.SetActive(true);
                    ekranBilgiText.text = "!!! Disqualified from race | Doping detected. ";

                }
                else
                {
                    for (int i = 0; i < envanterSlotlar.Length; i++)
                    {
                        if (envanterSlotlar[i].esya == yasakEsya)
                        {
                            
                            ekranBilgiText.color = Color.red;
                            panelBilgi.SetActive(true);
                            ekranBilgiText.text = "!!! Forbidden Item Found | You cannot participate in the race. ";
                            yarismayaKatilabilirMi = false;
                        }


                    }
                    if (yarismayaKatilabilirMi)
                    {
                        SceneManager.LoadScene(lvl2);
                    }

                }
            }



            FindObjectOfType<ButonKlavye>().butonaBasildiMi = false;

        }
    }


    public void DopingKullanKullanma()
    {

      
        dopingliMi = !dopingliMi;

        if (dopingliMi)
        {
            yarismayaKatilabilirMi = true;
        }

        Debug.Log("dopinggggg");
    }


    public void KupaKazandı()
    {
        kupaKazandiMi = true;
    }

}
