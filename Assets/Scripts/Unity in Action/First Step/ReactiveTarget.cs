using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityInAction
{
    public class ReactiveTarget : MonoBehaviour
    {
        public void ReactToHit()
        {
            WanderingAI behavior = GetComponent<WanderingAI>();
            if(behavior!= null)
            {
                behavior.SetAlive(false);
            }
            StartCoroutine(Die());
        }

        IEnumerator Die()
        {
            this.transform.Rotate(-75, 0, 0);

            yield return new WaitForSeconds(1);

            Destroy(this.gameObject);
        }
    }
}
