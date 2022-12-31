using UnityEngine;
using UnityEngine.UI;

public class EsyaBirlestiriciSlotu : MonoBehaviour
{
    public Transform esyalarEbeveyn;

    public Image ikon;

    public Text esyaAdtxt;

   

    Esya esya;

    public bool dilTurkceMi = true;
   



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


    public void DilDegis(bool secilenDil)
    {
        dilTurkceMi = secilenDil;
    }

}
