using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject splashPreFab;
    public float jumpForce;
    private GameManager gm;
   


    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        
    }


    void Update()
    {

    }
   

    private void OnCollisionEnter(Collision other)
    {
        rb.AddForce(Vector3.up * jumpForce);
        GameObject splash = Instantiate(splashPreFab, transform.position+new Vector3(0f,-0.2f,0f), transform.rotation);
        splash.transform.SetParent(other.gameObject.transform);

        string materialName = other.gameObject.GetComponent<MeshRenderer>().material.name;
        Debug.Log("Material Adý : " + materialName);

        if(materialName== "Safe Color (Instance)")
        {
            //puan alacak

        }
        if(materialName=="Unsafe Color (Instance)")
        {
            //Bolum yenýden baslayacak
            gm.RestartGame();
          
        }
        else if (materialName== "Last Ring (Instance)")
        {
            SceneManager.LoadScene("Level_2");

        }
    
        


    }
    


}