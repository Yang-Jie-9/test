using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSort : MonoBehaviour
{
    // Start is called before the first frame update


    public List<int> test = new List<int>();

    void Start()
    {
        for (int i = 0; i < 500; i++)
        {
            test.Add(Random.Range(0, 50));
        }
        test.Sort((bef, aft) => bef-aft);
    }

}
