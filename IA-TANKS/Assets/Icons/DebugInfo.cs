using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction
public class DebugInfo : MonoBehaviour
{
    public bool debugAA;
    public bool candebug;
    public Text blueBullets;
    public Text redBullets;
    public GameObject wt;
    public GameObject dp;
    public GameObject[] pp = new GameObject[12];
    public int selected;
    private Color cyan;
    // Start is called before the first frame update
    void Start()
    {
        selected = 0;
        cyan = Color.cyan;
        debugAA = false;
        candebug = false;
        redBullets.enabled = false;
        blueBullets.enabled = false;
        dp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 12; i++)
        {
            if(i != selected)
            {
                pp[i].GetComponent<MeshRenderer>().material.color = Color.white;
            }
            else
            {
                pp[i].GetComponent<MeshRenderer>().material.color = cyan;
            }
        }
       
        blueBullets.text = "Current Bullets: " + GameObject.Find("Time").GetComponent<TimeDelta>().blueBulletsInScene.Count.ToString();
        redBullets.text = "Current Bullets: " + GameObject.Find("Time").GetComponent<TimeDelta>().redBulletsInScene.Count.ToString();
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            debugAA = !debugAA;
        }
        if(debugAA && candebug)
        {
            dp.SetActive(true);
            blueBullets.enabled = true;
            redBullets.enabled = true;
            wt.SetActive(true);
            for (int i = 0; i < 12; i++)
            {
                pp[i].SetActive(true);
            }
        }
        if(!debugAA)
        {
            dp.SetActive(false);
            blueBullets.enabled = false;
            redBullets.enabled = false;
            wt.SetActive(false);
            for (int i = 0; i < 12; i++)
            {
                pp[i].SetActive(false);
            }
        }
    }
}
