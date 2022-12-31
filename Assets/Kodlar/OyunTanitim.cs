using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunTanitim : MonoBehaviour
{
    
    public static bool oyunTanitildiMi = false;

    static bool paraGostericiKapatildiMi = false;

    public UzunYaziDenetleyici uzunYazi;

    public GameObject tanitimCanvasObj;

    public Dialog[] dialog;


    public float odakSuresi;

    private float karakterHizTutucu;


    public Animator tanitimAnim;

    public GameObject baslangicPanel;

    public GameObject baslangicPanelEnglish;


    public GameObject paraGostericiObj;


    public GameObject kupaGostericiObj;

    public GameObject kupaAnimObj;

    private void Start()
    {


        if (paraGostericiKapatildiMi)
        {
            paraGostericiObj.SetActive(false);
        }



        if (oyunTanitildiMi)
        {
            
            //FindObjectOfType<OyunDenetleyici>().KupalariEsitle();  // burası hatalı düzlt
            Destroy(gameObject);
        }
        else
        {
            kupaGostericiObj.SetActive(false);
        }





    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        karakterHizTutucu = FindObjectOfType<KarakterHareket>().hareketHizi;
        FindObjectOfType<KarakterHareket>().hareketHizi = 0;

        paraGostericiObj.SetActive(false);

        tanitimCanvasObj.SetActive(true);

        tanitimAnim.SetBool("girdiMi", true);

        DialogTetikle(dialog[0]);

        FindObjectOfType<KameraKontrol>().TakipEdilenKisiyiDegistir(gameObject, odakSuresi);

        StartCoroutine(ObjeKapansin());



        oyunTanitildiMi = true;
    }


    IEnumerator ObjeKapansin()
    {
        yield return new WaitForSeconds(odakSuresi);

        FindObjectOfType<KarakterHareket>().hareketHizi = karakterHizTutucu;

       
    }




    public void PanelKapat()
    {
        baslangicPanel.SetActive(false);
    }

    public void PanelKapatE()
    {
        baslangicPanelEnglish.SetActive(false);
    }



    public void DialogTetikle(Dialog dialog)
	{
		uzunYazi.StartDialogue(dialog);
	}



    public void KupaGostericiObjAktifEt()
    {
        kupaGostericiObj.SetActive(true);
        kupaAnimObj.SetActive(false);
        paraGostericiKapatildiMi = true;

        Destroy(gameObject);
    }

    public void KupaGostericiAnimObjAktifEt()
    {
        kupaAnimObj.SetActive(true);
    }

}
