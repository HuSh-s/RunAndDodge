using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Semih;
using TMPro;
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

    }

    public void Hat_Buttons(string _operator)
    {
        if(_operator == "Forward")
        {
            if(HatIndex == -1)
            {
                HatIndex = 0;
                Hats[HatIndex].SetActive(true);
            }
            else
            {
                Hats[HatIndex].SetActive(false);
                HatIndex++;
                Hats[HatIndex].SetActive(true);
            }

            //----------------------------

            if(HatIndex == Hats.Length - 1)
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
            if(HatIndex!= -1)
            {
                Hats[HatIndex].SetActive(false);
                HatIndex--;

                if(HatIndex != -1)
                {
                    Hats[HatIndex].SetActive(true);
                    HatsButtons[0].interactable = true;
                }
                else
                {
                    HatsButtons[0].interactable = false;
                }
            }
            else
            {
                HatsButtons[0].interactable = false;
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
