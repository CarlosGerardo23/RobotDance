using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Poses/Checker")]
public class PosesCheckerSO : ScriptableObject
{
    [SerializeField] private List<PoseData> _poseData;
    private void OnEnable()
    {
        ResetPoses();
    }
    public void ResetPoses()
    {
        for (int i = 0; i < _poseData.Count; i++)
            _poseData[i].resultType = ResultType.BAD;    
    }
    public void SetData(PoseType poseType, ResultType resultType)
    {
        for (int i = 0; i < _poseData.Count; i++)
        {
            if (_poseData[i].poseType == poseType)
                _poseData[i].resultType = resultType;
        }
    }
}

public enum PoseType { RIGHT_ARM, LEFT_ARM, RIGHT_LEG, LEFT_LEG };