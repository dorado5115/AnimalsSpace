using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 32f;

    [SerializeField] Text countDownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        StartCoroutine(countDownSlow());
    }

    // Update is called once per frame
    void Update()
    {
        
        countDownText.text = "T I M E   T O   N E X T   W A V E: " + currentTime.ToString();
        if(currentTime == 0)
        {
            currentTime = 30f;
        }

    }

    IEnumerator countDownSlow()
    {
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
    }
}
