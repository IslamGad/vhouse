using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NewBehaviourScript : MonoBehaviour
{
    public Material newMat;
    public Material newMat2;
    public Material original;
    public bool check = false;
    public string[] oneimg;

 



    IEnumerator Start()
    {
        
        
        WWW itemdata = new WWW("http://localhost/semihouze/wp-content/themes/flatsome/themodel.php");
        yield return itemdata;
        string imgs = itemdata.text;
        oneimg = imgs.Split('=');
      // int length =  oneimg.Length;
      //  print(length);
        int i = 1;
        foreach (string item in oneimg)
        {
            
            newMat = Resources.Load<Material>("mainwall"+i++);
            WWW again = new WWW(item);
            yield return again;
            newMat.mainTexture = again.texture;
             //  print(i);

        }


       
 

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            newMat = Resources.Load<Material>("mainwall1");
            newMat2 = Resources.Load<Material>("mainwall2");

            newMat.mainTexture = newMat2.mainTexture;
        }

            if (Input.GetKeyDown(KeyCode.R))
        {
            for (int counter = 1; counter < oneimg.Length; counter++)
            {
                newMat = Resources.Load<Material>("mainwall" + counter++);

                     newMat.mainTextureScale = new Vector2(-10, 1);

            }

        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            for (int counter = 1; counter < oneimg.Length; counter++)
            {
                newMat = Resources.Load<Material>("mainwall" + counter++);

                newMat.mainTextureScale = new Vector2(1, 1);

            }

            //ray cast
            
        }

    }
 

}
