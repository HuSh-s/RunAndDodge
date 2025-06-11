using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;


namespace Semih
{
    public class Math_Operations : MonoBehaviour
    {
        public static void Multiply(int GetNumber, List<GameObject> Characters, Transform position_, List<GameObject> CreateEffects_)
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
        public static void Add(int GetNumber, List<GameObject> Characters, Transform position_, List<GameObject> CreateEffects_)
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
        public static void Sub(int GetNumber, List<GameObject> Characters, List<GameObject> DestroyEffects_)
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
        public static void Divide(int GetNumber, List<GameObject> Characters, List<GameObject> DestroyEffects_)
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
}