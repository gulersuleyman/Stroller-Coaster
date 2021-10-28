using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject _ball,_player;
    [SerializeField] Transform _target;


    float _timeBoundary;
    float _fireTime;

    private void Awake()
    {
        _timeBoundary = 7f;
    }
    private void Update()
    {
        _fireTime += Time.deltaTime;

        if(_fireTime > _timeBoundary  && transform.position.z < _player.transform.position.z)
        {
            GameObject ball= Instantiate(_ball, _target.position, Quaternion.identity);
            ball.GetComponent<Rigidbody>().velocity = Vector3.MoveTowards(_target.position, _player.transform.position, 0.1f);
            _fireTime = 0f;
        }
    }
}
