using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _player;
    
    private Animator _animator;

    private float _verticalInput;
    private float _horizontalInput;
    private float _speed = 3f;
    private bool _isMove = true;
    

    private void Start()
    { 
        GameController.Instance.StartGame += () => _isMove = true;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _verticalInput = Input.GetAxis("Vertical") * _speed;
        _horizontalInput = Input.GetAxis("Horizontal") * _speed;

        _animator.SetFloat("Vertical", _verticalInput);
        _animator.SetFloat("Horizontal", _horizontalInput);

    }

    private void FixedUpdate()
    {
        if (_isMove)
        {
            Vector2 dir = Vector2.right * _horizontalInput + Vector2.up * _verticalInput;
            _player.velocity = dir;
            _animator.SetBool("Walk", false);

            if (dir != Vector2.zero)
            {
                _animator.SetBool("Walk", true);
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), 0.5f);
            }
        }
    }
    
    
}
