import './App.css';
import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Modal from 'react-modal';
import YouTube from 'react-youtube';

function MovieList() {
  const [movies, setMovies] = useState([]);

  useEffect(() => {
    axios
      .get('removedsensitiveinfo')
      .then(response => {
        setMovies(response.data.results);
      });
  }, []);

  if (movies.length === 0) {
    return (
      <div style={{ flex: 1, padding: 20 }}>
        <p>Loading, please wait...</p>
      </div>
    );
  } else {
    const movieItems = movies.map((movie, index) => (
      <MovieListItem key={index} movie={movie} />
    ));

    return (
      <div className="list">
        {movieItems}
      </div>
    );
  }
}

function MovieListItem(props) {
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [videoKey, setVideoKey] = useState('');

  useEffect(() => {
    axios
      .get(`removedsensitiveinfo`)
      .then(response => {
        setVideoKey(response.data.videos.results[0]?.key || '');
      });
  }, [props.movie.id]);

  const openModal = () => {
    setIsModalOpen(true);
  };

  const closeModal = () => {
    setIsModalOpen(false);
  };

  return (
    <div className="movieCard">
      <h1>{props.movie.original_title}</h1>
      <img className="img" src={`https://image.tmdb.org/t/p/w500${props.movie.poster_path}`} />
      <p>{props.movie.overview}</p>
      <span
        style={{ color: 'blue', cursor: 'pointer' }}
        onClick={openModal}>
        {props.movie.original_title} Trailer
      </span>

      <Modal
        isOpen={isModalOpen}
        onRequestClose={closeModal}
        contentLabel="Trailer Modal"
        style={{
          overlay: {
            backgroundColor: 'rgba(0, 0, 0, 0.7)',
          },
          content: {
            top: '50%',
            left: '50%',
            right: 'auto',
            bottom: 'auto',
            marginRight: '-50%',
            transform: 'translate(-50%, -50%)',
            width: '80%',
          },
        }}>

        <YouTube videoId={videoKey} opts={{ width: '100%', height: '400px' }} />
      </Modal>
    </div>
  );
}

function App() {
  return (
    <div className="App">
      <h2 style={{}}>Now Playing</h2>
      <MovieList />
    </div>
  );
}

export default App;
