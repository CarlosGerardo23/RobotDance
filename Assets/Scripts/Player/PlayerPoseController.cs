using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPoseController : MonoBehaviour
{
    [SerializeField] private GameObject _spine;
    [SerializeField] private GameObject _rightHandSolver;
    [SerializeField] private GameObject _leftHandSolver;
    [SerializeField] private float _xSpeed = 2f;

    public float PosYSpine => _spine.transform.localPosition.y;
    public float PosXSpine => _spine.transform.localPosition.x;
    public float RightHandPosY => _rightHandSolver.transform.localPosition.y;
    public float LefttHandPosY => _leftHandSolver.transform.localPosition.y;
    private bool IsLeftLegGettingUP => (PosYSpine <= _legsValue1.y) && _legsValue1.y > 2.35f;
    private bool IsRighttLegGettingUP => (PosYSpine <= _legsValue2.y) && _legsValue2.y > 2.35f;
    private bool CanGetUpOneLeg => !((IsLeftLegGettingUP && !IsRighttLegGettingUP && _legsValue2.y != 0) || (IsRighttLegGettingUP && !IsLeftLegGettingUP && _legsValue1.y != 0));
    private bool _canMoveExtremity;
    //Legs
    private bool _returnToCenterLegs;
    private Vector3 _moveSpineDirection;
    private Vector2 _legsValue1;
    private Vector2 _legsValue2;
    //Hands
    private Vector3 _moveHandRightDirection;
    private Vector3 _moveHandLeftDirection;
    private Vector2 _handsValue1;
    private Vector2 _handsValue2;

    // Start is called before the first frame update
    void Start()
    {
        _moveSpineDirection = Vector3.zero;
    }

    private void Update()
    {
        if (_canMoveExtremity)
        {
            if (_returnToCenterLegs)
                GetXDirLegsZero();
            if (_moveSpineDirection.magnitude != 0)
                _spine.transform.localPosition = _moveSpineDirection;
            if (_moveHandRightDirection.y != 0)
                _rightHandSolver.transform.localPosition = _moveHandRightDirection;
            if (_moveHandLeftDirection.y != 0)
                _leftHandSolver.transform.localPosition = _moveHandLeftDirection;

        }
    }

    public void SetDirection(PlayerType player, ExtremityType extremityType, Vector2 value)
    {

        if (player == PlayerType.PLAYER1)
        {
            if (extremityType == ExtremityType.LEG)
                _legsValue1 = value;
            else
                _handsValue1 = value;
        }
        else
        {
            if (extremityType == ExtremityType.LEG)
                _legsValue2 = value;
            else
                _handsValue2 = value;
        }

        SetCurrentDirection();
    }

    private void SetCurrentDirection()
    {

        SetLegs();
        SetHands();
        _canMoveExtremity = _moveSpineDirection.magnitude != 0 || _moveHandRightDirection.x != 0 || _moveHandLeftDirection.x != 0;
    }
    private void SetLegs()
    {
        float yDir = 0;
        float xDir = 0;
        _returnToCenterLegs = false;
        if ((IsLeftLegGettingUP != IsRighttLegGettingUP) && _legsValue1.y != 0 && _legsValue2.y != 0)
            yDir = PosYSpine;
        else if (_legsValue1.y != 0)
            yDir = _legsValue1.y;
        else if (_legsValue2.y != 0)
            yDir = _legsValue2.y;

        Debug.Log($"{_legsValue1.x != 0} {_legsValue2.x != 0}, {!IsLeftLegGettingUP}, {!IsRighttLegGettingUP}, {_legsValue1.x != 0 && _legsValue2.x != 0 && !IsLeftLegGettingUP && !IsRighttLegGettingUP},{CanGetUpOneLeg}");
        if ((IsLeftLegGettingUP != IsRighttLegGettingUP) && _legsValue1.y != 0 && _legsValue2.y != 0)
            xDir = PosXSpine;
        else if ((_legsValue1.x != 0 && _legsValue2.x != 0 && !IsLeftLegGettingUP && !IsRighttLegGettingUP) ||
       (CanGetUpOneLeg && (IsLeftLegGettingUP || IsRighttLegGettingUP)))
            _returnToCenterLegs = true;
        else if (_legsValue1.x != 0)
            xDir = _legsValue1.x;
        else if (_legsValue2.x != 0)
            xDir = _legsValue2.x;
        _moveSpineDirection = new Vector3(xDir, yDir, 0);
    }
    private void SetHands()
    {
        float xDir = 0;
        if (_handsValue1.x != 0)
        {
            xDir = _handsValue1.x;
            _moveHandLeftDirection = new Vector3(_rightHandSolver.transform.localPosition.x, xDir, 0);
        }
        if (_handsValue2.x != 0)
        {
            xDir = _handsValue2.x;
            _moveHandRightDirection = new Vector3(_leftHandSolver.transform.localPosition.x, xDir, 0);
        }
    }

    private void GetXDirLegsZero()
    {
        // Obtener la dirección actual
        int direction = (int)Mathf.Sign(_spine.transform.localPosition.x) * -1;

        // Calcular la nueva posición en el eje X
        float result = _spine.transform.localPosition.x + direction * _xSpeed * Time.deltaTime;

        // Establecer los límites para el clamp
        float min = direction > 0 ? PosXSpine : 0;
        float max = direction > 0 ? 0 : PosXSpine;

        // Realizar el clamp para asegurar que esté dentro de los límites
        result = Mathf.Clamp(result, min, max);

        // Establecer la nueva posición del objeto
        _spine.transform.localPosition = new Vector3(result, _spine.transform.localPosition.y, 0f);

        // Actualizar la dirección de movimiento
        _moveSpineDirection = new Vector3(result, _moveSpineDirection.y, 0f);


    }
}
