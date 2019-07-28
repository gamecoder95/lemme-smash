using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence2 : MonoBehaviour
{
    [SerializeField]
    private GameObject leftArrow;

    [SerializeField]
    private GameObject downArrow;

    [SerializeField]
    private GameObject upArrow;

    [SerializeField]
    private GameObject rightArrow;

    [SerializeField]
    private GameObject beckyHint;


    private bool beckyHintLargeDelay;
    private float timeToNextSpawn;
    private const int MAX_NUM_ARROWS_AT_ONCE = 3;
    private const int CHANCE_TO_SPAWN_SECOND = 40;


    // Start is called before the first frame update
    void Start()
    {
        timeToNextSpawn = 1f;
        beckyHintLargeDelay = false;

        StartCoroutine(SpawnArrows());
        StartCoroutine(SpawnBeckyHint());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnArrow(GameObject arrow)
    {
        Instantiate(arrow, arrow.transform.position, Quaternion.identity);
    }

    private IEnumerator SpawnArrows()
    {
        // Initial wait
        yield return new WaitForSeconds(timeToNextSpawn);
        while (true)
        {
            List<GameObject> arrows = new List<GameObject>();

            arrows.Add(leftArrow);
            arrows.Add(downArrow);
            arrows.Add(upArrow);
            arrows.Add(rightArrow);

            int chanceToSpawnNext = CHANCE_TO_SPAWN_SECOND; 
            for (int i = 0; i < MAX_NUM_ARROWS_AT_ONCE; ++i)
            {
                if (i > 0)
                {
                    int spawnNextPercent = Random.Range(1, 101);

                    if (spawnNextPercent <= chanceToSpawnNext)
                    {
                        chanceToSpawnNext /= 2;
                    }
                    else
                    {
                        break;
                    }
                }

                int indexToSpawn = Random.Range(0, arrows.Count);
                SpawnArrow(arrows[indexToSpawn]);
                arrows.RemoveAt(indexToSpawn);
            }

            timeToNextSpawn = Random.Range(0.5f, 1.5f);

            yield return new WaitForSeconds(timeToNextSpawn);
        }
    }

    IEnumerator SpawnBeckyHint()
    {
        while (true)
        {
            Instantiate(beckyHint, beckyHint.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(15f * (beckyHintLargeDelay ? 2 : 1));
            beckyHintLargeDelay = !beckyHintLargeDelay;
        }
    }
}
