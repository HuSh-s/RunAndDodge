using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Semih;
using TMPro;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class CustomizationManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HatText;
    public GameObject[] Hats;
    public GameObject[] Sticks;
    public Material[] Materials;
    public Button[] HatsButtons;

    int HatIndex = -1;

    MemoryManage _MemoryManage = new MemoryManage();
    DataManage _DataManage = new DataManage();

    public List<ItemInfos> _ItemInfos = new List<ItemInfos>();

    void Start()
    {
        _MemoryManage.SaveData_int("SelectedHat", -1);

        if (_MemoryManage.ReadData_I("SelectedHat") == -1)
        {

            foreach (var item in Hats)
            {
                item.SetActive(false);
            }
            HatIndex = -1;
            HatText.text = "No Hat";
        }
        else
        {
            HatIndex = _MemoryManage.ReadData_I("SelectedHat");
            Hats[HatIndex].SetActive(true);
        }

       //_DataManage.Save(_ItemInfos);

        _DataManage.Load();
        _ItemInfos = _DataManage.GetList(); 
    }

    public void Hat_Buttons(string _operator)
    {
        if (_operator == "Forward")
        {
            if (HatIndex == -1)
            {
                HatIndex = 0;
                Hats[HatIndex].SetActive(true);
                HatText.text = _ItemInfos[HatIndex].Item_Name;
            }
            else
            {
                Hats[HatIndex].SetActive(false);
                HatIndex++;
                Hats[HatIndex].SetActive(true);
                HatText.text = _ItemInfos[HatIndex].Item_Name;
            }

            //----------------------------

            if (HatIndex == Hats.Length - 1)
            {
                HatsButtons[1].interactable = false;
            }
            else
            {
                HatsButtons[1].interactable = true;
            }

            if (HatIndex != -1)
            {
                HatsButtons[0].interactable = true;
            }
        }
        else
        {
            if (HatIndex != -1)
            {
                Hats[HatIndex].SetActive(false);
                HatIndex--;

                if (HatIndex != -1)
                {
                    Hats[HatIndex].SetActive(true);
                    HatsButtons[0].interactable = true;
                    HatText.text = _ItemInfos[HatIndex].Item_Name;
                }
                else
                {
                    HatsButtons[0].interactable = false;
                    HatText.text = "No Hat";
                }
            }
            else
            {
                HatsButtons[0].interactable = false;
                HatText.text = "No Hat";
            }

            //----------------------------

            if (HatIndex != Hats.Length - 1)
            {
                HatsButtons[1].interactable = true;
            }
        }
    }

   

    void Update()
    {

    }
}
