using SocketIO;
using UnityEngine;

namespace CaptainABC.Network {
    public class NetworkClient : SocketIOComponent {
        public override void Start() {
            base.Start();
            
            InitEvents();
        }

        private void InitEvents() {
            On("open", (e) => {
                Debug.Log("Connected to server");
            });
        }
    }
}