using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 30f;

    [SerializeField] Text countDownText;

    //waves
    public float currentWave = 0f;
    public float startingWave = 5f;

    [SerializeField] Text waveDownText;


    // Start is called before the first frame update
    void Start()
    { 
        currentTime = startingTime;
        StartCoroutine(countDownSlow());

        currentWave = startingWave;
    }

    // Update is called once per frame
    void Update()
    {        
        countDownText.text = currentTime.ToString();
        waveDownText.text = currentWave.ToString();
        if (currentTime == 0)
        {
            currentTime = 30f;
            currentWave--;
        }
        
        if(currentTime < 6)
        {
            countDownText.color = Color.red;
        }
        else
        {
            countDownText.color = Color.white;
        }
        

    }

    IEnumerator countDownSlow()
    {
        while (currentTime > -1)
        {
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        
    }

}
