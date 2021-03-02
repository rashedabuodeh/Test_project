using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawningClouds : MonoBehaviour
{
    public GameObject CloudPrefab, Cloud; //reference for your object
    //GameObject TeleportPrefab;
    public int numofclouds = 5, j = 0; //num of created objects
    public Sprite[] cloudsprite;
    public List<Vector3> Position;
    public Vector3 poss = new Vector3(1818, 997, 0);

    private void Awake()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)

            {
                Vector3 pos = new Vector3(1818 - 960 - (250 * j), 1000 - 540 - (156 * i), 0);
                Position.Add(pos);
            }
        }

        for (int i = 0; i < numofclouds; i++)
        {
            int n = Random.Range(0, Position.Count);
            Cloud = Instantiate(CloudPrefab, transform);
            Cloud.transform.localPosition = Position[n];
            Cloud.GetComponent<Image>().sprite = cloudsprite[Random.Range(0, 7)];

            Position.Remove(Position[n]);

        }
    }
}




