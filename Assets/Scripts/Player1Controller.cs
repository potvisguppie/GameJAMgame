using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1Controller : MonoBehaviour
{
    public bool jump;
    public float speed = 5.0f;
    public float horizantalInput;
    public float verticalInput;
    public float jumpForce;
    public float strength = 15.0f;
    public bool hasPowerUp;
  

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("VerticalP1");
        horizantalInput = Input.GetAxis("HorizontalP1");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizantalInput);

        if (Input.GetKeyDown(KeyCode.T) && jump == true)
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

    
    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(30);
        hasPowerUp = false;
    }



}



