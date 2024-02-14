package com.defaultcompany.ml.foregroundservice;

//import androidx.annotation.Nullable;
import androidx.core.app.NotificationCompat;

import android.app.Notification;
import android.app.NotificationChannel;
import android.app.NotificationManager;
import android.app.Service;
import android.content.Intent;
import android.os.Build;
import android.os.IBinder;
import androidx.annotation.NonNull;
// import androidx.annotation.Nullable;
import androidx.core.app.NotificationCompat;

public class ForegroundService extends Service {
    private static final String CHANNEL_ID = "ForegroundServiceChannel";

    @Override
    public void onCreate() {
        super.onCreate();
    }

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        createNotificationChannel();

        // Substitua R.drawable.ic_notification pelo ID real do seu recurso de ícone
        Notification notification = new NotificationCompat.Builder(this, CHANNEL_ID)
                .setContentTitle("Seu Modelo TensorFlow Lite está rodando.")
                .setSmallIcon(R.drawable.ic_notification)  // Substitua R.drawable.ic_notification pelo ID real do seu recurso de ícone
                .build();

        startForeground(1, notification);

        // Inicie aqui o código para rodar seu modelo TensorFlow Lite em segundo plano.

        return START_STICKY;
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
        // Pare aqui o código relacionado ao seu modelo TensorFlow Lite.
        stopForeground(true);
        stopSelf();
    }

    @Nullable
    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

    private void createNotificationChannel() {
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
            NotificationChannel serviceChannel = new NotificationChannel(
                    CHANNEL_ID,
                    "Foreground Service Channel",
                    NotificationManager.IMPORTANCE_DEFAULT
            );

            NotificationManager manager = getSystemService(NotificationManager.class);
            manager.createNotificationChannel(serviceChannel);
        }
    }
}
