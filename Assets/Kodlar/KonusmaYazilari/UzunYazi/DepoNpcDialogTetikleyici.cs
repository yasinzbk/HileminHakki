using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DepoNpcDialogTetikleyici : MonoBehaviour
{
    



    private  bool telefonVerilebilir = false;


    private bool gorevBittiMi = false;



    public Dialog[] dialog;

   

    public UzunYaziDenetleyici depoUzunYazi;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        DialogKontrol();

    }


    public void DialogKontrol()
    {
        if ( telefonVerilebilir && !gorevBittiMi)
        {
           
            DialogTetikle(dialog[0]);


        }
    }


    public void TelefonVerilebilir()
    {
        telefonVerilebilir = true;
    }

    public void DialogTetikle(Dialog dialog)
    {
        depoUzunYazi.StartDialogue(dialog);
    }

    public void Sustur()
    {
        DialogTetikle(dialog[1]);
        gorevBittiMi = true;
    }
}
