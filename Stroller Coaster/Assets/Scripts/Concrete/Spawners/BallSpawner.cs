using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    [SerializeField] GameObject _ball;
    [SerializeField] float _ballSpeed;

    float _curretnSpawnTime;
    float _timeBoundary;



    private void Start()
    {
        ResetTimes();
    }
    private void Update()
    {
        _curretnSpawnTime += Time.deltaTime;
        if (_curretnSpawnTime > _timeBoundary)
        {
            Spawn();
            ResetTimes();
        }
    }
    public void Spawn()
    {
        GameObject ball = Instantiate(_ball, transform.position, Quaternion.identity);
        ball.GetComponent<Rigidbody>().velocity = transform.forward * _ballSpeed * Time.deltaTime;
        Destroy(ball.gameObject, 3f);
    }

    private void ResetTimes()
    {
        _curretnSpawnTime = 0f;
        _timeBoundary = 0.3f;
    }
}
