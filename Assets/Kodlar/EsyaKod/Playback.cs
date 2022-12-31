using UnityEngine;

[CreateAssetMenu(fileName = "Yeni Esya", menuName = "Envanter/Playback")]
public class Playback : Esya
{
    override public void Kullan()
    {
        if (FindObjectOfType<SarkiYarismasi>() == null)
        {
            Debug.Log("sarki yarismasi bulunamadi");
            
        }
        else
        {

        FindObjectOfType<SarkiYarismasi>().PlaybackKullan();
        }
    }


}
