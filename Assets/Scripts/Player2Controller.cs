using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public bool jump;
    public float jumpForce;
    public float speed = 5.0f;
    public float horizantalInput;
    public float verticalInput;
    public float strength = 15.0f;
    public bool hasPowerUp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("VerticalP2");
        horizantalInput = Input.GetAxis("HorizontalP2");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizantalInput);

        if (Input.GetKeyDown(KeyCode.Period) && jump == true)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            jump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        jump = true;

        if (collision.rigidbody && hasPowerUp)
        {
            strength += 5;
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * strength, ForceMode.Impulse);
            strength -= 5;
        }

        if (collision.rigidbody)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * strength, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("Powerup"))
        {
            Debug.Log("hoi");
            hasPowerUp = true;
            collision.gameObject.SetActive(false);
        }
    }
}


