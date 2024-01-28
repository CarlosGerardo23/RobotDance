using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosesController : MonoBehaviour
{
    [SerializeField] private GameObject _posePrefab;
    [SerializeField] private List<Sprite> _poseList;
    [SerializeField] private float _timeToStart;
    [SerializeField] private float _timeToSpawn;
    [SerializeField] private Transform _poseTransfrom;
    private GameObject _currentPose;
    public bool DoPoses { get; private set; }

    private IEnumerator Start()
    {
        DoPoses=true;
        _currentPose = Instantiate(_posePrefab, _poseTransfrom.position, Quaternion.identity);
        _currentPose.SetActive(false);
        yield return new WaitForSeconds(_timeToStart);

        while (DoPoses)
        {
            CreatePose();
            yield return new WaitForSeconds(_timeToSpawn);
        }
    }

    private void CreatePose()
    {
       _currentPose.GetComponent<SpriteRenderer>().sprite = _poseList[Random.Range(0, _poseList.Count)];
        _currentPose.SetActive(true);
    }
}
