using System;
using UnityEngine;
using UnityEngine.InputSystem;
[CreateAssetMenu(menuName = "PlayerInput")]
public class PlayerInput : ScriptableObject, Inputs.IPlayerActions
{
    #region Delegates
    public event Action<PlayerType, ExtremityType, float> onMoveExtremityStartEvent;
    public event Action<PlayerType, ExtremityType> onMoveExtremityEndedEvent;
    public event Action<PlayerType, ExtremityType> onSelectExtremityEndedEvent;
    #endregion
    private Inputs _gameInput;
    private void OnEnable()
    {
        if (_gameInput == null)
        {
            _gameInput = new Inputs();
            _gameInput.Player.SetCallbacks(this);
        }
    }
    #region Hands/Legs Interaction
    public void OnLegMovement1(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            onMoveExtremityStartEvent?.Invoke(PlayerType.PLAYER1, ExtremityType.LEG, context.ReadValue<float>());
        if (context.phase == InputActionPhase.Disabled || context.phase == InputActionPhase.Canceled)
            onMoveExtremityEndedEvent?.Invoke(PlayerType.PLAYER1, ExtremityType.LEG);
    }

    public void OnLegMovement2(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            onMoveExtremityStartEvent?.Invoke(PlayerType.PLAYER2, ExtremityType.LEG, context.ReadValue<float>());
        if (context.phase == InputActionPhase.Disabled || context.phase == InputActionPhase.Canceled)
            onMoveExtremityEndedEvent?.Invoke(PlayerType.PLAYER2, ExtremityType.LEG);
    }

    public void OnHandMovement1(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            onMoveExtremityStartEvent?.Invoke(PlayerType.PLAYER1, ExtremityType.HAND, context.ReadValue<float>());
        if (context.phase == InputActionPhase.Disabled || context.phase == InputActionPhase.Canceled)
            onMoveExtremityEndedEvent?.Invoke(PlayerType.PLAYER1, ExtremityType.HAND);
    }

    public void OnHandMovement2(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            onMoveExtremityStartEvent?.Invoke(PlayerType.PLAYER2, ExtremityType.HAND, context.ReadValue<float>());
        if (context.phase == InputActionPhase.Disabled || context.phase == InputActionPhase.Canceled)
            onMoveExtremityEndedEvent?.Invoke(PlayerType.PLAYER2, ExtremityType.HAND);
    }
    #endregion
    #region Enable/Disable Player Inputs
    public void EnablePlayerInputs()
    {
        _gameInput.Enable();
    }
    public void DisableAllInputs()
    {
        _gameInput.Player.Disable();
    }


    #endregion
}
public enum PlayerType { PLAYER1, PLAYER2 }
public enum ExtremityType { HAND, LEG }