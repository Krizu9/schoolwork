import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Text, View, StyleSheet, Image, Linking, TouchableOpacity } from 'react-native';
import { WebView } from 'react-native-webview';

export default function MovieDetailScreen({ route, navigation }) {
    const { movie } = route.params;
    let IMAGEPATH = 'https://image.tmdb.org/t/p/w500';
    let imageurl = IMAGEPATH + movie.backdrop_path;

    const [genreData, setGenreData] = useState([]);
    const [movieData, setMovieData] = useState([]);

    useEffect(() => {
        axios
            .get('https://api.themoviedb.org/3/genre/movie/list?api_key=2c2ad928fdc821e3f6d2a63922f9ddb3&language=en-US')
            .then((response) => {
                setGenreData(response.data.genres);
            })
            .catch((error) => {
                console.log(error);
            });
    }, []);

    useEffect(() => {
        axios
            .get(
                'https://api.themoviedb.org/3/movie/' + movie.id + '?api_key=875bb04b769cd254a5cd16ded8babc13&language=en-US&append_to_response=videos',
            )
            .then((response) => {
                setMovieData(response.data);
            })
            .catch((error) => {
                console.log(error);
            });
    }, []);

    function getGenreName(genreId) {
        const genre = genreData.find((g) => g.id === genreId);
        return genre ? genre.name : '';
    }

    const handleNavigateToTrailer = () => {
        const video = movieData.videos?.results[0];
        if (video) {
            navigation.navigate('TrailerDisplayScreen', { video });
        }
    };

    const movieLength = movieData.runtime ? `${movieData.runtime} minutes` : '';
    return (
        <View>
            <Image source={{ uri: imageurl }} style={styles.image} />
            <Text style={styles.title}>{movie.title}</Text>
            <Text style={styles.text}>{movie.release_date}</Text>
            <Text style={styles.text}>{movie.overview}</Text>
            <Text style={styles.text}>Genres: {movie.genre_ids.map((id) => getGenreName(id)).join(', ')}.</Text>
            <Text style={styles.text}>Runtime: {movieLength}</Text>
            {movieData.homepage && (
                <Text style={{ color: 'blue', fontSize: 12, marginStart: 5, marginEnd: 5, flexWrap: 'wrap', }}
                    onPress={() => Linking.openURL(movieData.homepage)}>
                    Homepage
                </Text>
            )}
            <Text style={styles.text}>Trailers:</Text>
            {movieData.videos?.results?.map((video) => (
                <Text
                    key={video.id}
                    style={{ color: 'blue', fontSize: 12, marginStart: 5, marginEnd: 5, flexWrap: 'wrap' }}
                    onPress={handleNavigateToTrailer}
                >
                    {video.name}
                </Text>
            ))}
        </View>
    );
}

const styles = StyleSheet.create({
    image: {
        aspectRatio: 670 / 250,
    },
    title: {
        fontWeight: 'bold',
        fontSize: 15,
        marginStart: 5,
        marginEnd: 5,
    },
    text: {
        fontSize: 12,
        flexWrap: 'wrap',
        marginStart: 5,
        marginEnd: 5,
    },
});
