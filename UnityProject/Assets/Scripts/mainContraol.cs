using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public Image InvalidImage;
    public Image EndImage;
    public Text EndText;

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
        InvalidImage.gameObject.SetActive(false);
        EndImage.gameObject.SetActive(false);
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

        else if(currentThrow == n)
        {
            //construct the message
            double p = (double)collisionNumber / (double)n;
            double pi = 2 * (double)l / ((float)a * p);
            string EndMessage = "抛掷结束，一共抛掷了" + n.ToString() + "次！\n" + "根据抛掷结果估计的圆周率值为\n" + pi.ToString();
            EndText.text = EndMessage;
            EndImage.gameObject.SetActive(true);
            currentThrow++;
        }
    }

    //some function that is used to control buttons behaviour
    public void MainPanelDisable()
    {
        //control the apprear and disappear of two panels in game
        MainCanvas.gameObject.SetActive(false);
        InputCanvas.gameObject.SetActive(true);
    }
    public void InputPanelDisable()
    {
        GetValue();
        //check whether valid
        if (l > a || a == 0 || l == 0)
        {
            InvalidImage.gameObject.SetActive(true);
        }

        else
        {
            //disable the input panel and start game
            InputCanvas.gameObject.SetActive(false);

            //enable the panel that shows process and results;
            PlayCanvas.gameObject.SetActive(true);
            EndImage.gameObject.SetActive(false);
            gameStart = true;
        }
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("ThrowNeedle");
    }
    
    public void QuitGame()
    {
        Application.Quit();
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
