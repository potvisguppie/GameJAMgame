using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathHandler : MonoBehaviour
{
    // Start is called before the first frame update
    bool verloren = false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            
            Vector3 pos = other.transform.position;
            other.gameObject.SetActive(false);
            GameObject pentagraf = GameObject.Find("pentagraaafje");
            Instantiate(pentagraf, pos, Quaternion.identity);
            pentagraf.gameObject.SetActive(true);
            pentagraf.transform.position = pos;
            string verliezer = other.gameObject.name;
            if (verloren) { return; }
            verloren = true;

            if (verliezer == "Player1")
            {
                GameObject tekst = GameObject.FindGameObjectWithTag("TEKST");
                tekst.GetComponent<TextMeshProUGUI>().SetText("Rood heeft gewonnen!!");
            } else
            {
                GameObject tekst = GameObject.FindGameObjectWithTag("TEKST");
                tekst.GetComponent<TextMeshProUGUI>().SetText("Groen heeft gewonnen!!");
            }
        }
    }
}
