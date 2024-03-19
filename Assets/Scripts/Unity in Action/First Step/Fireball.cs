using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityInAction
{
    public class Fireball : MonoBehaviour
    {
        float speed = 10.0f;
        int damage = 1;
        // Update is called once per frame
        void Update()
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider collider)
        {
            PlayerCharacter player = collider.GetComponent<PlayerCharacter>();
            if(player != null)
            {
                Debug.Log("Player Hit!");
                player.Hurt(damage);
            }
            Destroy(this.gameObject);
        }
    }
}
