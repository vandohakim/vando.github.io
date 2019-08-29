package com.example.clientzenbovando;

import androidx.appcompat.app.AppCompatActivity;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.net.UnknownHostException;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.asus.robotframework.API.WheelLights;

public class Client extends AppCompatActivity {

    EditText SocketServerPORT;

    LinearLayout loginPanel, chatPanel;

    EditText editTextUserName, editTextAddress;
    Button buttonConnect;
    TextView chatMsg, textPort;

    EditText editTextSay;
    Button buttonSend;
    Button buttonDisconnect;

    String msgLog = "";

    Spinner spinner;
    Button btspinner;
    Button forward, right, left, afterward;

    ChatClientThread chatClientThread = null;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);

        loginPanel = (LinearLayout)findViewById(R.id.loginpanel);
        chatPanel = (LinearLayout)findViewById(R.id.chatpanel);

        editTextUserName = (EditText) findViewById(R.id.username);
        editTextAddress = (EditText) findViewById(R.id.address);
        SocketServerPORT = (EditText) findViewById(R.id.port);
        //textPort.setText("port: " + SocketServerPORT);
        buttonConnect = (Button) findViewById(R.id.connect);
        buttonDisconnect = (Button) findViewById(R.id.disconnect);
        chatMsg = (TextView) findViewById(R.id.chatmsg);

        buttonConnect.setOnClickListener(buttonConnectOnClickListener);
        buttonDisconnect.setOnClickListener(buttonDisconnectOnClickListener);

        editTextSay = (EditText)findViewById(R.id.say);
        buttonSend = (Button)findViewById(R.id.send);

        buttonSend.setOnClickListener(buttonSendOnClickListener);
        spinner = (Spinner) findViewById(R.id.spinner);
        btspinner = (Button) findViewById(R.id.btspinner);
        btspinner.setOnClickListener(buttonSpinnerOnClickListener);

        forward = (Button) findViewById(R.id.forward);
        right = (Button) findViewById(R.id.right);
        left = (Button) findViewById(R.id.left);
        afterward = (Button) findViewById(R.id.afterward);

        forward.setOnClickListener(forwardOnClickListener);
        right.setOnClickListener(rightOnClickListener);
        left.setOnClickListener(leftOnClickListener);
        afterward.setOnClickListener(afterwardOnClickListener);

    }

    OnClickListener forwardOnClickListener = new OnClickListener() {
        @Override
        public void onClick(View view) {
            chatClientThread.sendMsg("FORWARD");
        }
    };
    OnClickListener rightOnClickListener = new OnClickListener() {
        @Override
        public void onClick(View view) {
            chatClientThread.sendMsg("KIRI");
        }
    };
    OnClickListener leftOnClickListener = new OnClickListener() {
        @Override
        public void onClick(View view) {
            chatClientThread.sendMsg("KANAN");
        }
    };
    OnClickListener afterwardOnClickListener = new OnClickListener() {
        @Override
        public void onClick(View view) {
            chatClientThread.sendMsg("AFTERWARD");
        }
    };

    OnClickListener buttonSpinnerOnClickListener = new OnClickListener() {
        @Override
        public void onClick(View view) {
            chatClientThread.sendMsg(spinner.getSelectedItem().toString());
            Toast.makeText(Client.this, "Face: "+ spinner.getSelectedItem().toString(), Toast.LENGTH_SHORT).show();
        }
    };

    OnClickListener buttonDisconnectOnClickListener = new OnClickListener() {

        @Override
        public void onClick(View v) {
            chatClientThread.sendMsg("///Exit///");
            loginPanel.setVisibility(View.VISIBLE);
            chatPanel.setVisibility(View.GONE);
        }

    };

    OnClickListener buttonSendOnClickListener = new OnClickListener() {

        @Override
        public void onClick(View v) {
            if (editTextSay.getText().toString().equals("")) {
                return;
            }

            if(chatClientThread==null){
                return;
            }

            chatClientThread.sendMsg("Speak: " + editTextSay.getText().toString());
            Toast.makeText(Client.this, "Speak: "+ editTextSay.getText().toString(), Toast.LENGTH_SHORT).show();
        }

    };

    OnClickListener buttonConnectOnClickListener = new OnClickListener() {

        @Override
        public void onClick(View v) {
            String textUserName = editTextUserName.getText().toString();
            if (textUserName.equals("")) {
                Toast.makeText(Client.this, "Enter User's Name",
                        Toast.LENGTH_LONG).show();
                return;
            }

            String textAddress = editTextAddress.getText().toString();
            if (textAddress.equals("")) {
                Toast.makeText(Client.this, "Enter Server IP Address",
                        Toast.LENGTH_LONG).show();
                return;
            }

            String port = SocketServerPORT.getText().toString();
            if (port.equals("")) {
                Toast.makeText(Client.this, "Enter Server Port",
                        Toast.LENGTH_LONG).show();
                return;
            }

            msgLog = "";
            chatMsg.setText(msgLog);
            loginPanel.setVisibility(View.GONE);
            chatPanel.setVisibility(View.VISIBLE);

            chatClientThread = new ChatClientThread(textUserName, textAddress, Integer.parseInt(SocketServerPORT.getText().toString()));
            chatClientThread.start();
        }

    };

    private class ChatClientThread extends Thread {

        String name;
        String dstAddress;
        int dstPort;
        Socket socket = null;

        String msgToSend = "";
        boolean goOut = false;

        ChatClientThread(String name, String address, int port) {
            this.name = name;
            dstAddress = address;
            dstPort = port;
        }

        @Override
        public void run() {
            DataOutputStream dataOutputStream = null;
            DataInputStream dataInputStream = null;

            try {
                socket = new Socket(dstAddress, dstPort);
                dataOutputStream = new DataOutputStream(socket.getOutputStream());
                dataInputStream = new DataInputStream(socket.getInputStream());
                dataOutputStream.writeUTF(name);
                dataOutputStream.flush();

                while (!goOut) {
                    if (dataInputStream.available() > 0) {
                        String msg = dataInputStream.readUTF();
                        Log.i("DEBUG", "run: "+msg);
                        msgLog += msg;
                        if (msg.contains("///Exit///")) {
                            break;
                        }
                        Client.this.runOnUiThread(new Runnable() {

                            @Override
                            public void run() {
                                chatMsg.setText(msgLog);
                            }
                        });
                    }

                    if(!msgToSend.equals("")){
                        dataOutputStream.writeUTF(msgToSend);
                        dataOutputStream.flush();
                        msgToSend = "";
                    }
                }

            } catch (UnknownHostException e) {
                e.printStackTrace();
                final String eString = e.toString();
                Client.this.runOnUiThread(new Runnable() {

                    @Override
                    public void run() {
                        Toast.makeText(Client.this, "Server is OFF!!", Toast.LENGTH_LONG).show();
                    }

                });
            } catch (IOException e) {
                e.printStackTrace();
                final String eString = e.toString();
                Client.this.runOnUiThread(new Runnable() {

                    @Override
                    public void run() {
                        Toast.makeText(Client.this, "Server is OFF!!!", Toast.LENGTH_LONG).show();
                    }

                });
            } finally {
                if (socket != null) {
                    try {
                        socket.close();
                    } catch (IOException e) {
                        // TODO Auto-generated catch block
                        e.printStackTrace();
                    }
                }

                if (dataOutputStream != null) {
                    try {
                        dataOutputStream.close();
                    } catch (IOException e) {
                        // TODO Auto-generated catch block
                        e.printStackTrace();
                    }
                }

                if (dataInputStream != null) {
                    try {
                        dataInputStream.close();
                    } catch (IOException e) {
                        // TODO Auto-generated catch block
                        e.printStackTrace();
                    }
                }

                Client.this.runOnUiThread(new Runnable() {

                    @Override
                    public void run() {
                        loginPanel.setVisibility(View.VISIBLE);
                        chatPanel.setVisibility(View.GONE);
                    }

                });
            }

        }

        private void sendMsg(String msg){
            msgToSend = msg;
        }

        private void disconnect(){
            try{
                socket.close();
            } catch (IOException e){
                e.printStackTrace();
            }
            Toast.makeText(Client.this, "Disconnected successful",
                    Toast.LENGTH_LONG).show();
            goOut = true;
            loginPanel.setVisibility(View.VISIBLE);
            chatPanel.setVisibility(View.GONE);
        }
    }
}
