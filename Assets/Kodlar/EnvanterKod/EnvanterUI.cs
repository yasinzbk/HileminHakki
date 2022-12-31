using UnityEngine;

public class EnvanterUI : MonoBehaviour
{
    public Transform esyalarEbeveyn;
   // public GameObject envanterUI;

    Envanter envanter;

    EnvanterSlotu[] slotlar;

    //static EnvanterUI buHasBirKarakterdir;

    //void Awake()
    //{


    //    if (buHasBirKarakterdir == null)
    //    {
    //    buHasBirKarakterdir = this;
    //    GameObject.DontDestroyOnLoad(this.gameObject);
    //    }
    //    else if(buHasBirKarakterdir != null)
    //    {
    //        Destroy(gameObject);
    //        Debug.Log("canvastan 1 den fazla ornek bulundu");
    //    }


    //}

    void Start()
    {
        envanter = Envanter.ornek;
        envanter.esyaDegistigindeGeriCagir += UpdateUI;

        slotlar = esyalarEbeveyn.GetComponentsInChildren<EnvanterSlotu>();
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
        Debug.Log("UI guncellendi");
        for (int i = 0; i < slotlar.Length; i++)
        {
            if (i < envanter.esyalar.Count)
            {
                slotlar[i].EsyaEkle(envanter.esyalar[i]);
            }
            else
            {
                slotlar[i].SlotuTemizle();
            }
        }

    }

}
