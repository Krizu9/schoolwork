const http = require('http')
const fs = require('fs');
const hostname = '127.0.0.1'
const port = 3050
let counter = 0;

const server = http.createServer((req, res) => {
    res.statusCode = 200
    res.setHeader('Content-Type', 'text/html')
    res.write('<h1>Request counter value is ' + counter + '</h1>')
    res.end()
    counter++;
    fs.writeFile('./src/test.txt', counter.toString(), err => {
        if (err) {
            console.error(err);
        }

    });
})



server.listen(port, hostname, () => {
    console.log(`Server running at http://${hostname}:${port}/`)
})