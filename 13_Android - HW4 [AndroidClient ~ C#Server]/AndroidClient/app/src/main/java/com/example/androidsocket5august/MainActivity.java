package com.example.androidsocket5august;

import androidx.appcompat.app.AppCompatActivity;
//import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Handler;
import android.os.Looper;
import android.os.Message;
import android.os.StrictMode;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import org.w3c.dom.Text;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Scanner;


public class MainActivity extends AppCompatActivity {

    TextView textviewchat;
    EditText messageout;
    EditText ipaddresstext;
    EditText porttext;
    Socket s;
    PrintWriter pw;
    Handler handler;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Button button = findViewById(R.id.button);
        Button buttonConnect = findViewById(R.id.buttonConnect);
        Button buttonDisonnect = findViewById(R.id.buttonDisconnect);
        ipaddresstext = findViewById(R.id.ipaddresstext);
        porttext = findViewById(R.id.porttext);
        messageout = findViewById(R.id.messageout);
        textviewchat = findViewById(R.id.textView);
        handler = new Handler();
        porttext.setText("7800");
        ipaddresstext.setText("140.115.158.239");



        if (android.os.Build.VERSION.SDK_INT > 9)
        {
            StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
            StrictMode.setThreadPolicy(policy);
        }

        buttonDisonnect.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                try {
//                    Intent intent = getIntent();
                    s.close();
//                    finish();
//                    startActivity(intent);
                }catch (IOException e){
                    e.printStackTrace();
                }
            }
        });
        buttonConnect.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (ipaddresstext.getEditableText() != null && ipaddresstext.getEditableText().toString() != ""){
                    if (porttext.getEditableText() != null && porttext.getEditableText().toString() != ""){
                        try {
                            s = new Socket(ipaddresstext.getEditableText().toString(), Integer.parseInt(porttext.getEditableText().toString()));
                            thread.start();
                        }catch (IOException e){
                            e.printStackTrace();
                        }
                    }
                }
            }
        });
    }

    Thread thread = new Thread() {
        @Override
        public void run() {
            if (s != null){
                try{
                    while (true) {
                        if (s.isConnected()){
                            SimpleDateFormat formatter = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss");
                            Date date = new Date();
                            final String dateString = formatter.format(date);
                            final String msgIn = new BufferedReader(new InputStreamReader(s.getInputStream())).readLine();
                            if (msgIn != null && msgIn != ""){
                                runOnUiThread(new Runnable() {
                                    @Override
                                    public void run() {
                                        textviewchat.append("["+dateString+"] "+"C#: "+msgIn+"\n");
                                    }
                                });
                            }

                        }
                    }
                }catch (IOException e){
                    e.printStackTrace();
                }
            }
        }
    };

    public void send(View v){
        try {
            SimpleDateFormat formatter = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss");
            Date date = new Date();
            final String dateString = formatter.format(date);
            final String msgOut = messageout.getEditableText().toString()+"\n";
            if (pw == null){
                pw = new PrintWriter(s.getOutputStream());
            }
            pw.write(msgOut);
            pw.flush();
            if (msgOut != null && msgOut != ""){
                runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        textviewchat.append("["+dateString+"] "+"Android: "+msgOut);
                    }
                });
            }
        }catch (IOException e){
            e.printStackTrace();
        }

    }

}
