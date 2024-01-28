using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosesController : MonoBehaviour
{
    [SerializeField] private GameObject _posePrefab;
    [SerializeField] private List<Sprite> _poseList;
    [SerializeField] private float _timeToStart;
    [SerializeField] private float _timeToSpawn;
    //[SerializeField] private float _timeToEvaluate=;
    [SerializeField] private Transform _poseTransfrom;
    private GameObject _currentPose;
    public bool DoPoses { get; private set; }
    public float CurrentTime { get; private set; }
    private IEnumerator Start()
    {
        CurrentTime = _timeToSpawn;
        _currentPose = Instantiate(_posePrefab, _poseTransfrom.position, Quaternion.identity);
        _currentPose.SetActive(false);
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
        _currentPose.GetComponent<SpriteRenderer>().sprite = _poseList[Random.Range(0, _poseList.Count)];
        _currentPose.SetActive(true);
    }
}
