using UnityEngine;
[CreateAssetMenu(fileName = "Yeni Esya", menuName = "Envanter/Su")]
public class Su : Esya
{
    override public void  Kullan()
    {

            if (FindObjectOfType<KosuYarismasi>() == null)
            {
                Debug.Log("kosu yarismasi bulunamadi");

            }
            else
            {

                FindObjectOfType<KosuYarismasi>().DopingKullanKullanma();

              
            }
        




        if (FindObjectOfType<KarakterHareket>() == null)
        {
            Debug.Log("karakter bulunamadi");

        }
        else
        {

            FindObjectOfType<KarakterHareket>().DopingKullanKullanma();
           

        }
    }

    


}
