using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GremlinManagerScript : MonoBehaviour
{
    
    public float RER = 2.0f; //Random Encounter Rate
    public float elapsedTime;
    public float totalTime;
    //RER varies based on number of gremlins spawned
    //every time we add a gremlin, check if we have reached max, if so start climax
    public GameObject GremlinPrefab;
    public ParticleSystem NoteEmitterPrefab;
    public GameObject[] Spawnpoints;
    public List<int> freeSpawns = new List<int>();
    public ScoreManager scoremng;
    public bool hardmode = false;

    private List<ParticleSystem> emitters = new List<ParticleSystem>();

    void Start()
    {
        // get number of spawnpoints
        for(int x = 0; x<Spawnpoints.Length; x++)
        {
            freeSpawns.Add(x);
            emitters.Add(Instantiate(NoteEmitterPrefab));
            emitters[x].transform.position = Spawnpoints[x].transform.position;
            emitters[x].Stop();
            Spawnpoints[x].transform.Find("SpotLight").gameObject.SetActive(false);
        }
        elapsedTime = 0;
        totalTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //increment timer, if timer==RER
        elapsedTime += Time.deltaTime;
        totalTime += Time.deltaTime;
        if (elapsedTime >= RER)
        {
            // Spawn Gremlin
            Spawn();
            // reset timer
            elapsedTime = 0;
        }
        if(totalTime >= 30f && totalTime <= 31f && !hardmode)
        {
            RER--;
            hardmode = true;
        }

    }

    void IncrementRER()
    {
        if (freeSpawns.Count == Spawnpoints.Length-1)
        {
            RER += 0.2f;
        }
        RER += 0.2f;
        elapsedTime = 0;
    }

    void DecrementRER()
    {
        if (freeSpawns.Count == Spawnpoints.Length)
        {
            RER -= 0.2f;
        }
        RER -= 0.25f;
        if(RER<0.5)
        {
            RER = .5f;
        }
        elapsedTime = 0;
    }

    void Spawn()
    {
        // If no spawns left, no more spawn
        if (freeSpawns.Count == 0)
        {
            return;
        }

        // Get random location of spawnpoint to place gremlin
        Random.InitState(System.DateTime.Now.Millisecond);
        int loc = Random.Range(0, freeSpawns.Count); // Random Range is exclusive for ints
        int loc2 = Random.Range(0, Spawnpoints[freeSpawns[loc]].transform.childCount - 1); // - 1 because last element is spot light
        string ret = "Spawn Loc: " + loc.ToString();
        ret += "\nSpawn Point point: "+ loc2.ToString();
        Debug.Log(ret);


        Transform selectedZone = Spawnpoints[freeSpawns[loc]].transform.GetChild(loc2);

        GameObject babyGremlin = Instantiate(GremlinPrefab, selectedZone.position, selectedZone.rotation); // Create gremlin instance and place it
        emitters[loc].transform.position = selectedZone.position;
        emitters[loc].Play();

        Spawnpoints[freeSpawns[loc]].transform.Find("SpotLight").gameObject.SetActive(true);
        
        babyGremlin.GetComponent<GremlinScript>().setSpawnNum(freeSpawns[loc]);
        freeSpawns.RemoveAt(loc);


        IncrementRER(); // update encoutner rate of gremlin
    }
        

    // Remove gremlin once git with the swatter
    public void RemoveGobby(int num)
    {
        freeSpawns.Add(num);
        emitters[num].Stop();
        Spawnpoints[num].transform.Find("SpotLight").gameObject.SetActive(false);
        DecrementRER();
        scoremng.IncrementScore();
    }
}
