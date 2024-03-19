using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityInAction
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] GameObject enemyPrefab;
        private GameObject enemy;
        // Update is called once per frame
        void Update()
        {
            if(enemy == null)
            {
                enemy = Instantiate(enemyPrefab) as GameObject;
                enemy.transform.position = new Vector3(14.61f, 1, -3);
                float angle = Random.Range(0, 360);
                enemy.transform.Rotate(0, angle, 0);
            }
        }
    }
}
