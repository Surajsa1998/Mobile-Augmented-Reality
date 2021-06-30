using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ButtTarg1 : MonoBehaviour, IVirtualButtonEventHandler
{

    public GameObject vbtn1;
    public GameObject vbtn2;
    public GameObject vbtn3;
    public GameObject[] got1;
    public AudioSource soundTarget;
    public AudioClip clipTarget;
    private AudioSource[] allAudioSources;
    private int i = -1;
    private int len = 0;
    ArrayList audb = new ArrayList()
    {"sounds/Alpha/a","sounds/Alpha/b","sounds/Alpha/c","sounds/Alpha/d","sounds/Alpha/e","sounds/Alpha/f","sounds/Alpha/g","sounds/Alpha/h","sounds/Alpha/i","sounds/Alpha/j","sounds/Alpha/k","sounds/Alpha/l","sounds/Alpha/m","sounds/Alpha/n","sounds/Alpha/o","sounds/Alpha/p","sounds/Alpha/q","sounds/Alpha/r","sounds/Alpha/s","sounds/Alpha/t","sounds/Alpha/u","sounds/Alpha/v","sounds/Alpha/w","sounds/Alpha/x","sounds/Alpha/y","sounds/Alpha/z","sounds/Alpha/introalpha"};
    




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
        vbtn1 = GameObject.Find("T1N");
        vbtn2 = GameObject.Find("T1P");
        vbtn3 = GameObject.Find("T1R");

        vbtn1.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        vbtn2.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        vbtn3.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();
        len = (int)got1.Length;


    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        int j;
        switch(vb.VirtualButtonName)
        {
            case "T1N":
                i = (i + 1) % len;
                playSound((string)audb[i]);
                j = (i + (len - 1)) % len;
                got1[j].SetActive(false);
                got1[i].SetActive(true);
                break;
            case "T1P":
                i = (i + (len - 1)) % len;
                playSound((string)audb[i]);
                j = (i + 1) % len;
                got1[j].SetActive(false);
                got1[i].SetActive(true);
                break;

            case "T1R":
                if(i==-1){
                    i = len - 1;
                    got1[i].SetActive(true);
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