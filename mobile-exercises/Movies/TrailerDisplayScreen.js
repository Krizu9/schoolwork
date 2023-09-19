import React, { Component } from 'react';
import { StyleSheet, Text, View } from 'react-native';
import { WebView } from 'react-native-webview';

export default function TrailerDisplayScreen({ route }) {
    const { video } = route.params;

    return (
        <View style={styles.container}>
            <WebView
                source={{ uri: `https://www.youtube.com/watch?v=${video.key}` }}
                style={styles.webView}
            />
        </View>
    );
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: '#fff',
    },
    webView: {
        flex: 1,
    },
});
