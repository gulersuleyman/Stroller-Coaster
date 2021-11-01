using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
    [SerializeField] PathCreator _pathCreator;
    public float _speed;

    float _distanceTravelled;
    float _firstSpeed;
    bool _isRunning;


    CharacterAnimations _characterAnim;
    InputController _input;
    private void Awake()
    {
        _characterAnim = GetComponent<CharacterAnimations>();
        _input = new InputController();

        _firstSpeed = 0;
        _isRunning = false;
    }

    void Update()
    {
        if (_input.FirstMouseClick)
        {
            _firstSpeed = 1f;
            _isRunning = true;
        }

        _characterAnim.RunningAnimation(_isRunning);
        _distanceTravelled += _speed * Time.deltaTime * _firstSpeed;
        transform.position = _pathCreator.path.GetPointAtDistance(_distanceTravelled);
        transform.rotation = _pathCreator.path.GetRotationAtDistance(_distanceTravelled);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Decrease"))
        {
            _speed -= 4f;
        }
        if (other.CompareTag("Increase"))
        {
            _speed += 4f;
        }
        
    }
}
