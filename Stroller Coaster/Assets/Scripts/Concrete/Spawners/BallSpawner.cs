using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    [SerializeField] GameObject _ball;
    [SerializeField] float _ballSpeed;

    
    bool _fire;

    InputController _input;
    private void Awake()
    {
        _input = new InputController();


        _fire = false;
        
    }
    private void Update()
    {
        
        if (_input.MouseUp) _fire = true;
    }
    private void FixedUpdate()
    {
        if(_fire)
        {
            Spawn();
            _fire = false;
        }
    }
    public void Spawn()
    {
        GameObject ball = Instantiate(_ball, transform.position, Quaternion.identity);
        ball.GetComponent<Rigidbody>().velocity = transform.forward * _ballSpeed * Time.deltaTime;
        Destroy(ball.gameObject, 3f);
    }

    
}
