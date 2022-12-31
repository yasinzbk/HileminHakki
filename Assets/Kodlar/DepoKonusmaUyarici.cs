using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepoKonusmaUyarici : MonoBehaviour
{
    public DepoNpcDialogTetikleyici npcDialogObj;

    public float odakSuresi = 2.02f;

    public GameObject odakNoktasi;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        npcDialogObj.TelefonVerilebilir();

        FindObjectOfType<KameraKontrol>().TakipEdilenKisiyiDegistir(odakNoktasi, odakSuresi);

    }
}
