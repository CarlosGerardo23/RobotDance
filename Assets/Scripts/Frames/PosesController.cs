using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosesController : MonoBehaviour
{
    [SerializeField] private GameObject _posePrefab;
    [SerializeField] private List<GameObject> _poseList;
    [SerializeField] private float _timeToStart;
    [SerializeField] private float _timeToSpawn;
    //[SerializeField] private float _timeToEvaluate=;
    [SerializeField] private Transform _poseTransfrom;
    private GameObject _currentPose;
    public bool DoPoses { get; private set; }
    public float CurrentTime { get; private set; }

    [SerializeField] ScoreManager scoreManager;

    [Header("Bones Scripts")]
    private BonesInformation currentBone;
    [SerializeField]BonesInformation playerBones;

    private IEnumerator Start()
    {
        CurrentTime = _timeToSpawn;
        yield return new WaitForSeconds(_timeToStart);
        DoPoses = true;
        CreatePose();
        while (DoPoses)
        {
            CurrentTime -= Time.deltaTime;
            if (!( Mathf.CeilToInt(CurrentTime) < 0))
                yield return null;
            else
            {
                CurrentTime = _timeToSpawn;
                CreatePose();
            }
        }
    }

    private void CreatePose()
    {
        if(_currentPose != null)
        {
            Destroy(_currentPose);
        }
        _currentPose = Instantiate(_poseList[Random.Range(0, _poseList.Count)], _poseTransfrom.position, Quaternion.identity);
       // currentBone = _currentPose.GetComponent<BonesInformation>();
    }
}
