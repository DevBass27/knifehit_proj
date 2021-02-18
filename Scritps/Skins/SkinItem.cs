using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Skin", menuName = "Game/SkinsItem")]
public class SkinItem : ScriptableObject
{
    public string Name;
    public Sprite Skin;
    public int price;

  
}
