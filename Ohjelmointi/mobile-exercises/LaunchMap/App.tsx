import React, { useState } from 'react';
import { View, TextInput, Button, Platform, Linking } from 'react-native';

export default function App() {
  const [latitude, setLatitude] = useState(0);
  const [longitude, setLongitude] = useState(0);

  const launchMap = () => {
    if (isNaN(latitude) || isNaN(longitude)) {
      alert('Latitude and longitude must be valid numbers');
      return;
    }

    const location = `${latitude},${longitude}`;
    const url = Platform.select({
      ios: `maps:${location}`,
      android: `geo:${location}?center=${location}&q=${location}&z=16`,
    });

    Linking.openURL(url);
  }

  return (
    <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
      <TextInput
        placeholder='Latitude'
        onChangeText={text => setLatitude(text)}
      />
      <TextInput
        placeholder='Longitude'
        onChangeText={text => setLongitude(text)}
      />
      <Button
        title="Launch a Map"
        onPress={launchMap}
      />
    </View>
  );
}
