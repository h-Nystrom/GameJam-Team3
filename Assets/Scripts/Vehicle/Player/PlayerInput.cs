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

        public Vector2 Direction => direction;

        void Update(){
            direction = new Vector2(Input.GetAxis("Vertical"),Input.GetAxis("Horizontal"));
        }
    }

    public interface ICarHandler{
        Vector2 Direction{
            get;
        }
    }
}


