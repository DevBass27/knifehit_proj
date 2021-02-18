using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class btn_restart : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public Color32 curColor;
    public Color32 pressColor;
    Image sprite;

    private void Awake()
    {
        sprite = GetComponent<Image>();
        curColor = sprite.color;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        sprite.color = pressColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        sprite.color = curColor;
        Restart();
    }
    void Restart()
    {
        
        SceneManager.LoadScene(2);

    }
 
}
