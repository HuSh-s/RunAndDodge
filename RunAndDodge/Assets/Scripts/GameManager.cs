using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using Semih;

public class GameManager : MonoBehaviour
{
    public GameObject DestinationPoint;
    public static int CurrentCharacterCount = 1;

    public List<GameObject> Characters;

    void Start()
    {

    }

    void Update()
    {

    }

    public void ManManager(string OperationType, int GetNumber, Transform position_)
    {
        switch (OperationType)
        {
            case "Multiply":
                Math_Operations.Multiply(GetNumber, Characters, position_);
                break;

            case "Add":
                Math_Operations.Add(GetNumber, Characters, position_);
                break;

            case "Sub":
                Math_Operations.Sub(GetNumber, Characters);
                break;

            case "Divide":
                Math_Operations.Divide(GetNumber, Characters);
                break;
        }
    }
}
