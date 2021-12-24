using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif
using UnityEngine;

public class AndroidNotificationsHandler : MonoBehaviour
{
#if UNITY_ANDROID

    public const string ChannelId = "notification_channel";
    public void ScheduleNotification(DateTime dateTime)
    {
        AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel
        {
            Id = ChannelId,
            Name = "Notification Channel",
            Description = "This is notification channel",
            Importance = Importance.Default
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);
        AndroidNotification notification = new AndroidNotification
        {
            Title = "Energy Recharged :)",
            Text = "Energy has rechared, you can play again",
            SmallIcon = "default",
            LargeIcon = "default",
            FireTime = dateTime,
        };

        AndroidNotificationCenter.SendNotification(notification, ChannelId);
    }
#endif
}

