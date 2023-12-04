import react, { useState, useEffect } from 'react';
import axios from 'axios';
import { MapContainer, TileLayer, useMap, Marker, Popup } from 'react-leaflet'
import "leaflet/dist/leaflet.css";
import L from 'leaflet';


function App() {

  const ikoni = L.icon({
    iconUrl: '/pointer.jpg', iconsize: [25, 25]
  });

  const [courses, setCourses] = useState([])

  useEffect(() => {
    axios
      .get('http://localhost:3005/courses')
      .then(response => {
        //console.log(response.data);
        setCourses(response.data);
      })
  }, [])


  const position = [62, 26]
  const zoom = 7

  const markers = courses.map((course, index) =>
    <Marker position={[course.lat, course.lng]} icon={ikoni} key={index} >
      <Popup>
        <b>{course.course}</b><br />
        {course.address}<br />
        {course.phone}<br />
        {course.email}<br />
        <a href={course.web} target="_blank" rel="noopener noreferrer">{course.web}</a><br />
        <br />
        <i>{course.text}</i>
      </Popup>
    </Marker>
  );
  return (
    <div className="App" >
      <MapContainer style={{ height: "100vh", width: "100vh" }} center={position} zoom={13} scrollWheelZoom={false}>
        <TileLayer
          attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
          url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
        />
        {markers}
      </MapContainer>
    </div >
  );
}

export default App;
