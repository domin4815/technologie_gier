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
	float speed;
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
	            // Debug.Log("x:"+BitConverter.ToSingle(data, 0));
	            // Debug.Log("y:"+BitConverter.ToSingle(data, 3));
	            // Debug.Log("z:"+BitConverter.ToSingle(data, 7));
	            string text = Encoding.UTF8.GetString(data);
	            string[] words = text.Split(' ');
	            // Debug.Log(text);
	            x = float.Parse(words[1].TrimEnd(','));
	            y = float.Parse(words[3].TrimEnd(','));
	            z = float.Parse(words[5].TrimEnd(','));
	            speed = float.Parse(words[7].TrimEnd(','));
	            Debug.Log(x+" "+y+" "+z+" "+speed);
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
	}

	void OnApplicationQuit() { 
		receiveThread.Abort();
		client.Close();
		Debug.Log("exit");
	}



}
