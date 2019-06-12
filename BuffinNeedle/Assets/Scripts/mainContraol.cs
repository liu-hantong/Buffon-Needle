using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainContraol : MonoBehaviour
{
    //the canvas need to be enable during playing
    public GameObject MainCanvas;
    public GameObject InputCanvas;
    public GameObject PlayCanvas; 

    public GameObject ThrowText;
    public GameObject DistarnceText;
    public GameObject NeedleText;

    //the Text needed to be display during playing
    public Text ThrowTime;
    public Text CollideTime;
    public Text LengthBetween;
    public Text NeedleLength;

    public GameObject LinePrefab;
    public GameObject NeedlePrefab;

    private long a, l;
    private long n;
    private long currentThrow;
    public long collisionNumber;
    private bool gameStart;
    // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {
        gameStart = false;
        currentThrow = 0;
        collisionNumber = 0;
        InputCanvas.gameObject.SetActive(false);
        PlayCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        CollideTime.text = collisionNumber.ToString();
        if (currentThrow < n && gameStart)
        {
            //create needle to throw
            ThrowTime.text = (++currentThrow).ToString();
            float ZPositionZofNeedle = UnityEngine.Random.Range(-(float)38 + ((float)a / 2) / (float)1000, -(float)38 + (float)a / (float)1000);
            Vector3 PositionOfNeedle = new Vector3(392.07f, 200.02f, ZPositionZofNeedle);
            float AngelOfNeedle = UnityEngine.Random.Range(0f, 180f);
            GameObject NewNeedle = Instantiate(NeedlePrefab, PositionOfNeedle, Quaternion.Euler(0f, AngelOfNeedle, 0f));
            NewNeedle.transform.localScale = new Vector3( (float)l / 1000f, 0.01f, 0.01f);
            //if would be collided
            if ((float)a / 1000 - (ZPositionZofNeedle + 38f) < ((float)l / 2000) * Math.Sin(AngelOfNeedle / (float)180 * Math.PI)) 
            {
                collisionNumber++;
            }
        }
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

        //enable the panel that shows process and results;
        PlayCanvas.gameObject.SetActive(true);
        gameStart = true;
    }

    void GetValue()
    {
        //get value from input
        n = Convert.ToInt64(ThrowText.GetComponent<Text>().text);
        a = Convert.ToInt64(DistarnceText.GetComponent<Text>().text);
        l = Convert.ToInt64(NeedleText.GetComponent<Text>().text);
        //pass the value to the play canvas
        ThrowTime.text = n.ToString();
        LengthBetween.text = a.ToString();
        NeedleLength.text = l.ToString();

        //deal with a and l in order to fit the standards
        //a requires 1000 - 3000
        float trueA = -(float)38 + (float)a / (float)1000;

        //instantiate a ParalleLine Now!!!
        Vector3 PositionOfLine = new Vector3(395, 200, trueA);
        Instantiate(LinePrefab, PositionOfLine, transform.rotation);
    }
}
