using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsyaBirlestirici : MonoBehaviour
{
    #region Singleton
    public static EsyaBirlestirici ornek;

    private void Awake()
    {
        //if (ornek != null)
        //{
        //    Debug.LogWarning("Esya Birlestiriciden 1 den fazla ornek bulundu");
        //    Destroy(ornek.gameObject);


        //    return;
        //}
        //ornek = this;

        if (ornek == null)
        {
            ornek = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (ornek != null)
        {
            Debug.LogWarning("Esya Birlestiriciden 1 den fazla ornek bulundu");
        }
    }
    #endregion

    public delegate void EsyaDegistiginde();
    public EsyaDegistiginde esyaDegistigindeGeriCagir;

    public int bosYer = 2;

    public List<Esya> esyalar = new List<Esya>();

    public List<EsyaBirlestirmeDenklemi> denklemler = new List<EsyaBirlestirmeDenklemi>();

    Envanter envanter;

    EsyaBirlestiriciSlotu[] slotlar;

    public Transform esyalarEbeveyn;

    int birlestirilecekTutucu = 0;

    EnvanterSlotu[] envanterSlotlar;


    private float birlestiriciDolumVakti = Mathf.NegativeInfinity;

    [SerializeField]
    private float giriseVakit = 3f;

    private bool dolduMu = false;

    public bool Ekle(Esya esya)
    {
        if (esyalar.Count >= bosYer)
        {
            Debug.Log(" Yer Yok");
            return false;
        }
        esyalar.Add(esya);

        if (esyaDegistigindeGeriCagir != null)
        {
            esyaDegistigindeGeriCagir.Invoke();
        }

        return true;
    }

    public void Kaldir(Esya esya)
    {
        esyalar.Remove(esya);

        if (esyaDegistigindeGeriCagir != null)
        {
            esyaDegistigindeGeriCagir.Invoke();
        }
    }


    public void Temizle()
    {

        for (int i = 0; i < slotlar.Length; i++)
        {

                slotlar[i].SlotuTemizle();
           
        }
        esyalar.Clear();
        birlestirilecekTutucu = 0;
    }

    private void Start()
    {
        envanter = Envanter.ornek;
        slotlar = esyalarEbeveyn.GetComponentsInChildren<EsyaBirlestiriciSlotu>();

        envanterSlotlar = esyalarEbeveyn.GetComponentsInChildren<EnvanterSlotu>();
    }

    private void Update()
    {
        BosYerKontrol();
        DenklemKontrol();
    }

    public void BosYerKontrol()
    {
        if (esyalar.Count == bosYer && !dolduMu)
        {

            birlestiriciDolumVakti = Time.time;

            dolduMu = true;

        }

        }



    public void DenklemKontrol()
    {
        if (Time.time >= birlestiriciDolumVakti + giriseVakit && dolduMu)
        {

        foreach (EsyaBirlestirmeDenklemi denklem in denklemler)
        {

            for (int i = 0; i < denklem.Birlestirilecekler.Count; i++)
            {
                if (esyalar.Contains(denklem.Birlestirilecekler[i]))
                {
                    birlestirilecekTutucu++;
                }


            }



            if (birlestirilecekTutucu == esyalar.Count) //if (denklem.Birlestirilecekler.Contains(esyalar[1]) && denklem.Birlestirilecekler.Contains(esyalar[0]))
            {
                foreach (Esya birlestirilecekEsya in denklem.Birlestirilecekler)
                {
                    for (int i = 0; i < envanterSlotlar.Length; i++)
                    {
                            if (envanterSlotlar[i].esya == esyalar[esyalar.Count - 1] && envanterSlotlar[i].esya == birlestirilecekEsya)
                            {

                                envanterSlotlar[i].IptalTusunaBasilmasi();
                                //envanterSlotlar[i].IptalTusuAktifEtme();

                            }

                        }

                    


                }

                    foreach (Esya birlestirilecekEsya in denklem.Birlestirilecekler)
                    {
                        envanter.Kaldir(birlestirilecekEsya);
                    }

                        for (int i = 0; i < denklem.Urun.Count; i++)
                {
                    envanter.Ekle(denklem.Urun[i]);


                }


            }

            birlestirilecekTutucu = 0;
        }

        Temizle();

            dolduMu = false;
            birlestiriciDolumVakti = 0f;
        }
    }






}
