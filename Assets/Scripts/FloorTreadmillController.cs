using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTreadmillController : MonoBehaviour
{
    [SerializeField]
    Transform _player;

    [SerializeField]
    List<Transform> _column1 = new List<Transform>();
    [SerializeField]
    List<Transform> _column2 = new List<Transform>();
    [SerializeField]
    List<Transform> _column3 = new List<Transform>();



    [SerializeField]
    List<List<Transform>> _floorTiles = new List<List<Transform>>();



    [SerializeField]
    float _floorLength;
    [SerializeField]
    Transform _centerTile;
    [SerializeField]
    Vector2Int _centerTileIndex;

    void Start()
    {
        _floorTiles.Add(_column1);
        _floorTiles.Add(_column2);
        _floorTiles.Add(_column3);


        _floorLength = _floorTiles[0][0].localScale.x;
        _centerTile = _floorTiles[1][1];
        _centerTileIndex.x = 1;
        _centerTileIndex.y = 1;


    }

    //Transform[][] _floorTiles;

    //if(_player.position.x > _centerTile.position.x + _floorLength/2)
    //




    List<Transform> GetRow(int row)
    {
        List<Transform> tempList = new List<Transform>();
        tempList.Add(_column1[row]);
        tempList.Add(_column2[row]);
        tempList.Add(_column3[row]);

        return tempList;
    }
    void Update()
    {
        if (_player.position.x > _centerTile.position.x + _floorLength / 2)
        {

            Debug.Log("Moving last tile into first position");
            List<Transform> backFloorTileRow = _centerTileIndex.x % 3 == 0 ? _floorTiles[2] : _floorTiles[(_centerTileIndex.x - 1) % 3];
            for (int i = 0; i < 3; i++)
            {
                backFloorTileRow[i].position = new Vector3(_centerTile.position.x + _floorLength * 2, backFloorTileRow[i].position.y, backFloorTileRow[i].position.z);
            }

            _centerTileIndex.x = (_centerTileIndex.x + 1) % 3;
            _centerTile = _floorTiles[_centerTileIndex.x][_centerTileIndex.y];
        }

        if (_player.position.x < _centerTile.position.x - _floorLength / 2)
        {
            Debug.Log("Moving first tile into last position");
            List<Transform> frontFloorTileRow = _floorTiles[(_centerTileIndex.x + 1) % 3];
            for (int i = 0; i < 3; i++)
            {
                frontFloorTileRow[i].position = new Vector3(_centerTile.position.x - _floorLength * 2, frontFloorTileRow[i].position.y, frontFloorTileRow[i].position.z);
            }


            _centerTileIndex.x = _centerTileIndex.x % 3 == 0 ? 2 : _centerTileIndex.x - 1 % 3;
            _centerTile = _floorTiles[_centerTileIndex.x][_centerTileIndex.y];
        }

        if (_player.position.z > _centerTile.position.z + _floorLength / 2)
        {
            Debug.Log("Moving last tile into first position");
            List<Transform> backFloorTileRow = _centerTileIndex.y % 3 == 0 ? GetRow(2) : GetRow((_centerTileIndex.y - 1) % 3);
            for (int i = 0; i < 3; i++)
            {
                backFloorTileRow[i].position = new Vector3(backFloorTileRow[i].position.x, backFloorTileRow[i].position.y, _centerTile.position.z + _floorLength * 2);
            }

            _centerTileIndex.y = (_centerTileIndex.y + 1) % 3;
            _centerTile = _floorTiles[_centerTileIndex.x][_centerTileIndex.y];
        }

        if (_player.position.z < _centerTile.position.z - _floorLength / 2)
        {
            Debug.Log("Moving last tile into first position");
            List<Transform> backFloorTileRow = GetRow((_centerTileIndex.y + 1) % 3);
            for (int i = 0; i < 3; i++)
            {
                backFloorTileRow[i].position = new Vector3(backFloorTileRow[i].position.x, backFloorTileRow[i].position.y, _centerTile.position.z - _floorLength * 2);
            }

            _centerTileIndex.y = _centerTileIndex.y % 3 == 0 ? 2 : (_centerTileIndex.y - 1) % 3;
            _centerTile = _floorTiles[_centerTileIndex.x][_centerTileIndex.y];
        }




    }
}
