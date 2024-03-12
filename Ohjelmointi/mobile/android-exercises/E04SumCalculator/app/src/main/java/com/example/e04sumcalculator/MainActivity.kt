package com.example.e04sumcalculator

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.Button
import android.widget.TextView

class MainActivity : AppCompatActivity() {
    private var number: Int = 0
    private var sum: Int = 0
    private var currentOperation: String? = null
    private lateinit var textView: TextView

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        textView = findViewById(R.id.output)
    }

    fun numberInput(view: View) {
        val digit = (view as Button).text.toString().toInt()

        val currentText = textView.text.toString()
        textView.text = currentText + digit.toString()
    }

    fun onOperatorClick(view: View) {
        currentOperation = (view as Button).text.toString()
        val currentText = textView.text.toString()

        if (currentText.isNotEmpty() && currentText.last().isDigit()) {
            textView.text = currentText + currentOperation
        }
    }

    fun onClearClick(view: View) {
        textView.text = ""
        number = 0
        sum = 0
        currentOperation = null
    }

    fun onEqualsClick(view: View) {
        val currentText = textView.text.toString()

        if (currentOperation != null && currentText.isNotEmpty()) {
            val parts = currentText.split(currentOperation!!)

            if (parts.size == 2) {
                val firstNumber = parts[0].toInt()
                val secondNumber = parts[1].toInt()

                when (currentOperation) {
                    "+" -> {
                        sum = firstNumber + secondNumber
                        textView.text = currentText + "=" + sum
                    }
                }
            }
        }
    }



}
