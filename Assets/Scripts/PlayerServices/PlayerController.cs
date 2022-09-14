using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PlayerServices
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] public GameObject m_tailPrefab;
        [SerializeField] private int m_initialSnakeSize = 3;

        private Vector2 m_direction = Vector2.right;
        private bool m_isShieldActive = false;
        private bool m_ate = false;

        // Keep Track of Tail
        List<Transform> m_tail = new List<Transform>();

        private void Start()
        {
            InvokeRepeating("Move", 0.1f, 0.1f);
        }

        private void Update()
        {
            // Move in a new Direction?
            if (Input.GetKey(KeyCode.D))
                m_direction = Vector2.right;
            else if (Input.GetKey(KeyCode.S))
                m_direction = Vector2.down;
            else if (Input.GetKey(KeyCode.A))
                m_direction = Vector2.left;
            else if (Input.GetKey(KeyCode.W))
                m_direction = Vector2.up;
        }


        void Move()
        {
            Vector2 currentPosition = transform.position;
            transform.Translate(m_direction);

            if (m_ate)
            {
                GameObject prefab = (GameObject)Instantiate(m_tailPrefab, currentPosition, Quaternion.identity);
                m_tail.Insert(0, prefab.transform);
                m_ate = false;
            }
            else if (m_tail.Count > 0)
            {
                m_tail.Last().position = currentPosition;

                m_tail.Insert(0, m_tail.Last());
                m_tail.RemoveAt(m_tail.Count - 1);
            }
        }

        void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.CompareTag("Chicken"))
            {
                m_ate = true;
                Destroy(coll.gameObject);
            }
            // Collided with Tail or Border
            else
            {
                // ToDo 'You lose' screen
            }
        }



    }
}