using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float m_speed = 0.1f;
    protected float m_rotSpeed = 30;
    protected float m_changeDirectionTimer = 1.5f;
    protected Transform m_transform;

    public float m_life = 1;

	// Use this for initialization
	void Start () {
        this.m_transform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {

        UpdateMove();
	}

    protected void UpdateMove()
    {
        m_changeDirectionTimer -= Time.deltaTime;
        if (m_changeDirectionTimer <= 0)
        {
            m_changeDirectionTimer = 3;

            m_rotSpeed = -m_rotSpeed;
        }

        m_transform.Rotate(Vector3.up, m_rotSpeed * Time.deltaTime, Space.World);

        m_transform.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));

    
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("PlayerRocket") == 0)
        {
            Rocket rocket = other.GetComponent<Rocket>();
            if (rocket != null)
            {
                m_life -= rocket.m_power;   
            }
        }
        else if (other.tag.CompareTo("Player") == 0)
        {
            m_life = 0;
        }


        if (m_life <= 0)
        {
            Destroy(this.gameObject);
        }


    }

}
