using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : MonoBehaviour
{
    public GameObject leftArrow, downArrow, upArrow, rightArrow, beckyHint;

    private bool beckyHintLargeDelay;

    float nextSpawn = 1f;

    int whatToSpawn;
    int whatToSpawn2;
    int whatToSpawn3;

    int spawnSecond;
    int spawnThird;

    private void Start()
    {
        beckyHintLargeDelay = false;
        StartCoroutine(SpawnBeckyHint());
    }

    private void Update()
    {
        if (Time.time > nextSpawn)
        {
            whatToSpawn = Random.Range(1, 5);
            //Debug.Log("whatToSpawn: " + whatToSpawn);

            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(leftArrow, leftArrow.transform.position, Quaternion.identity);

                    spawnSecond = Random.Range(1, 101);

                    if (spawnSecond < 41)
                    {

                        whatToSpawn2 = Random.Range(1, 4);


                        switch (whatToSpawn2)
                        {

                            case 1:
                                Instantiate(downArrow, downArrow.transform.position, Quaternion.identity);

                                spawnThird = Random.Range(1, 101);

                                if (spawnThird < 21)
                                {
                                    whatToSpawn3 = Random.Range(1, 3);

                                    switch (whatToSpawn3)
                                    {

                                        case 1:
                                            Instantiate(upArrow, upArrow.transform.position, Quaternion.identity);
                                            break;
                                        case 2:
                                            Instantiate(rightArrow, rightArrow.transform.position, Quaternion.identity);
                                            break;
                                    }
                                }


                                        break;
                            case 2:
                                Instantiate(upArrow, upArrow.transform.position, Quaternion.identity);

                                spawnThird = Random.Range(1, 101);

                                if (spawnThird < 21)
                                {
                                    whatToSpawn3 = Random.Range(1, 3);

                                    switch (whatToSpawn3)
                                    {

                                        case 1:
                                            Instantiate(downArrow, downArrow.transform.position, Quaternion.identity);
                                            break;
                                        case 2:
                                            Instantiate(rightArrow, rightArrow.transform.position, Quaternion.identity);
                                            break;
                                    }
                                }

                                break;
                            case 3:
                                Instantiate(rightArrow, rightArrow.transform.position, Quaternion.identity);

                                spawnThird = Random.Range(1, 101);

                                if (spawnThird < 21)
                                {
                                    whatToSpawn3 = Random.Range(1, 3);

                                    switch (whatToSpawn3)
                                    {

                                        case 1:
                                            Instantiate(upArrow, upArrow.transform.position, Quaternion.identity);
                                            break;
                                        case 2:
                                            Instantiate(downArrow, downArrow.transform.position, Quaternion.identity);
                                            break;
                                    }
                                }

                                break;
                        }
                    }

                    break;
                case 2:
                    Instantiate(downArrow, downArrow.transform.position, Quaternion.identity);

                    spawnSecond = Random.Range(1, 101);

                    if (spawnSecond < 41)
                    {

                        whatToSpawn2 = Random.Range(1, 4);


                        switch (whatToSpawn2)
                        {

                            case 1:
                                Instantiate(leftArrow, leftArrow.transform.position, Quaternion.identity);

                                spawnThird = Random.Range(1, 101);

                                if (spawnThird < 21)
                                {
                                    whatToSpawn3 = Random.Range(1, 3);

                                    switch (whatToSpawn3)
                                    {

                                        case 1:
                                            Instantiate(upArrow, upArrow.transform.position, Quaternion.identity);
                                            break;
                                        case 2:
                                            Instantiate(rightArrow, rightArrow.transform.position, Quaternion.identity);
                                            break;
                                    }
                                }

                                break;
                            case 2:
                                Instantiate(upArrow, upArrow.transform.position, Quaternion.identity);

                                spawnThird = Random.Range(1, 101);

                                if (spawnThird < 21)
                                {
                                    whatToSpawn3 = Random.Range(1, 3);

                                    switch (whatToSpawn3)
                                    {

                                        case 1:
                                            Instantiate(leftArrow, leftArrow.transform.position, Quaternion.identity);
                                            break;
                                        case 2:
                                            Instantiate(rightArrow, rightArrow.transform.position, Quaternion.identity);
                                            break;
                                    }
                                }

                                break;
                            case 3:
                                Instantiate(rightArrow, rightArrow.transform.position, Quaternion.identity);

                                spawnThird = Random.Range(1, 101);

                                if (spawnThird < 21)
                                {
                                    whatToSpawn3 = Random.Range(1, 3);

                                    switch (whatToSpawn3)
                                    {

                                        case 1:
                                            Instantiate(upArrow, upArrow.transform.position, Quaternion.identity);
                                            break;
                                        case 2:
                                            Instantiate(leftArrow, leftArrow.transform.position, Quaternion.identity);
                                            break;
                                    }
                                }

                                break;
                        }
                    }

                    break;
                case 3:
                    Instantiate(upArrow, upArrow.transform.position, Quaternion.identity);

                    spawnSecond = Random.Range(1, 101);

                    if (spawnSecond < 41)
                    {

                        whatToSpawn2 = Random.Range(1, 4);


                        switch (whatToSpawn2)
                        {

                            case 1:
                                Instantiate(leftArrow, leftArrow.transform.position, Quaternion.identity);

                                spawnThird = Random.Range(1, 101);

                                if (spawnThird < 21)
                                {
                                    whatToSpawn3 = Random.Range(1, 3);

                                    switch (whatToSpawn3)
                                    {

                                        case 1:
                                            Instantiate(downArrow, downArrow.transform.position, Quaternion.identity);
                                            break;
                                        case 2:
                                            Instantiate(rightArrow, rightArrow.transform.position, Quaternion.identity);
                                            break;
                                    }
                                }

                                break;
                            case 2:
                                Instantiate(downArrow, downArrow.transform.position, Quaternion.identity);

                                spawnThird = Random.Range(1, 101);

                                if (spawnThird < 21)
                                {
                                    whatToSpawn3 = Random.Range(1, 3);

                                    switch (whatToSpawn3)
                                    {

                                        case 1:
                                            Instantiate(leftArrow, leftArrow.transform.position, Quaternion.identity);
                                            break;
                                        case 2:
                                            Instantiate(rightArrow, rightArrow.transform.position, Quaternion.identity);
                                            break;
                                    }
                                }

                                break;
                            case 3:
                                Instantiate(rightArrow, rightArrow.transform.position, Quaternion.identity);

                                spawnThird = Random.Range(1, 101);

                                if (spawnThird < 21)
                                {
                                    whatToSpawn3 = Random.Range(1, 3);

                                    switch (whatToSpawn3)
                                    {

                                        case 1:
                                            Instantiate(leftArrow, leftArrow.transform.position, Quaternion.identity);
                                            break;
                                        case 2:
                                            Instantiate(downArrow, downArrow.transform.position, Quaternion.identity);
                                            break;
                                    }
                                }

                                break;
                        }
                    }

                    break;
                case 4:
                    Instantiate(rightArrow, rightArrow.transform.position, Quaternion.identity);

                    spawnSecond = Random.Range(1, 101);

                    if (spawnSecond < 41)
                    {

                        whatToSpawn2 = Random.Range(1, 4);


                        switch (whatToSpawn2)
                        {

                            case 1:
                                Instantiate(leftArrow, leftArrow.transform.position, Quaternion.identity);

                                spawnThird = Random.Range(1, 101);

                                if (spawnThird < 21)
                                {
                                    whatToSpawn3 = Random.Range(1, 3);

                                    switch (whatToSpawn3)
                                    {

                                        case 1:
                                            Instantiate(upArrow, upArrow.transform.position, Quaternion.identity);
                                            break;
                                        case 2:
                                            Instantiate(downArrow, downArrow.transform.position, Quaternion.identity);
                                            break;
                                    }
                                }

                                break;
                            case 2:
                                Instantiate(upArrow, upArrow.transform.position, Quaternion.identity);

                                spawnThird = Random.Range(1, 101);

                                if (spawnThird < 21)
                                {
                                    whatToSpawn3 = Random.Range(1, 3);

                                    switch (whatToSpawn3)
                                    {

                                        case 1:
                                            Instantiate(leftArrow, leftArrow.transform.position, Quaternion.identity);
                                            break;
                                        case 2:
                                            Instantiate(downArrow, downArrow.transform.position, Quaternion.identity);
                                            break;
                                    }
                                }

                                break;
                            case 3:
                                Instantiate(downArrow, downArrow.transform.position, Quaternion.identity);

                                spawnThird = Random.Range(1, 101);

                                if (spawnThird < 21)
                                {
                                    whatToSpawn3 = Random.Range(1, 3);

                                    switch (whatToSpawn3)
                                    {

                                        case 1:
                                            Instantiate(upArrow, upArrow.transform.position, Quaternion.identity);
                                            break;
                                        case 2:
                                            Instantiate(leftArrow, leftArrow.transform.position, Quaternion.identity);
                                            break;
                                    }
                                }

                                break;
                        }
                    }

                    break;
            }

            nextSpawn = Time.time + Random.Range(0.5f, 1.5f); // 0.5f, 1 //Next Arrow will spawn between 2 and 5 seconds, 6 is exclusive
            //Debug.Log("Next Spawn In: " + (nextSpawn - Time.time));
        }
    }

    IEnumerator SpawnBeckyHint()
    {
        while (true)
        {
            Instantiate(beckyHint, beckyHint.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f * (beckyHintLargeDelay ? 2 : 1));
            beckyHintLargeDelay = !beckyHintLargeDelay;
        }
    }

}
