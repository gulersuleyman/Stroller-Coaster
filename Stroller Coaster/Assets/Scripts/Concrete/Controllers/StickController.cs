using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickController : MonoBehaviour
{
    [SerializeField] float _rotationSpeed;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _trej;

    
    float _centerPosition, _currentPosition, _lastPosition;
    float _centerPositionY, _currentPositionY, _lastPositionY;
    InputController _input;
    // Start is called before the first frame update
    void Awake()
    {
        _input = new InputController();

        _trej.gameObject.SetActive(false);
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
            _trej.gameObject.SetActive(true);
            _centerPosition = Input.mousePosition.x;
            _centerPositionY = Input.mousePosition.y;
            _lastPosition = transform.eulerAngles.y;
            _lastPositionY = transform.eulerAngles.x;
        }
        if (_input.MouseClick)
        {
            
            _currentPosition = Input.mousePosition.x;
            _currentPositionY = Input.mousePosition.y;

            transform.eulerAngles = new Vector3(((_centerPositionY-_currentPositionY ) * _rotationSpeed/2) + _lastPositionY,
                ((_currentPosition - _centerPosition) * _rotationSpeed) +_lastPosition ,
                transform.eulerAngles.z);
        }
        else
        {
            _trej.gameObject.SetActive(false);
        }
    }
}
