using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Drop : RandomItem<GameObject>
{
    public int amount;
}


public class DropController : MonoBehaviour
{
    public float dropAreaRadius;
    public List<Drop> drops = new List<Drop>();

    private PercentRandom<Drop> randomizer = new PercentRandom<Drop>();

    private void Start()
    {
        randomizer.Init(new List<RandomItem<Drop>>());
    }

    public void SpawnDrops()
    {
        Vector3 spawnPos;
        Vector3 randomRot;

        foreach (Drop drop in drops)
        {
            for (int i = 0; i < drop.amount; i++)
            {
                spawnPos = Random.insideUnitSphere * dropAreaRadius + transform.position;

                randomRot = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));

                GameObject instance = Instantiate(drop.item, spawnPos, Quaternion.identity);

                instance.GetComponent<Rigidbody>().AddRelativeTorque(randomRot * 150f);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, dropAreaRadius);
    }
}
