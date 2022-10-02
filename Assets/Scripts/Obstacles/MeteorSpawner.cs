using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public static MeteorSpawner Instance;
    public int spawnSize;
    public GameObject meteor;
    public bool questActive = false;
    public bool canSpawn = true;

    public List<GameObject> meteorsList;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Update()
    {
        if (canSpawn)
            StartCoroutine(SpawnMeteors());
        
    }

    IEnumerator SpawnMeteors()
    {
        if (!questActive)
        {          
            canSpawn = false;
            GameObject instance = Instantiate(meteor, new Vector3(transform.position.x, Random.Range(-(spawnSize / 2), spawnSize / 2)), Quaternion.identity);
            meteorsList.Add(instance);
            float size = Random.Range(1f, 2f);
            instance.transform.localScale = new Vector3(size, size, 0);
            Destroy(instance, 5f);
            yield return new WaitForSeconds(2f);
            canSpawn = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(2, spawnSize));
    }
}
