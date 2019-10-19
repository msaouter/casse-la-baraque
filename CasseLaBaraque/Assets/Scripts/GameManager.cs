using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    MicroInput micro;

    //class micro 

    // Start is called before the first frame update 
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

        micro = GetComponent<MicroInput>();

    }

    //db micro 
    public float getDbMicro()
    {
        return micro.GetMicroLoudness();
    }

    public float getDbCalme()
    {
        return 0;
    }

    // Update is called once per frame 
    void Update()
    {

    }
}
