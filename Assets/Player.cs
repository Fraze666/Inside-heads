using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speedWalk = 5;
    [SerializeField] private float _speedRun = 10;
    [SerializeField] private float _mouseSens = 400;
    [SerializeField] private float _jumpHeight = 1;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private float _groundCheckerRadius = 0.5f;

    private float _speed;
    private CharacterController _characterController;
    private Vector2 _moveDir;
    private Vector2 _mouseDir;
    private Vector3 _move;


    private bool _isJump;
    private bool _isGrounded;
    private bool _isRun;

    private const float G = 9.81f;
    private float _rotationCamY;
    private Transform _cameraTransform;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _characterController = GetComponent<CharacterController>();
        _cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        PlayerInput();
        SetGravity();
        OnJump();
        OnRotate();
        OnMove();
    }

    private void PlayerInput()
    {
        _moveDir.x = Input.GetAxisRaw("Horizontal");
        _moveDir.y = Input.GetAxisRaw("Vertical");
        _moveDir.Normalize();

        _mouseDir.x = Input.GetAxis("Mouse X");
        _mouseDir.y = Input.GetAxis("Mouse Y");

        _isJump = Input.GetKeyDown(KeyCode.Space);
        _isRun = Input.GetKey(KeyCode.LeftShift);
    }

    private void SetGravity()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, _groundCheckerRadius, _groundLayer);

        _move.y -= G * Time.deltaTime;

        if(_isGrounded)
        {
            _move.y = -2;
        }
    }

    private void OnJump()
    {
        if(_isJump == true && _isGrounded == true)
        {
            _move.y = Mathf.Sqrt(2 * G * _jumpHeight);
        }
    }

    private void OnRotate()
    {
        _mouseDir *= Time.deltaTime * _mouseSens;
        transform.Rotate(Vector3.up * _mouseDir.x);

        _rotationCamY -= _mouseDir.y;
        _rotationCamY = Mathf.Clamp(_rotationCamY, -50, 35);
        _cameraTransform.localEulerAngles = Vector3.right * _rotationCamY;
    }

    private void OnMove()
    {
        if(_isRun == true)
        {
            _speed = _speedRun;
        }
        else
        {
            _speed = _speedWalk;
        }

        _moveDir *= _speed;

        _move.x = _moveDir.x;
        _move.z = _moveDir.y;

        _move = transform.TransformDirection(_move);

        _characterController.Move(_move * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_groundChecker.position, _groundCheckerRadius);
    }
}
