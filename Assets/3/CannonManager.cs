using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonManager : MonoBehaviour
{
    public Transform[] CannonSpawnPoints;
    public GameObject CannonballPrefab;
    public List<GameObject> CannonballList;

    private void Start()
    {
        for (int i = 0; i < CannonSpawnPoints.Length; i++)
        {
            GameObject Cannonball =Instantiate(CannonballPrefab, CannonSpawnPoints[i]);
            CannonballList.Add(Cannonball);
            CannonballList[i].SetActive(false);
        }


        InvokeRepeating("Shoot1", 1f, 1f);

        InvokeRepeating("Shoot2", 2f, 1f);

        InvokeRepeating("Shoot3", 3f, 1f);

    }

    private void Shoot1()
    {
        for (int i = 0; i < 2; i++)
        {
            CannonballList[i].SetActive(true);
        }
    }
    private void Shoot2()
    {
        for (int i = 2; i < 4; i++)
        {
            CannonballList[i].SetActive(true);
        }
    }
    private void Shoot3()
    {
        for (int i = 4; i < 6; i++)
        {
            CannonballList[i].SetActive(true);
        }
    }
}
