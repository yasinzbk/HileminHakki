using UnityEngine;

public class ToplanabilirEsya : MonoBehaviour
{
    //public float cap = 0.45f;
    //public Transform esyaTransform;

    //bool temasEdiyorMu = false;
    //public LayerMask karakter;

    //static bool ilkSahneMi = true;

    public Esya esya;

    /*   private void FixedUpdate()
       {
         //  KontrolEtTemas();
          // EsyayiAl();
       }

       private void KontrolEtTemas()
       {
           temasEdiyorMu = Physics2D.OverlapCircle(esyaTransform.position, cap, karakter);
       }
       private void OnDrawGizmosSelected()
       {
           Gizmos.DrawWireSphere(esyaTransform.position, cap);
       } */


    private void Start()
    {
        //if(ilkSahneMi){
        //    esya.toplandiMi = false;
        //    ilkSahneMi = false;
        //}
        //else if(esya.toplandiMi)
        //{
        //    esya.toplandiMi = false;
        //    Destroy(gameObject);
        //}

         if (esya.toplandiMi)
        {
            
            Destroy(gameObject);
        }
    }


    public void EsyayiAl()
    {
            Debug.Log(esya.isim + " alindi");
            bool toplandiMi = Envanter.ornek.Ekle(esya);

        if (toplandiMi)
        {
            esya.toplandiMi = true;

            FindObjectOfType<SesYoneticisi>().Oynat("EsyaAlma");

                Destroy(gameObject);

        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "karakter")
        {
          
            EsyayiAl();

        }

    }

}
