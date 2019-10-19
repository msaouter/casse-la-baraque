using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* There might be some latency */
public class MicroInput : MonoBehaviour
{
    AudioClip microphoneInput;
    bool microInitialized;
    public float sensitivity;
    public bool party;

    void Awake()
    {
        //init micro input
        if (Microphone.devices.Length > 0)
        {
            microphoneInput = Microphone.Start(Microphone.devices[0], true, 999, 44100);
            microInitialized = true;
            Debug.Log("micro Init");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //initializing micro
        if(!microInitialized)
            Awake();


        //get mic volume
        int dec = 128;
        float[] waveData = new float[dec];

        int micPosition = Microphone.GetPosition(null) - (dec + 1); // null targets the first microphonee
        microphoneInput.GetData(waveData, micPosition);

        // Getting the higher level on the last 128 samples
        float levelMax = 0;

        for (int i = 0; i < dec; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if(levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }

        float level = Mathf.Sqrt(Mathf.Sqrt(levelMax)) * 100;

        //Conditions to party
        if (level > sensitivity)
        {
            //activate Party anim
            party = true;
        }
        if (level < sensitivity && party)
        {
            party = false;
        }
    }
}
