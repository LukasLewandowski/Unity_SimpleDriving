using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_IOS
using Unity.Notifications.iOS;
#endif

public class iOSNotificationsHandler : MonoBehaviour
{
#if UNITY_IOS
    public void ScheduleNotification(int minutes) {
        iOSNotification notification = new iOSNotification
        {
            Title = "Energy Rechared",
            Subtitle = "Your energy has been rechared",
            Body = "Energy has rechared, you can play again",
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
            CategoryIdentifier = "category_a",
            ThreadIdentifier =  "thread1",
            Trigger = new iOSNotificationTimeIntervalTrigger
            {
                TimeInterval = new System.TimeSpan(0, minutes, 0),
                Repeats = false
            }
        };
    
        iOSNotificationCenter.ScheduleNotification(notification);
    };

#endif

}
