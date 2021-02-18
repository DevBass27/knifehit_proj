using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsLoadBase : MonoBehaviour
{
    public SkinsSystem ss;
    public GameObject Skin_UI_pref;
    public Transform parrent;

    private void Start()
    {
        for (int i = 0; i < ss.skins.Length; i++)
        {
            GameObject newScin = Instantiate(Skin_UI_pref, parrent);
            newScin.transform.GetChild(0).GetComponent<Image>().sprite = ss.skins[i].Skin;
            newScin.transform.GetChild(1).GetComponent<Text>().text = ss.skins[i].Name;
            newScin.transform.GetChild(2).GetComponent<Text>().text = i.ToString();
        }
    }
}
