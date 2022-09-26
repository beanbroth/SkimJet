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
        //Debug.Log("populating: " + transform.gameObject.name);
        for (int i = 0; i < (int)(_maxDebrisPerTile * _tileWeight); i++)
        {
            float randXPos = Random.Range(-_tileWidth / 2, _tileWidth / 2);
            float randZPos = Random.Range(-_tileWidth / 2, _tileWidth / 2);
            float randYPos = Random.Range(0, -_prefabBoundsSize.y);

            Vector3 randomPos = new Vector3(randXPos, randYPos, randZPos);


            GameObject temp = _opc.GetPooledObject();
            temp.transform.parent = tileCenter;
            temp.transform.localPosition = randomPos;

            temp.SetActive(true);

            yield return null;
        }
    }

    private IEnumerator RemoveObjectsFromTileCo(Transform tileCenter)
    {
        Debug.Log("removing tiles");
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
