using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManeMusicManager : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private float _timeTranslition = 1;
    private bool _isPlayning;
    private float _timer;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_isPlayning == true && _audioSource.volume != 0.5)
        {
            _audioSource.volume = Mathf.Lerp(0, 0.2f, _timer / _timeTranslition);
        }

        if (_isPlayning == false && _audioSource.volume != 0)
        {
            _audioSource.volume = Mathf.Lerp(0.2f, 0, _timer / _timeTranslition);
        }
    }
    public void PlayMusic(AudioClip clip)
    {
        print("Play");
        _audioSource.clip = clip;
        _audioSource.Play();
        _isPlayning = true;
        _timer = 0;
    }
    public void StopMusic()
    {
        
        _isPlayning = false;
        _timer = 0;
    }
}
