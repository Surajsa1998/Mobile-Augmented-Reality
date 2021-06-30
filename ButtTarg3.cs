using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ButtTarg3 : MonoBehaviour, IVirtualButtonEventHandler
{

    public GameObject vbtn1;
    public GameObject vbtn2;
    public GameObject vbtn3;
    public GameObject[] got3;
    public AudioSource soundTarget;
    public AudioClip clipTarget;
    private AudioSource[] allAudioSources;
    private int i = -1;
    private int len = 0;
    ArrayList audb = new ArrayList()
    {"sounds/SolarSystem/Sun","sounds/SolarSystem/Mercury","sounds/SolarSystem/Venus","sounds/SolarSystem/earth","sounds/SolarSystem/Mars","sounds/SolarSystem/Jupiter","sounds/SolarSystem/Saturn","sounds/SolarSystem/Uranus","sounds/SolarSystem/Neptune","sounds/SolarSystem/Pluto","sounds/SolarSystem/Moon","sounds/SolarSystem/intross" };
    

    //function to stop all sounds
    void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }

    //function to play sound
    void playSound(string ss)
    {
        clipTarget = (AudioClip)Resources.Load(ss);
        soundTarget.clip = clipTarget;
        soundTarget.loop = false;
        soundTarget.playOnAwake = false;
        soundTarget.Play();
    }

    //-----------End Sound------------


    // Start is called before the first frame update
    void Start()
    {
        vbtn1 = GameObject.Find("T3N");
        vbtn2 = GameObject.Find("T3P");
        vbtn3 = GameObject.Find("T3R");

        vbtn1.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        vbtn2.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        vbtn3.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();
        len = (int)got3.Length;


    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        int j;
        switch (vb.VirtualButtonName)
        {
            case "T3N":
                i = (i + 1) % len;
                playSound((string)audb[i]);
                
                j = (i + (len - 1)) % len;
                got3[j].SetActive(false);
                got3[i].SetActive(true);
                break;
            case "T3P":
                i = (i + (len - 1)) % len;
                playSound((string)audb[i]);
             
                j = (i + 1) % len;
                got3[j].SetActive(false);
                got3[i].SetActive(true);
                break;

            case "T3R":
                if(i==-1){
                    i = len - 1;
                    got3[i].SetActive(true);
                }
                playSound((string)audb[i]);
                break;
            default:

                break;


        }

        Debug.Log("BTN Pressed");

    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        
        Debug.Log("BTN Released");
    }

    // Update is called once per frame
    void Update()
    {

    }
}