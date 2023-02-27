using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TimerText : MonoBehaviour
{
    float currentTime;
    public float startingTime = 10f;

    [SerializeField] Text countdownText;
    void Start()
    {
        currentTime = startingTime;
    }
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);   
        }
    }
}
