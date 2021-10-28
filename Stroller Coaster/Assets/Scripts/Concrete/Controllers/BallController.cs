using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    float _currentSpeed=0f,_firstSpeed;
    float _waitTime=0f, _waitTimeBoundary=2f;
    bool _ballTouch=false;
   
    GameObject _other;
    Rigidbody _rigidbody;
    MeshRenderer _meshRenderer;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {


        if (_ballTouch)
        {

            _waitTime += Time.deltaTime;

            if (_waitTime > _waitTimeBoundary)
            {
                ResetSpeed();

            }

           
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Player"))
        {
            _ballTouch = true;
            _firstSpeed = other.GetComponent<Follower>()._speed;
            other.GetComponent<Follower>()._speed = _currentSpeed;
            _other = other.gameObject;
            _rigidbody.velocity = Vector3.zero;
            this.gameObject.transform.localScale = Vector3.zero;
          

        }
    }
    private void ResetSpeed()
    {
        _other.GetComponent<Follower>()._speed = _firstSpeed;
        _waitTime = 0f;
        _ballTouch = false;
    }
   


}
