using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _gravity = -15;
    private CharacterController _characterController;
    private Vector3 _moveVector;
    private Animator _animator;


    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Move();
    }

    public void OnMove(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();

        _moveVector = new Vector3(inputVec.x, 0, inputVec.y) * _speed;
    }

    private void Move()
    {
        

        if (_moveVector.x != 0 || _moveVector.z != 0)
        {
            if (_characterController.isGrounded == false)
            {
                _moveVector.y += _gravity * Time.deltaTime;
            }

            _characterController.Move(_moveVector * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(_moveVector * Time.deltaTime);
            _animator.SetBool("Move", true);
        }
        else
        {
            _animator.SetBool("Move", false);
        }

       
    }
}
