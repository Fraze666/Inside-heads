using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField, TextArea] private string[] _dialogue;
    [SerializeField] private bool _isClosely;
    [SerializeField] private bool _isStartDialogue;

    [SerializeField] private AudioClip[] _audioClips;
    private AudioSource _audioSource;


    private Player _player;

    private int _currentDialogue;
    void Start()
    {
        _dialoguePanel.SetActive(false);
        _audioSource = GetComponent<AudioSource>();
        _player = FindObjectOfType<Player>();   
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _isClosely = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isClosely = false;
        }
    }

    void Update()
    {
        if (_isClosely == true && Input.GetKeyDown(KeyCode.E) && _isStartDialogue == false)
        {
            _isStartDialogue = true;
            _dialoguePanel.SetActive(true);
            _text.text = _dialogue[0];
            _player.enabled = false;
            _audioSource.PlayOneShot(_audioClips[_currentDialogue]);
        }
        if(Input.GetKeyDown(KeyCode.F) && _isStartDialogue == true)
        {
            _audioSource.Stop();
            if (_dialogue.Length - 1 == _currentDialogue)
            {
                _isStartDialogue = false;
                _dialoguePanel.SetActive(false);
                _currentDialogue = 0;
                _player.enabled = true;
            }
            else
            {
                _currentDialogue++;
                _text.text = _dialogue[_currentDialogue];
                _audioSource.PlayOneShot(_audioClips[_currentDialogue]);
            }
        }
    }
}
