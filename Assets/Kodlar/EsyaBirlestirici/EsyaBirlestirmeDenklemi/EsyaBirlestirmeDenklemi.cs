using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Yeni Birlestirme Denklemi", menuName = "Envanter/Birlestirme Denklemi")]
public class EsyaBirlestirmeDenklemi : ScriptableObject
{
    public List<Esya> Birlestirilecekler;
    public List<Esya> Urun;
}
