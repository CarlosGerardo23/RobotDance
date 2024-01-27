using System;
using UnityEngine;
using UnityEngine.InputSystem;
[CreateAssetMenu(menuName = "PlayerInput")]
public class PlayerInput : ScriptableObject, Inputs.IPlayerActions
{
    #region Delegates
    //Hands
    public event Action onHandFowardStartEvent;
    public event Action onHandFowardEndedEvent;
    public event Action onHandUPEvent;
    public event Action onLegFowardEvent;
    public event Action onLegUPEvent;
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
    public void OnHandFoward(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            Debug.Log("Started");
            onHandFowardStartEvent?.Invoke();
        }
         if (context.phase == InputActionPhase.Canceled||context.phase== InputActionPhase.Disabled)
        {
            Debug.Log("Ended");
            onHandFowardEndedEvent?.Invoke();
        }
    }

    public void OnHandUP(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnLegFoward(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnLegUP(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
    #endregion
    public void EnablePlayerInputs()
    {
        _gameInput.Enable();
    }
    public void DisableAllInputs()
    {
        _gameInput.Player.Disable();
    }
}
