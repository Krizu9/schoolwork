import { StatusBar } from 'expo-status-bar';
import React, { useState } from 'react';
import { StyleSheet, Text, View, TextInput, Button, Keyboard } from 'react-native';

export default function App() {
  const [number1, setNumber1] = useState('0');
  const [number2, setNumber2] = useState('0');
  const [result, setResult] = useState('0');

  const buttonPressed = (e, calc) => {
    if (calc === '+') setResult(parseInt(number1) + parseInt(number2) + "");
    else if (calc === '-') setResult(parseInt(number1) - parseInt(number2) + "");
    else if (calc === '/') setResult(parseInt(number1) / parseInt(number2) + "");
    else if (calc === '*') setResult(parseInt(number1) * parseInt(number2) + "");
    Keyboard.dismiss();
  }
  return (
    <View style={styles.container}>
      <Text style={styles.calculator}>Calculator</Text>
      <StatusBar style="auto" />
      <View style={styles.row}>
        <View style={styles.text}>
          <Text>Number 1:</Text>
        </View>
        <View style={styles.textInput}>
          <TextInput value={number1}
            onChangeText={text => setNumber1(text)}
            keyboardType={'numeric'}
            placeholder="0"
            style={{ textAlign: 'center' }}
          ></TextInput>
        </View>
      </View>
      <View style={styles.row}>
        <View style={styles.text}>
          <Text>Number 2:</Text>
        </View>
        <View style={styles.textInput}>
          <TextInput value={number2}
            onChangeText={text => setNumber2(text)}
            keyboardType={'numeric'}
            placeholder="0"
            style={{ textAlign: 'center' }}>
          </TextInput>
        </View>
      </View>
      <View style={styles.buttonRow}>
        <Button title="  +  " onPress={(e) => buttonPressed(e, '+')} />
        <Button title="  -  " onPress={(e) => buttonPressed(e, '-')} />
        <Button title="  *  " onPress={(e) => buttonPressed(e, '*')} />
        <Button title="  /  " onPress={(e) => buttonPressed(e, '/')} />
      </View>
      <View style={styles.row}>
        <View style={styles.text}>
          <Text>Result: </Text>
        </View>
        <View style={styles.textInput}>
          <TextInput
            placeholder="0"
            style={{ textAlign: 'center', color: 'black' }}
            value={result}
            editable={false}>
          </TextInput>
        </View>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#A3A798',
    alignItems: 'center',
    justifyContent: 'center',
  },
  calculator: {
    fontSize: 50,
    fontWeight: 'helvetica',
    marginBottom: 20,
  },
  row: {
    flexDirection: 'row',
  },
  text: {
    backgroundColor: '#8FC80F',
    border: 100,
    justifyContent: 'center',
    padding: 5,
    width: 100,
  },
  textInput: {
    color: 'black',
    justifyContent: 'center',
    padding: 1,
    borderBottomWidth: 1.0,
    width: 50,
    marginLeft: 2,
  },
  buttonRow: {
    flexDirection: 'row',
    marginTop: 10,
    marginBottom: 5,
    justifyContent: 'space-around',
    width: 150,
  },

});