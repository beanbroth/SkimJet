using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTreadmillController : MonoBehaviour
{
    [SerializeField]
    Transform _player;

    [SerializeField]
    Transform[] _floorTiles;

    [SerializeField]
    float _floorLength;
    [SerializeField]
    Transform _centerTile;
    [SerializeField]
    int _centerTileIndex;

    void Start()
    {
        _floorLength = _floorTiles[0].localScale.x;
        _centerTile = _floorTiles[1];
        _centerTileIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.position.x > _centerTile.position.x + _floorLength/2)
        {

            Debug.Log("Moving last tile into first position");
            Transform backFloorTile = _centerTileIndex % 3 == 0 ? _floorTiles[2] : _floorTiles[(_centerTileIndex - 1) % 3];
            backFloorTile.position = new Vector3(_centerTile.position.x + _floorLength * 2, backFloorTile.position.y,backFloorTile.position.z);

            _centerTileIndex = (_centerTileIndex + 1) % 3;
            _centerTile = _floorTiles[_centerTileIndex];
            
        }

        if (_player.position.x < _centerTile.position.x - _floorLength / 2)
        {
            Debug.Log("Moving first tile into last position");
            Transform frontFloorTile = _floorTiles[(_centerTileIndex + 1) % 3];
            frontFloorTile.position = new Vector3(_centerTile.position.x - _floorLength * 2, frontFloorTile.position.y, frontFloorTile.position.z);

            _centerTileIndex = _centerTileIndex % 3 == 0 ? 2 : _centerTileIndex - 1 % 3;
            _centerTile = _floorTiles[_centerTileIndex];




        }


    }
}
