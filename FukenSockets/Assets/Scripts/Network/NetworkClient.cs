using System.Collections.Generic;
using SocketIO;
using UnityEngine;

namespace CaptainABC.Network {
    public class NetworkClient : SocketIOComponent {

        [Header("Network client")] 
        [SerializeField] private Transform _networkContainer;

        private Dictionary<string, GameObject> _serverObjects;

        public override void Start() {
            base.Start();

            Init();
            
            InitEvents();
        }

        private void Init() {
            _serverObjects = new Dictionary<string, GameObject>();
        }
        
        private void InitEvents() {
            On("open", (e) => {
                Debug.Log("Connected to server");
            });

            On("register", (e) => {
                var id = e.data["id"].ToString().Replace("\"", "");
                
                Debug.Log("Client id : " + id);
            });

            On("spawn", (e) => {
                var id = e.data["id"].ToString().Replace("\"", "");
                
                var go = new GameObject("id" + id);
                go.transform.SetParent(_networkContainer);
                _serverObjects.Add(id, go);
            });

            On("userDisconnected", (e) => {
                var id = e.data["id"].ToString().Replace("\"", "");

                var go = _serverObjects[id];
                Destroy(go);
                _serverObjects.Remove(id);
            });
        }
    }
}