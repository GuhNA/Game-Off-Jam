using UnityEngine;
using UnityEngine.UI;

public class TimerCanvas : MonoBehaviour
{
    int sec;
    int milisec;

    public Text timer;
    Zawarudo zar;
    private void Awake() 
    {
        zar = FindObjectOfType<Zawarudo>();
    }
    void Update()
    {
        sec = (int)zar.time / 1000;

        milisec = (int) zar.time - sec*1000 ;

        if(sec == 5 || milisec == 0) timer.text = string.Format("0{0}:{1}00", sec, milisec);
        else timer.text = string.Format("0{0}:{1}", sec, milisec);
    }
}
