using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameManager
{

    public class GameManager : MonoBehaviour
    {
        [Header("Skins")]
        public SkinsSystem skinSys;
        [Space(5f)]
        [Header("Stat")]
        public int Score=0;
        public int Level=1;
      

        [Space(5f)]
        [Header("Global Static")]
        public int KnifeCount = 8;

        [Header("Circle")]
        public GameObject CenterObj;
        public GameObject CenterDead;
        public float SpeedRotation;
        int curveNum;

        [Space(5f)]
        [Header("Knife")]
        public GameObject KnifePrefab;
        public Transform KnifeParrent;
       
        private KnifeMechanic kmThis; //существующий нож
        [Space(5f)]
        [Header("Apples")]
        public  ChanceChange chanceFile;
        public GameObject[] Apples;

        [Space(5f)]
        [Header("UI")]
        public Sprite NullSprite;
        public Sprite SkinSprite;
        public Image[] spritesUI;
        public GameObject TouchPanel;

        [Space(5f)]
        [Header("UI panel System")]
        public GameObject GOMessagePanel;
        public GameObject WinPanel;
        public Text ScoreText;

        [Header("ToolTip")]
        public GameObject _tooltip;
        public Transform _ttParrent;

        AudioManager.AudioManager audi;
 
        public void Start()
        {
            curveNum = Random.Range(0,chanceFile.curve.Length);
            StartCoroutine(RotateCenterObjMech());
            KnifeSpawn();
            CheskStat();
            if (Random.Range(0, 100) < chanceFile.Chance)
            {
                Apples[Random.Range(0, Apples.Length)].SetActive(true);
            }
            Debug.Log(chanceFile.Chance);
            audi = GameObject.FindObjectOfType<AudioManager.AudioManager>();
           
            
        }
        private void Update()
        {
            
        }
        public void ShowTooltip(int _value, Color _color)
        {
            
            GameObject tooltip = Instantiate(_tooltip, _ttParrent);
            int val=tooltip.transform.parent.childCount;
            tooltip.transform.position = new Vector3(tooltip.transform.position.x, tooltip.transform.position.y - (val * 10), tooltip.transform.position.z);
            Text paramTxt = tooltip.GetComponentInChildren<Text>();
            paramTxt.color = _color;
            paramTxt.text = "+"+_value.ToString();
            

            
            Destroy(tooltip, 1f);
        }
        void CheskStat()
        {
            if (PlayerPrefs.HasKey("Skin"))
            {
                Debug.Log("SkinLoad");
            }
            else
            {
                PlayerPrefs.SetInt("Skin", 0);
            }
            if (PlayerPrefs.HasKey("Score"))
            {
                Score = PlayerPrefs.GetInt("Score");
                Level = PlayerPrefs.GetInt("Level");
            }
            else
            {
                PlayerPrefs.SetInt("Score", Score);
                PlayerPrefs.SetInt("Level", Level);
            }
            
            ScoreText.text = "Level: " + Level + "| " + "Score: " + Score;
        }
        public void KnifeShot()
        {
            if(kmThis!=null) kmThis.ShotKnife();
        }

        public void RemoveKnifeStat()
        {
           KnifeCount -=  1;
           if (KnifeCount == 0)
            {
               
                Destroy(GOMessagePanel);
                PlayerPrefs.SetInt("Score", Score);
                PlayerPrefs.SetInt("Level", Level+=1);
                StartCoroutine(DeadCircle());
                
                
            }
            for (int i = 0; i < spritesUI.Length; i++)
            {
                if (i < KnifeCount) spritesUI[i].sprite = SkinSprite;               
                else spritesUI[i].sprite = NullSprite;
                
            }
   
        }
        IEnumerator DeadCircle()
        {
            while (true)
            {
                CenterObj.SetActive(false);
                CenterDead.SetActive(true);
                audi.PlayDeadWood();
                yield return new WaitForSeconds(1f);
                audi.PlayWin();
                WinPanel.SetActive(true);
                Level += 1;
                yield break;
            }
        }
 
        public void Colorizer()
        {
            StartCoroutine(Coloriter());
        }
        public void AddScore(int _score)
        {
            Score += _score;
            ScoreText.text = "Level: " + Level + "| " + "Score: " + Score;
        }
        public void KnifeSpawn()
        {
            StartCoroutine(KnifeSpawnCorrutine());
        }

        public void GameOver()
        {
            try
            {
                GOMessagePanel.SetActive(true);
                audi.PlayLoose();
            }
            catch (System.Exception ex)
            {

                Debug.Log(ex);
            }
            
        }
        

        private IEnumerator RotateCenterObjMech()
        {
            while (true)
            {
                CenterObj.transform.Rotate(0, 0, chanceFile.curve[curveNum].Evaluate(Time.time)*2f);
                yield return new WaitForSeconds(0.001f);
            }
        }

        private IEnumerator KnifeSpawnCorrutine()
        {
            while (true)
            {
                TouchPanel.SetActive(false);
                yield return new WaitForSeconds(chanceFile.knifeRespawn);
                GameObject KnifeSpwn = Instantiate(KnifePrefab, KnifeParrent);
                int skinInt = PlayerPrefs.GetInt("Skin");
                KnifeSpwn.GetComponent<SpriteRenderer>().sprite = skinSys.skins[skinInt].Skin;
                kmThis = KnifeSpwn.GetComponent<KnifeMechanic>();
                TouchPanel.SetActive(true);
                yield break;
            }
        }

        private IEnumerator Coloriter()
        {
            while (true)
            {
                SpriteRenderer sr = CenterObj.GetComponent<SpriteRenderer>();
                for (int i = 0; i < 20; i++)
                {
                    sr.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
                    yield return new WaitForSeconds(0.01f);
                }
                sr.color = new Color32(255, 255, 255, 255);
                yield break;
            }
        }
    }
}
