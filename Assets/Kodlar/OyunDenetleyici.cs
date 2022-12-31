using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class OyunDenetleyici : MonoBehaviour
{
    
     static int kupaSayisi = 0;

    public int paraSayisi = 0;
    public int gerekenKupaSayisi = 3;
    public GameObject panelBitis;

    public Transform ikonlarEbevyn;

    public Text paraText;

    public Image[] ikonlar;
   

    Color yeniRenk = new Color();

    //static OyunDenetleyici buHasBirKarakterdir;

    //void Awake()
    //{


    //    if (buHasBirKarakterdir != null)
    //    {
    //        Destroy(this.gameObject);
    //        return;
    //    }

    //    buHasBirKarakterdir = this;
    //    GameObject.DontDestroyOnLoad(this.gameObject);

    //}

    private void Start()
    {
        ikonlar = ikonlarEbevyn.GetComponentsInChildren<Image>();
        yeniRenk = Color.white;
        paraText.text = paraSayisi.ToString();
    }

    private void Update()
    {
        if (kupaSayisi == gerekenKupaSayisi)
        {
            panelBitis.SetActive(true);
        }
    }


    public void KupaSayisiniArttir()
    {

        for (int i = 0; i <= kupaSayisi; i++)
        {
          ikonlar[i].color = yeniRenk;
            
        }

        kupaSayisi++;

    }

    public void KupalariEsitle()
    {

        for (int s = 0; s <= (kupaSayisi - 1); s++)
        {
            ikonlar[s].color = yeniRenk;

        }



    }


    public void ParaSayisiniArttir()
    {
        
        paraSayisi++;
        paraText.text = paraSayisi.ToString();


    }

    public int ParaSayisiniVer()
    {
        return paraSayisi;
    }


    public void OyunuKapat()
    {
        Debug.Log("cikis yapiyorum");
        Application.Quit();
    }


}
