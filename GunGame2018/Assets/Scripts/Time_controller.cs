using UnityEngine;
using UnityEngine.UI;

public class Time_controller : MonoBehaviour
{

    [SerializeField]
    private float time;

    private float timer;
    private bool canCount = true;
    private bool stop = false;

    private int displayTime;

    void Start()
    {
        timer = time;
    }

    void Update()
    {
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            gameObject.GetComponent<Text>().text = "Time Left: " + timer;
            Debug.Log(timer + "   " + Time.deltaTime);
        }
        else if (timer <= 0.0f && !stop)
        {
            canCount = false;
            GetComponent<Text>().text = "Time Left: " + 0;
            timer = 0.0f;
            stop = true;
        }
    }
}