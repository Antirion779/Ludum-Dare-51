using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{

    public int spawnSize;
    public GameObject meteor;
    public bool questActive = false;

    void Start()
    {
        StartCoroutine(SpawnMeteors());
    }

    IEnumerator SpawnMeteors()
    {
        while (true)
        {
            if (!questActive)
            {
                yield return new WaitForSeconds(2f);
                GameObject instance = Instantiate(meteor, new Vector3(transform.position.x, Random.Range(-(spawnSize / 2), spawnSize / 2)), Quaternion.identity);
                float size = Random.Range(1f, 2f);
                instance.transform.localScale = new Vector3(size, size, 0);
                Destroy(instance, 7f);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(2, spawnSize));
    }
}
