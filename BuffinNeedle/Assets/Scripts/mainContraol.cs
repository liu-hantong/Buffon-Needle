using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class mainContraol : MonoBehaviour
{
    public GameObject MainCanvas;
    public GameObject InputCanvas;
    public GameObject ThrowText;
    public GameObject DistarnceText;
    public GameObject NeedleText;

    private double a, l;
    private long n;
    // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {
        InputCanvas.SetActive(false);
    }

    public void MainPanelDisable()
    {
        //control the apprear and disappear of two panels in game
        MainCanvas.gameObject.SetActive(false);
        InputCanvas.gameObject.SetActive(true);
    }
    public void InputPanelDisable()
    {
        //disable the input panel and start game
        GetValue();
        InputCanvas.gameObject.SetActive(false);
    }

    void GetValue()
    {
        //get value from input
        n = Convert.ToInt64(ThrowText.GetComponent<Text>().text);
        a = Convert.ToDouble(DistarnceText.GetComponent<Text>().text);
        l = Convert.ToDouble(NeedleText.GetComponent<Text>().text);
    }
}
