using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickController : MonoBehaviour
{
    [SerializeField] float _rotationSpeed;
    [SerializeField] GameObject _player;
    
    float _centerPosition, _currentPosition, _lastPosition;

    InputController _input;
    // Start is called before the first frame update
    void Awake()
    {
        _input = new InputController();
    }

    // Update is called once per frame
    void Update()
    {
        DragMouse();
        
    }

    private void Drr()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0f, 10f));
            _centerPosition = mousePosition.x;
            _lastPosition = transform.eulerAngles.y;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0f, 10f));
            _currentPosition = mousePosition.x;

            transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                ((_currentPosition - _centerPosition)*_rotationSpeed)+_lastPosition+_player.transform.eulerAngles.y,
                transform.eulerAngles.z);
        }
    }
    
    private void DragMouse()
    {
        if (_input.FirstMouseClick)
        {

            _centerPosition = Input.mousePosition.x;
            _lastPosition = transform.eulerAngles.y;
        }
        if (_input.MouseClick)
        {
            
            _currentPosition = Input.mousePosition.x;

            transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                ((_currentPosition - _centerPosition) * _rotationSpeed) + _lastPosition + _player.transform.eulerAngles.y,
                transform.eulerAngles.z);
        }
    }
}
