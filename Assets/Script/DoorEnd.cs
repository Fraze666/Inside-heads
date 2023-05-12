using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnd : MonoBehaviour
{
    [SerializeField] private bool _isTriggerActivate;
    private bool _open = false;
    // Start is called before the first frame update
    void Start()
    {
        Manager.ActivateTriggerDoorEndKeyEvent.AddListener(Open);
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
