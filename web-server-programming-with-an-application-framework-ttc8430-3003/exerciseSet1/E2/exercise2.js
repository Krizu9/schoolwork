const os = require('os');

const uptimeInSeconds = os.uptime();

const days = Math.floor(uptimeInSeconds / 86400);
const hours = Math.floor((uptimeInSeconds % 86400) / 3600);
const minutes = Math.floor((uptimeInSeconds % 3600) / 60);
const seconds = Math.round(uptimeInSeconds % 60);

console.log(`System Uptime: ${days} days, ${hours} hours, ${minutes} minutes, ${seconds} seconds`);

const totalMemoryInBytes = os.totalmem();
const totalMemoryInGB = totalMemoryInBytes / (1024 * 1024 * 1024);

console.log(`Total Memory: ${totalMemoryInGB.toFixed(2)} GB`);