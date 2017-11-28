using System;
using UnityEngine;

public class Clock : MonoBehaviour {
	private const float degressPerHour = 30f;
	private const float degressPerMinute = 6f;
	private const float degressPerSecond = 6f;

	public Transform hoursTransform, minutesTransform, secondsTransform;

	void Update() {
		DateTime time = DateTime.Now; // To show Second as discrete
		TimeSpan timeSpan = time.TimeOfDay; // To show Hour and Minute as continuous

		hoursTransform.localRotation = Quaternion.Euler(0f, (float) timeSpan.TotalHours * degressPerHour, 0f);
		minutesTransform.localRotation = Quaternion.Euler(0f, (float) timeSpan.TotalMinutes * degressPerMinute, 0f);
		secondsTransform.localRotation = Quaternion.Euler(0f, time.Second * degressPerSecond, 0f);
	}
}