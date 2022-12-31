using UnityEngine;
using UnityEngine.UI;

public class EnvanterSlotu : MonoBehaviour
{
    public Transform esyalarEbeveyn;

    public Image ikon;
    public Button iptalTusu;
    //public Button[] kullanTuslari;
    public Button kullanTusu;

    public Text esyaAdtxt;

    EnvanterSlotu[] slotlar;

    public Esya esya;

    public bool dilTurkceMi = true;


    private void Start()
    {
        slotlar = esyalarEbeveyn.GetComponentsInChildren<EnvanterSlotu>();



        
    }

    public void EsyaEkle(Esya yeniEsya)
    {


        esya = yeniEsya;

        ikon.sprite = esya.ikon;
        ikon.enabled = true;
        esyaAdtxt.enabled = true;
        if (dilTurkceMi)
        {
          esyaAdtxt.text = esya.isim;

        }
        else
        {
            esyaAdtxt.text = esya.namen;
        }
    }

    public void SlotuTemizle()
    {
        esya = null;

        ikon.sprite = null;
        ikon.enabled = false;
        esyaAdtxt.enabled = false;
    }

    public void EsyayiKullan()
    {
        
        if (esya != null)
        {
            // Oceden Basili bi slot var mı diye kontrol edicek varsa iptal tusuna basicak


            for (int i = 0; i < slotlar.Length; i++)
            {

                if (slotlar[i].iptalTusu.interactable == true)
                {
                    slotlar[i].IptalTusunaBasilmasi();
                }

            }


            iptalTusu.interactable = true;
            esya.Kullan();
            EsyaBirlestirici.ornek.Ekle(esya);

            KullanTusuAktifEtme();
            //for (int i = 0; i < slotlar.Length; i++)
            //{
            //    slotlar[i].KullanTusuAktifEtme();

            //}



        }
    }


    public void IptalTusunaBasilmasi()
    {
        
        if (esya != null)
        {
            iptalTusu.interactable = false;
            esya.Kullan();
            Debug.Log("iptal tusuna basıldi");

        for (int i = 0; i < slotlar.Length; i++)
        {
            slotlar[i].KullanTusuAktifEt();

        }

        }
        //else
        //{
        //    iptalTusu.interactable = false;            // buraya bak  
        //}

    }


    public void KullanTusuAktifEt()
    {
        kullanTusu.interactable = true;
    }

    public void KullanTusuAktifEtme()
    {
        kullanTusu.interactable = false;
    }


    public void IptalTusuAktifEtme()
    {
        iptalTusu.interactable = false;
        for (int i = 0; i < slotlar.Length; i++)
        {
            
            slotlar[i].KullanTusuAktifEt();

        }
    }



    public void DilDegis(bool secilenDil)
    {
        dilTurkceMi = secilenDil;
    }


}
