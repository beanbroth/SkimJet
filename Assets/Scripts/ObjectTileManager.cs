using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectTileManager : MonoBehaviour
{
    [SerializeField] FloorTreadmillController _ftc;
    [SerializeField] ObjectTilePopulator _otp;

    [SerializeField] int tileLoadSize;
    [SerializeField] List<Transform> _tileCenters = new List<Transform>();
    [SerializeField] GameObject _tileCenterMarker;


    void Start()
    {
        GenerateAbstractTileOriginsAndPlaceBuildings(tileLoadSize);
    }
    int mod(int x, int m)
    {
        return (x % m + m) % m;
    }
    public void MoveObjectGridPostiveX()
    {
        List<Transform> backFloorTileRow = GetColumn(mod(_ftc.CenterTileIndex.x - tileLoadSize/2-7, tileLoadSize));
        for (int i = 0; i < tileLoadSize; i++)
        {
            _otp.UnloadObjets(backFloorTileRow[i]);
            backFloorTileRow[i].position = new Vector3((_ftc.CenterTileIndex.x + 2)  * _ftc.FloorLength + _ftc.FloorLength, backFloorTileRow[i].position.y, backFloorTileRow[i].position.z);
            _otp.LoadObjects(backFloorTileRow[i]);
        }
    }

    public void MoveObjectGridNegativeX()
    {
        List<Transform> backFloorTileRow = GetColumn(mod(_ftc.CenterTileIndex.x + tileLoadSize/2 +4, tileLoadSize));
        for (int i = 0; i < tileLoadSize; i++)
        {
            _otp.UnloadObjets(backFloorTileRow[i]);
            backFloorTileRow[i].position = new Vector3((_ftc.CenterTileIndex.x - tileLoadSize / 2) * _ftc.FloorLength - _ftc.FloorLength, backFloorTileRow[i].position.y, backFloorTileRow[i].position.z);
            _otp.LoadObjects(backFloorTileRow[i]);
        }
    }
    public void MoveObjectGridPostiveY()
    {
        List<Transform> backFloorTileRow = GetRow(mod(_ftc.CenterTileIndex.y - tileLoadSize / 2-7, tileLoadSize));
        for (int i = 0; i < tileLoadSize; i++)
        {
            _otp.UnloadObjets(backFloorTileRow[i]);
            backFloorTileRow[i].position = new Vector3(backFloorTileRow[i].position.x, backFloorTileRow[i].position.y, (_ftc.CenterTileIndex.y +2) * _ftc.FloorLength + _ftc.FloorLength);
            _otp.LoadObjects(backFloorTileRow[i]);
        }
    }

    public void MoveObjectGridNegativeY()
    {
        List<Transform> backFloorTileRow = GetRow(mod(_ftc.CenterTileIndex.y + tileLoadSize / 2 + 4, tileLoadSize));
        for (int i = 0; i < tileLoadSize; i++)
        {
            _otp.UnloadObjets(backFloorTileRow[i]);
            backFloorTileRow[i].position = new Vector3(backFloorTileRow[i].position.x, backFloorTileRow[i].position.y, (_ftc.CenterTileIndex.y - tileLoadSize / 2) * _ftc.FloorLength - _ftc.FloorLength);
            _otp.LoadObjects(backFloorTileRow[i]);
        }
    }

    private void GenerateAbstractTileOriginsAndPlaceBuildings(int tileLoadSize)
    {
        GameObject tempAnchor = null;
        for (int i = 0; i < tileLoadSize; i++)
        {
            for (int j = 0; j < tileLoadSize; j++)
            {
                Vector3 spawnPos = new Vector3((i - tileLoadSize / 2) * _ftc.FloorLength, 0, (j - tileLoadSize / 2) * _ftc.FloorLength);
                tempAnchor = Instantiate(_tileCenterMarker, spawnPos, Quaternion.identity, transform);
                tempAnchor.name = "(" + i + ", " + j + ")";
                _tileCenters.Add(tempAnchor.transform);
            }
        }

        for (int i = 0; i < tileLoadSize; i++)
        {
            for (int j = 0; j < tileLoadSize; j++)
            {
                if (!(i == tileLoadSize/2 && j == tileLoadSize / 2)) //skip center
                {
                    _otp.LoadObjects(GetTranformByIndex(i, j));
                }

            }
        }
    }


    private List<Transform> GetRow(int row)
    {
        List<Transform> temp = new List<Transform>();

        for (int i = 0; i < tileLoadSize; i++)
        {
            temp.Add(GetTranformByIndex(i, row));
        }

        return temp;

    }

    private List<Transform> GetColumn(int column)
    {
        List<Transform> temp = new List<Transform>();

        for (int i = 0; i < tileLoadSize; i++)
        {
            temp.Add(GetTranformByIndex(column, i));
        }

        return temp;
    }

    Transform GetTranformByIndex(int x, int y)
    {
        return _tileCenters[x * tileLoadSize + y];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
