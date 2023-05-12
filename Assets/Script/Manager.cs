using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Manager : MonoBehaviour
{
    public static UnityEvent ActivateTriggerDoorCrowEvent = new UnityEvent();
    public static UnityEvent ActivateTriggerDoorOrangeKeyEvent = new UnityEvent();
    public static UnityEvent ActivateTriggerDoorKeyEvent = new UnityEvent();
    public static UnityEvent ActivateTriggerDoorEndKeyEvent = new UnityEvent();

    void Start()
    {

        KeyGrey.ActivateTriggerKeyGreyEvent.AddListener(OnDoor);
        CrowBar.ActivateTriggerCrowBarEvent.AddListener(OnDoor2);
        KeyOrange.ActivateTriggerOrangeKeyEvent.AddListener(OnDoor3);
        Key.ActivateTriggerEndKeyEvent.AddListener(OnDoor4);


    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("выход из игры");
            Application.Quit();
        }
        
    }

    private void OnDoor()
    {
        ActivateTriggerDoorCrowEvent.Invoke();
    }
    private void OnDoor2()
    {
        ActivateTriggerDoorOrangeKeyEvent.Invoke();
    }
    private void OnDoor3()
    {
        ActivateTriggerDoorKeyEvent.Invoke();
    }
    private void OnDoor4()
    {
        ActivateTriggerDoorEndKeyEvent.Invoke();
    }

}
