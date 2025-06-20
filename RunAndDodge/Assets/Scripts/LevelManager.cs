using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Semih;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class LevelManager : MonoBehaviour
{
    public Button[] Buttons;
    public int Level;
    public Sprite LockButton;

    MemoryManage _MemoryManage = new MemoryManage();
    void Start()
    {
        int DefLevel = _MemoryManage.ReadData_I("EndLevel") - 4;

        int Index = 1;
        for (int i = 0; i < Buttons.Length; i++)
        {
            if (Index <= DefLevel)
            {
                Buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = Index.ToString();
                int sceneIndex = Index + 4;
                Buttons[i].onClick.AddListener(delegate { _LoadScene(sceneIndex); });
            }
            else
            {
                Buttons[i].GetComponent<Image>().sprite = LockButton;
                Buttons[i].enabled = false;
            }
            Index++;
        }
    }
    public void _LoadScene(int Index)
    {
        SceneManager.LoadScene(Index);
    }
    /* public void _LoadScene()
     {
         Debug.Log(EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text);
         SceneManager.LoadScene(int.Parse(EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text) + 4);
     }
    */
    public void _BackButton()
    {
        SceneManager.LoadScene(0);
    }
}
