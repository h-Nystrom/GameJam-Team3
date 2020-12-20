using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Patient{
    [System.Serializable]
    public class StringEvent : UnityEvent<string>{}
    public class JobManager : MonoBehaviour{
        List<Transform> patientList = new List<Transform>();
        [SerializeField] Transform nextTargetIndicator;
        [SerializeField] Transform hospital;
        [SerializeField] StringEvent pointsEvent;
        [SerializeField] StringEvent killsEvent;
        [SerializeField] StringEvent GameOverEvent;
        [SerializeField] VoidEvent addTimeEvent;
        Transform nextTarget;
        Transform currentPatient;
        [SerializeField]bool hasPatients;
        bool isFull;
        public bool HasPatients => hasPatients;
        int kills;
        int point;
        int totalPatients;
        bool killedLastPatient;
        

        void Start(){
            Invoke(nameof(OnNewObjective),0.1f);
            Invoke(nameof(GetTotalPatients),0.2f);
            killsEvent?.Invoke($"Accidents: {kills}/3");
        }

        void FixedUpdate(){
            if(!hasPatients) return;
            nextTargetIndicator.LookAt(nextTarget);
        }

        public void AddPatient(Transform patient){
            patientList.Add(patient);
            hasPatients = true;
        }

        public void OnPickUp(){
            nextTarget = hospital;
            isFull = true;
        }

        void GetTotalPatients(){
            totalPatients = patientList.Count;
            pointsEvent?.Invoke($"Saved: {point}/{totalPatients}");
        }
        void OnNewObjective(){
            if (kills >= 3 || killedLastPatient){
                GameOverEvent?.Invoke("Mission failed!");
                return;
            }
            if (patientList.Count > 0){
                nextTarget = patientList[Random.Range(0, patientList.Count)];
                nextTarget.GetComponent<PatientsScript>().IsSick = true;
                nextTargetIndicator.gameObject.SetActive(true);
                hasPatients = true;
                currentPatient = nextTarget;
            }
            else{
                hasPatients = false;
                nextTargetIndicator.gameObject.SetActive(false);
                GameOverEvent?.Invoke("Mission complete!");
            }
        }

        public void RemovePatientToHospital(){
            if(!isFull)
                return;
            patientList.Remove(currentPatient);
            hasPatients = false;
            isFull = false;
            point++;
            OnNewObjective();
            addTimeEvent?.Invoke();
            pointsEvent?.Invoke($"Saved: {point}/{totalPatients}");
        }
        public void RemoveDeadPatient(Transform patient){
            patientList.Remove(patient);
            kills++;
            killsEvent?.Invoke($"Accidents: {kills}/3");
            if (patient != currentPatient) return;
            nextTargetIndicator.gameObject.SetActive(false);
            hasPatients = false;
            if (patientList.Count == 0)
                killedLastPatient = true;
            OnNewObjective();
            
        }

    }
}

