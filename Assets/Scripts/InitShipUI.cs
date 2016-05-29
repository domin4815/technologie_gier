using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class InitShipUI : MonoBehaviour {

	void Start() {
		PlayerStats stats = PlayerStats.getInstance();
		GameObject canvasController = GameObject.FindGameObjectWithTag ("CanvasController");
		stats.canvasController = canvasController.GetComponent<GameOverCanvas> ();
		stats.updateHpText();
		stats.updateScoreText();
	
	  	string localIP = "Unknown";
    	using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
	    {
	        socket.Connect("10.0.2.4", 9876);
	        IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
	        localIP = endPoint.Address.ToString();
	    }
	    TextMesh text = (TextMesh) GameObject.Find("IPAddr").GetComponent("TextMesh");
	    text.text = localIP;

	}
}