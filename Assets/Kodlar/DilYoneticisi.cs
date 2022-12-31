using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DilYoneticisi : MonoBehaviour
{
    public GameObject fabrikaTabelaObj;
    public GameObject depoTabelaObj;

    public GameObject reklamYazi;
    public GameObject reklamYaziEng;

    public Sprite fabTabEng;
    public Sprite fabTabTurk;
    public Sprite depoTabEng;
    public Sprite depoTabTurk;


    public List<TextMesh> SahnelerdekiTextMeshler;              //hide ins
    public List<Text> SahnelerdekiTextler;                       //hide inspector
    public List<SahnedekiCeviri> Ceviriler;
    public List<MeshSahnedekiCeviri> CevirilerMesh;

   

    public bool turkceMi = true;

    public bool SahneGecisiVar = false;

    public bool cevirilebilir = true;

    private void Start()
    {
        SahnelerdekiTextler.Clear();
        SahnelerdekiTextMeshler.Clear();

        turkceMi = FindObjectOfType<EnvanterSlotu>().dilTurkceMi;


        foreach (Text yazi in Resources.FindObjectsOfTypeAll(typeof(Text)))
        {


               SahnelerdekiTextler.Add(yazi);

          
        }

        foreach (TextMesh yazi in Resources.FindObjectsOfTypeAll(typeof(TextMesh)))
        {

                SahnelerdekiTextMeshler.Add(yazi);

           

            
        }



 



    }

    private void Update()
    {
        if(!turkceMi && cevirilebilir)
        {
            Debug.Log("enayi");

            DilDegistir("yasin");

            cevirilebilir = false;
        }
    }

    public void SahneGecisi()
    {
        SahneGecisiVar = true;
    }

    public void Cevir(string CevirilecekDil)
    {
        for (int i = 0; i < Ceviriler.Count; i++)
        {
            for (int s = 0; s < SahnelerdekiTextler.Count; s++)
            {
                if (turkceMi)
                {
                    if (Ceviriler[i].english == SahnelerdekiTextler[s].text)
                    {
                        SahnelerdekiTextler[s].text = Ceviriler[i].turkcesi;
                    }
                }
                else
                {
                    if (Ceviriler[i].turkcesi == SahnelerdekiTextler[s].text)
                    {
                        SahnelerdekiTextler[s].text = Ceviriler[i].english;
                    }
                }
            }
        }


    }



    public void CevirMesh(string CevirilecekDil)
    {
        for (int i = 0; i < CevirilerMesh.Count; i++)
        {
            for (int s = 0; s < SahnelerdekiTextMeshler.Count; s++)
            {
                if (turkceMi)
                {
                    if (CevirilerMesh[i].english == SahnelerdekiTextMeshler[s].text)
                    {
                        SahnelerdekiTextMeshler[s].text = CevirilerMesh[i].turkcesi;
                    }
                }
                else
                {
                    if (CevirilerMesh[i].turkcesi == SahnelerdekiTextMeshler[s].text)
                    {
                        SahnelerdekiTextMeshler[s].text = CevirilerMesh[i].english;
                    }
                }
            }
        }
    }



    public void DilDegistir(string CevirilecekDil)
    {

        if (CevirilecekDil == "Turkce")
        {
            turkceMi = true;

            fabrikaTabelaObj.GetComponent<SpriteRenderer>().sprite = fabTabTurk;
            depoTabelaObj.GetComponent<SpriteRenderer>().sprite = depoTabTurk;
            reklamYazi.SetActive(true);
            reklamYaziEng.SetActive(false);


        }
        else
        {
            turkceMi = false;

            fabrikaTabelaObj.GetComponent<SpriteRenderer>().sprite = fabTabEng;
            depoTabelaObj.GetComponent<SpriteRenderer>().sprite = depoTabEng;

            reklamYazi.SetActive(false);
            reklamYaziEng.SetActive(true);


        }
        Cevir(CevirilecekDil);
        CevirMesh(CevirilecekDil);

        foreach (EnvanterSlotu slot in Resources.FindObjectsOfTypeAll(typeof(EnvanterSlotu)))
        {
            slot.DilDegis(turkceMi);
        }

        foreach (EsyaBirlestiriciSlotu slot in Resources.FindObjectsOfTypeAll(typeof(EsyaBirlestiriciSlotu)))
        {
            slot.DilDegis(turkceMi);
        }

    }




}

[System.Serializable]
public class SahnedekiCeviri
{
    public string turkcesi;
    public string english;


    public SahnedekiCeviri(string turkcesi, string english)
    {
        this.turkcesi = turkcesi;
        this.english = english;
    }
}

[System.Serializable]
public class MeshSahnedekiCeviri
{
    public string turkcesi;
    public string english;

    public MeshSahnedekiCeviri(string turkcesi, string english)
    {
        this.turkcesi = turkcesi;
        this.english = english;
    }
}
    
