using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ButtTarg2 : MonoBehaviour, IVirtualButtonEventHandler
{

    public GameObject vbtn1;
    public GameObject vbtn2;
    public GameObject vbtn3;
    public GameObject[] got2;
     public AudioSource soundTarget;
    public AudioClip clipTarget;
    private AudioSource[] allAudioSources;
    private int i = -1;
    private int len = 0;
    ArrayList audb = new ArrayList()
    {"sounds/body/skeleton","sounds/body/skull","sounds/body/brain","sounds/body/heart","sounds/body/eyes","sounds/body/ear","sounds/body/hand","sounds/body/skin","sounds/body/nose","sounds/body/tongue","sounds/body/intestines","sounds/body/stomach","sounds/body/liver","sounds/body/lungs","sounds/body/introbody"};
    




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
        vbtn1 = GameObject.Find("T2N");
        vbtn2 = GameObject.Find("T2P");
        vbtn3 = GameObject.Find("T2R");

        vbtn1.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        vbtn2.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        vbtn3.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();
        len = (int)got2.Length;


    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        int j;
        switch(vb.VirtualButtonName)
        {
            case "T2N":
                i = (i + 1) % len;
                playSound((string)audb[i]);
                j = (i + (len - 1)) % len;
                got2[j].SetActive(false);
                got2[i].SetActive(true);
                break;
            case "T2P":
                i = (i + (len - 1)) % len;
                playSound((string)audb[i]);
                j = (i + 1) % len;
                got2[j].SetActive(false);
                got2[i].SetActive(true);
                break;

            case "T2R":
                if(i==-1){
                    i = len - 1;
                    got2[i].SetActive(true);
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