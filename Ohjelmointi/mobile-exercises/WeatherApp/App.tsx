import React, { useState, useEffect } from 'react';
import { View, Text, ScrollView, StyleSheet } from 'react-native';
import { SafeAreaView } from 'react-native';
import { Header, Input, Card, Button } from 'react-native-elements';
import Dialog from "react-native-dialog";
import Icon from 'react-native-vector-icons/FontAwesome';
import useAxios from 'axios-hooks';
import AsyncStorage from '@react-native-async-storage/async-storage';



const WeatherForecast = (params) => {
  const city = params.city;
  const API_KEY = '172010e616335e6d9a3be23079bc868c';
  const URL = 'https://api.openweathermap.org/data/2.5/weather?q=';
  const [{ data, loading, error }, refetch] = useAxios(
    URL + city.name + '&appid=' + API_KEY + '&units=metric'
  );

  return (
    <Card>
      <Card.Title>{city.name}</Card.Title>
      {loading && <Text>Loading...</Text>}
      {error && (<>
        <Text style={styles.text}>Error loading weather forecast!</Text>
        <Button style={styles.buttonContainer}
          title="  Delete"
          icon={<Icon name="trash" size={15} color="white" />}
          onPress={() => params.handleDelete(city.id)}
        />
      </>)}
      {data && (
        <>
          <Text style={styles.text}>Main: {data.weather[0].main}</Text>
          <Text style={styles.text}>Temp: {data.main.temp} °C</Text>
          <Text style={styles.text}>Feels: {data.main.feels_like} °C</Text>
          <Text style={styles.text}>Humidity: {data.main.humidity} %</Text>
          <Text style={styles.text}>Wind: {data.wind.speed} m/s</Text>
          <View style={styles.buttonContainer}>
            <Button style={styles.buttonContainer}
              title="  Delete"
              icon={<Icon name="trash" size={15} color="white" />}
              onPress={() => params.handleDelete(city.id)}
            />
            <Button
              style={styles.buttonContainer}
              title="  Refresh"
              icon={<Icon name="refresh" size={15} color="white" />}
              onPress={() => params.handleRefresh(city.id)}
            />
          </View>
        </>
      )}
    </Card>
  );
}
const styles = StyleSheet.create({
  buttonContainer: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    marginTop: 10,
  },
  text: {
    color: 'black',
    marginBottom: 5,
  }
});

const App = () => {
  const [modalVisible, setModalVisible] = useState(false);
  const [cityName, setCityName] = useState("");
  const [cities, setCities] = useState([]);

  useEffect(() => {
    getData();
  }, []);

  useEffect(() => {
    storeData();
  }, [cities]);

  const openDialog = () => {
    setModalVisible(true);
  };

  const addCity = () => {
    setCities([...cities, { id: Math.random(), name: cityName }]);
    setModalVisible(false);
  };

  const cancelCity = () => {
    setModalVisible(false);
  };

  const handleDelete = (id) => {
    setCities((prevCities) => prevCities.filter((city) => city.id !== id));
  };

  const handleRefresh = (id) => {
    setCities((prevCities) => {
      const index = prevCities.findIndex((city) => city.id === id);
      const cityToUpdate = prevCities[index];
      return [
        ...prevCities.slice(0, index),
        { ...cityToUpdate },
        ...prevCities.slice(index + 1),
      ];
    });
  };
  const storeData = async () => {
    try {
      await AsyncStorage.setItem('@cities', JSON.stringify(cities))
    } catch (e) {
      console.log("Cities saving error! " + e);
    }
  }
  const getData = async () => {
    try {
      const value = await AsyncStorage.getItem('@cities')
      if (value !== null) {
        setCities(JSON.parse(value));
      }
    } catch (e) {
      console.log("Cities loading error!");
    }
  }

  return (
    <SafeAreaView>
      <Header
        centerComponent={{ text: 'Weather App', style: { color: '#fff' } }}
        rightComponent={<Icon name='plus' size={25} color='#fff' onPress={openDialog} />}
      />
      <Dialog.Container visible={modalVisible}>
        <Dialog.Title>Add a new city</Dialog.Title>
        <View>
          <Input
            onChangeText={(text) => setCityName(text)}
            placeholder='Type cityname here'
          />
        </View>
        <Dialog.Button label="Cancel" onPress={cancelCity} />
        <Dialog.Button label="Add" onPress={addCity} />
      </Dialog.Container>
      <ScrollView contentContainerStyle={{ paddingBottom: 80 }}>
        {cities.map(city => (
          <WeatherForecast key={city.id} city={city} handleDelete={handleDelete} handleRefresh={handleRefresh} />
        ))}
      </ScrollView>
    </SafeAreaView>
  );
};

export default App;
