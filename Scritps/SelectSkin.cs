using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectSkin : MonoBehaviour, IPointerClickHandler,IPointerDownHandler,IPointerUpHandler
{
    Vector3 curSize;
    private void Start()
    {
        curSize = transform.localScale;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
       PlayerPrefs.SetInt("Skin", int.Parse(transform.GetChild(2).GetComponent<Text>().text));
        Debug.Log(PlayerPrefs.GetInt("Skin"));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = new Vector2(curSize.x - 0.1f, curSize.y - 0.1f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = curSize;
    }
}
