using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyGrey : MonoBehaviour
{
    public static UnityEvent ActivateTriggerKeyGreyEvent = new UnityEvent();
    

    private bool _isTriggerActivate;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && _isTriggerActivate == true)
        {
            print("test");
            ActivateTriggerKeyGreyEvent.Invoke();
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _isTriggerActivate = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isTriggerActivate = false;
        }
    }

}
