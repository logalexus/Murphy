using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _player;
    
    private Animator _animator;

    private float _verticalInput;
    private float _horizontalInput;
    private float _speed = 5f;
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
    }

    private void FixedUpdate()
    {
        if (_isMove)
        {
            _animator.SetBool("Walk", false);
            Vector2 dir = Vector2.right * _horizontalInput + Vector2.up * _verticalInput;
            _player.velocity = dir;

            if (dir != Vector2.zero)
            {
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                _animator.SetBool("Walk", true);
                _animator.SetFloat("Angle", angle);
                //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), 0.5f);
            }



        }
    }
    
    
}
