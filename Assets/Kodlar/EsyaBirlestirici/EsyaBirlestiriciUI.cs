using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsyaBirlestiriciUI : MonoBehaviour
{
    public Transform esyalarEbeveyn;
    // public GameObject envanterUI;

    EsyaBirlestirici esyaBirlestirici;

    EsyaBirlestiriciSlotu[] slotlar;

    void Start()
    {
        esyaBirlestirici = EsyaBirlestirici.ornek;
        esyaBirlestirici.esyaDegistigindeGeriCagir += UpdateUI;

        slotlar = esyalarEbeveyn.GetComponentsInChildren<EsyaBirlestiriciSlotu>();
    }

    // Update is called once per frame
    void Update()
    {
        /* if (Input.GetKeyDown(KeyCode.J))
         {
             envanterUI.SetActive(!envanterUI.activeSelf);
         } */
    }


    void UpdateUI()
    {
        Debug.Log("Birlestirici UI guncellendi");
        for (int i = 0; i < slotlar.Length; i++)
        {
            if (i < esyaBirlestirici.esyalar.Count)
            {
                slotlar[i].EsyaEkle(esyaBirlestirici.esyalar[i]);
            }
            else
            {
                slotlar[i].SlotuTemizle();
            }
        }

    }

}
