import React, { useState, useEffect } from 'react';
import { StyleSheet, View, TextInput, Button, PermissionsAndroid } from 'react-native';
import MapView, { Marker } from 'react-native-maps';
import Geocoder from 'react-native-geocoding';
import Geolocation from '@react-native-community/geolocation';


Geocoder.init('AIzaSyDbHlugxOHi616oGUyvikhC2GWEQywTUAw');

export default function App() {
  const [region, setRegion] = useState(null);
  const [location, setLocation] = useState('');
  const [memo, setMemo] = useState('');
  const [markers, setMarkers] = useState([]);

  useEffect(() => {
    async function requestLocationPermission() {
      try {
        const granted = await PermissionsAndroid.request(
          PermissionsAndroid.PERMISSIONS.ACCESS_FINE_LOCATION,
          {
            title: "Location Permission",
            message: "This app needs to access your location.",
            buttonNeutral: "Ask Me Later",
            buttonNegative: "Cancel",
            buttonPositive: "OK"
          }
        );
        if (granted === PermissionsAndroid.RESULTS.GRANTED) {
          Geolocation.getCurrentPosition(
            position => {
              const { latitude, longitude } = position.coords;
              setRegion({
                latitude,
                longitude,
                latitudeDelta: 0.01,
                longitudeDelta: 0.01,
              });
            },
            error => console.log(error),
            { enableHighAccuracy: true, timeout: 20000, maximumAge: 1000 }
          );
        } else {
          console.log("Location permission denied");
        }
      } catch (err) {
        console.warn(err);
      }
    }
    requestLocationPermission();
  }, []);

  useEffect(() => {
    Geolocation.getCurrentPosition(
      position => {
        const { latitude, longitude } = position.coords;
        setRegion({
          latitude,
          longitude,
          latitudeDelta: 0.01,
          longitudeDelta: 0.01,
        });
      },
      error => console.log(error),
      { enableHighAccuracy: true, timeout: 20000, maximumAge: 1000 }
    );
  }, []);

  const handleAddMarker = () => {
    Geocoder.from(location)
      .then(response => {
        const { lat, lng } = response.results[0].geometry.location;
        const newMarker = { lat, lng, memo };
        setMarkers([...markers, newMarker]);
      })
      .catch(error => console.log(error));
  };

  return (
    <View style={styles.container}>
      {region && (
        <MapView style={styles.map} region={region}>
          {markers.map((marker, index) => (
            <Marker key={index} coordinate={{ latitude: marker.lat, longitude: marker.lng }} title={marker.memo} />
          ))}
        </MapView>
      )}
      <View style={styles.form}>
        <TextInput
          style={styles.input}
          placeholder="Location"
          value={location}
          onChangeText={text => setLocation(text)}
        />
        <TextInput
          style={styles.input}
          placeholder="Memo"
          value={memo}
          onChangeText={text => setMemo(text)}
        />
        <Button title="Add Marker" onPress={handleAddMarker} />
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  map: {
    position: 'absolute',
    top: 0,
    left: 0,
    right: 0,
    bottom: 0,
    zIndex: -1,
  },
  form: {
    backgroundColor: 'white',
    padding: 10,
  },
  input: {
    borderWidth: 1,
    borderColor: 'gray',
    marginBottom: 10,
    padding: 10,
  },
});
