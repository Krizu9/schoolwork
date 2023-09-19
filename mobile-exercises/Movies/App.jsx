import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { SafeAreaView, StatusBar, StyleSheet, Text, View, ScrollView, Image } from 'react-native';
import { NavigationContainer } from '@react-navigation/native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import MovieListScreen from './MovieListScreen';
import MovieDetailScreen from './MovieDetailScreen';
import TrailerDisplayScreen from './TrailerDisplayScreen';

const Stack = createNativeStackNavigator();

function App() {
  return (
    <NavigationContainer>
      <Stack.Navigator>
        <Stack.Screen
          name="MoviesList"
          component={MovieListScreen}
          options={{ title: 'Movie List' }}
        />
        <Stack.Screen
          name="MovieDetails"
          component={MovieDetailScreen}
          options={{ title: 'Movie Details' }}
        />
        <Stack.Screen
          name="TrailerDisplayScreen"
          component={TrailerDisplayScreen}
          options={{ title: 'Trailer Display' }}
        />
      </Stack.Navigator>
    </NavigationContainer>
  );
}

export default App;
