using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : MonoBehaviour
{
    [Header("Spawning Position")]

    [SerializeField]
    // Allows for spawning the same generated arrow multiple times in different places
    private Vector3[] spawnPositions;

    [Header("Spawning Objects")]

    [SerializeField]
    private GameObject leftArrow;

    [SerializeField]
    private GameObject downArrow;

    [SerializeField]
    private GameObject upArrow;

    [SerializeField]
    private GameObject rightArrow;

    private List<GameObject> arrows;

    private bool beckyHintLargeDelay;
    private float timeToNextSpawn;

    // Start is called before the first frame update
    void Awake()
    {
        arrows = new List<GameObject>();
        arrows.Add(leftArrow);
        arrows.Add(downArrow);
        arrows.Add(upArrow);
        arrows.Add(rightArrow);

        timeToNextSpawn = 1f;
        beckyHintLargeDelay = false;

        StartCoroutine(SpawnArrows());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnArrows(GameObject arrow)
    {
        foreach (var pos in spawnPositions)
        {
            Instantiate(arrow, pos, Quaternion.identity);
        }
    }

    private IEnumerator SpawnArrows()
    {
        // Initial wait
        yield return new WaitForSeconds(timeToNextSpawn);

        while (true)
        {
            //Debug.Log(arrows);
            //Debug.Log(arrows.Count);
            int indexToSpawn = Random.Range(0, arrows.Count);
            SpawnArrows(arrows[indexToSpawn]);

            timeToNextSpawn = Random.Range(0.5f, 1.5f);

            yield return new WaitForSeconds(timeToNextSpawn);
        }
    }
}
