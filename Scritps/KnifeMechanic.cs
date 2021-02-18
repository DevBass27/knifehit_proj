using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeMechanic : MonoBehaviour
{
    Rigidbody2D rb2d;
    GameManager.GameManager gm;
    KnifeMechanic km;
    AudioManager.AudioManager audi;


     private void Awake()
    {
        km = this;
        rb2d = GetComponent<Rigidbody2D>();
        gm = GameObject.FindObjectOfType<GameManager.GameManager>();
        audi = GameObject.FindObjectOfType<AudioManager.AudioManager>();
    }
    private void Start()
    {
        
        
    }
    public void ShotKnife()
    {
        rb2d.AddForce(Vector2.up * gm.chanceFile.knifeSpeed, ForceMode2D.Impulse);
        try
        {
            audi.PlayShot();
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex);
        } 
        gm.KnifeSpawn();
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Circle"))
        {
           
            gm.Colorizer();
            transform.SetParent(collision.transform);
            rb2d.bodyType = RigidbodyType2D.Static;
            gm.AddScore(gm.chanceFile.CircleScore);
            gm.ShowTooltip(gm.chanceFile.CircleScore,Color.yellow);
            gm.RemoveKnifeStat();
            try
            {
                audi.PlayHit();
            }
            catch (System.Exception ex)
            {

                Debug.Log("Audio error: " + ex);
            }
            
        }
        else if(collision.transform.CompareTag("Knife"))
        {
            Handheld.Vibrate();
            audi.PlayKnifeToKnife();
            StartCoroutine(CircleHideCollider());
            rb2d.gravityScale = 5f;
            km = null;
            transform.SetParent(null);
            rb2d.bodyType = RigidbodyType2D.Dynamic;
            gm.GameOver();
            audi.PlayLoose();
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (collision.transform.CompareTag("Apple"))
        {
            Handheld.Vibrate();
            Destroy(collision.gameObject);
            collision.transform.parent.GetChild(1).GetComponent<ParticleSystem>().Play();
            rb2d.AddForce(Vector2.up * gm.chanceFile.knifeSpeed, ForceMode2D.Impulse);
            gm.AddScore(gm.chanceFile.AppleScore);
            gm.ShowTooltip(gm.chanceFile.AppleScore,Color.yellow);
        }

        


    }
    IEnumerator CircleHideCollider()
    {
        while (true)
        {
            CircleCollider2D cr = gm.CenterObj.GetComponent<CircleCollider2D>();
            cr.enabled = false;
            yield return new WaitForSeconds(1f);
            cr.enabled = true;
            yield break;
        }
    }
}
