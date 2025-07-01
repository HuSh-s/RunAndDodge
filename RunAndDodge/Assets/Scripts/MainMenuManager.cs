using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Semih;

public class MainMenuManager : MonoBehaviour
{
    MemoryManage _MemoryManage = new MemoryManage();
    public GameObject ExitPanel;
    public List<ItemInfos> _ItemInfos = new List<ItemInfos>();
    DataManage _DataManage = new DataManage();
    void Start()
    {
        _MemoryManage.ControlAndDefine();
        //_DataManage.FirstTimeCreateFile(_ItemInfos); all item if finished activate this
    }

    public void _LoadScence(int Index)
    {
        SceneManager.LoadScene(Index);
    }

    public void _Play()
    {
        SceneManager.LoadScene(_MemoryManage.ReadData_I("EndLevel"));
    }
    public void _Exit()
    {
        ExitPanel.SetActive(true);
    }
    public void _ExitButtonAnswer(string state)
    {
        if(state == "YES")
        {
            Application.Quit();
        }
        else
        {
            ExitPanel.SetActive(false);
        }
    
    }

}
