using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Legs Values")]
    [SerializeField] private float _xMaxValueLegs = 1.5f;
    [SerializeField] private float _xMinValueLegs = -1.5f;
    [SerializeField] private float _xDirectionLegs = 1;
    [SerializeField] private float _yMaxValueLegs = 3f;
    [SerializeField] private float _yMinValueLegs = 2.35f;
    [Header("Hands Values")]
    [SerializeField] private float _xMaxValueHands = 1.5f;
    [SerializeField] private float _xMinValueHands = -1.5f;
    [Header("Speeds")]
    [SerializeField] private float _xSpeed = 2f;
    [SerializeField] private float _ySpeed = 2f;
    [Header("Global Variables")]
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerType _currentPlayerType;
    private bool _checkMovement;
    private PlayerPoseController _poseController;
    //Legs
    private float _legsDirection;
    private Vector2 _newLegsValue;
    //Hands
    private float _handsDirection;
    private Vector2 _newHandValue;

    private void Awake()
    {
        _poseController = FindObjectOfType<PlayerPoseController>();
    }
    void Start()
    {
        _playerInput.EnablePlayerInputs();

    }
    private void OnEnable()
    {
        _playerInput.onMoveExtremityStartEvent += MoveExtremityStart;
        _playerInput.onMoveExtremityEndedEvent += MoveExtremityEnded;
    }
    private void OnDisable()
    {
        _playerInput.onMoveExtremityStartEvent -= MoveExtremityStart;
        _playerInput.onMoveExtremityEndedEvent -= MoveExtremityEnded;
    }
    private void Update()
    {
        if (_checkMovement)
        {
            if (_legsDirection != 0)
            {
                SetDirectionLegs();
                _poseController.SetDirection(_currentPlayerType, ExtremityType.LEG, _newLegsValue);
            }
            if (_handsDirection != 0)
            {
                SetHandDirection();

                _poseController.SetDirection(_currentPlayerType, ExtremityType.HAND, _newHandValue);
            }

        }
    }
    private void MoveExtremityStart(PlayerType playerType, ExtremityType exremityType, float direction)
    {
        if (_currentPlayerType != playerType) return;
        _checkMovement = true;
        if (exremityType == ExtremityType.LEG)
        {
            _legsDirection = direction < 0 ? -1 : 1;
            SetDirectionLegs();
            _poseController.SetDirection(playerType, ExtremityType.LEG, _newLegsValue);
        }
        else if (exremityType == ExtremityType.HAND)
        {
            _handsDirection = direction < 0 ? -1 : 1;
            SetHandDirection();
            _poseController.SetDirection(playerType, ExtremityType.HAND, _newHandValue);
        }

    }

    private void SetHandDirection()
    {
        float currentPosY = _currentPlayerType == PlayerType.PLAYER1 ? _poseController.LefttHandPosY : _poseController.RightHandPosY;
        float newHandValueX = currentPosY + _handsDirection * _xSpeed * Time.deltaTime;
        newHandValueX = Mathf.Clamp(newHandValueX, _xMinValueHands, _xMaxValueHands);
        _newHandValue = new Vector2(newHandValueX, 0);
    }

    private void MoveExtremityEnded(PlayerType playerType, ExtremityType exremityType)
    {
        if (_currentPlayerType != playerType) return;
        _checkMovement = false;
        _legsDirection = 0;
        _handsDirection = 0;
        _poseController.SetDirection(playerType, ExtremityType.LEG, Vector2.zero);
        _poseController.SetDirection(playerType, ExtremityType.HAND, Vector2.zero);
    }
    private void SetDirectionLegs()
    {
        float newLegValueY = _poseController.PosYSpine + _legsDirection * _ySpeed * Time.deltaTime;
        float newLegValueX = _poseController.PosXSpine + _xDirectionLegs * _xSpeed * Time.deltaTime;
        newLegValueY = Mathf.Clamp(newLegValueY, _yMinValueLegs, _yMaxValueLegs);
        newLegValueX = Mathf.Clamp(newLegValueX, _xMinValueLegs, _xMaxValueLegs);
        _newLegsValue = new Vector2(newLegValueX, newLegValueY);
//        Debug.Log($"Return to diurection is {_legsDirection},{-_xMaxValueLegs},{_xMaxValueLegs},{newLegValueX}");
    }
}
