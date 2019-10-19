using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* There might be some latency */
public class MicroInput : MonoBehaviour
{
    AudioClip microphoneInput;
    bool microInitialized;
    float clipLoudness = 0f;


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

    public float GetMicroLoudness()
    {
        return clipLoudness;
    } 

    // Update is called once per frame
    void Update()
    {
        //initializing micro
        if(!microInitialized)
            Awake();


        //get mic volume
        float[] waveData = new float[microphoneInput.samples];
        microphoneInput.GetData(waveData, 0);
        
        foreach (var sample in waveData)
        {
            clipLoudness += Mathf.Abs(sample);
        }
        clipLoudness /= waveData.Length;
    }
}
