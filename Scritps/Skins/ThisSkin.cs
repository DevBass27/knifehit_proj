using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThisSkin : MonoBehaviour
{
    public SkinsSystem ss;
    Image img;
    private void Awake()
    {
        img = GetComponent<Image>();
    }
    private void Update()
    {
        img.sprite = ss.skins[PlayerPrefs.GetInt("Skin")].Skin;
    }
}
