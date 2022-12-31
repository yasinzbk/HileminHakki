using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KarakterHareket : MonoBehaviour
{
    public float hareketHizi = 5f;
    public Rigidbody2D rb;
    #region CocukDegiskenler
    private Rigidbody2D cocukRb;
    private bool cocukHareketEdebilirMi = false;
    private bool cocuguAldiMi = false;
    private float cocukYuzununYonu =1f;

    public Animator cocukAnim;
    Vector2 cocukOzelHareket;
    #endregion

    Vector2 hareket;

    public Animator anim;

    public float yuzununYonu = 1f;

    public float portalMesafe = 2f;

    public int portalBaslatici = 0;

    public bool kizMi = false;

    public bool dopingliMi = false;

    private bool muzikCaliyorMu = false;

    static KarakterHareket ornek;

    public GameObject portal1, portal2;

    public Joystick joySTck;
    
    void Awake()
    {
        if (ornek != null)
        {
            Destroy(this.gameObject);
            return;
        }

        ornek = this;
        GameObject.DontDestroyOnLoad(this.gameObject);

    }

    private void Start()
    {
        cocukOzelHareket.x = 0f;
        
    }

    void Update()
    {
        //hareket.x = joySTck.Horizontal;
        //hareket.y = joySTck.Vertical;
        /*hareket.x = Input.GetAxisRaw("Horizontal");*/
        /*hareket.y = Input.GetAxisRaw("Vertical");*/

        if (joySTck.Horizontal >= .4f)
        {
            hareket.x = 1f;
        }else if(joySTck.Horizontal <= -.4f)
        {
            hareket.x = -1f;
        }
        else
        {
            hareket.x = 0f;
        }


        if (joySTck.Vertical >= .4f)
        {
            hareket.y = 1f;
        }
        else if (joySTck.Vertical <= -.4f)
        {
            hareket.y = -1f;
        }
        else
        {
            hareket.y = 0f;
        }

        cocukOzelHareket.y = hareket.y;
        AnimKontrol();
        DondurKontrol();
        CocukDondurKontrol();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + hareket * hareketHizi * Time.deltaTime);

        CocukHareketEttir();
    }

    private void CocukHareketEttir()
    {

        if (cocukHareketEdebilirMi)
        {
           if (yuzununYonu*(rb.position.x - cocukRb.position.x) >= 2f && Mathf.Abs(rb.position.y - cocukRb.position.y) <= 0.5f)
           {
                cocukAnim.SetBool("yuruyebilirMi", true);
                cocukRb.MovePosition(cocukRb.position + hareket * hareketHizi * Time.deltaTime);


            }
            else if (Mathf.Abs(rb.position.y - cocukRb.position.y) > 10f || Mathf.Abs(rb.position.x - cocukRb.position.x) > 10f)
            {
                cocukRb.MovePosition(rb.position);
            }



        }
    }

    private void CocukDondurKontrol()
    {
        if (cocukHareketEdebilirMi && yuzununYonu != cocukYuzununYonu)
        {
            cocukRb.transform.Rotate(0, 180, 0);
            cocukYuzununYonu = cocukYuzununYonu * -1;
        }
    }

    public void CocuguVer()
    {
        cocukHareketEdebilirMi = false;

        cocukAnim.SetBool("yuruyebilirMi", false);
    }

    private void AnimKontrol()
    {
        if(hareket.x != 0 || hareket.y != 0)
        {
            anim.SetBool("yuruyorMu", true);

            if (!muzikCaliyorMu)
            {
            
                FindObjectOfType<SesYoneticisi>().Oynat("KarakterYurume");
                muzikCaliyorMu = true;

            }
        }
        else if(cocukHareketEdebilirMi)
        {
            anim.SetBool("yuruyorMu", false);
            cocukAnim.SetBool("yuruyebilirMi", false);
            FindObjectOfType<SesYoneticisi>().Durdur("KarakterYurume");
            muzikCaliyorMu = false;
        }
        else
        {
            anim.SetBool("yuruyorMu", false);
            FindObjectOfType<SesYoneticisi>().Durdur("KarakterYurume");
            muzikCaliyorMu = false;
        }


        if (!kizMi)
        {
            anim.SetBool("erkekMi", true);
        }else if (kizMi)
        {
            anim.SetBool("erkekMi", false);
        }


    }


    private void DondurKontrol()
    {
        if (hareket.x != yuzununYonu && hareket.x != 0)
        {
            transform.Rotate(0, 180, 0);
            yuzununYonu = yuzununYonu * -1;
        }

    }
         



    public void CinsiyetDegis()
    {
        kizMi = !kizMi;
    }


    public void DopingKullanKullanma()
    {
        if (!dopingliMi)
        {
            hareketHizi += 2;
            dopingliMi = true;
        }
        else
        {
            hareketHizi -= 2;
            dopingliMi = false;
        }
    }

    public void Portal()
    {
        if (portalBaslatici % 2 == 0)
        {
            portal1.SetActive(true);
            portal1.transform.position = transform.position;

        transform.position = new Vector3(transform.position.x + yuzununYonu*portalMesafe, transform.position.y, transform.position.z);

            portal2.SetActive(true);
            portal2.transform.position = transform.position;

            FindObjectOfType<SesYoneticisi>().Oynat("Portal");

        }
        portalBaslatici++;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "cocuk" && !cocuguAldiMi )
        {
            GameObject.Find("EngelKontrol").GetComponent<EngelGiris>().EngelKapat();
            GameObject.Find("CopKontrol").GetComponent<EngelGiris>().EngelKapat();
            GameObject.Find("FabrikaEngelleriKapatici").GetComponent<FabrikaEngelleriKapatici>().EngelKapat();
            FindObjectOfType<DialogTetikleyici>().CocukAlindiBilgisiVer();

            
            cocukRb = collision.GetComponent<Rigidbody2D>();

                if(cocukYuzununYonu != yuzununYonu)
            {
                cocukRb.transform.Rotate(0, 180, 0);
                cocukYuzununYonu = cocukYuzununYonu * -1;

            }
            
           
            cocukHareketEdebilirMi = true;
            cocuguAldiMi = true;
            
        }


     

    }




    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "box")
        {
            FindObjectOfType<SesYoneticisi>().Oynat("Kutu");
        }
    }


    void OnCollisionExit2D(Collision2D colExt)
    {
        if (colExt.gameObject.tag == "box")
        {
            colExt.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

            FindObjectOfType<SesYoneticisi>().Durdur("Kutu");


        }

    }
}
