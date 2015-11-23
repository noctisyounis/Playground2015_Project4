using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class PressStartBehaviour : MonoBehaviour
{
    #region Public Variable

    public float tempsAnimation = 0.5f; // pour regler le clignotement depuis l'editor

    #endregion

    #region Main Methodes

    
    void Start()
    {
        iTween.ColorTo(this.gameObject, iTween.Hash("a", 0, "time", tempsAnimation, "looptype", iTween.LoopType.pingPong));
    }

    void OnMouseUp()
    {
        GameObject button = GameObject.Find("Button");
        button.GetComponent<AnimationMenuBehaviour>().Move();

        GameObject title = GameObject.Find("TitreBis");
        title.GetComponent<MoveTitleBehaviour>().Move();
        
        Destroy(GameObject.Find("PressStart"));
    }

    #endregion

    #region Utils
   
    #endregion

    #region Private Variable

    #endregion
}
