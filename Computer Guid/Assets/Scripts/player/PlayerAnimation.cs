using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private playerMove move;
    private Animation playerAnimation;
    // Start is called before the first frame update
    void Start()
    {
        move = this.GetComponent<playerMove>();
        playerAnimation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (move.state == PlayerState.Moving)
        {
            PlayAnim("Run");
        }
        else if(move.state==PlayerState.Idle){
            PlayAnim("Idle");
        }
    }

    void PlayAnim(string animName)
    {
        playerAnimation.CrossFade(animName);

    }
}
