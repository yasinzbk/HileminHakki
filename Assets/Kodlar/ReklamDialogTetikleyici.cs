using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Placement;

public class ReklamDialogTetikleyici : MonoBehaviour
{

    private static int dialogNumarasi = 0;

    private static bool reklamlarBittiMi = false;

    public GameObject reklamButtonObj;

    public GameObject reklamTextObj;

    public GameObject reklamTextArkaPanel;

    public GameObject kilikPanel;

    public GameObject dopingPanel;


    public Dialog[] dialog;


    public UzunYaziDenetleyici reklamUzunYazi;


    RewardedAdGameObject interstitialAd;


    private void Start()
    {

        ReklamYukle();

    }



    public void ReklamYukle()
    {
        if (!reklamlarBittiMi)
        {
            interstitialAd = MobileAds.Instance.GetAd<RewardedAdGameObject>("Rewarded Ad");


            MobileAds.Initialize((initStatus) => {
                Debug.Log("MobileAds initialized");

                interstitialAd.LoadAd();
            });
        }


    }
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dialogNumarasi >= dialog.Length)
        {


            DialogTetikle(dialog[dialog.Length - 1]);

        }
        else
        {
            DialogTetikle(dialog[dialogNumarasi]);
        }


        if (dialogNumarasi == 2)
        {
            kilikPanel.SetActive(true);
        }

        if (dialogNumarasi == 3)
        {
            dopingPanel.SetActive(true);
        }

        reklamTextArkaPanel.SetActive(true);
        reklamTextObj.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        reklamTextArkaPanel.SetActive(false);
        reklamTextObj.SetActive(false);

        if (dialogNumarasi == 2)
        {
            kilikPanel.SetActive(false);
        }

        if (dialogNumarasi == 3)
        {
            dopingPanel.SetActive(false);
        }
    }


    public void ReklamIzlendi()
    {
        dialogNumarasi++;



        if (dialogNumarasi >= dialog.Length)
        {
            

            DialogTetikle(dialog[dialog.Length - 1]);

        }
        else
        {
            DialogTetikle(dialog[dialogNumarasi]);
        }


        if (dialogNumarasi == (dialog.Length - 3))
        {
            reklamlarBittiMi = true;

            

            DialogTetikle(dialog[dialogNumarasi]);

           

        }

        if (dialogNumarasi == 2)
        {
            kilikPanel.SetActive(true);
        }
        else if (dialogNumarasi == 3)
        {
            kilikPanel.SetActive(false);
            dopingPanel.SetActive(true);
        }
        else
        {
            kilikPanel.SetActive(false);
            dopingPanel.SetActive(false);
        }

    }



    public void DialogTetikle(Dialog dialog)
    {
        reklamUzunYazi.StartDialogue(dialog);
    }
}
