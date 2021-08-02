using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnOrb : MonoBehaviour
{

    [SerializeField] public GameObject [] OrbPrefabs;
    public Vector3 center;
    public Vector3 size;


  
    
    void Start()
    {
     //   time = minTime;
        InvokeRepeating("spawnOrb", 3.0f, 3.0f);
    }

    Vector3 GetRandomLocation()
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();

        // Pick the first indice of a random triangle in the nav mesh
        int t = Random.Range(0, navMeshData.indices.Length - 3);

        // Select a random point on it
        Vector3 point = Vector3.Lerp(navMeshData.vertices[navMeshData.indices[t]], navMeshData.vertices[navMeshData.indices[t + 1]], Random.value);
        Vector3.Lerp(point, navMeshData.vertices[navMeshData.indices[t + 2]], Random.value);

        return point;
    }



    public void spawnOrb()
    {
        // time = 0;
        //Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2),2, Random.Range(-size.z / 2, size.z / 2));
        Vector3 pos = GetRandomLocation();
        pos.y += 1.69f; 
        GameObject tmp =Instantiate(OrbPrefabs[Random.Range(0, OrbPrefabs.Length)],pos, Quaternion.identity);
        //Debug.Log(tmp.name);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }

    void SetRandomTime()
    {
       // spawnTime = Random.Range(minTime, maxTime);
    }

}
