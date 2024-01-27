using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoseController : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _rotationSpeed = 4;
    [SerializeField] private GameObject _hand;
    [SerializeField] private GameObject _leg;
    private bool _isMovingHand;
    // Start is called before the first frame update
    void Start()
    {
        _playerInput.EnablePlayerInputs();
    }
    private void OnEnable()
    {
        _playerInput.onHandFowardStartEvent += MoveHand;
        _playerInput.onHandFowardEndedEvent += StopHand;
    }
    private void OnDisable()
    {
        _playerInput.onHandFowardStartEvent -= MoveHand;
        _playerInput.onHandFowardEndedEvent -= StopHand;
    }
    private void Update()
    {
        if (_isMovingHand)
        {
            Vector3 rotation = (new Vector3(0, 0, 1)) * _rotationSpeed * Time.deltaTime;
            _hand.transform.Rotate(rotation, Space.Self);
        }
    }
    private void MoveHand()
    {
        _isMovingHand=true;
    }
    private void StopHand()
    {
        _isMovingHand=false;
    }
}
