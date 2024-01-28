using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;


public class UIPoseTimer : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _text;
    private PosesController _poses;
    private void Awake()
    {
        _poses = FindObjectOfType<PosesController>();
    }
    private void Update()
    {
        _text.text = Mathf.CeilToInt(_poses.CurrentTime).ToString();
    }
}
