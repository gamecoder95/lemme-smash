using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : MonoBehaviour
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
            Debug.Log(arrows);
            Debug.Log(arrows.Count);
            int indexToSpawn = Random.Range(0, arrows.Count);
            SpawnArrow(arrows[indexToSpawn]);

            timeToNextSpawn = Random.Range(0.5f, 1.5f);

            yield return new WaitForSeconds(timeToNextSpawn);
        }
    }

    // TODO: change to better becky stuff
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
