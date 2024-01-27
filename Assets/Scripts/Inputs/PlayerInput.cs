using System;
using UnityEngine;
using UnityEngine.InputSystem;
[CreateAssetMenu(menuName = "PlayerInput")]
public class PlayerInput : ScriptableObject, Inputs.IPlayerActions
{
    #region Delegates
    //Hands
    public event Action<PlayerType, ExtremityType> onSelectExtremityStartedEvent;
    public event Action<PlayerType, ExtremityType> onSelectExtremityEndedEvent;

    public event Action<PlayerType, Vector2> onMoveExtremity;
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
    public void OnPlayerExtremity1(InputAction.CallbackContext context)
    {
        ExtremityType extremityType = context.ReadValue<float>() < 0 ? ExtremityType.HAND : ExtremityType.LEG;
        if (context.phase == InputActionPhase.Performed)
            onSelectExtremityStartedEvent?.Invoke(PlayerType.PLAYER1, extremityType);
        if (context.phase == InputActionPhase.Canceled || context.phase == InputActionPhase.Disabled)
            onSelectExtremityEndedEvent?.Invoke(PlayerType.PLAYER1, extremityType);
    }

    public void OnPlayerExtremity2(InputAction.CallbackContext context)
    {
        ExtremityType extremityType = context.ReadValue<float>() < 0 ? ExtremityType.HAND : ExtremityType.LEG;
        if (context.phase == InputActionPhase.Performed)
            onSelectExtremityStartedEvent?.Invoke(PlayerType.PLAYER2, extremityType);
    }

    public void OnPlayerMap1(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            onMoveExtremity?.Invoke(PlayerType.PLAYER1, context.ReadValue<Vector2>());
    }

    public void OnPlayerMap2(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            onMoveExtremity?.Invoke(PlayerType.PLAYER2, context.ReadValue<Vector2>());
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
}
#endregion
public enum PlayerType { PLAYER1, PLAYER2 }
public enum ExtremityType { HAND, LEG }