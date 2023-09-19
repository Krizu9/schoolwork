import {
    React,
    useState,
    useEffect,
} from 'react';
import axios from 'axios';
import {
    SafeAreaView,
    StatusBar,
    StyleSheet,
    Text, View,
    ScrollView,
    Image,
    TouchableHighlight,
    itemPressed
} from 'react-native';



function MovieListItem(props) {
    let IMAGEPATH = 'http://image.tmdb.org/t/p/w500'
    let imageurl = IMAGEPATH + props.movie.poster_path;
    return (
        <View style={styles.movieItem}>
            <View style={styles.movieItemImage}>
                <Image source={{ uri: imageurl }} style={{ width: 99, height: 146 }} />
            </View>
            <View style={{ marginRight: 50 }}>
                <Text style={styles.movieItemTitle}>{props.movie.title}</Text>
                <Text style={styles.movieItemText}>{props.movie.release_date}</Text>
                <Text numberOfLines={6} ellipsizeMode="tail" style={styles.movieItemText}>{props.movie.overview}</Text>
            </View>
        </View>
    )
}

function MovieList(props) {
    const [movies, setMovies] = useState([]);
    useEffect(() => {
        axios
            .get('https://api.themoviedb.org/3/movie/top_rated?api_key=2c2ad928fdc821e3f6d2a63922f9ddb3&language=en-US&page=1')
            .then(response => {
                console.log(response.data.results);
                setMovies(response.data.results);
            })

    }, [])
    const itemPressed = (index) => {
        props.navigation.navigate('MovieDetails', { movie: movies[index] });
    }
    if (movies.length === 0) {
        return (
            <View style={{ flex: 1, padding: 20 }}>
                <Text>Loading, please wait...</Text>
            </View>
        )
    }
    let movieItems = movies.map(function (movie, index) {
        return (
            <TouchableHighlight onPress={_ => itemPressed(index)}
                underlayColor="lightgray" key={index}>
                <MovieListItem movie={movie} key={index} />
            </TouchableHighlight>
        )
    });

    return (
        <ScrollView>
            {movieItems}
        </ScrollView>
    )
}
const MovieListScreen: () => Node = ({ navigation }) => {
    return (
        <SafeAreaView>
            <StatusBar />
            <ScrollView contentInsetAdjustmentBehavior="automatic">
                <MovieList navigation={navigation} />
            </ScrollView>
        </SafeAreaView>
    );
}

const styles = StyleSheet.create({
    sectionContainer: {
        marginTop: 32,
        paddingHorizontal: 24,
    },
    movieItem: {
        margin: 5,
        flex: 1,
        flexDirection: 'row',
    },
    movieItemImage: {
        marignRight: 5,
    },
    movieItemTitle: {
        fontWeight: 'bold',
        marginStart: 5,
    },
    movieItemText: {
        marginEnd: 60,
        marginStart: 5,

    }
});

export default MovieListScreen;