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
    public float meteorSpeed = 0.35f;
    public float timeBeforeSpawn = 2f;

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
            float size = Random.Range(0.15f, 0.5f);
            instance.transform.localScale = new Vector3(size, size, 0);
            instance.GetComponent<Meteor>().speed = meteorSpeed;
            Destroy(instance, 10f);
            yield return new WaitForSeconds(timeBeforeSpawn);
            canSpawn = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(2, spawnSize));
    }
}
