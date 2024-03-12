package com.example.e06myfirstapp

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.TextView

class SecondActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_second)

        val button2 = findViewById<Button>(R.id.switch_button2)
        val message = intent.getStringExtra("Message")
        val wantedText = findViewById<TextView>(R.id.display_message)
        wantedText.text = message

        button2.setOnClickListener {
            val intent = Intent(this, MainActivity::class.java)
            intent.putExtra("Message", message)
            startActivity(intent)
        }
    }
}