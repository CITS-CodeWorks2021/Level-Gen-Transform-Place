using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public List<Chunk> platforms = new List<Chunk>();
    private List<Chunk> fullLevel = new List<Chunk>();
    public Chunk Marker;
    private Chunk lastSpawn;
    public int runway = 3;
    public int length = 10;
    // Start is called before the first frame update
    void Start()
    {
        //starting platform
        lastSpawn = Instantiate(platforms[0], Vector3.zero, Quaternion.identity);
        fullLevel.Add(lastSpawn);
        //

        levelGen(length, runway);

    }

    public void levelGen ( int l, int r )
    {
        //runway
        for (int i = 0; i < r; i++)
        {
            Vector2 imaginarypos = fullLevel[fullLevel.Count - 1].transform.TransformPoint(fullLevel[fullLevel.Count - 1].end.transform.localPosition);
            lastSpawn = Instantiate(platforms[0], imaginarypos, Quaternion.identity);
            lastSpawn.transform.position += lastSpawn.transform.position - lastSpawn.transform.TransformPoint(lastSpawn.start.transform.localPosition);
            fullLevel.Add(lastSpawn);
        }
        //length
        for (int i = 0; i < l; i++)
        {
            int rnd = Random.Range(0, platforms.Count);

            Vector2 imaginarypos = fullLevel[fullLevel.Count - 1].transform.TransformPoint(fullLevel[fullLevel.Count - 1].end.transform.localPosition);
            lastSpawn = Instantiate(platforms[rnd], imaginarypos, Quaternion.identity);
            lastSpawn.transform.position += lastSpawn.transform.position - lastSpawn.transform.TransformPoint(lastSpawn.start.transform.localPosition);
            fullLevel.Add(lastSpawn);
        }
        //runway
        for (int i = 0; i < r; i++)
        {
            Vector2 imaginarypos = fullLevel[fullLevel.Count - 1].transform.TransformPoint(fullLevel[fullLevel.Count - 1].end.transform.localPosition);
            lastSpawn = Instantiate(platforms[0], imaginarypos, Quaternion.identity);
            lastSpawn.transform.position += lastSpawn.transform.position - lastSpawn.transform.TransformPoint(lastSpawn.start.transform.localPosition);
            fullLevel.Add(lastSpawn);
        }
        //Final Chunk
        Vector2 pos = fullLevel[fullLevel.Count - 1].transform.TransformPoint(fullLevel[fullLevel.Count - 1].end.transform.localPosition);
        lastSpawn = Instantiate(Marker, pos, Quaternion.identity);
        lastSpawn.transform.position += lastSpawn.transform.position - lastSpawn.transform.TransformPoint(lastSpawn.start.transform.localPosition);
        fullLevel.Add(lastSpawn);
    }
}
