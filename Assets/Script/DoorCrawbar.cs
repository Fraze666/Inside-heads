using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DoorCrawbar : MonoBehaviour
{
    [SerializeField] private bool _isTriggerActivate;
    private bool _open = false;
    // Start is called before the first frame update
    void Start()
    {
        Manager.ActivateTriggerDoorOrangeKeyEvent.AddListener(Open);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && _isTriggerActivate == true && _open == true)
        {

            Destroy(gameObject);
        }
    }
    private void Open()
    {
        _open = true;
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
