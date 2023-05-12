using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    public static UnityEvent ActivateTriggerEndKeyEvent = new UnityEvent();


    [SerializeField] private bool _isTriggerActivate;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && _isTriggerActivate == true)
        {
            ActivateTriggerEndKeyEvent.Invoke();
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
