let fs = require('fs')

fs.readFile('./src/integers.txt', (err, data) => {
    console.log(data)
    if (err) {
    } else {
        console.log("Reading file and calculate a sum...")
        let integers = data.toString().split(',')
        sum = 0;
        integers.forEach((integer) => {
            sum = sum + parseInt(integer)
        })
        console.log("Sum is " + sum)
    }
})


