using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenKnife : MonoBehaviour
{
    [SerializeField] GameObject[] Spawner;
    void Start()
    {
        int count = Random.Range(1, 4);

        for (int i = 0; i < count; i++)
        {
            
            Spawner[Random.Range(0, Spawner.Length)].transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private void Update()
    {
       // Debug.Log(Random.Range(1, 4));
    }


}
