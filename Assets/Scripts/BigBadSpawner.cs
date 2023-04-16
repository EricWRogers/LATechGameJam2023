using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PositionAndId
{
    public Vector3 position;
    public int id;
}

public class BigBadSpawner : MonoBehaviour
{
    public float spaceRange = 500.0f;
    public float safeOriginRange = 30.0f;
    public float safeRange = 30.0f;
    private PositionAndId[] paid = new PositionAndId[5000];
    int currentGoodIndex = 0;

    public List<GameObject> prefabs;

    bool IsValidPosition()
    {
        for(int i = 0; i < currentGoodIndex; i++){
            if (Vector3.Distance(paid[currentGoodIndex].position,paid[i].position) < safeRange)
            {
                return false;
            }
        }

        return true;
    }
    void Start()
    {
        int lastIndexPrefab = prefabs.Count - 1;

        while(currentGoodIndex != paid.Length)
        {
            if (paid[currentGoodIndex] == null)
                paid[currentGoodIndex] = new PositionAndId();

            paid[currentGoodIndex].id = Random.Range(0,lastIndexPrefab);
            paid[currentGoodIndex].position.x = Random.Range(-spaceRange,spaceRange);
            paid[currentGoodIndex].position.y = Random.Range(-spaceRange,spaceRange);
            paid[currentGoodIndex].position.z = Random.Range(-spaceRange,spaceRange);

            if (Vector3.Distance(paid[currentGoodIndex].position,Vector3.zero) < safeOriginRange)
            {
                continue;
            }

            if (IsValidPosition())
            {
                currentGoodIndex++;
            }
        }

        for(int i = 0; i < paid.Length; i++)
        {
            GameObject bullet = Instantiate(
                prefabs[paid[i].id],
                paid[i].position,
                Quaternion.identity,
                transform);
            
            bullet.transform.localScale += new Vector3(Random.Range(0.75f, 10.0f),Random.Range(0.75f, 10.0f),Random.Range(0.75f, 10.0f));
            //bullet.transform.Rotate(new Vector3(Random.Range(-30.0f, 30.0f),Random.Range(-30.0f, 30.0f),Random.Range(-30.0f, 30.0f)), Space.World);
        }
    }
}
