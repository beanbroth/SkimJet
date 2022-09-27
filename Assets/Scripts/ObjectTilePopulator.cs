using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTilePopulator : MonoBehaviour
{
    [SerializeField] FloorTreadmillController _tmc;
    [SerializeField] ObjectPoolController _opc;

    [SerializeField] GameObject _buildingPrefab;

    [SerializeField] float _tileWeight;
    [SerializeField] int _maxDebrisPerTile;

    [SerializeField] float _tileWidth;
    [SerializeField] Vector2Int _centerGridPos;

    [SerializeField] Vector3 _prefabBoundsSize;

    [SerializeField] Vector3 _minScaleMult;
    [SerializeField] Vector3 _maxScaleMult;
    [SerializeField] Vector3 _maxRotDegrees;


    [SerializeField] AnimationCurve _rotDegreesCurve;

    [SerializeField] private float _noiseScale;

    [SerializeField] AnimationCurve _tileWeightCurve;

    public void LoadObjects(Transform tileCenter)
    {
        StartCoroutine(PlaceObjectsOnTileCo(tileCenter));
    }

    public void UnloadObjets(Transform tileCenter)
    {
        StartCoroutine(RemoveObjectsFromTileCo(tileCenter));
    }

    private IEnumerator PlaceObjectsOnTileCo(Transform tileCenter)
    {
        _tileWeight = _tileWeightCurve.Evaluate(Mathf.PerlinNoise((float)tileCenter.position.x / _tileWidth * Mathf.PI * _noiseScale, (float)tileCenter.position.z / _tileWidth * Mathf.PI * _noiseScale));
        Debug.Log(tileCenter.position.x / 300f + ", " + tileCenter.position.z / 300f + "||| Tile Weight: " + _tileWeight);
        //Debug.Log("populating: " + transform.gameObject.name);
        for (int i = 0; i < (int)(_maxDebrisPerTile * _tileWeight); i++)
        {

            float randXScale = Random.Range(_minScaleMult.x, _maxScaleMult.x) * Mathf.Sign(Random.Range(-1, 1));
            float randYScale = Random.Range(_minScaleMult.y, _maxScaleMult.y) * Mathf.Sign(Random.Range(-1, 1));
            float randZScale = Random.Range(_minScaleMult.z, _maxScaleMult.z) * Mathf.Sign(Random.Range(-1, 1));

            Vector3 randomScale = new Vector3(randXScale, randYScale, randZScale);

            float randXPos = Random.Range(-_tileWidth / 2, _tileWidth / 2);
            float randZPos = Random.Range(-_tileWidth / 2, _tileWidth / 2);
            float randYPos = Random.Range(0, -_prefabBoundsSize.y * randYScale);

            Vector3 randomPos = new Vector3(randXPos, randYPos, randZPos);

            float randXRot = _rotDegreesCurve.Evaluate(Random.Range(-1f, 1f)) * _maxRotDegrees.x;
            float randYRot = _rotDegreesCurve.Evaluate(Random.Range(-1f, 1f)) * _maxRotDegrees.y;
            float randZRot = _rotDegreesCurve.Evaluate(Random.Range(-1f, 1f)) * _maxRotDegrees.z;

            Vector3 randomRot = new Vector3(randXRot, randYRot, randZRot);

            GameObject temp = _opc.GetPooledObject();
            temp.transform.parent = tileCenter;
            temp.transform.localPosition = randomPos;
            temp.transform.localScale = randomScale;
            temp.transform.localRotation = Quaternion.Euler(randomRot);

            temp.SetActive(true);

            yield return null;
        }
    }

    private IEnumerator RemoveObjectsFromTileCo(Transform tileCenter)
    {
        for (int i = 0; i < tileCenter.childCount; i++)
        {
            GameObject go = tileCenter.GetChild(i).gameObject;
            go.transform.parent = null;
            go.SetActive(false);
            yield return null;
        }
    }

    void Start()
    {

        _tileWidth = _tmc.FloorLength;


        //StartCoroutine(PlaceObjectsOnTile(transform));

    }

    // Update is called once per frame
    void Update()
    {

    }
}
