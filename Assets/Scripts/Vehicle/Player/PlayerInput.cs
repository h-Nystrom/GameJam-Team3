using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Searcher;
using UnityEngine;
using UnityEngine.EventSystems;
using Vehicle;

namespace Player{
    
    public class PlayerInput : MonoBehaviour, ICarHandler{

        Vector2 direction;
        float handBreak;
        public Vector2 Direction => direction;
        public float HandBreak => handBreak;

        void Update(){
            direction = new Vector2(Input.GetAxis("Vertical"),Input.GetAxis("Horizontal"));
            if (Input.GetAxis("Jump") == 0){
                handBreak = 1;
            }
            else
                handBreak = 0.01f;
        }
    }

    public interface ICarHandler{
        Vector2 Direction{
            get;
        }

        float HandBreak{
            get;
        }
    }
}


