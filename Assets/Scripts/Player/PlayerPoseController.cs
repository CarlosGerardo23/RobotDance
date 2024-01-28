using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPoseController : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerType _playerType;
    [SerializeField] private float _rotationSpeed = 4;
    [SerializeField] private GameObject _hand;
    [SerializeField] private GameObject _hand2;
    [SerializeField] private GameObject _leg;
    [SerializeField] private GameObject _leg2;
    private ExtremityType _currentExtremityType;
    private bool _isMovingHand;
    private bool _isMovingLeg;
    private int _movingDirection;
    private GameObject _currentExtremity;
    // Start is called before the first frame update
    void Start()
    {
        _playerInput.EnablePlayerInputs();
    }
    private void OnEnable()
    {
        _playerInput.onSelectExtremityStartedEvent += SelectExtremity;
        _playerInput.onSelectExtremityEndedEvent += DeselectExtremity;
        _playerInput.onMoveExtremity += SetExtremityToMove;
    }

    private void OnDisable()
    {
        _playerInput.onSelectExtremityStartedEvent -= SelectExtremity;
        _playerInput.onSelectExtremityEndedEvent -= DeselectExtremity;
        _playerInput.onMoveExtremity -= SetExtremityToMove;

    }
    private void Update()
    {
        Debug.Log($"My player is {_playerType}, movinf hand? {_isMovingHand}, moving leg {_isMovingLeg}, direction {_movingDirection}");
        if(_currentExtremity!=null)
        Debug.Log($"Current extremity {_currentExtremity.name}");
        if (_movingDirection != 0 && (_isMovingHand || _isMovingLeg))
        {
            Vector3 rotation = (new Vector3(0, 0, 1)) * _movingDirection * _rotationSpeed * Time.deltaTime;
            _currentExtremity.transform.Rotate(rotation, Space.Self);
        }

    }
    private void SelectExtremity(PlayerType playerType, ExtremityType extremityType)
    {
        if (playerType != _playerType) return;
        if (extremityType == ExtremityType.HAND) { _isMovingHand = true; _isMovingLeg = false; }
        if (extremityType == ExtremityType.LEG) { _isMovingHand = false; _isMovingLeg = true; }
        _movingDirection = 0;
    }
    private void DeselectExtremity(PlayerType playerType, ExtremityType extremityType)
    {
        if (playerType != _playerType) return;
        if (extremityType == ExtremityType.HAND) { _isMovingHand = false; }
        if (extremityType == ExtremityType.LEG) { _isMovingLeg = false; }
        _movingDirection = 0;
    }
    private void SetExtremityToMove(PlayerType playerType, Vector2 pivotToMove)
    {
        if (playerType != _playerType) return;

        SetExtremity(pivotToMove);
    }
    //TO DO: refactor
    private void SetExtremity(Vector2 pivotToMove)
    {
        if (_currentExtremityType == ExtremityType.HAND)
        {
            if (pivotToMove.x != 0)
            {
                _currentExtremity = _hand;
                if (pivotToMove.x < 0)
                    _movingDirection = -1;
                else
                    _movingDirection = 1;
            }
            else if (pivotToMove.y != 0)
            {
                _currentExtremity = _hand2;
                if (pivotToMove.y < 0)
                    _currentExtremity = _leg;
                else
                    _currentExtremity = _leg2;
            }

        }
        else
        {
            if (pivotToMove.x != 0)
            {
                _currentExtremity = _leg;
                if (pivotToMove.x < 0)
                    _movingDirection = -1;
                else
                    _movingDirection = 1;
            }
            else if (pivotToMove.y != 0)
            {
                _currentExtremity = _leg2;
                if (pivotToMove.y < 0)
                    _currentExtremity = _leg;
                else
                    _currentExtremity = _leg2;
            }
        }

    }
}
