using UnityEngine;
using System.Collections;

[AddComponentMenu("MyGame/Player")]
public class Player : MonoBehaviour {


    public float m_speed = 1;


    protected Transform m_transform;

    public Transform m_rocket;
    
    protected float m_rocketRate = 0;

	// Use this for initialization
	void Start () {

        m_transform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {

        float movex = 0;
        float movez = 0;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            movez -= m_speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            movez += m_speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movex += m_speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            movex -= m_speed * Time.deltaTime;
        }

        m_transform.Translate(new Vector3(movex, 0, movez));

        m_rocketRate -= Time.deltaTime;

        if(m_rocketRate<0)
        {
            m_rocketRate = 0.1f;

            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                Instantiate(m_rocket, m_transform.position, m_transform.rotation);
            
            }

        }

	}
}
