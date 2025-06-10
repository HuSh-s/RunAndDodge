using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class GameManager : MonoBehaviour
{
    public GameObject DestinationPoint;
    public int CurrentCharacterCount = 1;

    public List<GameObject> Characters;

    void Start()
    {

    }

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (var item in Characters)
            {
                if (!item.activeInHierarchy)
                {
                    item.transform.position = StartPoint.transform.position;
                    item.SetActive(true);
                    CurrentCharacterCount++;
                    break;
                }
            }
        }*/
    }

    public void ManManager(string data_, Transform position_)
    {
        switch (data_)
        {
            case "x2":
                int number = 0;
                foreach (var item in Characters)
                {
                    if (number < CurrentCharacterCount)
                    {
                        if (!item.activeInHierarchy)
                        {
                            item.transform.position = position_.transform.position;
                            item.SetActive(true);
                            number++;
                        }
                        else
                        {
                            number = 0;
                            break;
                        }
                    }
                }
                CurrentCharacterCount *= 2;
                break;

            case "+3":
                int number2 = 0;
                foreach (var item in Characters)
                {
                    if (number2 < 3)
                    {
                        if (!item.activeInHierarchy)
                        {
                            item.transform.position = position_.transform.position;
                            item.SetActive(true);
                            number2++;
                        }
                        else
                        {
                            number2 = 0;
                            break;
                        }
                    }
                }
                CurrentCharacterCount += 3;
                break;

            case "-4":

                if(CurrentCharacterCount < 4)
                {
                    foreach (var item in Characters)
                    {
                        item.transform.position = Vector3.zero;
                        item.SetActive(false);
                    }
                    CurrentCharacterCount = 1;
                }
                else
                {

                    int number3 = 0;
                    foreach (var item in Characters)
                    {
                        if (number3 < 4)
                        {
                            if (item.activeInHierarchy)
                            {
                                item.transform.position = Vector3.zero;
                                item.SetActive(false);
                                number3++;
                            }
                            else
                            {
                                number3 = 0;
                                break;
                            }
                        }
                    }
                    CurrentCharacterCount -= 4;
                }
                break;

            case "/2":

                if (CurrentCharacterCount <= 2)
                {
                    foreach (var item in Characters)
                    {
                        item.transform.position = Vector3.zero;
                        item.SetActive(false);
                    }
                    CurrentCharacterCount = 1;
                }
                else
                {
                    int divisor = CurrentCharacterCount / 2;
                    int number4 = 0;
                    foreach (var item in Characters)
                    {
                        if (number4 < divisor)
                        {
                            if (item.activeInHierarchy)
                            {
                                item.transform.position = Vector3.zero;
                                item.SetActive(false);
                                number4++;
                            }
                            else
                            {
                                number4 = 0;
                                break;
                            }
                        }
                    }

                    if (CurrentCharacterCount % 2 == 0)
                    {
                        CurrentCharacterCount /= 2;
                    }
                    else
                    {
                        CurrentCharacterCount /= 2;
                        CurrentCharacterCount++;
                    }


                }
                break;
        }
    }
}
