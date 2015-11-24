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
        GameObject.FindObjectOfType<AnimationMenuBehaviour>().Move();
        
		GameObject.FindObjectOfType<MoveTitleBehaviour>().Move();
        
        Destroy(GameObject.FindObjectOfType<PressStartBehaviour>().gameObject);
    }

    #endregion

    #region Utils
   
    #endregion

    #region Private Variable

    #endregion
}
