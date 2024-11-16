using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
#if UNITY_IOS
using UnityEngine.iOS;
#endif
public class NotificationRequest : MonoBehaviour
{
    void Start()
    {
        RequestNotificationPermission();
    }

    public void RequestNotificationPermission()
    {
        Debug.Log("Checking for notification permission...");

        if (Application.platform == RuntimePlatform.Android)
        {
            string postNotificationsPermission = "android.permission.POST_NOTIFICATIONS";

            if (Permission.HasUserAuthorizedPermission(postNotificationsPermission))
            {
                Debug.Log("Notification permission already granted.");
            }
            else
            {
                Debug.Log("Requesting notification permission...");
                Permission.RequestUserPermission(postNotificationsPermission);
            }
        }
#if UNITY_IOS
    else if (Application.platform == RuntimePlatform.IPhonePlayer)
    {
        Debug.Log("Requesting notification permission for iOS...");
        NotificationServices.RegisterForNotifications(
            NotificationType.Alert | NotificationType.Badge | NotificationType.Sound
        );
    }
#endif
        else
        {
            Debug.LogWarning("Notification permission request not applicable on this platform.");
        }
    }

}
