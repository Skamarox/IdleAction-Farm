using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCultureOnPlane : MonoBehaviour
{
    [SerializeField] private Transform Point;
    [SerializeField] private float SpawnOffset;
    [SerializeField] private CultureScriptObject cultureScriptObject;
    [SerializeField] private int PlaneColumn;
    [SerializeField] private int PlaneRow;
    private Vector3[,] PlanePosition;
    private Marker _Marker;

    private void Start()
    {
        PlanePosition = new Vector3[PlaneRow, PlaneColumn];
        _Marker = FindObjectOfType<Marker>();
        Vector3 spawnPoint = Point.position;
        for (int i = 0; i < PlanePosition.GetLength(0); i++)
        {
            for (int j = 0; j < PlanePosition.GetLength(1); j++)
            {
                PlanePosition[i, j] = new Vector3(spawnPoint.x + i * SpawnOffset, 0f, spawnPoint.z + j * SpawnOffset);
                GameObject culture = Instantiate(cultureScriptObject.Prefab, transform);
                culture.transform.position = PlanePosition[i, j];
                culture.name = "Culture " + i + "_" + j;
                culture.GetComponent<CultureCut>().SetProperty(cultureScriptObject.HitCount, _Marker);
                culture.GetComponent<CultureDead>().SetProperty(cultureScriptObject.RespawnTime);
            }
        }
    }
}
