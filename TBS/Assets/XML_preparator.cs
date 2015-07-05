using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

public class XML_preparator : MonoBehaviour {

	public UnitsClass config;
	// Use this for initialization
	void Start () {
		var serializer = new XmlSerializer(typeof(UnitsClass));
		using (var fs = new FileStream("Assets\\db\\Units.xml", FileMode.Open, FileAccess.Read))
		{
			config = (UnitsClass)serializer.Deserialize(fs);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
