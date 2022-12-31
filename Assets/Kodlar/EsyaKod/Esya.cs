using UnityEngine;

[CreateAssetMenu(fileName ="Yeni Esya", menuName ="Envanter/Esya")]
public class Esya : ScriptableObject
{
    // new public string isimdi degistirdim 
    public string isim = "Yesi Esya";
    public string namen = "New Item";
    public Sprite ikon = null;
    public bool toplandiMi = false;

 

    public virtual void Kullan()
    {
        // Esyayi kullanir bisi olur

        Debug.Log(isim + " Esya Kullaniliyor ");

     


    }

}
