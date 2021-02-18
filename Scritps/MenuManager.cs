using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MenuManager 
{
    public class MenuManager : MonoBehaviour
    {
        public GameObject[] Menus;
        private void Start()
        {
            for (int i = 0; i < Menus.Length; i++)
            {
                if (i == 0) Menus[i].SetActive(true);
                else Menus[i].SetActive(false);
            }
        }
        public void SetMenu(int _value)
        {
            for (int i = 0; i < Menus.Length; i++)
            {
                if (i == _value) Menus[i].SetActive(true);
                else Menus[i].SetActive(false);
            }
        }
    }
}
