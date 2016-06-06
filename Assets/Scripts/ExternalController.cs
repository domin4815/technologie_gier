using UnityEngine;
using System.Collections;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class ExternalController : MonoBehaviour {

	Thread receiveThread;
	UdpClient client;
	float x;
	float y;
	float z;
	float speed = 0f;
	public int port = 9876;
	// Use this for initialization
	void Start () {
		receiveThread = new Thread(new ThreadStart(ReceiveData));
		receiveThread.IsBackground = true;
		receiveThread.Start();

	}

	private  void ReceiveData() {
		client = new UdpClient(port);
		
		while (true) {
			try {
				IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
	            byte[] data = client.Receive(ref anyIP);
	            Array.Reverse(data, 0, 4);
	            Array.Reverse(data, 4, 4);
	            Array.Reverse(data, 8, 4);
	            Array.Reverse(data, 12, 4);
	            x = BitConverter.ToSingle(data, 0);
	            y = BitConverter.ToSingle(data, 4);
	            z = BitConverter.ToSingle(data, 8);
	            speed = BitConverter.ToSingle(data, 12);
	            Debug.Log(x+" "+y+" "+z+" "+speed+" "+data.Length);
	      	}catch (Exception err) {
                print(err.ToString());
            }
		}

	}


	// Update is called once per frame
	void Update () {
		//transform.rotation = Quaternion.LookRotation(new Vector3(y/100,x/100,z/100));

		transform.Rotate(Vector3.left * Time.deltaTime*(10*z));
		transform.Rotate(Vector3.back * Time.deltaTime*(10*y));

		transform.position += transform.forward * Time.deltaTime * (20+3*speed);
	}

	void OnApplicationQuit() { 
		if(receiveThread != null) 
			receiveThread.Abort();
		if(client != null)
			client.Close();
		Debug.Log("Exit");
	}

	void OnDestroy(){
		if(receiveThread != null) 
			receiveThread.Abort();
		if(client != null)
			client.Close();
		Debug.Log("Destroy");
	}

}
