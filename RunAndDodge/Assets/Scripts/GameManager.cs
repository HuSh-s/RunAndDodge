using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using Semih;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour
{
    public static int CurrentCharacterCount = 1;
    public List<GameObject> Characters;
    public List<GameObject> CreateEffects;
    public List<GameObject> DestroyEffects;
    public List<GameObject> ManMarkEffects;
    public List<GameObject> Enemys;
    public int HowMuchEnemy;
    public GameObject MainChar;
    public bool GameFinished;
    bool ReachEnd;

    void Start()
    {
        CreateEnemy();
    }

    public void CreateEnemy()
    {
        for (int i = 0; i < HowMuchEnemy; i++)
        {
            Enemys[i].SetActive(true);
        }
    }

    public void EnemyTrigger()
    {
        foreach (var item in Enemys)
        {
            if (item.activeInHierarchy)
            {
                item.GetComponent<Enemy>().Animation_Trigger();
            }
        }
        ReachEnd = true;
        WarState();
    }

    void Update()
    {

    }

    void WarState()
    {
        if (ReachEnd)
        {
            if (CurrentCharacterCount == 1 || HowMuchEnemy == 0)
            {
                GameFinished = true;
                foreach (var item in Enemys)
                {
                    if (item.activeInHierarchy)
                    {
                        item.GetComponent<Animator>().SetBool("Attack", false);
                    }
                }

                foreach (var item in Characters)
                {
                    if (item.activeInHierarchy)
                    {
                        item.GetComponent<Animator>().SetBool("Attack", false);
                    }
                }

                MainChar.GetComponent<Animator>().SetBool("Attack", false);

                if (CurrentCharacterCount < HowMuchEnemy || CurrentCharacterCount == HowMuchEnemy)
                {
                    Debug.Log("kaybettin");
                }
                else
                {
                    Debug.Log("kazanadýn");
                }
            }
        }
    }

    public void ManManager(string OperationType, int GetNumber, Transform position_)
    {
        switch (OperationType)
        {
            case "Multiply":
                Math_Operations.Multiply(GetNumber, Characters, position_, CreateEffects);
                break;

            case "Add":
                Math_Operations.Add(GetNumber, Characters, position_, CreateEffects);
                break;

            case "Sub":
                Math_Operations.Sub(GetNumber, Characters, DestroyEffects);
                break;

            case "Divide":
                Math_Operations.Divide(GetNumber, Characters, DestroyEffects);
                break;
        }
    }

    public void DestroyEffect_Create(Vector3 position_, bool Hammer = false, bool State_ = false)
    {
        foreach (var item in DestroyEffects)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position = position_;
                item.GetComponent<ParticleSystem>().Play();
                item.GetComponent<AudioSource>().Play();
                if (!State_)
                    CurrentCharacterCount--;
                else
                    HowMuchEnemy--;
                break;
            }
        }

        if (Hammer)
        {
            Vector3 newPos = new Vector3(position_.x, .005f, position_.z);
            foreach (var item in ManMarkEffects)
            {
                if (!item.activeInHierarchy)
                {
                    item.SetActive(true);
                    item.transform.position = newPos;
                    break;
                }
            }
        }

        if (!GameFinished)
        {
            WarState();
        }
    }
}
