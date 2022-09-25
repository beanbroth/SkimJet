using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacementManager : MonoBehaviour
{
    [SerializeField] FloorTreadmillController _tmc;
    [SerializeField] GameObject _buildingPrefab;

    [SerializeField] float _tileWeight;
    [SerializeField] int _maxDebrisPerTile;

    [SerializeField] float _tileWidth;
    [SerializeField] Vector2Int _centerGridPos;

    [SerializeField] Vector3 _prefabBoundsSize;
    IEnumerator PlaceObjects()
    {
        Debug.Log("in placing loop");
        for (int i = 0; i < (int)(_maxDebrisPerTile * _tileWeight); i++)
        {
            Vector3 centerWorldPos = new Vector3(_centerGridPos.x * _tileWidth, 0, _centerGridPos.y * _tileWidth);

            float randXPos = Random.Range(centerWorldPos.x - _tileWidth / 2, centerWorldPos.x + _tileWidth / 2);
            float randZPos = Random.Range(centerWorldPos.y - _tileWidth / 2, centerWorldPos.y + _tileWidth / 2);
            float randYPos = Random.Range(0, -_prefabBoundsSize.y);

            Vector3 randomPos = new Vector3(randXPos, randYPos, randZPos);

            Debug.Log("placing building");
            Instantiate(_buildingPrefab, randomPos, Quaternion.identity, transform);
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

    void Start()
    {
        
        Debug.Log("Starting to place objecst");
        _tileWidth = _tmc.FloorLength;

        _centerGridPos = new Vector2Int(0, 0); //temporary

        StartCoroutine(PlaceObjects());

    }

    // Update is called once per frame
    void Update()
    {

    }
}
