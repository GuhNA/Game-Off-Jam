using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{
    KeyCode key;
    public List<items> inventory = new ();
    public int selectedItem;

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            foreach(items i in inventory)
            {
                print(i);
            }
        }
    }

    void ChangeItem()
    {
        if((int)key > 47 && key < KeyCode.Alpha9)
        {
            switch ((int)key)
            {
                case 49:

                break;
            }
        }
    }

    /*void OnTimeStop()
    {
        if(inventory.Contains())
        {
            inventory.
        }
        if(Input.GetKeyDown(KeyCode.Q)) changeSize.timeStop = true;
        if(changeSize.timeStop == true)
        {
            time -= Time.deltaTime;
            if(time <= 0)
            {
                changeSize.timeStop = false;
                time = iniTime;
            }
        }
    }*/

    void OnGUI()
    {
        Event e = Event.current;
        if(e.isKey)
        {
            key = e.keyCode;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        //Se n funcionar erro aq
        if(other.GetComponent<items>())
            if(Input.GetKeyDown(KeyCode.E)) inventory.Add(other.GetComponent<items>());
    }
}
