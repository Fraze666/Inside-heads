using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    [SerializeField] private ManeMusicManager _mainMusicManager;
    [SerializeField] private AudioClip _audioClip;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        if (other.tag == "Player")
        {
            _mainMusicManager.PlayMusic(_audioClip);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _mainMusicManager.StopMusic();
        }
    }
}
