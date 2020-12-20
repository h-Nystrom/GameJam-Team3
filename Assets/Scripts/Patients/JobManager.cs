using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Patient{
    public class JobManager : MonoBehaviour{
        List<Transform> patientList = new List<Transform>();
        [SerializeField] Transform nextTargetIndicator;
        [SerializeField] Transform hospital;
        Transform nextTarget;
        Transform currentPatient;
        [SerializeField]bool hasPatients;
        bool isFull;
        public bool HasPatients => hasPatients;

        [SerializeField] int kills;
        [SerializeField] int point;

        void Start(){
            Invoke(nameof(OnNewObjective),5f);
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
        void OnNewObjective(){
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
                print("Win!");
            }
        }

        public void RemovePatientToHospital(){
            if(!isFull)
                return;
            patientList.Remove(currentPatient);
            print(patientList.Count);
            hasPatients = false;
            isFull = false;
            point++;
            OnNewObjective();
        }
        public void RemoveDeadPatient(Transform patient){
            patientList.Remove(patient);
            print(patientList.Count);
            kills++;
            if (patient != currentPatient) return;
            nextTargetIndicator.gameObject.SetActive(false);
            hasPatients = false;
            OnNewObjective();
        }

    }
}

