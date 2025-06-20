using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;


namespace Semih
{
    public class Math_Operations
    {
        public void Multiply(int GetNumber, List<GameObject> Characters, Transform position_, List<GameObject> CreateEffects_)
        {

            int RepeatNumber = (GameManager.CurrentCharacterCount * GetNumber) - GameManager.CurrentCharacterCount;
            int number = 0;
            foreach (var item in Characters)
            {
                if (number < RepeatNumber)
                {
                    if (!item.activeInHierarchy)
                    {
                        foreach (var item2 in CreateEffects_)
                        {
                            if (!item2.activeInHierarchy)
                            {
                                item2.SetActive(true);
                                item2.transform.position = position_.position;
                                item2.GetComponent<ParticleSystem>().Play();
                                item2.GetComponent<AudioSource>().Play();
                                break;
                            }
                        }
                        item.transform.position = position_.position;
                        item.SetActive(true);
                        number++;
                    }
                }
                else
                {
                    number = 0;
                    break;
                }
            }
            GameManager.CurrentCharacterCount *= GetNumber;

        }
        public void Add(int GetNumber, List<GameObject> Characters, Transform position_, List<GameObject> CreateEffects_)
        {

            int number2 = 0;
            foreach (var item in Characters)
            {
                if (number2 < GetNumber)
                {
                    if (!item.activeInHierarchy)
                    {
                        foreach (var item2 in CreateEffects_)
                        {
                            if (!item2.activeInHierarchy)
                            {
                                item2.SetActive(true);
                                item2.transform.position = position_.position;
                                item2.GetComponent<ParticleSystem>().Play();
                                item2.GetComponent<AudioSource>().Play();
                                break;
                            }
                        }
                        item.transform.position = position_.position;
                        item.SetActive(true);
                        number2++;
                    }
                }
                else
                {
                    number2 = 0;
                    break;
                }
            }
            GameManager.CurrentCharacterCount += GetNumber;


        }
        public void Sub(int GetNumber, List<GameObject> Characters, List<GameObject> DestroyEffects_)
        {

            if (GameManager.CurrentCharacterCount < GetNumber)
            {
                foreach (var item in Characters)
                {
                    foreach(var item2 in DestroyEffects_)
                    {
                        if (!item2.activeInHierarchy)
                        {
                            Vector3 newPos = new Vector3(item.transform.position.x, .23f, item.transform.position.z);

                            item2.SetActive(true);
                            item2.transform.position = newPos;
                            item2.GetComponent<ParticleSystem>().Play();
                            item2.GetComponent<AudioSource>().Play();
                            break;
                        }

                    }
                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
                GameManager.CurrentCharacterCount = 1;
            }
            else
            {

                int number3 = 0;
                foreach (var item in Characters)
                {
                    if (number3 < GetNumber)
                    {
                        if (item.activeInHierarchy)
                        {
                            foreach (var item2 in DestroyEffects_)
                            {
                                if (!item2.activeInHierarchy)
                                {
                                    Vector3 newPos = new Vector3(item.transform.position.x, .23f, item.transform.position.z);

                                    item2.SetActive(true);
                                    item2.transform.position = newPos;
                                    item2.GetComponent<ParticleSystem>().Play();
                                    item2.GetComponent<AudioSource>().Play();
                                    break;
                                }
                            }
                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            number3++;
                        }
                    }
                    else
                    {
                        number3 = 0;
                        break;
                    }
                }
                GameManager.CurrentCharacterCount -= GetNumber;
            }
        }
        public void Divide(int GetNumber, List<GameObject> Characters, List<GameObject> DestroyEffects_)
        {
            if (GameManager.CurrentCharacterCount <= GetNumber)
            {
                foreach (var item in Characters)
                {

                    foreach (var item2 in DestroyEffects_)
                    {
                        if (!item2.activeInHierarchy)
                        {
                            Vector3 newPos = new Vector3(item.transform.position.x, .23f, item.transform.position.z);

                            item2.SetActive(true);
                            item2.transform.position = newPos;
                            item2.GetComponent<ParticleSystem>().Play();
                            item2.GetComponent<AudioSource>().Play();
                            break;
                        }
                    }
                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
                GameManager.CurrentCharacterCount = 1;
            }
            else
            {
                int divisor = GameManager.CurrentCharacterCount / GetNumber;
                int number4 = 0;
                foreach (var item in Characters)
                {
                    if (number4 < divisor)
                    {
                        if (item.activeInHierarchy)
                        {
                            foreach (var item2 in DestroyEffects_)
                            {
                                if (!item2.activeInHierarchy)
                                {
                                    Vector3 newPos = new Vector3(item.transform.position.x, .23f, item.transform.position.z);

                                    item2.SetActive(true);
                                    item2.transform.position = newPos;
                                    item2.GetComponent<ParticleSystem>().Play();
                                    item2.GetComponent<AudioSource>().Play();
                                    break;
                                }
                            }

                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            number4++;
                        }
                    }
                    else
                    {
                        number4 = 0;
                        break;
                    }
                }

                if (GameManager.CurrentCharacterCount % GetNumber == 0)
                {
                    GameManager.CurrentCharacterCount /= GetNumber;
                }
                else if (GameManager.CurrentCharacterCount % GetNumber == 1)
                {
                    GameManager.CurrentCharacterCount /= GetNumber;
                    GameManager.CurrentCharacterCount++;
                }
                else if (GameManager.CurrentCharacterCount % GetNumber == 2)
                {
                    GameManager.CurrentCharacterCount /= GetNumber;
                    GameManager.CurrentCharacterCount += 2;
                }
            }
        }
    }

    public class MemoryManage
    {
        public void SaveData_string(string Key, string Value)
        {
            PlayerPrefs.SetString(Key, Value);
            PlayerPrefs.Save();
        }
        public void SaveData_int(string Key, int Value)
        {
            PlayerPrefs.SetInt(Key, Value);
            PlayerPrefs.Save();
        }
        public void SaveData_float(string Key, float Value)
        {
            PlayerPrefs.SetFloat(Key, Value);
            PlayerPrefs.Save();
        }


        public string ReadData_S(string Key)
        {
            return PlayerPrefs.GetString(Key);
        }
        public int ReadData_I(string Key)
        {
            return PlayerPrefs.GetInt(Key);
        }
        public float ReadData_F(string Key)
        {
            return PlayerPrefs.GetFloat(Key);
        }

        public void ControlAndDefine()
        {
            if (!PlayerPrefs.HasKey("EndLevel"))
            {
                PlayerPrefs.SetInt("EndLevel", 5);
                PlayerPrefs.SetInt("Score", 100);
            }
        }
    }
}