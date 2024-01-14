using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    float timer;
    public List<Image> buttons = new();
    public List<Sprite> images = new();

    public List<GameObject> scenes = new();

    Sprite sub;
    bool active;

    bool activeBut;
    bool activeOpt;

    bool activeCdt;

    private void Start() 
    {
        timer = 0.25f;
    }
    public void OnStart()
    {
        buttons[0].sprite = images[0];
        SceneManager.LoadScene(1);
    }

    public void OnExit()
    {
        buttons[3].sprite = images[3];
        Application.Quit();
    }

    public void OnOption()
    {
        sub = buttons[1].sprite;
        buttons[1].sprite = images[1];
        active = true;
    }

    public void OnCredits()
    {
        sub = buttons[2].sprite;
        buttons[2].sprite = images[2];
        activeBut = true;
    }


    public void OnExitOpt()
    {
        sub = buttons[4].sprite;
        buttons[4].sprite = images[3];
        activeOpt = true;
    }

    public void OnExitCdt()
    {
        sub = buttons[5].sprite;
        buttons[5].sprite = images[3];
        activeCdt = true;
    }

    private void Update() 
    {
        /*if(active)
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                GameObject.Find("Menu").SetActive(false);
                active = false;
                buttons[1].sprite = sub;
                timer = .25f;
            }
        }*/

        transition(ref active, scenes[0], scenes[1], buttons[1]);
        transition(ref activeOpt, scenes[1],scenes[0], buttons[4]);
        transition(ref activeBut, scenes[3], scenes[2], buttons[2]);
        transition(ref activeCdt, scenes[2], scenes[3], buttons[5]);
    }

    void transition(ref bool active, GameObject deactiveObj, GameObject activeObj, Image button)
    {
        if(active)
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                deactiveObj.SetActive(false);
                activeObj.SetActive(true);
                button.sprite = sub;
                timer = .25f;
                active = false;
            }
        }
    }
}
