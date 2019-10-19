using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "scripts settings/Difficulty Settings")]
public class DifficultySettings : ScriptableObject
{
    [Range(5, 3600)]
    public float playTimeInSeconds = 60f;

    [Header("Time Between 2 Checks")]
    [Range(0, 50)]
    public float InitialTimeBetween2Checks = 5f;

    [Range(0, 50)]
    public float EndTimeBetween2Checks = 3f;

    [Header("Random TimeBetwwen 2 Checks")]
    [Range(0, 50)]
    public float InitialRandomTimeBetween2Checks = 5f;

    [Range(0, 50)]
    public float EndRandomTimeBetween2Checks = 5f;

    [Header("Reaction Time")]
    [Range(0.1f, 10f)]
    public float InitialReactionTime = 2f;

    [Range(0.1f, 10f)]
    public float EndReactionTime = 1f;


    void OnValidate()
    {
        if (InitialTimeBetween2Checks < EndTimeBetween2Checks)
        {
            InitialTimeBetween2Checks = EndTimeBetween2Checks;
        }


        if(InitialTimeBetween2Checks < InitialRandomTimeBetween2Checks)
        {
            InitialRandomTimeBetween2Checks = InitialTimeBetween2Checks;
        }

        if (EndTimeBetween2Checks < EndRandomTimeBetween2Checks)
        {
            EndRandomTimeBetween2Checks = EndTimeBetween2Checks;
        }

        if (InitialReactionTime < EndReactionTime)
        {
            InitialReactionTime = EndReactionTime;
        }


    }


}
